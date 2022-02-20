using System.Threading.Tasks;

namespace BiathlonSuccess.Infrastructure
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string endpoint);
    }
}
