using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Entities
{
    /*
    Class Weather use DataContract and DataMember 
    but dont need to :) We can create it without it      
    */
    [DataContract]
    public class Weather
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int HumidityPercent { get; set; }
        [DataMember]
        public string Wind { get; set; }
        [DataMember]
        public string Temperature { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Country { get; set; }

    }
}
