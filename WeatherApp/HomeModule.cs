using Nancy;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", args => GetWeather());
        }


        public Response GetWeather()
        {
            try
            {
                var city_name = "Dallas";
                var API_key = "55cc2e6a6be0c5ebc88db63a08b53817";
                var url = $"http://api.openweathermap.org/data/2.5/weather?q={city_name}&appid={API_key}";

                IRestClient client = new RestClient(url);

                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);

                Console.WriteLine(response);
                if ((int)response.StatusCode == 200)
                {
                    return Response.AsJson(response.Content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return HttpStatusCode.BadRequest;
        }
    }
}
