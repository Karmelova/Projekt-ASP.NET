using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Linq;
using YourITMatch.Areas.Identity.Data;
using YourITMatch.Models;

namespace YourITMatch.Controllers
{
    public class JobOfferController : Controller
    {
        private readonly YourITMatchDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public JobOfferController(YourITMatchDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> JobOffersAddedByUser(string userName)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var jobOffers = _context.JobOffer.Where(c => c.AddedBy == currentUser.UserName).ToList();
            return View(jobOffers);
        }

        public ActionResult Index()
        {
            var jobOffers = _context.JobOffer.ToList();
            return View(jobOffers);
        }

        public ActionResult Details(int id)
        {
            var jobOffer = _context.JobOffer.FirstOrDefault(j => j.Id == id);
            if (jobOffer == null)
            {
                return NotFound();
            }
            return View(jobOffer);
        }

        // GET: HomeController1/Create
        public async Task<IActionResult> Create(int companyId)
        {
            var jobOffer = new JobOfferModel { CompanyId = companyId };
            return View(jobOffer);
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyId,Title,Description,SalaryFrom,SalaryTo,JobCategoryId,Remote")] JobOfferModel jobOfferModel)
        {
            if (ModelState.IsValid)
            {
                var company = await _context.Company.FindAsync(jobOfferModel.CompanyId);
                var currentUser = await _userManager.GetUserAsync(User);
                jobOfferModel.AddedBy = currentUser.UserName;
                _context.Add(jobOfferModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(JobOffersAddedByUser));
            }
            return View(jobOfferModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var jobOffer = await _context.JobOffer.FindAsync(id);

            if (jobOffer == null)
            {
                return NotFound();
            }

            return View(jobOffer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddedBy,Id,CompanyId,Company,Title,Description,SalaryFrom,SalaryTo,Remote")] JobOfferModel jobOfferModel)
        {
            if (id != jobOfferModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobOfferModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!jobOfferExists(jobOfferModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(JobOffersAddedByUser));
            }

            return View(jobOfferModel);
        }

        private bool jobOfferExists(int id)
        {
            return _context.JobOffer.Any(e => e.Id == id);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var jobOffer = await _context.JobOffer.FindAsync(id);

            if (jobOffer == null)
            {
                return NotFound();
            }

            return View(jobOffer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            var jobOffer = await _context.JobOffer.FindAsync(id);

            if (jobOffer == null)
            {
                return NotFound();
            }

            _context.JobOffer.Remove(jobOffer);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(JobOffersAddedByUser));
        }
    }
}