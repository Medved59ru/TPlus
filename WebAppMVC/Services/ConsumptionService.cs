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

        public void AddConsumptionAsync(InitialDto dto, int consumerId, int calendarId)
        {
            Consumption item = new Consumption();
            item.ConsumptionValue = GetCompsumptionFrom(dto.Consumption);
            item.ConsumerId = consumerId;
            item.CalendarId = calendarId;
            if (CheckUnOriginality(item))
            {
                context.Consumptions.AddAsync(item);
                context.SaveChangesAsync();
            }

        }

        public int GetConsumptionIdBy(InitialDto dto)
        {
            var consumptionDto = GetCompsumptionFrom(dto.Consumption);
            return context.Consumptions.First(d => d.ConsumptionValue == consumptionDto).Id;
        }

        private decimal GetCompsumptionFrom(string consumption)
        {
            return Decimal.Parse(consumption, NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent, CultureInfo.InvariantCulture);
        }
        private bool CheckUnOriginality(Consumption item)
        {
            bool exist = false;
            if (!context.Consumptions.Any(i=>i.ConsumptionValue == item.ConsumptionValue))
            {
                exist = true;
            }
            return exist;
        }

    }
}
