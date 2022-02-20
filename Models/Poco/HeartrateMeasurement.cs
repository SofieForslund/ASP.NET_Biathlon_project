using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Poco
{
    public class HeartrateMeasurement
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public int Value { get; set; }
        public int DayId { get; set; }
    }
}
