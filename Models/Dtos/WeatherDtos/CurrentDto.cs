using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.Dtos
{
    public class CurrentDto
    {
        public float Temp { get; set; }
        public int Humidity { get; set; }
        public int Visibility { get; set; }
        public float Wind_Speed { get; set; }
        public int Wind_Deg { get; set; }
        public float Wind_Gust { get; set; }
        public List<WeatherDto> Weather { get; set; }


    }
}
