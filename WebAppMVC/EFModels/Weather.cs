using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class Weather
    {
        public int Id { get; set; }

        [Display(Name = "Температура")]
        public decimal Temperature { get; set; }
        public int CalendarId { get; set; }
        public Calendar? Calendar { get; set; }
    }
}
