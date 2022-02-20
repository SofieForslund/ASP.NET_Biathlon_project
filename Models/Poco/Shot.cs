using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Poco
{
    public class Shot
    {
        public int Id { get; set; }
        public int ShotNumberOfSeries { get; set; }
        public string Result { get; set; }  //från aimtrack
        public DateTime Time { get; set; } //räknas ut från skottseriens tidpunkt+timetofire
        public float? Wind_Speed { get; set; } 
        public int? Wind_Deg { get; set; } 
        public float? Wind_Gust { get; set; } 
        public int ShotSeriesId { get; set; }  //FK till ShotSeries
        [DisplayName("Puls")]
        public int Pulse { get; set; }
        public ICollection<ShotFiringCoordinates> FiringCoordinates { get; set; } = new List<ShotFiringCoordinates>();



        //en egenskap för att visa var på tavlan man träffar?? känns avancerat




    }
}
