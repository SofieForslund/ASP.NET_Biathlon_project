using BiathlonSuccess.Models.Dtos;
using BiathlonSuccess.Models.Poco;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Repositories
{
    public class CalculationsConversionsRepo: ICalculationsConversionsRepo
    {

        /// <summary>
        /// Calculates hitrate for a single shotseries
        /// </summary>
        /// <param name="shotList">List of Shot</param>
        /// <returns>Hitraing in float</returns>
        public float CalculateSingleSeriesHitRate(List<Shot> shotList)
        {
            var numberOfHits = 0;

            for (int i = 0; i < shotList.Count; i++)
            {
                if (shotList[i].Result == "hit")
                {
                    numberOfHits++;
                }
            }
            float rating = (float)numberOfHits / shotList.Count;
            return rating;
        }

        /// <summary>
        /// Calculates hitrating for all shotseries for a specific day
        /// </summary>
        /// <param name="listOfSeriesForCurrentDay">List of ShotSeries</param>
        /// <returns>Hitrating in float</returns>
        public float CalculateAllDayHitRate(List<ShotSeries> listOfSeriesForCurrentDay)
        {
            var shotlist = new List<Shot>();

            foreach (var series in listOfSeriesForCurrentDay)
            {
                foreach (var shot in series.Shots)
                {
                    shotlist.Add(shot);
                }   
            }
            float result = (float)CalculateSingleSeriesHitRate(shotlist);
            return result;
        }


        /// <summary>
        /// Calculates the duration of a single shotseries
        /// </summary>
        /// <param name="startTime">starttime of the shotseries (datetime)</param>
        /// <param name="shots">List of ShotsDto</param>
        /// <returns>TimeSpan</returns>
        public TimeSpan CalculateSeriesDuration(DateTime start, List<ShotsDto> shots)
        {

            var startTime = start;
            float duration = 0;

            foreach (var shot in shots)
            {
                duration += shot.timeToFire;
            }

            var endTime = startTime.AddSeconds(duration);
            TimeSpan timeSpan = endTime - startTime;
            return timeSpan;

        }

        /// <summary>
        /// Calculates the exakt time when a shot fires
        /// </summary>
        /// <param name="shotSeries">SeriesDto</param>
        /// <param name="currentShot">ShotsDto of current shot</param>
        /// <returns>DateTime for exakt time of shot</returns>
        public DateTime CalculateExactShotTime(SeriesDto shotSeries, ShotsDto currentShot)
        {
            var startTime = shotSeries.dateTime;
            float duration = 0;

            var stopCount = currentShot.shotNr;

            for (int i = 0; i < stopCount; i++)
            {
                duration += shotSeries.shots[i].timeToFire;
            }

            var exactFiringTime = startTime.AddSeconds(duration);
            return exactFiringTime;

        }


        /// <summary>
        /// Calculate timespan in seconds
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <returns>string</returns>
        public string CreateDuration(TimeSpan? timeSpan)
        {
            var durationWithSek = $"{timeSpan.Value.Seconds.ToString()} sek";

            return durationWithSek;
        }

        /// <summary>
        /// Displays wind speed and cardinaldirection
        /// </summary>
        /// <param name="degrees"></param>
        /// <param name="speed"></param>
        /// <returns>string</returns>
        public string CreateWindProp(int? degrees, float? speed) //Kolla om den kan fixas med swith/case istället för if. 
        {
            string cardinalDirection = "";
            #region Switch-statement
            switch (degrees)
            {
                case var d when d > 348 && d <= 11:
                    cardinalDirection = "N";
                    break;

                case var d when d > 11 && d <= 34:
                    cardinalDirection = "NNE";
                    break;

                case var d when d > 34 && d <= 56:
                    cardinalDirection = "NE";
                    break;

                case var d when d > 56 && d <= 79:
                    cardinalDirection = "ENE";
                    break;

                case var d when d > 79 && d <= 101:
                    cardinalDirection = "E";
                    break;

                case var d when d > 101 && d <= 124:
                    cardinalDirection = "ESE";
                    break;

                case var d when d > 124 && d <= 146:
                    cardinalDirection = "SE";
                    break;

                case var d when d > 146 && d <= 169:
                    cardinalDirection = "SSE";
                    break;

                case var d when d > 169 && d <= 191:
                    cardinalDirection = "S";
                    break;

                case var d when d > 191 && d <= 214:
                    cardinalDirection = "SSW";
                    break;

                case var d when d > 214 && d <= 236:
                    cardinalDirection = "SW";
                    break;

                case var d when d > 236 && d <= 259:
                    cardinalDirection = "WSW";
                    break;

                case var d when d > 259 && d <= 281:
                    cardinalDirection = "W";
                    break;

                case var d when d > 281 && d <= 304:
                    cardinalDirection = "WNW";
                    break;

                case var d when d > 304 && d <= 326:
                    cardinalDirection = "NW";
                    break;

                case var d when d > 326 && d <= 348:
                    cardinalDirection = "NNW";
                    break;

                default:
                    break;

            }
            #endregion
            var windspeedAndDegrees = $"{speed.ToString()}MS {cardinalDirection}";
            return windspeedAndDegrees;
        }

        /// <summary>
        /// Creates and returns stance in Swedish
        /// </summary>
        /// <param name="stance">string stance in English</param>
        /// <returns>string stance in Swedish</returns>
        public string GetStanceInSwedish(string stance)
        {

            if (stance == "Prone")
            {
                return "Liggande";
            }
            return "Stående";

        }

        /// <summary>
        /// Creates a string with hitrating
        /// </summary>
        /// <param name="rating">float rating</param>
        /// <returns>string of rating in percentage</returns>
        public string CreateHitRating(float rating)
        {

            return String.Format("{0:0.##\\%}", rating * 100);

        }


    }
}
