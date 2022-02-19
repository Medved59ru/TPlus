using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class Price
    {
        public int Id { get; set; }
        public decimal PriceValue { get; set; }
        public Consumer? Consumer { get; set; }
        public int ConsumerId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
    }
}
