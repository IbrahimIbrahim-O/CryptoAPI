using CryptoAPI.DTO;
using CryptoAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAPI.Controllers
{
    [Route("api/cryptoCurrency")]
    [ApiController]
    public class CryptoCurrencyController : ControllerBase
    {
        private readonly ICryptoCurrencyService _cryptoService;

        public CryptoCurrencyController(ICryptoCurrencyService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        /// <summary>
        /// Returns all coins from coin app api,
        /// can also return coins based on search value
        /// if it's not null or empty
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     Search: string (default is an empty string),
        ///     Page Number: 1 (default page number is 1),
        ///     Page Size: 10 (default page size is 10)
        /// </remarks>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("GetCoins")]
        [ProducesResponseType(typeof(CoinCapResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetCryptoCurrencyService(string? search,[FromQuery] PagingParam param)
        {
            try
            {
                var result = await _cryptoService.GetCryptoCurrencies(search, param);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"Internal server error: {ex.Message}" });
            }
         
        }
    }
}
