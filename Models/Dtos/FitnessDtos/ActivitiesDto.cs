using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Dtos.FitnessDtos
{

    public class ActivitiesDto
    {
        public Activity[] activities { get; set; }
        public Goals goals { get; set; }
        public Summary summary { get; set; }
    }

    public class Summary
    {
        public int activeScore { get; set; }
        public int activityCalories { get; set; }
        public int caloriesBMR { get; set; }
        public int caloriesOut { get; set; }
        public Distance[] distances { get; set; }
        public float elevation { get; set; }
        public int fairlyActiveMinutes { get; set; }
        public int floors { get; set; }
        public Heartratezone[] heartRateZones { get; set; }
        public int lightlyActiveMinutes { get; set; }
        public int marginalCalories { get; set; }
        public int restingHeartRate { get; set; }
        public int sedentaryMinutes { get; set; }
        public int steps { get; set; }
        public int veryActiveMinutes { get; set; }
    }

    public class Activity
    {
        public int activityId { get; set; }
        public int activityParentId { get; set; }
        public string activityParentName { get; set; }
        public int calories { get; set; }
        public string description { get; set; }
        public int duration { get; set; }
        public bool hasStartTime { get; set; }
        public bool isFavorite { get; set; }
        public DateTime lastModified { get; set; }
        public int logId { get; set; }
        public string name { get; set; }
        public string startDate { get; set; }
        public string startTime { get; set; }
    }

}
