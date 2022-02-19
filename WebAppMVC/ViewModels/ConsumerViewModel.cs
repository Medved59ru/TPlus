using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.ViewModels
{
    public class ConsumerViewModel
    {
         
        public int Id { get; set; }

        [Display(Name = "Потребитель")]
        public string? ConsumerName { get; set; }

        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Потребление")]
        public decimal? ConsumptionValue { get; set; }

        [Display(Name = "Температура")]
        public decimal? Temperature { get; set; }

        [Display(Name = "Цена")]
        [DataType(DataType.Currency)]
        public decimal? PriceValue { get; set; }


    }
}
