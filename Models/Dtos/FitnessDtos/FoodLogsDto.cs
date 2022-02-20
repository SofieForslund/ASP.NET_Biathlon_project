using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Dtos.FitnessDtos
{

    public class FoodLogsDto
    {
        public Food[] foods { get; set; }
        public Summary summary { get; set; }
        public Goals goals { get; set; }
    }

    public class Food
    {
        public bool isFavorite { get; set; }
        public string logDate { get; set; }
        public int logId { get; set; }
        public Loggedfood loggedFood { get; set; }
        public Nutritionalvalues nutritionalValues { get; set; }
    }

    public class Loggedfood
    {
        public string accessLevel { get; set; }
        public float amount { get; set; }
        public string brand { get; set; }
        public int calories { get; set; }
        public int foodId { get; set; }
        public int mealTypeId { get; set; }
        public string locale { get; set; }
        public string name { get; set; }
        public Unit unit { get; set; }
        public int[] units { get; set; }
    }

    public class Unit
    {
        public int id { get; set; }
        public string name { get; set; }
        public string plural { get; set; }
    }

    public class Nutritionalvalues
    {
        public int calories { get; set; }
        public float carbs { get; set; }
        public int fat { get; set; }
        public float fiber { get; set; }
        public float protein { get; set; }
        public int sodium { get; set; }
    }

}
