//------------------------------------------------------------------------------
// File: ApiService.cs
//
// Description: This file contains the ApiService class representing a service
//              for interacting with an external API. It includes methods to 
//              retrieve data from the API.
//
// Author: Travis Back
//
// Created: 2024-1-28
//
// Last Modified: 2024-1-28
//
// Notes:
// - This service class uses HttpClient to make asynchronous requests to the API.
//------------------------------------------------------------------------------

using wasm.travisback.com.Models;

namespace wasm.travisback.com.Services
{
    /// <summary>
    /// Service class for interacting with the API.
    /// </summary>
    public class ApiService
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseApiURL;
        private HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Initializes a new instance of the ApiService class.
        /// </summary>
        /// <param name="configuration">The configuration to retrieve settings.</param>
        public ApiService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Gets the scoreboard for the specified league.
        /// </summary>
        /// <param name="league">The league for which to retrieve the scoreboard.</param>
        /// <returns>A string representing the scoreboard data.</returns>
        public async Task<string> GetScoreBoard(League league)
        {
            // Construct the URL for retrieving the scoreboard based on the league.
            var scoreURL = _baseApiURL + LeagueInfoAttribute.GetLeagueURL(league) + "/scoreboard";

            try
            {
                // Make an asynchronous GET request to the API.
                var response = await httpClient.GetAsync(scoreURL);

                // Ensure the response indicates success.
                response.EnsureSuccessStatusCode();

                // Read and return the response content.
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an error message.
                Console.WriteLine(ex);
                return ex.Message;
            }
        }
    }
}
