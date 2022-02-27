using System.Globalization;
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

        public void AddWeatherAsync(InitialDto dto)
        {
            Weather weather = new Weather();
            weather.Temperature = GetTemperatureFrom(dto.Weather);
            weather.Date = DateTime.Parse(dto.Date);
            if (CheckUnOriginality(weather))
            {
                context.Weathers.AddAsync(weather);
                context.SaveChangesAsync();
            }

        }

        public Weather GetTemperatureOrDefaultBy(Consumption consumption)
        {
            return context.Weathers.Where(item => item.Date == consumption.Date).FirstOrDefault();
        }

        public void UpdateTemperatureAsync(DateTime? date, decimal? tempValue)
        {
            var weather = context.Weathers.Where(t => t.Date == date).FirstOrDefault();
            if (weather != null && tempValue != null && weather.Temperature != tempValue)
            {
                weather.Temperature = tempValue;
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
            if (!context.Weathers.Any(i => i.Date == item.Date))
            {
                exist = true;
            }
            return exist;
        }
    }
}
