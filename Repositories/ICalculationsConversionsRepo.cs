using BiathlonSuccess.Models.Dtos;
using BiathlonSuccess.Models.Poco;
using System;
using System.Collections.Generic;

namespace BiathlonSuccess.Repositories
{
    public interface ICalculationsConversionsRepo {

        float CalculateSingleSeriesHitRate(List<Shot> shotList);
        TimeSpan CalculateSeriesDuration(DateTime start, List<ShotsDto> shots);
        float CalculateAllDayHitRate(List<ShotSeries> listOfSeriesForDay);
        DateTime CalculateExactShotTime(SeriesDto shotSeries, ShotsDto currentShot);
        string CreateDuration(TimeSpan? timeSpan);
        string CreateWindProp(int? degrees, float? speed);
        string GetStanceInSwedish(string stance);
        string CreateHitRating(float rating);
    }
}