using CryptoAPI.DTO;
using static CryptoAPI.Interfaces.ICoinCap;

namespace CryptoAPI.Interfaces
{
    public interface ICryptoCurrencyService
    {
        Task<CoinCapResponseDTO> GetCryptoCurrencies(string? search, PagingParam pagingParam); 
    }
}
