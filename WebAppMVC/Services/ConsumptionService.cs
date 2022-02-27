using System.Globalization;
using WebAppMVC.Dto;
using WebAppMVC.Models;

namespace WebAppMVC.Services
{
    public class ConsumptionService
    {
        private readonly DatabaseContext context;
        public ConsumptionService(DatabaseContext context)
        {
            this.context = context;
        }

        public void AddConsumptionAsync(InitialDto dto, int consumerId)
        {
            Consumption item = new Consumption();
            item.ConsumptionValue = GetCompsumptionFrom(dto.Consumption);
            item.ConsumerId = consumerId;
            item.Date = DateTime.Parse(dto.Date);
            if (CheckUnOriginality(item))
            {
                context.Consumptions.AddAsync(item);
                context.SaveChangesAsync();
            }

        }

        public void UpdateAsync(int? consumerId, DateTime? date, decimal? newValue)
        {
            var item = GetConsumptionBy(consumerId, date);

            if(item != null && newValue != null && item.ConsumptionValue != newValue)
            {
                item.ConsumptionValue = (decimal)newValue;
                context.SaveChangesAsync();
            }

        }
      

        public List<Consumption> GetAllConsumption()
        {
            return context.Consumptions.ToList();
        }
        public int GetConsumptionIdBy(InitialDto dto)
        {
            var consumptionDto = GetCompsumptionFrom(dto.Consumption);
            return context.Consumptions.First(d => d.ConsumptionValue == consumptionDto).Id;
        }

        public List<Consumption> GetListOfConsumptionsBy(int? consumerId, DateTime? date)
        {
            return context.Consumptions.Where(item => item.ConsumerId == consumerId).Where(item => item.Date == date).ToList();
        }

        public List<Consumption> GetListOfConsumptionsBy(int? consumerId)
        {
            return context.Consumptions.Where(item => item.ConsumerId == consumerId).ToList();
        }

        private Consumption GetConsumptionBy(int? consumerId, DateTime? date) => context.Consumptions.Where(i => i.ConsumerId == consumerId).Where(i => i.Date == date).FirstOrDefault();

        private decimal GetCompsumptionFrom(string consumption)
        {
            return Decimal.Parse(consumption, NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent, CultureInfo.InvariantCulture);
        }
        private bool CheckUnOriginality(Consumption item)
        {
            bool exist = false;
            if (!context.Consumptions.Any(i => i.ConsumptionValue == item.ConsumptionValue))
            {
                exist = true;
            }
            return exist;
        }

    }
}
