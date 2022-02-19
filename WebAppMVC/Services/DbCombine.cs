using System.Globalization;
using WebAppMVC.Dto;
using WebAppMVC.Models;

namespace WebAppMVC.Services
{
    public class DbCombine
    {
        private readonly DatabaseContext context;
        private readonly ConsumerService consumerService;
        private readonly ConsumptionService consumptionService;
        private readonly PriceService priceService;
        private readonly WeatherService weatherService;
   

        public DbCombine(DatabaseContext context, ConsumerService consumerService, 
                        ConsumptionService consumptionService,
                        PriceService priceService, WeatherService weatherService)
        {
            this.context = context;
            this.consumerService = consumerService;
            this.consumptionService = consumptionService;
            this.priceService = priceService;
            this.weatherService = weatherService;
           
        }

        public void FillTheDB(HashSet<InitialDto> dtoSet)
        {
            foreach (var dto in dtoSet)
            {
                consumerService.AddConsumerAsync(dto);
            }

            foreach(var dto in dtoSet)
            {               
                int consumerId = consumerService.GetConsumerIdBy(dto);
                consumptionService.AddConsumptionAsync(dto, consumerId);
                if (dto.Weather != null)
                {
                    weatherService.AddWeatherAsync(dto);
                }
                
                if(dto.Price != null)
                {
                    priceService.AddPriceAsync(dto, consumerId);
                }
                              
            }            
        }

        
        
       

       

    }
}
