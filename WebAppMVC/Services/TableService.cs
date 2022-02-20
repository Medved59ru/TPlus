using WebAppMVC.Models;
using WebAppMVC.ViewModels;

namespace WebAppMVC.Services
{
    public class TableService
    {
        private readonly ConsumerService _consumerService;
        private readonly ConsumptionService _consumptionService;
        private readonly PriceService _priceService;
        private readonly WeatherService _weatherService;


        public TableService(ConsumerService consumerService, ConsumptionService consumptionService, PriceService priceService, WeatherService weatherService)
        {
            _consumerService = consumerService;
            _consumptionService = consumptionService;
            _priceService = priceService;
            _weatherService = weatherService;

        }

        public List<ConsumerViewModel> GetAllConsumers(int? id, DateTime? date)
        {
            List<ConsumerViewModel> consumersForView = new List<ConsumerViewModel>();
            List<Consumer> consumerList = new List<Consumer>();
            List<Consumption> consumptionList = new List<Consumption>();
            int itemId = 1;

            if (id == 0 || id == null)
                consumerList = _consumerService.GetAllConsumers();

            if (id != null && id != 0)
                consumerList = _consumerService.GetConsumerById(id);

            
                

            foreach (var consumer in consumerList)
            {
                if (date == null || date == DateTime.Today)
                    consumptionList = _consumptionService.GetListOfConsumptionsBy(consumer.Id);

                if (date !=null && date != DateTime.Today)
                    consumptionList = _consumptionService.GetListOfConsumptionsBy(consumer.Id, date);

                foreach (var consumption in consumptionList)
                {
                    var temperature = _weatherService.GetTemperatureOrDefaultBy(consumption);
                    var price = _priceService.GetPriceOrDefualtBy(consumption);
                    ConsumerViewModel item = new ConsumerViewModel();
                    
                        if (temperature != null)
                        {
                            item.Id = itemId;
                            item.ConsumerName = consumer.ConsumerName;
                            item.Date = consumption.Date;
                            item.ConsumptionValue = consumption.ConsumptionValue;
                            item.Temperature = temperature.Temperature;
                            item.PriceValue =  null;
                        }

                        if (price != null)
                        {
                            item.Id = itemId;
                            item.ConsumerName = consumer.ConsumerName;
                            item.ConsumptionValue = consumption.ConsumptionValue;
                            item.Date = consumption.Date;
                            item.Temperature = null;
                            item.PriceValue = price.PriceValue;

                        }
                        consumersForView.Add(item);
                        itemId++;
                                                          
                }
            }

            return consumersForView;
        }

        public List<Consumer> GetConsumersListForSelector()
        {
            return _consumerService.GetAllConsumers();
        }

        public List<Consumption> GetConsumptionsForSelector()
        {
            return _consumptionService.GetAllConsumption();
        }


    }
}
