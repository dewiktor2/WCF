using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Permissions;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Data.DAL;
using WeatherApp.Entities;

namespace WeatherApp.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class WeatherAppService : IWeatherAppService,IDisposable
    {
        readonly WeatherDbContext _Context = new WeatherDbContext();

        public Weather GetWeather(string city)
        {
            return _Context.Weathers.FirstOrDefault(e => e.City == city);
        }

        public Weather GetWeatherByDateAndCity(string city, DateTime date)
        {
            return _Context.Weathers.FirstOrDefault(e => e.City == city
            && e.Date == date);
        }

        public Weather DeleteWeather(int? id)
        {
     
            Weather weather = _Context.Weathers.Find(id);
            return weather;
            
        }
        public Weather confirmDeleteWeather(int? id)
        {

            Weather weather = _Context.Weathers.Find(id);
            _Context.Weathers.Remove(weather);
            _Context.SaveChanges();

            return weather;
        }

        public IEnumerable<Weather> GetWeathers()
        {
            
            return _Context.Weathers.ToList();
        }

        // [OperationBehavior(TransactionScopeRequired =true)]
        public void SubmitWeather(Weather weather)
        {
            _Context.Weathers.Add(weather);
            _Context.SaveChanges();
        }

        public void EditRecordInDatabase(Weather weather)
        {
            _Context.Entry(weather).State = EntityState.Modified;
            _Context.SaveChanges();
        }

        public  void Dispose()
        {
            _Context.Dispose();
        }

       
    }
}
