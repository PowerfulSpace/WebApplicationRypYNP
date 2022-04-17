using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplicationRypYNP.Domain.Abstracts.Interfaces;
using WebApplicationRypYNP.Domain.Entities;
using WebApplicationRypYNP.Models;
using WebApplicationRypYNP.Models.EmailModel;
using WebApplicationRypYNP.Models.ProjectTimerModel;

namespace WebApplicationRypYNP.Controllers
{
    public class PayerController : Controller
    {

        private readonly IPayer _contextRepository;

        private TimerModule timerModule;


        public PayerController(IPayer contextRepository)
        {
            _contextRepository = contextRepository;

            timerModule = new TimerModule(contextRepository, 86400000); // 24 часа
            timerModule.Init();
        }


        public IActionResult SearchPage(string searchText = "")
        {
            ViewBag.SearchText = searchText;

            IEnumerable<Payer> payers = _contextRepository.GetItems(searchText).Result;


            InfoModel infoModel = new InfoModel();
            infoModel = _contextRepository.GetInfoModel(infoModel);

            ViewBag.Local = infoModel.IsInTheLocalDb ? "Присутствует" : "Не присутствует";
            ViewBag.Server = infoModel.IsInTheServerDb ? "Присутствует" : "Не присутствует";

            return View(payers);
        }



    }
}

//100582333