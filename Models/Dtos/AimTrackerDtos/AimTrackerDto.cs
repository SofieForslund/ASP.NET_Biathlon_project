using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Dtos
{
    public class AimTrackerDto
    {
        #region Properties

        //ShotSeries
        public ICollection<ShootingsDto> shootings { get; set; } = new List<ShootingsDto>();
        #endregion

    }
}
