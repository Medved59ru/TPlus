using WebAppMVC.Dto;
using WebAppMVC.Models;

namespace WebAppMVC.Services
{
    public class ConsumerService
    {
        private readonly DatabaseContext context;

        public ConsumerService(DatabaseContext context)
        {
            this.context = context;
        }
        public void AddConsumerAsync(InitialDto dto)
        {
           
            if (!CheckUnOriginality(dto.Name))
            {
                Consumer consumer = new Consumer();
                consumer.ConsumerName = dto.Name;
                context.Consumers.AddAsync(consumer);
                context.SaveChangesAsync();
            }

        }

        public int GetConsumerIdBy(InitialDto dto)
        {
             return context.Consumers.First(d => d.ConsumerName == dto.Name).Id;
        }

        public int GetConsumerIdBy(string consumerName)
        {
            return context.Consumers.First(d => d.ConsumerName == consumerName).Id;
        }

        public List<Consumer> GetAllConsumers()
        {
            return context.Consumers.ToList();
        }

        public List<Consumer> GetConsumerById(int? id) => context.Consumers.Where(item =>item.Id == id).ToList();

        private bool CheckUnOriginality(string name)
        {
            bool exist = false;

            if(context.Consumers.Count(c => c.ConsumerName == name) != 0)
            {
             exist = true;
            }
            return exist;

        }


    }
}
