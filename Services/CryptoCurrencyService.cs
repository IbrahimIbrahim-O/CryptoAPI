using CryptoAPI.DTO;
using CryptoAPI.Interfaces;
using RestEase;
using System.Linq;
using static CryptoAPI.Interfaces.ICoinCap;

namespace CryptoAPI.Services
{
    public class CryptoCurrencyService : ICryptoCurrencyService
    {
        private readonly IConfiguration _configuration;
        private readonly ICoinCap _coinCap;

        public CryptoCurrencyService(IConfiguration configuration)
        {
            _configuration = configuration;
            _coinCap = RestClient.For<ICoinCap>(_configuration["CoinCap:Api"]);
        }

        public async Task<CoinCapResponseDTO> GetCryptoCurrencies(string? search, PagingParam param)
        {
            try
            {
                // Get data from coin cap API
                var currencies = await _coinCap.GetCryptoCurrenciesFromCoinCap();

                if (currencies == null)
                {
                    throw new Exception($"Failed to fetch cryptocurrencies");
                }

                // pagination calculation
                var skip = (param.PageNumber - 1) * param.PageSize;

                if (currencies.Data != null)
                {
                    if (!string.IsNullOrEmpty(search))
                    {
                        // Get filtered coin by search if search is not null or empty
                        currencies.Data = currencies.Data
                        .Where(x => x.Name != null && x.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                        .ToList(); 
                    }

                    // Paginate the data
                    currencies.Data = currencies.Data.Skip(skip).Take(param.PageSize).ToList();

                    // Update count after filtering
                    currencies.Count = currencies.Data.Count(); 
                }

                // return currencies
                return currencies;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching cryptocurrencies from CoinCap API", ex);
            }
           
        }
    }
}
