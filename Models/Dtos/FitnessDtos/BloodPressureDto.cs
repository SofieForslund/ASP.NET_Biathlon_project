using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Dtos.FitnessDtos
{
    public class BloodPressureDto
    {
        public Average average { get; set; }
        public Bp[] bp { get; set; }
    }

    public class Average
    {
        public string condition { get; set; }
        public int diastolic { get; set; }
        public int systolic { get; set; }
    }

    public class Bp
    {
        public int diastolic { get; set; }
        public int logId { get; set; }
        public int systolic { get; set; }
        public string time { get; set; }
    }

}
