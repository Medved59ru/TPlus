using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Dto
{
    public class HouseDto
    {

        [Display(Name = "Потребитель")]
        public string? ConsumerName { get; set; }

        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Display(Name = "Потребление")]
        public decimal ConsumptionValue { get; set; }

        [Display(Name = "Температура")]
        public decimal Temperature { get; set; }



       
    }
}
