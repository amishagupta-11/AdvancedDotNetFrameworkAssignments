using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;

namespace DevelopmentEntityframeworkApproches.Controllers
{
    public class StaffRegistrationsController : Controller
    {
        private ElectronicStoreEntities db = new ElectronicStoreEntities();

        // GET: StaffRegistrations
        public async Task<ActionResult> Index()
        {
            return View(await db.StaffRegistrations.ToListAsync());
        }

        // GET: StaffRegistrations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffRegistration staffRegistration = await db.StaffRegistrations.FindAsync(id);
            if (staffRegistration == null)
            {
                return HttpNotFound();
            }
            return View(staffRegistration);
        }

        // GET: StaffRegistrations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffRegistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StaffId,FirstName,LastName,Email,PhoneNumber,Address,Department,Role,DateOfJoining,IsActive,CreatedAt")] StaffRegistration staffRegistration)
        {
            if (ModelState.IsValid)
            {
                staffRegistration.CreatedAt= DateTime.Now;
                db.StaffRegistrations.Add(staffRegistration);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(staffRegistration);
        }

        // GET: StaffRegistrations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffRegistration staffRegistration = await db.StaffRegistrations.FindAsync(id);
            if (staffRegistration == null)
            {
                return HttpNotFound();
            }
            return View(staffRegistration);
        }

        // POST: StaffRegistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StaffId,FirstName,LastName,Email,PhoneNumber,Address,Department,Role,DateOfJoining,IsActive,UpdatedAt")] StaffRegistration staffRegistration)
        {
            if (ModelState.IsValid)
            {
                staffRegistration.UpdatedAt= DateTime.Now;
                db.Entry(staffRegistration).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(staffRegistration);
        }

        // GET: StaffRegistrations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffRegistration staffRegistration = await db.StaffRegistrations.FindAsync(id);
            if (staffRegistration == null)
            {
                return HttpNotFound();
            }
            return View(staffRegistration);
        }

        // POST: StaffRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StaffRegistration staffRegistration = await db.StaffRegistrations.FindAsync(id);
            db.StaffRegistrations.Remove(staffRegistration);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
