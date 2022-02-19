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

        public void AddPriceAsync(InitialDto dto, int comsumerId)
        {
            Price price = new Price();
            price.PriceValue = GetPriceFrom(dto.Price);
            price.ConsumerId = comsumerId;
            price.Date = DateTime.Parse(dto.Date);
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

        public Price GetPriceOrDefualtBy(Consumption consumption)
        {
            return context.Prices.Where(item => item.ConsumerId == consumption.ConsumerId).Where(item => item.Date == consumption.Date).FirstOrDefault();
        }

        private decimal GetPriceFrom(string price)
        {
            return Decimal.Parse(price, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);

        }

        private bool CheckUnOriginality(Price item)
        {
            bool exist = false;
            if (!context.Prices.Where(c=>c.ConsumerId == item.ConsumerId).Any(i=>i.Date==item.Date))
            {
                exist = true;
            }
            return exist;
        }
    }
}
