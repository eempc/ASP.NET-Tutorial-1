using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Database Step 5

namespace WebApplication1.Pages {
    public class CreateModel : PageModel {
        private readonly AppDbContext _db; // Database context required here, private so it cannot be access via inheritance

        // Constructor
        public CreateModel(AppDbContext db) {
            _db = db;
        }

        [BindProperty]
        public Customer Customer { get; set; } // Required for the asp-input in the create razor page

        // This is the submit button sent stuff but I don't see how it links to the submit button
        public async Task<IActionResult> OnPostAsync() {
            // If the data is valid then add add customer to database
            // If I could name this method, I would name it AddCustomerToDatabase, but tutorial wants this
            if (!ModelState.IsValid) {
                return Page();
            }

            _db.Customers.Add(Customer);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Index");
        }

        //public void OnGet() {
        //}
    }
}