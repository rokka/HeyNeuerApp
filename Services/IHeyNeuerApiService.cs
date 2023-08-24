using HeyNeuer.Models.ApiModels;

namespace HeyNeuer.Services
{
    public interface IHeyNeuerApiService
    {
        Task<GetComputerResponse> GetComputer(string computerNo);
    }
}
