using CryptoAPI.DTO;
using CryptoAPI.Interfaces;
using CryptoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAPI.Controllers
{
    [Route("api/cryptoCurrency")]
    [ApiController]
    public class CryptoCurrencyController : ControllerBase
    {
        private readonly ICryptoCurrencyService _cryptoService;
        private readonly ILogger<CryptoCurrencyController> _logger;

        public CryptoCurrencyController(ICryptoCurrencyService cryptoService, ILogger<CryptoCurrencyController> logger)
        {
            _cryptoService = cryptoService;
            _logger = logger;
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
                var currencies = await _cryptoService.GetCryptoCurrencies(search, param);

                // Check if currencies is null
                if (currencies == null)
                {
                    return StatusCode(500, "Internal Server Error");
                }

                // Return the appropriate HTTP status code based on the service response

                return currencies.Data != null && currencies.Data.Any()
                    ? Ok(currencies)   // 200 OK with currencies if there are data
                    : NoContent();     // 204 No Content
            }
            catch (Exception ex)
            {
                _logger.LogError("coin app api service is down");
                return StatusCode(500, new { error = $"Internal server error: {ex.Message}" });
            }
         
        }
    }
}
