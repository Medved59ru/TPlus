using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class Price
    {
        public int Id { get; set; }

        [Display (Name = "Цена")]
        public decimal PriceValue { get; set; }

        public Consumer? Consumer { get; set; }
        public int ConsumerId { get; set; }

        public Calendar? Calendar { get; set; }
        public int CalendarId { get; set; }
    }
}
