using System.Runtime.CompilerServices;
using wasm.travisback.com.Models;

namespace wasm.travisback.com.Services
{
    public class ApiService
    {
        private readonly IConfiguration _configuration;

        private readonly string _baseApiURL;
        
        private HttpClient httpClient = new HttpClient();

        public ApiService(IConfiguration configuration)
        {
            _configuration = configuration;

            
        }

        public async Task<string> GetScoreBoard(League league)
        {
            var scoreURL = _baseApiURL + LeagueInfoAttribute.GetLeagueURL(league) + "/scoreboard";

            try
            {
                var response = await httpClient.GetAsync(scoreURL);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ex.Message;
            }
        }
    }
}
