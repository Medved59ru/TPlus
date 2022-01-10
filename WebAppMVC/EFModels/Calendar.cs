using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class Calendar
    {
        public int Id { get; set; }

        [Display (Name = "Дата")]
        public DateTime Date { get; set; }
       
       
    }
}
