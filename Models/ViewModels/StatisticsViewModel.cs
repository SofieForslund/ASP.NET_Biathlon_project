
using BiathlonSuccess.Models.Poco;
using BiathlonSuccess.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.ViewModels
{
    public class StatisticsViewModel
    {


        private readonly IDbRepository _repo;
        private readonly ICalculationsConversionsRepo _calculationsRepo;

        public List<int> ShotSeriesOfTheDay { get; set; } = new List<int>();
        public List<string> NumberOfHitsPerSerie { get; set; } = new List<string>();
        public int NumberOfHitsOfTheDay { get; set; }
        public int NumberOfMissesOfTheDay { get; set; }
        public List<int> HitsAndMissesPieChartData { get; set; } = new List<int>();

        public List<TableOfSeriesInDay> TodaysShotSeries { get; set; } = new List<TableOfSeriesInDay>();


        public StatisticsViewModel(DateTime date, IDbRepository repo, ICalculationsConversionsRepo calculationsRepo) 
        {
            _repo = repo;
            _calculationsRepo = calculationsRepo;
            ShotSeriesOfTheDay = _repo.GetListOfShotSeriesNumber(date);
            NumberOfHitsPerSerie = _repo.GetNumberOfHitsPerSerie(date);
            NumberOfHitsOfTheDay = _repo.GetNumberOfHitsOfTheDay(date);
            NumberOfMissesOfTheDay = _repo.GetNumberOfMissesOfTheDay(date);
            HitsAndMissesPieChartData = CreateListOfHitsAndMisses(NumberOfHitsOfTheDay, NumberOfMissesOfTheDay);
            var series = _repo.GetSeriesByDate(date);

            foreach (var serie in series)
            {
                var shotSeries = new TableOfSeriesInDay(serie, _calculationsRepo);
                TodaysShotSeries.Add(shotSeries);
            }

        }

        public StatisticsViewModel()
        {

        }

        private List<int> CreateListOfHitsAndMisses(int hits, int misses)
        {
            var list = new List<int>();
            list.Add(hits);
            list.Add(misses);
            return list;
        }

    }
}
