using BiathlonSuccess.Models.Poco;

namespace BiathlonSuccess.Models.ViewModels
{
    public class ChartCoordinates
    {
        public double x { get; set; }
        public double? y { get; set; }
        public int r { get; set; }

        public ChartCoordinates(Shot shot, ShotSeries series)
        {
            x = (shot.Time - series.DateWithTime).TotalSeconds;
            y = shot.Pulse;
            r = 12;
        }

    }

}