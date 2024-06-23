namespace CryptoAPI.DTO
{
    public class CoinCapResponseDTO
    {
        public IEnumerable<CryptoCurrencyDTO>? Data { get; set; }

        public double Timestamp { get; set; }

        public int? Count { get; set; }

        public string? Message { get; set; }
        
    }
}
