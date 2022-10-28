using InventoryBeginners.Data;
using InventoryBeginners.Interfaces;
using InventoryBeginners.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InventoryBeginners.Controllers
{
    public class UnitController : Controller
    {
        //private readonly InventoryContext _context;
        //public UnitController(InventoryContext context)
        //{
        //    _context = context;
        //}

        
        private readonly IUnit _unitRepo;
        public UnitController(IUnit unitrepo)
        {
            _unitRepo = unitrepo;
        }


        //public IActionResult Index()
        //{
        //    List<Unit> units = _context.Units.ToList();
        //    return View(units);
        //}


        public IActionResult Index()
        {
            List<Unit> units = _unitRepo.GetItems();
            return View(units);
        }



        //[HttpGet]
        //public IActionResult Create()
        //{
        //    Unit unit = new Unit();
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Unit unit)
        //{
        //    try
        //    {
        //        _context.Units.Add(unit);
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {

        //    }

        //    return RedirectToAction(nameof(Index));
        //}




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
                unit = _unitRepo.Create(unit);
            }
            catch
            {

            }

            return RedirectToAction(nameof(Index));
        }




        //public IActionResult Details(int id)
        //{
        //    Unit unit = GetUnit(id);
        //    return View(unit);
        //}


        public IActionResult Details(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }




        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    Unit unit = GetUnit(id);
        //    return View(unit);
        //}

        //[HttpPost]
        //public IActionResult Edit(Unit unit)
        //{
        //    try
        //    {
        //        _context.Units.Attach(unit);
        //        _context.Entry(unit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {

        //    }

        //    return RedirectToAction(nameof(Index));
        //}





        [HttpGet]
        public IActionResult Edit(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Edit(Unit unit)
        {
            try
            {
                unit = _unitRepo.Edit(unit);
            }
            catch
            {

            }

            return RedirectToAction(nameof(Index));
        }






        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    Unit unit = _unitRepo.GetUnit(id);
        //    return View(unit);
        //}

        //[HttpPost]
        //public IActionResult Delete(Unit unit)
        //{
        //    try
        //    {
        //        _context.Units.Attach(unit);
        //        _context.Entry(unit).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {

        //    }

        //    return RedirectToAction(nameof(Index));
        //}





        [HttpGet]
        public IActionResult Delete(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Delete(Unit unit)
        {
            try
            {
                unit = _unitRepo.Delete(unit);
            }
            catch
            {

            }

            return RedirectToAction(nameof(Index));
        }





        //private Unit GetUnit(int id)
        //{
        //    Unit unit = _context.Units.Where(u => u.Id == id).FirstOrDefault();
        //    return unit;
        //}
    }
}
