using WebAppMVC.Dto;
using WebAppMVC.Models;

namespace WebAppMVC.Services
{
    public class CalendarService
    {

        private readonly DatabaseContext context;

        public CalendarService(DatabaseContext context)
        {

            this.context = context;
        }

        public void AddDatesAsync(InitialDto dto)
        {
            Calendar localItem = new Calendar();
            localItem.Date = DateTime.Parse(dto.Date);
            if (CheckUnOriginality(localItem))
            {
                context.Calendars.AddAsync(localItem);
                context.SaveChangesAsync();
            }
           
        }

        public int GetDateIdBy(InitialDto dto)
        {
            DateTime item = DateTime.Parse(dto.Date);
            return context.Calendars.First(d => d.Date == item).Id;
        }

        private bool CheckUnOriginality(Calendar item)
        {
            bool exist = false;

            if (!context.Calendars.Any(i=>i.Date==item.Date))
            {
                exist = true;
            }
            return exist;
        }



    }
}
