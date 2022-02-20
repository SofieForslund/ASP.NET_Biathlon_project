using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Poco
{
    public class ShotSeries
    {
        [Key]
        public int Id { get; set; } //från aimtrack
        public int ShotSerieNumber { get; set; } //egen siffra för vy.
        public DateTime Date { get; set; } 
        public DateTime DateWithTime { get; set; }
        public string Location { get; set; } //från aimtrack tex Östersund Stadium
        //public int? ShotId { get; set; }
        public virtual ICollection<Shot> Shots { get; set; } = new List<Shot>(); //från aimtrack
        public TimeSpan? Duration { get; set; } //anges av total tid för skottens "timeToFire"
        public string Stance { get; set; } //aimtrack
        public float HitRating { get; set; } //räknas ut av skottens hit/miss
        public float? Wind_Speed { get; set; } //väderapi
        public int? Wind_Deg { get; set; } //väderapi
        public float? Wind_Gust { get; set; } //väderapi
        public string WeatherDescription { get; set; } //väderapi
        public string WeatherIcon { get; set; } //väderapi

        public int ShootingId { get; set; }



        //puls, oklart vilken datatyp?



    }
}
