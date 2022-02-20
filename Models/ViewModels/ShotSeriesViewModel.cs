using BiathlonSuccess.Models.Poco;
using BiathlonSuccess.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.ViewModels
{
    public class ShotSeriesViewModel
    {
        private readonly IDbRepository _repo;
        private readonly ICalculationsConversionsRepo _calculationsRepo;

        public int ShotSeriesNumberOfDay { get; set; }
        public string Weekday { get; set; }
        public string Date { get; set; }
        public List<ChartCoordinates> JsonListMisses { get; set; } = new List<ChartCoordinates>();
        public List<ChartCoordinates> JsonListHits { get; set; } = new List<ChartCoordinates>();

        [DisplayName("Vind")]
        public string WindSpeedWithDirection { get; set; }
        //public List<Pulse> Pulscurve { get; set; }
        public List<ShotForView> Shotlist { get; set; } = new List<ShotForView>();
        public string Location { get; set; }
        [DisplayName("Serie")]
        public int SeriesNumber { get; set;  }
        public ShotSeriesViewModel(ShotSeries shotSeries, IDbRepository repo, ICalculationsConversionsRepo calculationsRepo)
        {
            _repo = repo;
            _calculationsRepo = calculationsRepo;
            Date = shotSeries.DateWithTime.ToString();
            Location = shotSeries.Location;
            SeriesNumber = shotSeries.ShotSerieNumber; 

            WindSpeedWithDirection = calculationsRepo.CreateWindProp(shotSeries.Wind_Deg, shotSeries.Wind_Speed);

            foreach (var shot in shotSeries.Shots)
            {
                var singleShot = new ShotForView(shot, shotSeries, _calculationsRepo);
                Shotlist.Add(singleShot);
            }

            for (int i = 0; i < Shotlist.Count; i++)
            {
                if (Shotlist[i].Result.Equals("bom"))
                {
                    var jsonMiss = Shotlist[i].Coordinates;
                    JsonListMisses.Add(jsonMiss);
                }
                else
                {
                    var jsonHit = Shotlist[i].Coordinates;
                    JsonListHits.Add(jsonHit);
                }
            }
        }

        public ShotSeriesViewModel()
        {
               
        }
    }

}