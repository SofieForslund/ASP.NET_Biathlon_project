using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Dtos.FitnessDtos
{

    public class SleepDto
    {
        public Sleep[] sleep { get; set; }
        public Summary summary { get; set; }
    }

    public class Sleep
    {
        public string dateOfSleep { get; set; }
        public int duration { get; set; }
        public int efficiency { get; set; }
        public bool isMainSleep { get; set; }
        public Levels levels { get; set; }
        public long logId { get; set; }
        public int minutesAfterWakeup { get; set; }
        public int minutesAsleep { get; set; }
        public int minutesAwake { get; set; }
        public int minutesToFallAsleep { get; set; }
        public DateTime startTime { get; set; }
        public int timeInBed { get; set; }
        public string type { get; set; }
    }

    public class Levels
    {
        public Summary1 summary { get; set; }
        public Datum[] data { get; set; }
        public Shortdata[] shortData { get; set; }
    }

    public class Summary1
    {
        public Deep deep { get; set; }
        public Light light { get; set; }
        public Rem rem { get; set; }
        public Wake wake { get; set; }
    }

    public class Deep
    {
        public int count { get; set; }
        public int minutes { get; set; }
        public int thirtyDayAvgMinutes { get; set; }
    }

    public class Light
    {
        public int count { get; set; }
        public int minutes { get; set; }
        public int thirtyDayAvgMinutes { get; set; }
    }

    public class Rem
    {
        public int count { get; set; }
        public int minutes { get; set; }
        public int thirtyDayAvgMinutes { get; set; }
    }

    public class Wake
    {
        public int count { get; set; }
        public int minutes { get; set; }
        public int thirtyDayAvgMinutes { get; set; }
    }

    public class Datum
    {
        public DateTime datetime { get; set; }
        public string level { get; set; }
        public int seconds { get; set; }
    }

    public class Shortdata
    {
        public DateTime datetime { get; set; }
        public string level { get; set; }
        public int seconds { get; set; }
    }

}
