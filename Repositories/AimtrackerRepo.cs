using BiathlonSuccess.Infrastructure;
using BiathlonSuccess.Models.Dtos;
using BiathlonSuccess.Models.Dtos.AimTrackerDtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Repositories
{
    public class AimtrackerRepo : IAimtrackerRepo
    {
        private IApiClient _apiClient;
        private IConfiguration _config;
        private readonly string _baseEndpoint = "https://grupp8.dsvkurs.miun.se";

        public AimtrackerRepo(IApiClient apiClient, IConfiguration config)
        {
            _apiClient = apiClient;
            _config = config;
        }

        public async Task<List<AthleteDto>> GetAthletes() => await _apiClient.GetAsync<List<AthleteDto>>($"{_baseEndpoint}/api/athletes");

        public async Task<List<ShootingsDto>> GetDaysByDateAndIBUId(string startDate, string endDate, string ibuId) => await _apiClient.GetAsync<List<ShootingsDto>>($"{_baseEndpoint}/api/history/Date/{ibuId}?startDate={startDate}&endDate={endDate}");

        public async Task<List<ShootingsDto>> GetAllShootingsByIBUId(string ibuId) => await _apiClient.GetAsync<List<ShootingsDto>>($"{_baseEndpoint}/api/history/All/{ibuId}");
        
        public async Task<ShootingsDto> GetTrainingByIBUId(string ibuId) => await _apiClient.GetAsync<ShootingsDto>($"{_baseEndpoint}/api/Training/{ibuId}");


    }
}