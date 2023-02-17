using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourITMatch.Models;

namespace YourITMatch.Controllers
{
    public class JobOfferController : Controller
    {
        private readonly YourITMatchDBContext _context;

        public JobOfferController(YourITMatchDBContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var jobOffers = _context.JobOffer.ToList();
            return View(jobOffers);
        }

        // GET: HomeController1/Create
        public IActionResult Create(int companyId)
        {
            var jobOffer = new JobOfferModel { CompanyId = companyId };
            return View(jobOffer);
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyID,Title,Description,SalaryFrom,SalaryTo,DateAdded,JobCategoryId,Remote")] JobOfferModel jobOfferModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobOfferModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobOfferModel);
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