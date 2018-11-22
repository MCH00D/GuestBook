using GuestBook.DataAccessLayer;
using GuestBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuestBook.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _recordRepository;

        public HomeController(IRepository repository)
        {
            _recordRepository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_recordRepository.GetRecords());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RecordViewModel recordViewModel)
        {
            if (ModelState.IsValid)
            {
                Record record = new Record
                {
                    Author = recordViewModel.Author,
                    Message = recordViewModel.Message,
                    Date = DateTime.Now
                };

                _recordRepository.CreateRecord(record);
                return RedirectToAction("Index");
            }

            return View(recordViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Record record = _recordRepository.GetRecord(id);

            RecordViewModel recordViewModel = new RecordViewModel
            {
                Id = record.Id,
                Author = record.Author,
                Message = record.Message,
                Date = record.Date
            };

            return View(recordViewModel);
        }

        [HttpPost]
        public ActionResult Edit(RecordViewModel recordViewModel)
        {
            if (ModelState.IsValid)
            {
                Record record = new Record
                {
                    Id = recordViewModel.Id,
                    Author = recordViewModel.Author,
                    Message = recordViewModel.Message,
                    Date = DateTime.Now
                };

                _recordRepository.UpdateRecord(record);
                return RedirectToAction("Index");
            }

            return View(recordViewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Record record = _recordRepository.GetRecord(id);

            RecordViewModel recordViewModel = new RecordViewModel
            {
                Id = record.Id,
                Author = record.Author,
                Message = record.Message,
                Date = record.Date
            };

            return View(recordViewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Record record = _recordRepository.GetRecord(id);

            RecordViewModel recordViewModel = new RecordViewModel
            {
                Id = record.Id,
                Author = record.Author,
                Message = record.Message,
                Date = record.Date
            };

            return View(recordViewModel);
        }

        [HttpPost]
        public ActionResult Delete(RecordViewModel recordViewModel)
        {
            _recordRepository.DeleteRecord(recordViewModel.Id);
            return RedirectToAction("Index");
        }
    }
}