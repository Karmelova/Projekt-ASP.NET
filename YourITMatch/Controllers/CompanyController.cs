using Microsoft.AspNetCore.Mvc;
using YourITMatch.Models;
using Microsoft.AspNetCore.Identity;
using YourITMatch.Areas.Identity.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace YourITMatch.Controllers
{
    public class CompanyController : Controller
    {
        private readonly YourITMatchDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CompanyController(YourITMatchDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //companies added by user
        [HttpGet]
        public async Task<IActionResult> CompaniesAddedByUser(string userName)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var companies = _context.Company.Where(c => c.AddedBy == currentUser.UserName).ToList();
            return View(companies);
        }

        // GET: HomeController1
        public ActionResult Index()
        {
            var company = _context.Company.ToList();
            return View(company);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            var company = _context.Company.FirstOrDefault(j => j.ID == id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Email,NIP,Regon,PostCode,City,Voivodeship,Street,CompanySize,CompanyEstablished,CompanyWebsite")] CompanyModel companyModel)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                companyModel.AddedBy = currentUser.UserName;

                _context.Add(companyModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CompaniesAddedByUser));
            }

            return View(companyModel);
        }

        //edit company
        public async Task<IActionResult> Edit(int id)
        {
            var company = await _context.Company.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Email,NIP,Regon,PostCode,City,Voivodeship,Street,CompanySize,CompanyEstablished,CompanyWebsite")] CompanyModel companyModel)
        {
            if (id != companyModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(companyModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(CompaniesAddedByUser));
            }

            return View(companyModel);
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.ID == id);
        }

        //delete company
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            var company = await _context.Company
                .Include(c => c.JobOffers)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (company == null)
            {
                return NotFound();
            }

            // usuwanie ofert pracy powiązanych z firmą
            foreach (var jobOffer in company.JobOffers)
            {
                _context.JobOffer.Remove(jobOffer);
            }

            _context.Company.Remove(company);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}