using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeatherAppWebClient.WeatherAppServices;
using WeatherAppWebClient.Models;
namespace WeatherAppWebClient.Controllers
{
    public class WeathersController : Controller
    {
        WeatherAppServiceClient client = new WeatherAppServiceClient();

        // GET: Weathers
        public ActionResult Index()
        {
            return View(client.GetWeathers());
        }

        // GET: Weathers/Details/5
        /*  
         *  WeatherAppServices.Weather weather = client.DeleteWeather(id);  
         *  This invoke find specific weather in database no deleting it, for delete there is method ConfirmDeleteWeather
         *  return weather
        * */
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            WeatherAppServices.Weather weather = client.DeleteWeather(id);
            if (weather == null)
            {
                return HttpNotFound();
            }
            return View(weather);
        }

        // GET: Weathers/Create
        public ActionResult Create()
        {

            Models.Weather  weather= new Models.Weather();
            weather.Date=DateTime.Now;
            return View(weather);
        }

        // POST: Weathers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HumidityPercent,Wind,Temperature,Date,City,Country")]  Models.Weather weather)
        {
            
            if (ModelState.IsValid)
            {
                WeatherAppServices.Weather weatherService = new WeatherAppServices.Weather();
                weatherService.Id = weather.Id;
                weatherService.HumidityPercent = weather.HumidityPercent;
                weatherService.Wind = weather.Wind;
                weatherService.Temperature = weather.Temperature;
                weatherService.Date = weather.Date;
                weatherService.City = weather.City;
                weatherService.Country = weather.Country;
                client.SubmitWeather(weatherService);
                return RedirectToAction("Index");
            }

            return View(weather);
        }

        // GET: Weathers/Edit/5
        public ActionResult Edit(int? id)
        {
            WeatherAppServices.Weather weather = client.DeleteWeather(id);

            

            Models.Weather weatherWeb = new Models.Weather();

            weatherWeb.Date = DateTime.Now;
            weatherWeb.Id = weather.Id;
            weatherWeb.HumidityPercent = weather.HumidityPercent;
            weatherWeb.Wind = weather.Wind;
            weatherWeb.Temperature = weather.Temperature;
            weatherWeb.City = weather.City;
            weatherWeb.Country = weather.Country;

            if (weatherWeb == null)
            {
                return HttpNotFound();
            }
            return View(weatherWeb);
        }

        // POST: Weathers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HumidityPercent,Wind,Temperature,Date,City,Country")] Models.Weather weather)
        {
            if (ModelState.IsValid)
            {

                WeatherAppServices.Weather weatherService = new WeatherAppServices.Weather();

                weatherService.Id = weather.Id;
                weatherService.HumidityPercent = weather.HumidityPercent;
                weatherService.Wind = weather.Wind;
                weatherService.Temperature = weather.Temperature;
                weatherService.Date = weather.Date;
                weatherService.City = weather.City;
                weatherService.Country = weather.Country;

                client.EditRecordInDatabase(weatherService);
                    

                return RedirectToAction("Index");
            }
            return View(weather);
        }

        // GET: Weathers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeatherAppServices.Weather weather = client.DeleteWeather(id);

            if (weather == null)
            {
                return HttpNotFound();
            }
            return View(weather);
        }

        // POST: Weathers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WeatherAppServices.Weather weather = client.confirmDeleteWeather(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //  db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
