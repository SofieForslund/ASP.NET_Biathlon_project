using BiathlonSuccess.Models.Dtos;
using System;
using System.Threading.Tasks;

namespace BiathlonSuccess.Repositories
{
    public interface IWeatherRepo
    {
        int DateTimeToUnix(DateTime date);
        Task<WeatherSearchDto> GetWeather(string lat, string lon, DateTime time);
        Task<WeatherSearchDto> GetHistoricalWeatherAsync(string lat, string lon, int unix);
        Task<WeatherSearchDto> GetTodaysWeatherAsync(string lat, string lon, int unix);
    }
}