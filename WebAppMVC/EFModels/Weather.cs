using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class Weather
    {
        public int? Id { get; set; }
        public decimal? Temperature { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
    }
}
