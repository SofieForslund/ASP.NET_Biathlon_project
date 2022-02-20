using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Poco
{
    public class TrainingFacilityLocation
    {

        public int Id { get; set; }
        public string Cityname { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }


    }
}