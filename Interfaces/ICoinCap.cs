using CryptoAPI.DTO;
using RestEase;

namespace CryptoAPI.Interfaces
{
    public interface ICoinCap
    {
        [Get("assets")]
        Task<CoinCapResponseDTO> GetCryptoCurrenciesFromCoinCap();
    }
}
