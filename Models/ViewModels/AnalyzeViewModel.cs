using BiathlonSuccess.Models.Dtos;
using BiathlonSuccess.Models.Poco;
using BiathlonSuccess.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.ViewModels
{
    public class AnalyzeViewModel
    {
        private readonly IDbRepository _dbRepository;

        #region Datum

        [Required]
        [Display(Name = "Startdatum")]
        [DataType(DataType.Date)]
        public DateTime? Startdate { get; set; }

        [Required]
        [Display(Name = "Slutdatum")]
        [DataType(DataType.Date)]
        public DateTime? Enddate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime? StartTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime? EndTime { get; set; }

        public int? ShotSerieNumber { get; set; }
        public string Stance { get; set; }

        public List<ShootingsDto> Shootings { get; set; } = new List<ShootingsDto>(); //lista kopplad till kalendersorteringen
        public List<SeriesDto> SeriesForDropDown { get; set; } = new List<SeriesDto>(); //lista kopplad till drop down-valen
        #endregion

        public string ZeroShootingsFound { get; set; }

        public AnalyzeViewModel(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public AnalyzeViewModel()
        {

        }

        public string ShowMessageForZeroHits(int listCount)
        {
            if (listCount.Equals(0))
            {
                ZeroShootingsFound = "Vi kunde inte hitta några pass inom aktuellt tidsintervall";
            }
            return ZeroShootingsFound;
        }
    }
}
