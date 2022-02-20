using BiathlonSuccess.Controllers;
using BiathlonSuccess.Infrastructure;
using BiathlonSuccess.Models.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BiathlonSuccess.Repositories
{
    public class WeatherRepo : IWeatherRepo
    {

        private IApiClient _apiClient;
        private IConfiguration _config;
        private readonly string _baseEndpoint = "http://api.openweathermap.org/data/2.5/onecall";

        public WeatherRepo(IApiClient apiClient, IConfiguration config)
        {
            _apiClient = apiClient;
            _config = config;
        }


        /// <summary>
        /// Api call for fetching weather for a specifik aimtracker, using the aimtrack location and time
        /// </summary>
        /// <param name="lat">latitude</param>
        /// <param name="lon">longitude</param>
        /// <param name="unix">unix</param>
        /// <returns>WeatherSearchDto</returns>
        public async Task<WeatherSearchDto> GetHistoricalWeatherAsync(string lat, string lon, int unix) => await _apiClient.GetAsync<WeatherSearchDto>($"{_baseEndpoint}/timemachine?lat={lat}&lon={lon}&units=metric&dt={unix}&appid={_config["Keys:WeatherAPIKey"]}&lang=sv");
        public async Task<WeatherSearchDto> GetTodaysWeatherAsync(string lat, string lon, int unix) => await _apiClient.GetAsync<WeatherSearchDto>($"{_baseEndpoint}?lat={lat}&lon={lon}&units=metric&dt={unix}&appid={_config["Keys:WeatherAPIKey"]}&lang=sv");

        /// <summary>
        /// Method for creating params for the apicall
        /// </summary>
        /// <param name="aimtracker">AimTrackerDto</param>
        /// <returns>WeatherSearchDto</returns>
        public async Task<WeatherSearchDto> GetWeather(string lat, string lon, DateTime time)
        {            
            try
            {
                var unix = DateTimeToUnix(time);

                if (time.Date == DateTime.Now.Date)
                {
                    var task1 = GetTodaysWeatherAsync(lat, lon, unix);
                    await Task.WhenAll(task1);
                    var weatherToday = await task1;
                    return weatherToday;
                }
                else
                {
                    var task2 = GetHistoricalWeatherAsync(lat, lon, unix);
                    await Task.WhenAll(task2);
                    var historicalWeather = await task2;
                    return historicalWeather;

                }
                
            }
            catch (System.Exception)//Detta måste vara null 
            {
                return null;
            }

            
        }

        /// <summary>
        /// Creating a unix from DateTime obejct
        /// </summary>
        /// <param name="date">DateTime</param>
        /// <returns>unix</returns>
        public int DateTimeToUnix(DateTime date)
        {
            TimeSpan timeSpan = date - new DateTime(1970, 1, 1, 0, 0, 0);
            return (int)timeSpan.TotalSeconds;
        }

    }
}
