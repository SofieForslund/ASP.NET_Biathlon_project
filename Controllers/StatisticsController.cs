
using BiathlonSuccess.Models.Dtos;
using BiathlonSuccess.Models.Dtos.FitnessDtos;
using BiathlonSuccess.Models.Poco;
using BiathlonSuccess.Models.ViewModels;
using BiathlonSuccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Controllers
{
    [AllowAnonymous]
    public class StatisticsController : Controller
    {

        private readonly ILogger<StatisticsController> _logger;

        private readonly IDbRepository _repo;
        private readonly IFitnessRepo _fitnessRepo;
        private readonly ICalculationsConversionsRepo _calculationsRepo;

        public StatisticsController(ILogger<StatisticsController> logger, 
                                    IDbRepository repo, 
                                    IFitnessRepo fitnessRepo, 
                                    ICalculationsConversionsRepo calculationsRepo)
        {
            _logger = logger;
            _repo = repo;
             _fitnessRepo = fitnessRepo;
            _calculationsRepo = calculationsRepo;
        }
                
        public async Task<IActionResult> Day(DateTime date) 
        {

            var sleepdata = await _fitnessRepo.GetSleepRangeAsync();
            var model = new StatisticsViewModel(date.Date, _repo, _calculationsRepo);

            return View(model);
        }


        public IActionResult ShotSeriesByDate(DateTime date) //chosen shotseries object from analyze view
        {
            
            var series = _repo.GetSingleSeriesByDate(date);

            if (series != null)
            {
                var model = new ShotSeriesViewModel(series, _repo, _calculationsRepo);
                return View(model);
            }
            else
            {

                return View("Error");
            }


        }

        

    }
}

