using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;

namespace DevelopmentEntityframeworkApproches.Controllers
{
    /// <summary>
    /// Controller for managing staff registrations in the electronic store.
    /// Provides actions for viewing, creating, editing, and deleting staff registrations.
    /// </summary>
    public class StaffRegistrationsController : Controller
    {
        private ElectronicStoreEntities db = new ElectronicStoreEntities();

        /// <summary>
        /// Displays a list of all staff registrations.
        /// </summary>
        /// <returns>View with a list of all staff registrations</returns>
        public async Task<ActionResult> Index()
        {
            return View(await db.StaffRegistrations.ToListAsync());
        }

        /// <summary>
        /// Displays the details of a specific staff registration by ID.
        /// </summary>
        /// <param name="id">The ID of the staff registration to display</param>
        /// <returns>View with details of the staff registration, or an error if not found</returns>
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

        /// <summary>
        /// Displays the form for creating a new staff registration.
        /// </summary>
        /// <returns>View with a form to create a new staff registration</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Handles the form submission for creating a new staff registration.
        /// Adds the new staff registration to the database if the model is valid.
        /// </summary>
        /// <param name="staffRegistration">The staff registration details to be added</param>
        /// <returns>Redirects to the index view if the registration is successful, or re-renders the create view with errors</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StaffId,FirstName,LastName,Email,PhoneNumber,Address,Department,Role,DateOfJoining,IsActive,CreatedAt")] StaffRegistration staffRegistration)
        {
            if (ModelState.IsValid)
            {
                staffRegistration.CreatedAt = DateTime.Now;
                db.StaffRegistrations.Add(staffRegistration);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(staffRegistration);
        }

        /// <summary>
        /// Displays the form for editing an existing staff registration by ID.
        /// </summary>
        /// <param name="id">The ID of the staff registration to edit</param>
        /// <returns>View with a form to edit the staff registration, or an error if not found</returns>
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

        /// <summary>
        /// Handles the form submission for editing an existing staff registration.
        /// Updates the staff registration in the database if the model is valid.
        /// </summary>
        /// <param name="staffRegistration">The updated staff registration details</param>
        /// <returns>Redirects to the index view if the update is successful, or re-renders the edit view with errors</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StaffId,FirstName,LastName,Email,PhoneNumber,Address,Department,Role,DateOfJoining,IsActive,UpdatedAt")] StaffRegistration staffRegistration)
        {
            if (ModelState.IsValid)
            {
                staffRegistration.UpdatedAt = DateTime.Now;
                db.Entry(staffRegistration).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(staffRegistration);
        }

        /// <summary>
        /// Displays the confirmation page for deleting a staff registration by ID.
        /// </summary>
        /// <param name="id">The ID of the staff registration to delete</param>
        /// <returns>View with confirmation of the staff registration to delete, or an error if not found</returns>
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

        /// <summary>
        /// Handles the deletion of a staff registration from the database.
        /// </summary>
        /// <param name="id">The ID of the staff registration to delete</param>
        /// <returns>Redirects to the index view after deletion</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StaffRegistration staffRegistration = await db.StaffRegistrations.FindAsync(id);
            db.StaffRegistrations.Remove(staffRegistration);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Disposes of the database context when the controller is disposed.
        /// </summary>
        /// <param name="disposing">Indicates whether to dispose the database context</param>
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
