using BiathlonSuccess.Models.Dtos;
using BiathlonSuccess.Models.Dtos.FitnessDtos;
using System.Threading.Tasks;

namespace BiathlonSuccess.Repositories
{
    public interface IFitnessRepo
    {
        Task<ActivitiesStatsDto> GetActivitiesStatsAsync();
        Task<ActivityGoalsDto> GetActivityGoalsAsync();
        Task<ActivitiesDto> GetActivitiesAsync();
        Task<HeartrateDto> GetHearthRateAsync();
        Task<BloodPressureDto> GetBloodPressureAsync();
        Task<FoodLogsDto> GetFoodLogsAsync();
        Task<SleepGoalDto> GetSleepGoalsAsync();
        Task<SleepDto> GetSleepAsync();
        Task<SleepRangeDto> GetSleepRangeAsync();
    }
}