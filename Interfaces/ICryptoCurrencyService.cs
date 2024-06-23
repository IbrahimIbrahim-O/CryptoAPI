using CryptoAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAPI.Interfaces
{
    public interface ICryptoCurrencyService
    {
        Task<CoinCapResponseDTO> GetCryptoCurrencies(string? search, PagingParam pagingParam); 
    }
}
