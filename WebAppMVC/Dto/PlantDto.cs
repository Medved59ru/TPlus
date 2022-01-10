namespace WebAppMVC.Dto
{
    public class PlantDto
    {
        public int Id { get; set; }
        public string? ConsumerName { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Consumption { get; set; }
        public decimal? Price { get; set; }
       
    }
}
