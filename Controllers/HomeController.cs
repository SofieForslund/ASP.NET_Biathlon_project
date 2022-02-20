using BiathlonSuccess.Data;
using BiathlonSuccess.Models;
using BiathlonSuccess.Models.Dtos;
using BiathlonSuccess.Models.Dtos.AimTrackerDtos;
using BiathlonSuccess.Models.Poco;
using BiathlonSuccess.Models.ViewModels;
using BiathlonSuccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDbRepository _repo;
        private readonly IAimtrackerRepo _aimtrackerRepo;
        private static Shooter _athlete;
        public Shooter Athlete
        {
            get { return _athlete; }
            set { _athlete = value; }
        }

        public HomeController(ILogger<HomeController> logger, IDbRepository repo, IAimtrackerRepo aimtrackerRepo)
        {
            _logger = logger;
            _repo = repo;
            _aimtrackerRepo = aimtrackerRepo;
        }

        [Route("Home/Dashboard/{ibuid}")]
        public async Task<IActionResult> Dashboard(string ibuid)
        {

             var ibuId = ibuid;
            var athlete = _repo.GetShooter(ibuId);
            _athlete = athlete;


            try
            {
                var amountOfDaysToGet = 6;
                var todaysDate = DateTime.Now.ToString("yyMMdd");
                var dateOfFirstDate = DateTime.Now.AddDays(-amountOfDaysToGet).ToString("yyMMdd");
                var historicalData = await _aimtrackerRepo.GetDaysByDateAndIBUId($"{dateOfFirstDate}", $"{todaysDate}", $"{ibuId}");
                foreach (var singleShooting in historicalData)
                {
                    var shootingSaved = await _repo.CreateShootingsAsync(singleShooting);
                }

                //JUST NU HÄMTAS NEDAN INTE FRÅN API:T OCH EFTERSOM DATETIME STÄMPELN ÄNDRAS VID VARJE HÄMTNING, BLIR DET DUBLETTER I DATABSEN:

                //var shooting = await _aimtrackerRepo.GetTrainingByIBUId(_athlete.IbuId);
                //var save = await _repo.CreateShootingsAsync(shooting);

                var numberOfDaysToGetToView = 6;
                var listOfDates = new List<DateTime>();
                for (int i = 0; i < numberOfDaysToGetToView; i++)
                {
                    listOfDates.Add(DateTime.Now.Date.AddDays(-i));
                }

                var shootings =  _repo.GetShootingsByDayDate(listOfDates, _athlete.IbuId);

                var model = new ShootingsViewModel(shootings, athlete);

                return View(model);
            }
            catch (System.Exception) //för felhantering
            {
                var model = new ShootingsViewModel();
                ModelState.AddModelError(string.Empty, "Ingen kontakt med API");
                return View(model);
                throw;
            }


        }

        public IActionResult Dashboard()
        {
            return RedirectToAction("Dashboard", "Home", new { ibuid = _athlete.IbuId });
        }

        public async Task<IActionResult> Analyze() 
        {

            var model = new AnalyzeViewModel(_repo);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Analyze(AnalyzeViewModel model)
        {
            
            //athlete = Athlete; den här raden funkar när man först varit inne i dashboard, så att Athlete har värde

            var startdate = model.Startdate.Value.Date.ToString("yyMMdd"); 
            var enddate = model.Enddate.Value.Date.ToString("yyMMdd");

            model.Shootings = await _aimtrackerRepo.GetDaysByDateAndIBUId(startdate, enddate, _athlete.IbuId); //tar ibuid från athlete när körs skarpt

            var resultOfHits = model.ShowMessageForZeroHits(model.Shootings.Count);
            model.SeriesForDropDown = Sort(model);

            return View(model);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        /// <summary>
        /// Takes the chosen sort properties in the analyzeviewmodel and returns a list sorted by those properties
        /// </summary>
        /// <param name="model">Analyzeviewmodel</param>
        /// <returns>A sorted list of SeriesDto</returns>
        public List<SeriesDto> Sort(AnalyzeViewModel model)
        {
            var listOfShotSeries = NumberSeries(model.Shootings);
            var isTimeApplied = (model.StartTime == null || model.EndTime == null) ? false : true;
            var list = listOfShotSeries;
            list = (model.ShotSerieNumber != null) ? listOfShotSeries.Where(x => x.ShotSerieNumber == model.ShotSerieNumber).ToList() : list;
            list = (model.Stance != "Välj position") ? list.Where(x => x.stance == model.Stance).ToList() : list;
            list = isTimeApplied ? list.Where(x => x.dateTime.TimeOfDay >= model.StartTime.Value.TimeOfDay && x.dateTime.TimeOfDay <= model.EndTime.Value.TimeOfDay).ToList() : list;


            return list;
        }

        public List<SeriesDto> NumberSeries(List<ShootingsDto> shootingsList)
        {
            var listOfShotSeries = new List<SeriesDto>();

            foreach (var shooting in shootingsList)
            {
                int shotNumber = 1;
                var shotseriesAscending = shooting.results.OrderBy(x => x.dateTime).ToList(); 

                foreach (var series in shotseriesAscending)
                {
                    series.ShotSerieNumber = shotNumber++;
                    listOfShotSeries.Add(series);
                }
            }

            return listOfShotSeries;
        }

    }
}