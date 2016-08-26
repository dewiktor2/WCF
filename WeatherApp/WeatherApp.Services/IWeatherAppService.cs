using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Data.DAL;
using WeatherApp.Entities;

namespace WeatherApp.Services
{
    [ServiceContract]
    public interface IWeatherAppService
    {
        [OperationContract]
        Weather GetWeather(string city);

        [OperationContract]
        Weather GetWeatherByDateAndCity(string city, DateTime data);

        [OperationContract]
        void SubmitWeather(Weather weather);

        [OperationContract]
        IEnumerable<Weather> GetWeathers();

        [OperationContract]
        Weather DeleteWeather(int? id);
        [OperationContract]
        Weather confirmDeleteWeather(int? id);

        [OperationContract]
        void EditRecordInDatabase(Weather weather);

    }
}
