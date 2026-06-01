using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolarCRMManagement.Data;
using SolarCRMManagement.Models.Master;

namespace SolarCRMManagement.Controllers
{
    public class DistrictsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DistrictsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Districts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Districts.ToListAsync());
        }

        // GET: Districts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var district = await _context.Districts
                .FirstOrDefaultAsync(m => m.DistrictId == id);

            if (district == null)
            {
                return NotFound();
            }

            return View(district);
        }

        // GET: Districts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Districts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("DistrictId,StateId,DistrictCode,DistrictName,IsActive,CreatedDate")]
            District district)
        {
            if (ModelState.IsValid)
            {
                _context.Add(district);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(district);
        }

        // GET: Districts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var district = await _context.Districts.FindAsync(id);

            if (district == null)
            {
                return NotFound();
            }

            return View(district);
        }

        // POST: Districts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("DistrictId,StateId,DistrictCode,DistrictName,IsActive,CreatedDate")]
            District district)
        {
            if (id != district.DistrictId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(district);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistrictExists(district.DistrictId))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(district);
        }

        // GET: Districts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var district = await _context.Districts
                .FirstOrDefaultAsync(m => m.DistrictId == id);

            if (district == null)
            {
                return NotFound();
            }

            return View(district);
        }

        // POST: Districts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var district = await _context.Districts.FindAsync(id);

            if (district != null)
            {
                _context.Districts.Remove(district);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool DistrictExists(int id)
        {
            return _context.Districts.Any(e => e.DistrictId == id);
        }
    }
}
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using SolarCRMManagement.Models.Master;
//using SolarCRMManagement.Data;

//public class DistrictsController : Controller
//{
//    private readonly ApplicationDbContext _context;

//    public DistrictsController(ApplicationDbContext context)
//    {
//        _context = context;
//    }

//    // GET: DISTRICTS
//    public async Task<IActionResult> Index()    
//    {
//        return View(await _context.Districts.ToListAsync());
//    }

//    // GET: DISTRICTS/Details/5
//    public async Task<IActionResult> Details(int? districtid)
//    {
//        if (districtid == null)
//        {
//            return NotFound();
//        }

//        var district = await _context.Districts
//            .FirstOrDefaultAsync(m => m.DistrictId == districtid);
//        if (district == null)
//        {
//            return NotFound();
//        }

//        return View(district);
//    }

//    // GET: DISTRICTS/Create
//    public IActionResult Create()
//    {
//        return View();
//    }

//    // POST: DISTRICTS/Create
//    // To protect from overposting attacks, enable the specific properties you want to bind to.
//    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Create([Bind("DistrictId,StateId,DistrictCode,DistrictName,IsActive,CreatedDate,State")] District district)
//    {
//        if (ModelState.IsValid)
//        {
//            _context.Add(district);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }
//        return View(district);
//    }

//    // GET: DISTRICTS/Edit/5
//    public async Task<IActionResult> Edit(int? districtid)
//    {
//        if (districtid == null)
//        {
//            return NotFound();
//        }

//        var district = await _context.Districts.FindAsync(districtid);
//        if (district == null)
//        {
//            return NotFound();
//        }
//        return View(district);
//    }

//    // POST: DISTRICTS/Edit/5
//    // To protect from overposting attacks, enable the specific properties you want to bind to.
//    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Edit(int? districtid, [Bind("DistrictId,StateId,DistrictCode,DistrictName,IsActive,CreatedDate,State")] District district)
//    {
//        if (districtid != district.DistrictId)
//        {
//            return NotFound();
//        }

//        if (ModelState.IsValid)
//        {
//            try
//            {
//                _context.Update(district);
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!DistrictExists(district.DistrictId))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }
//            return RedirectToAction(nameof(Index));
//        }
//        return View(district);
//    }

//    // GET: DISTRICTS/Delete/5
//    public async Task<IActionResult> Delete(int? districtid)
//    {
//        if (districtid == null)
//        {
//            return NotFound();
//        }

//        var district = await _context.Districts
//            .FirstOrDefaultAsync(m => m.DistrictId == districtid);
//        if (district == null)
//        {
//            return NotFound();
//        }

//        return View(district);
//    }

//    // POST: DISTRICTS/Delete/5
//    [HttpPost, ActionName("Delete")]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> DeleteConfirmed(int? districtid)
//    {
//        var district = await _context.Districts.FindAsync(districtid);
//        if (district != null)
//        {
//            _context.Districts.Remove(district);
//        }

//        await _context.SaveChangesAsync();
//        return RedirectToAction(nameof(Index));
//    }

//    private bool DistrictExists(int? districtid)
//    {
//        return _context.Districts.Any(e => e.DistrictId == districtid);
//    }
//}
