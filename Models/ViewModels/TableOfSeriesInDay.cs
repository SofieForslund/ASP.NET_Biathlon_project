using BiathlonSuccess.Models.Poco;
using BiathlonSuccess.Repositories;
using System;
using System.ComponentModel;

namespace BiathlonSuccess.Models.ViewModels
{
    public class TableOfSeriesInDay
    {
        private readonly ICalculationsConversionsRepo _calculationsRepo;

        [DisplayName("Skjutserie")]
        public string ShotSeriesNumber { get; set; }
        [DisplayName("Träffsäkerhet")]
        public string HitRatingPercentage { get; set; }
        [DisplayName("Ställning")]
        public string StanceInSwedish { get; set; }
        [DisplayName("Total tid")]
        public string DurationInSwedish { get; set; }
        [DisplayName("Vind")]
        public string WindSpeedWithDegree { get; set; }
        public int ShotSeriesId { get; set; }
        public DateTime DateTime { get; set; }
        [DisplayName("Klockan")]
        public string SeriesTime { get; set; }

        public TableOfSeriesInDay(ShotSeries shotSeries, ICalculationsConversionsRepo calculationsRepo)
        {
            _calculationsRepo = calculationsRepo;
            ShotSeriesNumber = CreateShotSeriesId(shotSeries.ShotSerieNumber);
            HitRatingPercentage = _calculationsRepo.CreateHitRating(shotSeries.HitRating);
            StanceInSwedish = _calculationsRepo.GetStanceInSwedish(shotSeries.Stance);
            DurationInSwedish = _calculationsRepo.CreateDuration(shotSeries.Duration);
            WindSpeedWithDegree = _calculationsRepo.CreateWindProp(shotSeries.Wind_Deg, shotSeries.Wind_Speed);
            ShotSeriesId = shotSeries.Id;
            DateTime = shotSeries.DateWithTime;
            SeriesTime = GetTimeFromDateTime(shotSeries.DateWithTime);
        }

        public string GetTimeFromDateTime(DateTime date)
        {
            return date.ToString("HH:mm:ss");

        }

        public string CreateShotSeriesId(int id)
        {
            return id.ToString();
        }





        public string CreateStance(string stance)
        {
            if (stance == "Prone")
            {
                return "Liggande";
            }
            return "Stående";
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
        public string CreateWindProp(int? degrees, float? speed)
        {           
            string cardinalDirection ="";
            #region If-statement
            if (degrees > 348 && degrees <= 11)
            {
                cardinalDirection = "N"; 
            }
            if (degrees > 11 && degrees <= 34)
            {
                cardinalDirection = "NNE";
            }
            if (degrees > 34 && degrees <= 56)
            {
                cardinalDirection = "NE";
            }
            if (degrees > 56 && degrees <= 79)
            {
                cardinalDirection = "ENE";
            }
            if (degrees > 79 && degrees <= 101)
            {
                cardinalDirection = "E";
            }
            if (degrees > 101 && degrees <= 124)
            {
                cardinalDirection = "ESE";
            }
            if (degrees > 124 && degrees <= 146)
            {
                cardinalDirection = "SE";
            }
            if (degrees > 146 && degrees <= 169)
            {
                cardinalDirection = "SEE";
            }
            if (degrees > 169 && degrees <= 191)
            {
                cardinalDirection = "S";
            }
            if (degrees > 191 && degrees <= 214)
            {
                cardinalDirection = "SSW";
            }
            if (degrees > 214 && degrees <= 236)
            {
                cardinalDirection = "SW";
            }
            if (degrees > 236 && degrees <= 259)
            {
                cardinalDirection = "WSW";
            }
            if (degrees > 259 && degrees <= 281)
            {
                cardinalDirection = "W";
            }
            if (degrees > 281 && degrees <= 304)
            {
                cardinalDirection = "WNW";
            }
            if (degrees > 304 && degrees <= 326)
            {
                cardinalDirection = "NW";
            }
            if (degrees > 326 && degrees <= 348)
            {
                cardinalDirection = "NW";
            }            
            #endregion
            var windspeedAndDegrees = $"{speed.ToString()}M/S {cardinalDirection}";
            return windspeedAndDegrees;
        }

    }

}

