using BiathlonSuccess.Models.Dtos;
using BiathlonSuccess.Models.Dtos.AimTrackerDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiathlonSuccess.Repositories
{
    public interface IAimtrackerRepo
    {
        Task<List<ShootingsDto>> GetAllShootingsByIBUId(string ibuId);
        Task<List<AthleteDto>> GetAthletes();
        Task<List<ShootingsDto>> GetDaysByDateAndIBUId(string startDate, string endDate, string ibuId);
        Task<ShootingsDto> GetTrainingByIBUId(string ibuId);
    }
}