using System.Globalization;
using WebAppMVC.Dto;
using WebAppMVC.Models;

namespace WebAppMVC.Services
{
    public class DbCombine
    {
        private readonly DatabaseContext context;
        private readonly CalendarService calendarService;
        private readonly ConsumerService consumerService;
        private readonly ConsumptionService consumptionService;
        private readonly PriceService priceService;
        private readonly WeatherService weatherService;
   

        public DbCombine(DatabaseContext context, CalendarService calendarService, 
                        ConsumerService consumerService, ConsumptionService consumptionService,
                        PriceService priceService, WeatherService weatherService)
        {
            this.context = context;
            this.calendarService = calendarService; 
            this.consumerService = consumerService;
            this.consumptionService = consumptionService;
            this.priceService = priceService;
            this.weatherService = weatherService;
           
        }

        public void FillTheDB(HashSet<InitialDto> dtoSet)
        {
            foreach (var dto in dtoSet)
            {
                calendarService.AddDatesAsync(dto);
                consumerService.AddConsumerAsync(dto);
            }

            foreach(var dto in dtoSet)
            {
                int calendarId = calendarService.GetDateIdBy(dto);
                int consumerId = consumerService.GetConsumerIdBy(dto);
                consumptionService.AddConsumptionAsync(dto, consumerId, calendarId);
                if (dto.Weather != null)
                {
                    weatherService.AddWeatherAsync(dto, calendarId);
                 
                }
                
                if(dto.Price != null)
                {
                    priceService.AddPriceAsync(dto, consumerId, calendarId);
                }
                              
            }            
        }

        
        
       

       

    }
}
