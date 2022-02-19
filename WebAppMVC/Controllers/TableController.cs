using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;
using WebAppMVC.Services;
using WebAppMVC.ViewModels;

namespace WebAppMVC.Controllers
{
    public class TableController : Controller
    {
        private readonly TableService _tableService;
        List<ConsumerViewModel> consumerList;
        List<Consumer> consumers;
        List<Consumption> consumptions;
        public TableController(TableService tableService)
        {
            _tableService = tableService;
        }
        // GET: TableController
       
        public ActionResult Index(int? consumerId, DateTime? date)
        {
            consumers = _tableService.GetConsumersListForSelector();
            consumerList = _tableService.GetAllConsumers(consumerId, date);
            consumptions = _tableService.GetConsumptionsForSelector();

            consumers.Insert(0, new Consumer { Id = 0, ConsumerName = "Потребители" });
            consumptions.Insert(0, new Consumption { Id = 0, Date = DateTime.Today });

            IndexViewModel viewModel = new IndexViewModel { Consumers = consumers, ConsumerViewModels = consumerList, Consumptions = consumptions };

            return View(viewModel);
        }

       
        //// GET: TableController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: TableController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

       

       
    }
}
