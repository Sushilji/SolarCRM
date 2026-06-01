
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolarCRMManagement.Models.Master;
using SolarCRMManagement.Data;

public class CitiesController : Controller
{
    private readonly ApplicationDbContext _context;

    public CitiesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: CITYS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Cities.ToListAsync());
    }

    // GET: CITYS/Details/5
    public async Task<IActionResult> Details(int? cityid)
    {
        if (cityid == null)
        {
            return NotFound();
        }

        var city = await _context.Cities
            .FirstOrDefaultAsync(m => m.CityId == cityid);
        if (city == null)
        {
            return NotFound();
        }

        return View(city);
    }

    // GET: CITYS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CITYS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CityId,DistrictId,CityCode,CityName,IsActive,CreatedDate,District")] City city)
    {
        if (ModelState.IsValid)
        {
            _context.Add(city);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(city);
    }

    // GET: CITYS/Edit/5
    public async Task<IActionResult> Edit(int? cityid)
    {
        if (cityid == null)
        {
            return NotFound();
        }

        var city = await _context.Cities.FindAsync(cityid);
        if (city == null)
        {
            return NotFound();
        }
        return View(city);
    }

    // POST: CITYS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? cityid, [Bind("CityId,DistrictId,CityCode,CityName,IsActive,CreatedDate,District")] City city)
    {
        if (cityid != city.CityId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(city);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(city.CityId))
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
        return View(city);
    }

    // GET: CITYS/Delete/5
    public async Task<IActionResult> Delete(int? cityid)
    {
        if (cityid == null)
        {
            return NotFound();
        }

        var city = await _context.Cities
            .FirstOrDefaultAsync(m => m.CityId == cityid);
        if (city == null)
        {
            return NotFound();
        }

        return View(city);
    }

    // POST: CITYS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? cityid)
    {
        var city = await _context.Cities.FindAsync(cityid);
        if (city != null)
        {
            _context.Cities.Remove(city);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CityExists(int? cityid)
    {
        return _context.Cities.Any(e => e.CityId == cityid);
    }
}
