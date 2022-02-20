using BiathlonSuccess.Models.Poco;
using System;
using System.ComponentModel;
using System.Globalization;

namespace BiathlonSuccess.Models.ViewModels
{
    public class DaysForDayView
    {
        public DateTime Date { get; set; }
        public string DateString { get; set; }

        [DisplayName("Antal skjutningar")]
        public int NumberOfShootings { get; set; }
       
        [DisplayName("Hälsotillstånd")]
        public string Health { get; set; }

        [DisplayName("Väder")]
        public string Weather { get; set; }   

        [DisplayName("Sömn")]
        public int Sleep { get; set; }

        public int Id { get; set; }

        public DaysForDayView(Day day)
        {
            Date = day.Date;
            DateString = DateFormatYYYYMMDD(day.Date);
            NumberOfShootings = day.Shootings.Count;
            Health = "hej";
            Weather = "hej";
            Sleep = 1;
            Id = day.Id; //Provar att skicka primary key id istället för en datetime 

        }

        

        public string DateFormatYYYYMMDD(DateTime date)
        {
            return date.ToShortDateString();


        }
    }
}



