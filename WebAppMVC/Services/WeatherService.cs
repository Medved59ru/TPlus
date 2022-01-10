using System.Globalization;
using System.Linq;
using WebAppMVC.Dto;
using WebAppMVC.Models;

namespace WebAppMVC.Services
{
    public class WeatherService
    {
        private readonly DatabaseContext context;
        public WeatherService(DatabaseContext context)
        {
            this.context = context;
        }

        public void AddWeatherAsync(InitialDto dto, int calendarId)
        {
            Weather weather = new Weather();
            weather.Temperature = GetTemperatureFrom(dto.Weather);
            weather.CalendarId = calendarId;
            if (CheckUnOriginality(weather))
            {
                context.Weathers.AddAsync(weather);
                context.SaveChangesAsync();
            }

        }

        private decimal GetTemperatureFrom(string weather)
        {
            return Decimal.Parse(weather, NumberStyles.Any | NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent, CultureInfo.InvariantCulture);
        }

        private bool CheckUnOriginality(Weather item)
        {
            bool exist = false;
            if (!context.Weathers.Any(i=>i.Temperature == item.Temperature))
            {
                exist = true;
            }
            return exist;
        }
    }
}
