using RestDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestDemo.Controllers
{
    public class WeatherController : ApiController
    {
        // GET: api/Weather
        public IEnumerable<WeatherInfo> Get()
        {
            
            for (int i = 0; i < 10; i++)
            {
                var WeatherInfo = new WeatherInfo
                {
                    ID = i,
                    Location = $"Location {i}",
                    Degree = i * 23 / 17,
                    DateTime = DateTime.Now.ToUniversalTime()
                };

                StaticList.staticList.Add(WeatherInfo);

            }
            return StaticList.staticList;
        }

        // GET: api/Weather/5
        public WeatherInfo Get(int id)
        {
            
            for(int i = 0;i < StaticList.staticList.Count; i++)
            {
                if(StaticList.staticList[i].ID == id)
                {
                    return new WeatherInfo
                    {
                        ID = StaticList.staticList[i].ID,
                        Location = StaticList.staticList[i].Location,
                        Degree = StaticList.staticList[i].Degree,
                        DateTime = StaticList.staticList[i].DateTime
                    };
                }
            }
            return new WeatherInfo();
        }

        // POST: api/Weather
        public void Post([FromBody] WeatherInfo value)
        {
            if(value != null)
            {
                StaticList.staticList.Add(new WeatherInfo
                {
                    ID = value.ID,
                    Location = value.Location,
                    Degree = value.ID * 23 / 17,
                    DateTime = DateTime.Now.ToUniversalTime()
                });
            }
            
        }

        // PUT: api/Weather/5
        public void Put(int id, [FromBody] WeatherInfo value)
        {
            int item = StaticList.staticList.FindIndex(x => x.ID == id);
            StaticList.staticList[item].ID = value.ID;
            StaticList.staticList[item].Location = value.Location;
            StaticList.staticList[item].Degree = value.Degree;
            StaticList.staticList[item].DateTime = value.DateTime;
        }

        // DELETE: api/Weather/5
        public void Delete(int id)
        {
            for (int i = 0; i < StaticList.staticList.Count; i++)
            {
                if (StaticList.staticList[i].ID == id)
                {
                    StaticList.staticList.Remove(StaticList.staticList[i]);

                }
            }
        }
    }
}
