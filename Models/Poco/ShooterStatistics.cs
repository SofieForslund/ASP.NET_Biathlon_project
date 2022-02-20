using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Poco
{
    public class ShooterStatistics
    {
        public int Id { get; set; }
        [DisplayName("Säsong")]
        public string Season { get; set; }
        [DisplayName("Liggande")]
        public string PronePercentage { get; set; }
        [DisplayName("Stående")]
        public string StandingPercentage { get; set; }
        public string ShooterIbuID { get; set; }
    }
}
