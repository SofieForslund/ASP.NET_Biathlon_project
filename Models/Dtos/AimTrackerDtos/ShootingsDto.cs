using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Dtos
{
    public class ShootingsDto
    {


        public string id { get; set; }
        public string shooter { get; set; }
        public DateTime date { get; set; }
        //Platsdata
        public GeometryDto geometry { get; set; }
        public string location { get; set; }
        public string ibuId { get; set; }
        #region List
        //innehåller serier
        public List<SeriesDto> results { get; set; } = new List<SeriesDto>();
        #endregion
    }
}
