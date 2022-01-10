using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class Consumer
    {
        public int Id { get; set; }
        
        [Display (Name="Потребитель")]
        public string? ConsumerName { get; set; }
    }
}
