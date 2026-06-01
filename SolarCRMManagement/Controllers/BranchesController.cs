
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolarCRMManagement.Models.Master;
using SolarCRMManagement.Data;

public class BranchesController : Controller
{
    private readonly ApplicationDbContext _context;

    public BranchesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: BRANCHS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Branches.ToListAsync());
    }

    // GET: BRANCHS/Details/5
    public async Task<IActionResult> Details(int? branchid)
    {
        if (branchid == null)
        {
            return NotFound();
        }

        var branch = await _context.Branches
            .FirstOrDefaultAsync(m => m.BranchId == branchid);
        if (branch == null)
        {
            return NotFound();
        }

        return View(branch);
    }

    // GET: BRANCHS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: BRANCHS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("BranchId,CityId,BranchCode,BranchName,Address,ContactPerson,MobileNo,EmailId,GSTNo,BranchManager,IsActive,CreatedDate,ModifiedDate,City,Branches")] Branch branch)
    {
        if (ModelState.IsValid)
        {
            _context.Add(branch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(branch);
    }

    // GET: BRANCHS/Edit/5
    public async Task<IActionResult> Edit(int? branchid)
    {
        if (branchid == null)
        {
            return NotFound();
        }

        var branch = await _context.Branches.FindAsync(branchid);
        if (branch == null)
        {
            return NotFound();
        }
        return View(branch);
    }

    // POST: BRANCHS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? branchid, [Bind("BranchId,CityId,BranchCode,BranchName,Address,ContactPerson,MobileNo,EmailId,GSTNo,BranchManager,IsActive,CreatedDate,ModifiedDate,City,Branches")] Branch branch)
    {
        if (branchid != branch.BranchId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(branch);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchExists(branch.BranchId))
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
        return View(branch);
    }

    // GET: BRANCHS/Delete/5
    public async Task<IActionResult> Delete(int? branchid)
    {
        if (branchid == null)
        {
            return NotFound();
        }

        var branch = await _context.Branches
            .FirstOrDefaultAsync(m => m.BranchId == branchid);
        if (branch == null)
        {
            return NotFound();
        }

        return View(branch);
    }

    // POST: BRANCHS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? branchid)
    {
        var branch = await _context.Branches.FindAsync(branchid);
        if (branch != null)
        {
            _context.Branches.Remove(branch);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BranchExists(int? branchid)
    {
        return _context.Branches.Any(e => e.BranchId == branchid);
    }
}
