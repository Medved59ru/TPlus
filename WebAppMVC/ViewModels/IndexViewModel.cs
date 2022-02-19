using WebAppMVC.Models;

namespace WebAppMVC.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<ConsumerViewModel>? ConsumerViewModels { get; set; }
        public IEnumerable<Consumer>? Consumers { get; set; }
        public IEnumerable<Consumption>? Consumptions { get; set; }
    }
}
