using InventoryBeginners.Data;
using InventoryBeginners.Interfaces;
using InventoryBeginners.Models;

namespace InventoryBeginners.Repositories
{
    public class UnitRepository : IUnit
    {
        private readonly InventoryContext _context;

        public UnitRepository(InventoryContext context)
        {
            _context = context;
        }

        public Unit Create(Unit unit)
        {
            _context.Units.Add(unit);
            _context.SaveChanges();

            return unit;
        }

        public Unit Delete(Unit unit)
        {
            _context.Units.Attach(unit);
            _context.Entry(unit).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();

            return unit;
        }

        public Unit Edit(Unit unit)
        {
            _context.Units.Attach(unit);
            _context.Entry(unit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return unit;
        }

        public List<Unit> GetItems()
        {
            List<Unit> units = _context.Units.ToList();
            return units;
        }

        public Unit GetUnit(int id)
        {
            Unit unit = _context.Units.Where(u => u.Id == id).FirstOrDefault();
            return unit;
        }
    }
}
