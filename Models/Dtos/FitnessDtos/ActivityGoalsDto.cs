using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Dtos.FitnessDtos
{
    public class ActivityGoalsDto
    {
        public Goals goals { get; set; }
    }

    public class Goals
    {
        public int activeMinutes { get; set; }
        public int caloriesOut { get; set; }
        public float distance { get; set; }
        public int steps { get; set; }
    }

}
