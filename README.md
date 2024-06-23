# CryptoCurrency API

This .NET Core API project provides an endpoint to fetch a list of cryptocurrencies, with optional search functionality.

## Getting Started

To get started with this API, follow these steps:

### Prerequisites

Make sure you have the following installed:

- [.NET Core SDK](https://dotnet.microsoft.com/download) (version 3.1 or higher)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) 

### Installation

1. Clone this repository to your local machine:

   ```bash
   git clone http://github.com/your/repository.git
   ```

2. Navigate to the project directory:

   ```bash
   cd CryptoAPI
   ```

3. Build the project:

   ```bash
   dotnet build
   ```

4. Run the project:

   ```bash
   dotnet run
   ```

5. The API will start running on `https://localhost:5255`.

## Endpoint

### GET /api/cryptoCurrency/GetCoins

- **Description**: Retrieves a list of cryptocurrencies.
- **Query Parameters**:
  - `search` (optional): Filters the list of cryptocurrencies based on the provided search term.
  - `pageNumber` (optional): Filters the list of cryptocurrencies based on the provided search term.
  - `pageSize` (optional): Filters the list of cryptocurrencies based on the provided search term.
- **Example Request**:
  ```http
  GET /api/cryptoCurrency/GetCoins?search=bit&PageNumber=1&PageSize=12
  ```
- **Example Response**:
  ```json
  [
    {
     "id": "bitcoin",
      "rank": "1",
      "symbol": "BTC",
      "name": "Bitcoin",
      "supply": "19712456.0000000000000000",
      "maxSupply": "21000000.0000000000000000",
      "marketCapUsd": "1264957110517.7447097615716568",
      "volumeUsd24Hr": "2649829638.6843643935772725",
      "priceUsd": "64170.4468746940873203",
      "changePercent24Hr": "-0.3012675704493903",
      "vwap24Hr": "64510.8883410766500286",
      "explorer": "https://blockchain.info/"
    },
    {
     "id": "wrapped-bitcoin",
      "rank": "12",
      "symbol": "WBTC",
      "name": "Wrapped Bitcoin",
      "supply": "153235.7378324500000000",
      "maxSupply": null,
      "marketCapUsd": "9827775476.2086188541536248",
      "volumeUsd24Hr": "33507525.1403747496747172",
      "priceUsd": "64135.0093341439688703",
      "changePercent24Hr": "-0.4277393291044383",
      "vwap24Hr": "64418.7749796475265960",
      "explorer": "https://etherscan.io/token/0x2260fac5e5542a773aa44fbcfedf7c193bc2c599"
    },
    ...
  ]
  ```
  
## Technologies Used

- .NET Core
- C#
- Restease (for interacting with remote REST endpoints).

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---
