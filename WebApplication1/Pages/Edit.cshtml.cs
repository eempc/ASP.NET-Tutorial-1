using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

// Step 7, create Edit database page

namespace WebApplication1.Pages
{
    public class EditModel : PageModel
    {
        //These are required in every .cs file. Can't I stick it into the PageModel inherited class?
        private readonly AppDbContext _db; // The database

        // Constructor
        public EditModel (AppDbContext db) {
            _db = db;
        } 
       
        [BindProperty]
        public Customer Customer { get; set; } // Customer class

        // Instructions method to go to Edit page
        public async Task<IActionResult> OnGetAsync (int id) {
            Customer = await _db.Customers.FindAsync(id);
            if (Customer == null) {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        // Edit the name of the customer, submit button
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {               
                return Page();
            }

            _db.Attach(Customer).State = EntityState.Modified;

            // In case someone else is editing at the same time, use this try/catch
            try {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e) {
                throw new Exception($"Customer {Customer.Id} not found!", e);
            }

            return RedirectToPage("/Index");
        }

        // Remove default OnGet

    }
}