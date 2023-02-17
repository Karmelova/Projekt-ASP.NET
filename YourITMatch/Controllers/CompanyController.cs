using Microsoft.AspNetCore.Mvc;
using YourITMatch.Models;
using Microsoft.AspNetCore.Identity;
using YourITMatch.Areas.Identity.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

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
            return View();
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
                return RedirectToAction(nameof(Index));
            }

            return View(companyModel);
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}