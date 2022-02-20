using BiathlonSuccess.Models.Poco;
using BiathlonSuccess.Repositories;
using System;
using System.ComponentModel;

namespace BiathlonSuccess.Models.ViewModels
{
    public class ShotForView
    {
        [DisplayName("Skott nr")]
        public int ShotNumber { get; set; }
        [DisplayName("Puls")]
        public int? Pulse { get; set; }
        [DisplayName("Resultat")]
        public string Result { get; set; }
        public ChartCoordinates Coordinates { get; set; }
        [DisplayName("Ställning")]
        public string Stance { get; set; }
        [DisplayName("Tid")]
        public string Time { get; set; }

        public ShotForView(Shot shot, ShotSeries series, ICalculationsConversionsRepo calculationsRepo)
        {
            ShotNumber = shot.ShotNumberOfSeries;
            Result = ConvertResultToSwedish(shot); 
            Coordinates = new ChartCoordinates(shot, series);
            Stance = calculationsRepo.GetStanceInSwedish(series.Stance);
            Pulse = shot.Pulse;
            Time = DateToString(shot.Time);
        }

        public string ConvertResultToSwedish (Shot shot) 
        {
            if (shot.Result == "miss")
            {
                Result = "bom";
            }
            else
            {
                Result = "träff"; 
            }
            return Result; 
        }

        public string DateToString(DateTime date)
        {
            return date.ToString("HH:mm:ss");
        }
    }

}