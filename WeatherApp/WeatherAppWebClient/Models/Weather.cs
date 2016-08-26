using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherAppWebClient.Models
{
    public class Weather
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Humudity- required")]
        [Range(1, 100, ErrorMessage = "Too Long")]
        public int HumidityPercent { get; set; }

        [Required(ErrorMessage = "Wind- required")]
        [StringLength(60, MinimumLength = 3)]
        public string Wind { get; set; }

        [Required(ErrorMessage = "Temp- required")]
        [StringLength(40, MinimumLength = 3)]
        public string Temperature { get; set; }

        [Required(ErrorMessage = "Date- required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Country- required")]
        [StringLength(60, MinimumLength = 3)]
        public string City { get; set; }

        [Required(ErrorMessage ="Country- required")]
        [StringLength(70, MinimumLength = 3)]
        public string Country { get; set; }
    }
}