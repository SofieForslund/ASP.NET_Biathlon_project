using BiathlonSuccess.Infrastructure;
using BiathlonSuccess.Models.Dtos;
using Fitbit.Api.Portable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitbit.Models;
using BiathlonSuccess.Models.Dtos.FitnessDtos;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace BiathlonSuccess.Repositories
{
    public class FitnessRepo : IFitnessRepo
    {

        private IApiClient _apiClient;
        private IConfiguration _config;
        private readonly string basePath;


        public FitnessRepo(IApiClient apiClient, IConfiguration config, IWebHostEnvironment environment)
        {
            _apiClient = apiClient;
            _config = config;
            basePath = $@"{environment.ContentRootPath}\Assets\Json\"; // hämtar den absoluta sökvägen 
        }

        /// <summary>
        /// Hämtar data om max, min puls och antal minuter för en fysisk aktivitet ett visst datum. 
        /// </summary>
        /// <returns>Task<HeartrateDto></returns>
        public async Task<HeartrateDto> GetHearthRateAsync()
        {
            await Task.Delay(0);
            return GetTestData<HeartrateDto>("HearthRateIntradayTimeSeries.json");
        }

        /// <summary>
        /// Hämtar total statistik för alla aktiviteter. 
        /// </summary>
        /// <returns>Task<ActivitiesStatsDto></returns>
        public async Task<ActivitiesStatsDto> GetActivitiesStatsAsync()
        {
            await Task.Delay(0);
            return GetTestData<ActivitiesStatsDto>("ActivitiesStats.json");
        }

        /// <summary>
        /// Hämtar aktivitetsmål
        /// </summary>
        /// <returns>Task<ActivityGoalsDto></returns>
        public async Task<ActivityGoalsDto> GetActivityGoalsAsync()
        {
            await Task.Delay(0);
            return GetTestData<ActivityGoalsDto>("ActivityGoals.json");
        }

        /// <summary>
        /// Hämtar statistik för aktiviteter, mål och sammanfattning av aktiviteter
        /// </summary>
        /// <returns>Task<ActivitiesDto></returns>
        public async Task<ActivitiesDto> GetActivitiesAsync()
        {
            await Task.Delay(0);
            return GetTestData<ActivitiesDto>("GetActivities.json");
        }

        /// <summary>
        /// Hämtar statistik för blodtryck
        /// </summary>
        /// <returns>Task<BloodPressureDto></returns>
        public async Task<BloodPressureDto> GetBloodPressureAsync()
        {
            await Task.Delay(0);
            return GetTestData<BloodPressureDto>("GetBloodPressure.json");
        }

        /// <summary>
        /// Hämtar loggad mat och vilka näringsämnen som maten har. Samt en sammanfattning och mål för dagens kcal.
        /// </summary>
        /// <returns>Task<FoodLogsDto></returns>
        public async Task<FoodLogsDto> GetFoodLogsAsync()
        {
            await Task.Delay(0);
            return GetTestData<FoodLogsDto>("GetFoodLogs.json");
        }

        /// <summary>
        /// Hämtar mål för sömn. 
        /// </summary>
        /// <returns>Task<SleepGoalDto></returns>
        public async Task<SleepGoalDto> GetSleepGoalsAsync()
        {
            await Task.Delay(0);
            return GetTestData<SleepGoalDto>("GetSleepGoal.json");
        }

        /// <summary>
        /// Hämtar statistik för sömn, hur djupt du har sovit och hur länge för REM, ligt och wake. 
        /// Hämtar även sammanfattning till skilnad mot GetSleepRangeAsync som bara hämtar statistik för sömn. 
        /// </summary>
        /// <returns>Task<SleepDto></returns>
        public async Task<SleepDto> GetSleepAsync()
        {
            await Task.Delay(0);
            return GetTestData<SleepDto>("GetSleep.json");
        }

        /// <summary>
        /// Hämtar statistik för sömn, hur djupt du har sovit och hur länge för REM, ligt och wake.
        /// </summary>
        /// <returns>Task<SleepRangeDto></returns>
        public async Task<SleepRangeDto> GetSleepRangeAsync()
        {
            await Task.Delay(0);
            return GetTestData<SleepRangeDto>("GetSleepRange.json");
        }

        /// <summary>
        /// Läser in och deserialiserar json-fil
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="testfile">Testfilens sträng</param>
        /// <returns>T</returns>
        private T GetTestData<T>(string testfile)
        {
            var path = $"{basePath}{testfile}";
            string data = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(data);
        }
    }    
}


