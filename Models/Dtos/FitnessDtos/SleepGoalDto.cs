using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Dtos.FitnessDtos
{

    public class SleepGoalDto
    {
        public Goal goal { get; set; }
    }

    public class Goal
    {
        public int minDuration { get; set; }
        public string updatedOn { get; set; }
    }

}
