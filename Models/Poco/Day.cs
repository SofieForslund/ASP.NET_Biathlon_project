using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Poco
{
    public class Day
    {

        [DisplayName("namn")]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual List<Shooting> Shootings { get; set; } = new List<Shooting>();
        public string Location { get; set; }
        public int? Humidity { get; set; }
        public float? Temp { get; set; }


        //hälsotillstånd 
        public virtual ICollection<HeartrateMeasurement> HeartrateMeasurements { get; set; } = new List<HeartrateMeasurement>();

        //sömn
    }
}
