using BiathlonSuccess.Data;
using BiathlonSuccess.Models;
using BiathlonSuccess.Models.Dtos;
using BiathlonSuccess.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Repositories
{
    public class DbRepository : IDbRepository
    {

        private readonly AppDbContext _appDb;
        private readonly IWeatherRepo _weatherRepo;
        private readonly ICalculationsConversionsRepo _calculationsRepo;
        private readonly IFitnessRepo _fitnessRepo;
        private readonly IAimtrackerRepo _aimtrackerRepo;
        private readonly LoginDbContext _loginDb;

        public AimTrackerDto AimTracker { get; set; }

        public DbRepository(AppDbContext db, 
                            IWeatherRepo weatherRepo, 
                            ICalculationsConversionsRepo calculationsRepo, 
                            IFitnessRepo fitnessRepo, 
                            IAimtrackerRepo aimtrackerRepo, 
                            LoginDbContext loginDb)
        {
            _appDb = db;
            _weatherRepo = weatherRepo;
            _calculationsRepo = calculationsRepo;
            _fitnessRepo = fitnessRepo;
            _aimtrackerRepo = aimtrackerRepo;
            _loginDb = loginDb;
        }

        #region Read methods


        /// <summary>
        /// Checks if there is a shooting with the exact supplied time in database
        /// </summary>
        /// <param name="time">DateTime object</param>
        /// <returns>true if shooting exists</returns>
        public bool IsShootingInDb(DateTime time)
        {
            if (_appDb.Shootings.Where(x => x.Date == time).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns a user from database based on email adress
        /// </summary>
        /// <param name="email">string</param>
        /// <returns>ApplicationUser</returns>
        public ApplicationUser GetUser(string email)
        {
            var user = _loginDb.AppUsers.Where(x => x.Email == email).FirstOrDefault();
            return user;
        }

        /// <summary>
        /// Gets and returns a shooter from database based on ibuid
        /// </summary>
        /// <param name="ibuid">string</param>
        /// <returns>Shooter</returns>
        public Shooter GetShooter(string ibuid)
        {
            var shooter = _appDb.Shooters.Where(x => x.IbuId == ibuid).FirstOrDefault();
            shooter.ShooterStatisticsList = _appDb.ShooterStatistics.Where(x => x.ShooterIbuID == shooter.IbuId).ToList();
            return shooter;
        }

        /// <summary>
        /// Retrieves and returns a single shotseries if it is found in database, based on exact time, otherwise returns null
        /// </summary>
        /// <param name="date">DateTime</param>
        /// <returns>ShotSeries</returns>
        public ShotSeries GetSingleSeriesByDate(DateTime date)
        {
            var shotseries = _appDb.ShotSeries.Where(x => x.DateWithTime == date).FirstOrDefault();
            if (shotseries != null)
            {
                shotseries.Shots = GetShotsBySeriesId(shotseries);
            }
            return shotseries;
        }

        /// <summary>
        /// Returns true if a user with supplied ibuid is registered in the database, false if not
        /// </summary>
        /// <param name="ibuid">string</param>
        /// <returns>bool</returns>
        public bool IsIfIdTaken(string ibuid)
        {
            if (_loginDb.AppUsers.Where(x => x.IbuID == ibuid).FirstOrDefault() != null )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Retrieves all shootings for a specific day based on date and ibuid
        /// </summary>
        /// <param name="dayId">Integer day ID</param>
        /// <param name="ibuId">String IbuId</param>
        /// <returns>List of Shooting</returns>
        public List<Shooting> GetShootingsByDayDate(List<DateTime> dates, string ibuId)
        {
            var shootingsList = new List<Shooting>();
            foreach (var date in dates)
            {
                var allShootingsPerDay = _appDb.Shootings
                    .Where(x => x.Date.Date == date)
                    .Where(x => x.IbuId == ibuId)
                    .ToList();

                var list = new List<Shooting>();
                foreach (var singleShooting in allShootingsPerDay)
                {
                    singleShooting.ShotSeries = GetSeriesByShootingId(singleShooting.Id);
                    list.Add(singleShooting);
                };

                foreach (var shooting in list)
                {
                    shootingsList.Add(shooting);
                }
            }
            return shootingsList;
        }


        /// <summary>
        /// Retrieves all shotseries completed for a specific shooting by shooting ID
        /// </summary>
        /// <param name="shootingId">int</param>
        /// <returns>List of ShotSeries</returns>
        public List<ShotSeries> GetSeriesByShootingId(int shootingId)
        {
            var allShotSeriesPerDay = _appDb.ShotSeries
                .Where(x => x.ShootingId == shootingId)
                .ToList();

            var list = new List<ShotSeries>();

            foreach (var singleSeries in allShotSeriesPerDay)
            {
                singleSeries.Shots = GetShotsBySeriesId(singleSeries);
                list.Add(singleSeries);
            }
            return list;
        }

        /// <summary>
        /// Retrieves all ShotSeries for a specific date
        /// </summary>
        /// <param name="date">DateTime object</param>
        /// <returns>List of ShotSeries</returns>
        public List<ShotSeries> GetSeriesByDate(DateTime date)
        {
            var allShotSeriesPerDay = _appDb.ShotSeries.OrderBy(x=> x.ShotSerieNumber)
                .Where(x => x.Date == date)
                .ToList();

            foreach (var singleSeries in allShotSeriesPerDay)
            {
                var shotList = GetShotsBySeriesId(singleSeries);
                singleSeries.Shots = shotList;
            }
            return allShotSeriesPerDay;
        }

        /// <summary>
        /// Retrieves complete ShotSeries object by series ID
        /// </summary>
        /// <param name="id">Id of shotseries to be retrieved</param>
        /// <returns>A Shotseries object</returns>
        public ShotSeries GetShotSeriesById(int id)
        {
            var series = _appDb.ShotSeries
            .Where(x => x.Id == id).FirstOrDefault();

            series.Shots = GetShotsBySeriesId(series);
            return series;

        }

        /// <summary>
        /// Retrieves a list of shots for a specific shotseries
        /// </summary>
        /// <param name="series">ShotSeries</param>
        /// <returns>List of Shot</returns>
        public List<Shot> GetShotsBySeriesId(ShotSeries series)
        {
            var shots = _appDb.Shots
            .OrderBy(x => x.Time)
            .Where(x => x.ShotSeriesId == series.Id)
            .ToList();
            return shots;
        }

        /// <summary>
        /// Gets the number of tempList for a specific day and returns an integer that represents the number of tempList
        /// </summary>
        /// <param name="dayId"></param>
        /// <returns>total amount of tempList</returns>
        public int GetNumberOfHitsOfTheDay(DateTime date)
        {
            var hits = new List<string>();

            var seriesToday = GetSeriesByDate(date);
            int seriesId;

            foreach (var series in seriesToday)
            {
                seriesId = series.Id;
                var shots = _appDb.Shots.Where(x => x.Result.Contains("hit"))
                .Where(y => y.ShotSeriesId == seriesId);

                foreach (var item in shots)
                {
                    hits.Add(item.Result);
                }
            }

            return hits.Count;
        }

        /// <summary>
        /// Gets the number of misses for a specific day and returns an integer that represents the number of misses
        /// </summary>
        /// <param name="date"></param>
        /// <returns>total amount of misses</returns>
        public int GetNumberOfMissesOfTheDay(DateTime date)
        {
            var hits = new List<string>();

            var seriesToday = GetSeriesByDate(date);
            int seriesId;

            foreach (var series in seriesToday)
            {
                seriesId = series.Id;
                var shots = _appDb.Shots.Where(x => x.Result.Contains("miss"))
                .Where(y => y.ShotSeriesId == seriesId);

                foreach (var item in shots)
                {
                    hits.Add(item.Result);
                }
            }

            return hits.Count;
        }

        /// <summary>
        /// Gets the hits per shotserie og specific day and returns a list of the amount of hits per shotserie
        /// </summary>
        /// <param name="date"></param>
        /// <returns>List of hits per shotserie</returns>
        public List<string> GetNumberOfHitsPerSerie(DateTime date)
        {
            var series = GetSeriesByDate(date);
            int numberOfShots;
            var allhits = new List<string>();

            foreach (var item in series)
            {

                var shots = _appDb.Shots.Where(x => x.Result.Contains("hit")).
                Where(y => y.ShotSeriesId == item.Id);

                numberOfShots = shots.Count();
                allhits.Add(numberOfShots.ToString());
            }
            return allhits;
        }

        /// <summary>
        /// Gets a list of all shotseries numerations for a specific day
        /// </summary>
        /// <param name="date"></param>
        /// <returns>List of shotseries numerations</returns>
        public List<int> GetListOfShotSeriesNumber(DateTime date)
        {
            var seriesNumbers = new List<int>();
            var shotlist = GetSeriesByDate(date).OrderBy(x => x.ShotSerieNumber).ToList();
            foreach (var item in shotlist)
            {
                seriesNumbers.Add(item.ShotSerieNumber);
            }
            return seriesNumbers;
        }



        #endregion

        #region Create methods


        /// <summary>
        /// Hämtar pulsdata och skapar en lista av mätpunkter. Measurements. 
        /// </summary>
        private async Task<List<HeartrateMeasurement>> GetHeartrateMeasurements()
        {
            var heartrateData = await _fitnessRepo.GetHearthRateAsync();
            var measurements = new List<HeartrateMeasurement>();

            foreach (var item in heartrateData.activitiesHeartIntraday.dataset)
            {
                HeartrateMeasurement heartrateMeasurement = new HeartrateMeasurement
                {
                    DayId = 0,
                    Time = item.time,
                    Value = item.value
                };
                measurements.Add(heartrateMeasurement);
            }

            return measurements;
        }

        /// <summary>
        /// Creates and adds a list of shooters to database
        /// </summary>
        /// <param name="athletes">List of AhtleteDto</param>
        /// <returns>List of Shooter</returns>
        public async Task<List<Shooter>> AddAthletesAsync(List<AthleteDto> athletes)
        {
            var listOfShooter = new List<Shooter>();
            foreach (var athlete in athletes)
            {
                if (_appDb.Shooters.Where(x => x.IbuId == athlete.ibuId).FirstOrDefault()==null)
                {
                    var shooter = new Shooter()
                    {
                        IbuId = athlete.ibuId,
                        Fullname = athlete.fullname,
                        FamilyName = athlete.familyName,
                        GivenName = athlete.givenName,
                        Country = athlete.country,
                        Nationality = athlete.nat,
                        GenderId = athlete.genderId,
                        MaxHeartRate = athlete.maxHeartRate,
                        Image = athlete.image,
                        ShooterStatisticsList = CreateShooterStatistics(athlete)
                    };
                    listOfShooter.Add(shooter);
                }
            }

            await _appDb.AddRangeAsync(listOfShooter);
            _appDb.SaveChanges();
            return listOfShooter;
        }

        /// <summary>
        /// Creates a list of Shooter statistics for given athlete
        /// </summary>
        /// <param name="athlete">A single ahtleteDto</param>
        /// <returns>List of Shooterstatistics</returns>
        public List<ShooterStatistics> CreateShooterStatistics(AthleteDto athlete)
        {
            var listOfStats = new List<ShooterStatistics>();
            for (int i = 0; i < athlete.statSeasons.Count; i++)
            {
                var stat = new ShooterStatistics { Season = athlete.statSeasons[i], PronePercentage = athlete.statShootingProne[i], StandingPercentage = athlete.statShootingStanding[i], ShooterIbuID = athlete.ibuId};
                listOfStats.Add(stat);
            }
            return listOfStats;
        }

        /// <summary>
        /// Creates and adds a Shooting object to db
        /// </summary>
        /// <param name="shooting">ShootingsDto</param>
        /// <returns>Shooting</returns>
        public async Task<Shooting> CreateShootingsAsync(ShootingsDto shooting)
        {

            if (IsShootingInDb(shooting.date).Equals(false))
            {
                var listOfSeries = new List<ShotSeries>();            
                var shootingResultAscending= shooting.results.OrderBy(x => x.dateTime).ToList(); 
                int shotNumber = 1;
                foreach (var shotSeries in shootingResultAscending)
                {
                    shotSeries.ShotSerieNumber = shotNumber++;
                    var pocoSeries = await CreateShotSeriesAsync(shotSeries, shooting);
                    listOfSeries.Add(pocoSeries);
                }

                var singleShooting = new Shooting()
                {
                    ShotSeries = listOfSeries,
                    HitRating = _calculationsRepo.CalculateAllDayHitRate(listOfSeries),
                    Location = shooting.location,
                    Date = shooting.date.AddTicks(-shooting.date.Ticks % TimeSpan.TicksPerSecond),
                    IbuId = shooting.ibuId
                };

                await _appDb.AddAsync(singleShooting);
                _appDb.SaveChanges();
                return singleShooting;
            }
            else
            {
                return new Shooting();
            }

        } 

        /// <summary>
        /// Creates and returns a ShotSeries saveable in db out of a AimTracker SeriesDto
        /// </summary>
        /// <param name="series">SeriesDto</param>
        /// <returns>ShotSeries</returns>
        public async Task<ShotSeries> CreateShotSeriesAsync(SeriesDto series, ShootingsDto shooting)
        {
            var weather = await _weatherRepo.GetWeather(shooting.geometry.coordinates[0].ToString(), shooting.geometry.coordinates[1].ToString(), shooting.date); //blir null
            var shotList = await CreateShotList(series, shooting);
            var shotSeries = new ShotSeries()
            {
                Date = series.dateTime.Date,
                ShotSerieNumber = series.ShotSerieNumber,
                DateWithTime = series.dateTime.AddTicks(-series.dateTime.Ticks % TimeSpan.TicksPerSecond),
                Location = shooting.location,
                Shots = shotList,
                Duration = _calculationsRepo.CalculateSeriesDuration(shooting.date, series.shots),
                Stance = series.stance,
                HitRating = _calculationsRepo.CalculateSingleSeriesHitRate(shotList),
                Wind_Speed = (weather == null) ? null : weather.Current.Wind_Speed,
                Wind_Deg = (weather == null) ? null : weather.Current.Wind_Deg,
                Wind_Gust = (weather == null) ? null : weather.Current.Wind_Gust,
                WeatherDescription = (weather == null) ? null : weather.Current.Weather[0].Description,
                WeatherIcon = (weather == null) ? null : weather.Current.Weather[0].Icon
            };

            return shotSeries;

        }

        /// <summary>
        /// Creates and returns a list of Shot saveable in db for shots listen in the Aimtracker SeriesDto
        /// </summary>
        /// <param name="shotseries">SeriesDto</param>
        /// <returns>List of Shot</returns>
        public async Task<List<Shot>> CreateShotList(SeriesDto shotseries, ShootingsDto shooting)
        {
            var shotList = new List<Shot>();

            foreach (var shot in shotseries.shots)
            {
                var timeOfShot = _calculationsRepo.CalculateExactShotTime(shotseries, shot);
                var coordinates = CreateFiringCoordinatesList(shot.shotXY);

                var singleShot = new Shot()
                {
                    Result = shot.result,
                    ShotNumberOfSeries = shot.shotNr,
                    Time = timeOfShot,
                    Pulse = (int)((shot.heartRate == null) ? 0 : shot.heartRate),
                    FiringCoordinates = coordinates
                    

                };
                    shotList.Add(singleShot);
            }

            return shotList;
        }

        /// <summary>
        /// Creates and returns a list of firing coordinates 
        /// </summary>
        /// <param name="list">List of ShotXYDto</param>
        /// <returns>List of ShotFiringCoordinates</returns>
        public List<ShotFiringCoordinates> CreateFiringCoordinatesList(List<ShotXYDto> list)
        {
            var newList = new List<ShotFiringCoordinates>();

            for (int i = 0; i < list.Count; i++)
            {
                var coord = new ShotFiringCoordinates();
                coord.x = list[i].x;
                coord.y = list[i].y;
                newList.Add(coord);
            }

            return newList;
        }
        #endregion


    }
}