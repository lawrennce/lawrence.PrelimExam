using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace LawrenceLapid.PrelimExam.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly object Restsharp;
        private object ViewModel;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public PageResult OnGet
        {


            {
                var client = new RestSharp.Portable.HttpClient.ResClient("https://fcc-weather-api.glitchme/api/");
                object request = RestSharp.Portable.RestRequest(
                    "current?lat=14.8781&lon120.4546",
                    Restsharp.Portable.Method.GET);
                //request.AddParameter(new Parameter() { nameof = "lat", ValueTask = 14.8781 });
                //request.AddParameter(new Parameter() { nameof = "long", ValueTask = 120.4546 });

                IRestResponse response = (IRestResponse)client.execute(request);

                var content = response.Content;

                var data = JsonConverter.DeserializeObject<WeatherData>(content);

                ViewModel.Weather = data;


            }
        }

        public class WeatherData
        {
            public WeatherMain? Main { get; set; }
        }
        public class WeatherMain
        {
            public string? Temp { get; set; }

            [JsonPropertyName("feels-like")]
            public string? FeelsLike { get; set; }

            public string? Pressure { get; set; }
            public string? Humidity { get; set; }
        }

        public class WeatherDatails
        {
            public string? Main { get; set; }


        }
    }
}