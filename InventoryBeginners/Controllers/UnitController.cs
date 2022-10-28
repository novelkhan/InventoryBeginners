using InventoryBeginners.Data;
using InventoryBeginners.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InventoryBeginners.Controllers
{
    public class UnitController : Controller
    {
        private readonly InventoryContext _Context;
        public UnitController(InventoryContext context)
        {
            _Context = context;
        }


        public IActionResult Index()
        {
            List<Unit> units = _Context.Units.ToList();

            return View(units);
        }



        [HttpGet]
        public IActionResult Create()
        {
            Unit unit = new Unit();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Unit unit)
        {
            try
            {
                _Context.Units.Add(unit);
                _Context.SaveChanges();
            }
            catch
            {

            }

            return RedirectToAction(nameof(Index));
        }




        public IActionResult Details(int id)
        {
            Unit unit = GetUnit(id);
            return View(unit);
        }




        [HttpGet]
        public IActionResult Edit(int id)
        {
            Unit unit = GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Edit(Unit unit)
        {
            try
            {
                _Context.Units.Attach(unit);
                _Context.Entry(unit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _Context.SaveChanges();
            }
            catch
            {

            }

            return RedirectToAction(nameof(Index));
        }






        [HttpGet]
        public IActionResult Delete(int id)
        {
            Unit unit = GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Delete(Unit unit)
        {
            try
            {
                _Context.Units.Attach(unit);
                _Context.Entry(unit).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _Context.SaveChanges();
            }
            catch
            {

            }

            return RedirectToAction(nameof(Index));
        }





        private Unit GetUnit(int id)
        {
            Unit unit = _Context.Units.Where(u => u.Id == id).FirstOrDefault();
            return unit;
        }
    }
}
