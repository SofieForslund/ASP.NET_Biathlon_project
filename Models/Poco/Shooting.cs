using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Poco
{
    public class Shooting
    {
        public int Id { get; set; }
        public virtual ICollection<ShotSeries> ShotSeries { get; set; } = new List<ShotSeries>();
        public float? HitRating { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string IbuId { get; set; }
    }
}
