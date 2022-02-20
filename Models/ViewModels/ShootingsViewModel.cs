using BiathlonSuccess.Models.Poco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.ViewModels
{
    public class ShootingsViewModel
    {
        public List<ShootingForVM> Shootings { get; set; } = new List<ShootingForVM>();

        public string TodaysDate { get; set; }

        public string ImageOfShooter { get; set; }

        public string ShooterName { get; set; }
        public List<ShooterStatistics> ShooterStatistics { get; set; } = new List<ShooterStatistics>();
        public string DayOfTheWeek { get; set; }


        public ShootingsViewModel(List<Shooting> shootings, Shooter shooter)
        {

            if (ImageOfShooter == null)
            {
                ImageOfShooter = "~/Images/BrokenImage.png"; 
            }
            ImageOfShooter = shooter.Image;
            ShooterName = shooter.GivenName;
            ShooterStatistics = shooter.ShooterStatisticsList;


            foreach (var shooting in shootings)
            {
                var singleShooting = new ShootingForVM(shooting);
                Shootings.Add(singleShooting);
                TodaysDate = singleShooting.DateFormatYYYYMMDD(DateTime.Now);
                DayOfTheWeek = singleShooting.GetDayOfTheWeek(DateTime.Now);
            }
        }


        public ShootingsViewModel()
        {

        }

    }

}