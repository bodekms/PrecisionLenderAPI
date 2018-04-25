using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class API
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [Display(Name = "Get URL")]
        public string Url { get; set; }

        public async Task<List<APIData>> GetData()
        {
            //Normally, this would fire and return the data, if the URL is valid
            //Assuming all APIs return data in the same format with the same naming conventions
            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 10);

            List<APIData> data = new List<APIData>();
            try
            {
                //Because these URLs do not exist, a HttpRequestException will be thrown
                HttpResponseMessage response = await client.GetAsync(this.Url).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    data = await response.Content.ReadAsAsync<List<APIData>>();
                }
                else
                {
                    Random rnd = new Random();
                    data = new List<APIData> {
                        new APIData { Name = "LIBOR 1 month", Term = 1, Rate = rnd.NextDouble() },
                        new APIData { Name = "LIBOR 2 month", Term = 2, Rate = rnd.NextDouble() },
                        new APIData { Name = "LIBOR 3 month", Term = 3, Rate = rnd.NextDouble() },
                        new APIData { Name = "LIBOR 6 month", Term = 6, Rate = rnd.NextDouble() },
                        new APIData { Name = "LIBOR 12 month", Term = 12, Rate = rnd.NextDouble() }
                    };
                }
            }
            catch(HttpRequestException re)
            {
                Random rnd = new Random();
                data = new List<APIData> {
                        new APIData { Name = "LIBOR 1 month", Term = 1, Rate = rnd.NextDouble() },
                        new APIData { Name = "LIBOR 2 month", Term = 2, Rate = rnd.NextDouble() },
                        new APIData { Name = "LIBOR 3 month", Term = 3, Rate = rnd.NextDouble() },
                        new APIData { Name = "LIBOR 6 month", Term = 6, Rate = rnd.NextDouble() },
                        new APIData { Name = "LIBOR 12 month", Term = 12, Rate = rnd.NextDouble() }
                    };
            }

            return data;
        }
    }
    public class APIData
    {
        public string Name;
        public int Term;
        public double Rate;
        public APIData() { }
    }
}