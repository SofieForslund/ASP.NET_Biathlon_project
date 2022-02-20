using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Dtos
{
    public class SeriesDto
    {
        #region Properties
        public int Id { get; set; }
        public int ShotSerieNumber { get; set; }
        public string stance { get; set; }
        public DateTime dateTime { get; set; }
        #endregion

        #region List
        //shot
        public List<ShotsDto> shots { get; set; }
        #endregion

    }
}
