using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class Consumption
    {
        public int Id { get; set; }

        [Display (Name = "Потребление")]
        public decimal ConsumptionValue { get; set; }

        public Consumer? Consumer { get; set; }
        public int ConsumerId { get; set; }

        public Calendar? Calendar { get; set; }
        public int CalendarId { get; set; }
        
    }
}
