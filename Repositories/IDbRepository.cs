using BiathlonSuccess.Models;
using BiathlonSuccess.Models.Dtos;
using BiathlonSuccess.Models.Poco;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiathlonSuccess.Repositories
{
    public interface IDbRepository
    {
        //Task<Day> AddToDbAsync(ShootingsDto shootingDto);
        Task<ShotSeries> CreateShotSeriesAsync(SeriesDto series, ShootingsDto shooting);
        Task<List<Shot>> CreateShotList(SeriesDto shotseries, ShootingsDto shooting);
        List<ShotSeries> GetSeriesByDate(DateTime date);
        List<Shot> GetShotsBySeriesId(ShotSeries series);
        List<int> GetListOfShotSeriesNumber(DateTime date);
        int GetNumberOfHitsOfTheDay(DateTime date);
        int GetNumberOfMissesOfTheDay(DateTime date);
        List<string> GetNumberOfHitsPerSerie(DateTime date);
        ShotSeries GetShotSeriesById(int id);
        bool IsShootingInDb(DateTime time);
        Task<Shooting> CreateShootingsAsync(ShootingsDto shooting);
        List<Shooting> GetShootingsByDayDate(List<DateTime> dates, string ibuId);
        ApplicationUser GetUser(string email);
        bool IsIfIdTaken(string ibuid);
        Shooter GetShooter(string ibuid);
        Task<List<Shooter>> AddAthletesAsync(List<AthleteDto> athletes);
        ShotSeries GetSingleSeriesByDate(DateTime date);
    }
}