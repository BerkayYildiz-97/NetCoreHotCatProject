using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TableController : Controller
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }
        public IActionResult Index()
        {
            return View(_tableService.GetAll());
        }
        public IActionResult AddTable()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTable(Table table)
        {
            _tableService.Create(table);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveTable(int id)
        {
            var result = _tableService.GetById(id);
            _tableService.Delete(result);
            return RedirectToAction("Index");
        }
        public IActionResult GetTable(Table table)
        {
            var result = _tableService.GetById(table.Id);
            return View(result);
        }
        public IActionResult UpdateTable(int id)
        {
            var result = _tableService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateTable(Table table)
        {
            _tableService.Update(table);
            return RedirectToAction("Index");
        }
    }
}
