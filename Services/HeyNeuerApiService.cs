using HeyNeuer.Models.ApiModels;

using Newtonsoft.Json;

using Computer = HeyNeuer.Models.Computer;

namespace HeyNeuer.Services
{
    public class HeyNeuerApiService : IHeyNeuerApiService
    {
        private const string APIKEY = "rLEtJrkxLvrguSB8yvTTjFO8liL4h296fKB3vYWj";
        private readonly HttpClient httpClient;

        public HeyNeuerApiService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://heyneuer.com/api");
        }

        public async Task<GetComputerResponse> GetComputer(string computerNo)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return null;
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"{this.httpClient.BaseAddress}/computers/{computerNo}");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", $"Bearer {APIKEY}");

            var response = await this.httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<GetComputerResponse>(content);
            }

            return null;
        }

        public async Task UpdateState(int id, string state)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return;
            }

            var request = new HttpRequestMessage(HttpMethod.Patch, $"{this.httpClient.BaseAddress}/computers/{id}");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", $"Bearer {APIKEY}");
            request.Content = new StringContent("{\n  \"state\": \"" + state + "\"\n}", null, "application/json");

            var response = await this.httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        private class Root
        {
            public Computer computer { get; set; }
        }
    }
}
