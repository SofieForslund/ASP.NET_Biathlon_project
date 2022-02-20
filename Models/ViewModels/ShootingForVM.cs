using BiathlonSuccess.Models.Poco;
using System;
using System.ComponentModel;

namespace BiathlonSuccess.Models.ViewModels
{
    public class ShootingForVM
    {
        [DisplayName("Träffsäkerhet")]
        public string HitRatingShooting { get; set; }

        public DateTime Date { get; set; }

        public string DateString { get; set; }

        [DisplayName("Serier")]
        public int NumberOfShotSeries { get; set; }

        public string DayOfTheWeek { get; set; }

        [DisplayName("Plats")]
        public string Location { get; set; }
        public string ShootingTime { get; set; }

        public ShootingForVM(Shooting shooting)
        {
            HitRatingShooting = CreateStringForAccuracy(shooting.HitRating);
            NumberOfShotSeries = shooting.ShotSeries.Count;
            Date = shooting.Date;
            DateString = DateFormatYYYYMMDD(shooting.Date);
            DayOfTheWeek = GetDayOfTheWeek(shooting.Date);
            Location = shooting.Location;
            ShootingTime = GetTimeFromDateTime(shooting.Date); 
        }

        public string GetTimeFromDateTime(DateTime date)
        {
            return date.ToString("HH:mm");

        }

        /// <summary>
        /// returnerar vilken veckodag det är för att visa passet 
        /// översatt till svenska för tillfället, men går att köra utan ifsatserna på engelska
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string GetDayOfTheWeek(DateTime date)
        {
            var dayOfTheWeek = date.DayOfWeek.ToString();

            if (dayOfTheWeek == "Sunday")
            {
                dayOfTheWeek = "Söndag"; 
            }
            else if (dayOfTheWeek == "Monday")
            {
                dayOfTheWeek = "Måndag";
            }
            else if (dayOfTheWeek == "Tuesday")
            {
                dayOfTheWeek = "Tisdag";
            }
            else if (dayOfTheWeek == "Wednesday")
            {
                dayOfTheWeek = "Onsdag";
            }
            else if (dayOfTheWeek == "Thursday")
            {
                dayOfTheWeek = "Torsdag";
            }
            else if (dayOfTheWeek == "Friday")
            {
                dayOfTheWeek = "Fredag";
            }
            else if (dayOfTheWeek == "Saturday")
            {
                dayOfTheWeek = "Lördag";
            }

            return dayOfTheWeek; 
        }


        public string CreateStringForAccuracy(float? hitRatingFloat)
        {

            return String.Format("{0:0.##\\%}", hitRatingFloat * 100);
        }

        public string DateFormatYYYYMMDD(DateTime date)
        {
            return date.ToShortDateString();


        }
    }

}