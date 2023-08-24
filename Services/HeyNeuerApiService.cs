using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeyNeuer.Models.ApiModels;
using Newtonsoft.Json;
using Computer = HeyNeuer.Models.Computer;

namespace HeyNeuer.Services
{
    public class HeyNeuerApiService : IHeyNeuerApiService
    {
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
            request.Headers.Add("Authorization", "Bearer rLEtJrkxLvrguSB8yvTTjFO8liL4h296fKB3vYWj");

            var response = await this.httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<GetComputerResponse>(content);
            }

            return null;
        }

        private class Root
        {
            public Computer computer { get; set; }
        }
    }
}
