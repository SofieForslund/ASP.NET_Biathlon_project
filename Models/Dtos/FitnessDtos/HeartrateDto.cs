using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Dtos.FitnessDtos
{
    public class HeartrateDto
    {
        public Activitiesheart[] activitiesHeart { get; set; }
        public Activitiesheartintraday activitiesHeartIntraday { get; set; }
    }

    public class Activitiesheartintraday
    {
        public Dataset[] dataset { get; set; }
        public int datasetInterval { get; set; }
        public string datasetType { get; set; }
    }

    public class Dataset
    {
        public string time { get; set; }
        public int value { get; set; }
    }

    public class Activitiesheart
    {
        public string dateTime { get; set; }
        public Value value { get; set; }
    }

    public class Value
    {
        public object[] customHeartRateZones { get; set; }
        public Heartratezone[] heartRateZones { get; set; }
        public int restingHeartRate { get; set; }
    }

    public class Heartratezone
    {
        public float caloriesOut { get; set; }
        public int max { get; set; }
        public int min { get; set; }
        public int minutes { get; set; }
        public string name { get; set; }
    }

}
