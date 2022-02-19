using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class Consumption
    {
        public int Id { get; set; }

        public decimal ConsumptionValue { get; set; }
        public Consumer? Consumer { get; set; }
        public int ConsumerId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
    }
}
