using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Poco
{
    public class Shooter
    {
        public int Id { get; set; }
        public string IbuId { get; set; }
        public string Fullname { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string Country { get; set; }
        public string Nationality { get; set; }
        public string GenderId { get; set; }
        public int MaxHeartRate { get; set; }
        public string Image { get; set; }
        public string Team { get; set; }
        public float? RifleWeightAdded { get; set; }
        public List<ShooterStatistics> ShooterStatisticsList { get; set; }


    }
}
