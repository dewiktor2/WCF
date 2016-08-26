using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Entities;

namespace WeatherApp.Data.DAL
{
    public class WeatherInitiliazer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WeatherDbContext>
    {
        protected override void Seed(WeatherDbContext context)
        {
            List<Weather> weathers = new List<Weather>
            {
                new Weather { City="Warsaw",
                Country="Poland",
                Date=DateTime.Now,
                HumidityPercent=43,
                Temperature="33 celsius",
                Wind="25 km/h"
                },
                new Weather { City="Moscow",
                Country="Russia",
                Date=DateTime.Now,
                HumidityPercent=99,
                Temperature="22 celsius",
                Wind="10 km/h"
                },

            };
            weathers.ForEach(i => context.Weathers.Add(i));
            context.SaveChanges();
        }
    }
}
