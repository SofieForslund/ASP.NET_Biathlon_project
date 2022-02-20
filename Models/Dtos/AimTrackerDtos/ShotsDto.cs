using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Dtos
{
    public class ShotsDto
    {
        #region Properties
        public int shotNr { get; set; }
        public string result { get; set; }
        public int firingIndex { get; set; }
        public float firingAngle { get; set; }
        public FiringCordsDto firingCords { get; set; }
        #region List
        //Gevärsrörelsen, skulle ej illustreras
        public List<ShotXYDto> shotXY { get; set; }
        #endregion
        public int? heartRate { get; set; }
        public float timeToFire { get; set; }
        //koordinater för skottögonblicket
        
        #endregion


    }
}
