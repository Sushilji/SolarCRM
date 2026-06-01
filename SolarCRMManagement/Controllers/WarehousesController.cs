
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolarCRMManagement.Models.Master;
using SolarCRMManagement.Data;

public class WarehousesController : Controller
{
    private readonly ApplicationDbContext _context;

    public WarehousesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: WAREHOUSES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Warehouses.ToListAsync());
    }

    // GET: WAREHOUSES/Details/5
    public async Task<IActionResult> Details(int? warehouseid)
    {
        if (warehouseid == null)
        {
            return NotFound();
        }

        var warehouse = await _context.Warehouses
            .FirstOrDefaultAsync(m => m.WarehouseId == warehouseid);
        if (warehouse == null)
        {
            return NotFound();
        }

        return View(warehouse);
    }

    // GET: WAREHOUSES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: WAREHOUSES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("WarehouseId,BranchId,WarehouseCode,WarehouseName,Address,WarehouseManager,MobileNo,EmailId,Capacity,IsActive,CreatedDate,ModifiedDate,Branch")] Warehouse warehouse)
    {
        if (ModelState.IsValid)
        {
            _context.Add(warehouse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(warehouse);
    }

    // GET: WAREHOUSES/Edit/5
    public async Task<IActionResult> Edit(int? warehouseid)
    {
        if (warehouseid == null)
        {
            return NotFound();
        }

        var warehouse = await _context.Warehouses.FindAsync(warehouseid);
        if (warehouse == null)
        {
            return NotFound();
        }
        return View(warehouse);
    }

    // POST: WAREHOUSES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? warehouseid, [Bind("WarehouseId,BranchId,WarehouseCode,WarehouseName,Address,WarehouseManager,MobileNo,EmailId,Capacity,IsActive,CreatedDate,ModifiedDate,Branch")] Warehouse warehouse)
    {
        if (warehouseid != warehouse.WarehouseId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(warehouse);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarehouseExists(warehouse.WarehouseId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(warehouse);
    }

    // GET: WAREHOUSES/Delete/5
    public async Task<IActionResult> Delete(int? warehouseid)
    {
        if (warehouseid == null)
        {
            return NotFound();
        }

        var warehouse = await _context.Warehouses
            .FirstOrDefaultAsync(m => m.WarehouseId == warehouseid);
        if (warehouse == null)
        {
            return NotFound();
        }

        return View(warehouse);
    }

    // POST: WAREHOUSES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? warehouseid)
    {
        var warehouse = await _context.Warehouses.FindAsync(warehouseid);
        if (warehouse != null)
        {
            _context.Warehouses.Remove(warehouse);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool WarehouseExists(int? warehouseid)
    {
        return _context.Warehouses.Any(e => e.WarehouseId == warehouseid);
    }
}
