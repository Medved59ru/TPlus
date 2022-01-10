using System.Globalization;
using WebAppMVC.Dto;
using WebAppMVC.Models;

namespace WebAppMVC.Services
{
    public class PriceService
    {
        private readonly DatabaseContext context;
        public PriceService(DatabaseContext context)
        {
            this.context = context;
        }

        public void AddPriceAsync(InitialDto dto, int comsumerId, int calendarId)
        {
            Price price = new Price();
            price.PriceValue = GetPriceFrom(dto.Price);
            price.ConsumerId = comsumerId;
            price.CalendarId = calendarId;
            if (CheckUnOriginality(price))
            {
                context.Prices.AddAsync(price);
                context.SaveChangesAsync();
            }

        }

        public int GetPriceIdBy(InitialDto dto)
        {
            var priceDto = GetPriceFrom(dto.Price);
            return context.Prices.First(d => d.PriceValue == priceDto).Id;
        }

        private decimal GetPriceFrom(string price)
        {
            return Decimal.Parse(price, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);

        }

        private bool CheckUnOriginality(Price item)
        {
            bool exist = false;
            if (!context.Prices.Any(i=>i.PriceValue==item.PriceValue))
            {
                exist = true;
            }
            return exist;
        }
    }
}
