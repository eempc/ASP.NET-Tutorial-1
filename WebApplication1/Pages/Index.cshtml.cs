using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

// Index was repurposed to the display database stuff page and requires the database stuff you see here
// public void is now public async, used in conjunction with await to allow server to process
// Changes to cs files requires a reboot of the web server, whereas changes to html do not
// This page displays all records, unfiltered

namespace WebApplication1.Pages {
    public class IndexModel : PageModel {

        private readonly AppDbContext _db; // Database context required here, private so it cannot be access via inheritance
       
        public IndexModel(AppDbContext db) { _db = db; } // Constructor

        public IList<Customer> Customers { get; private set; }

        // Temp message
        [TempData]
        public string Message { get; set; }

        public async Task OnGetAsync() {
            Customers = await _db.Customers.AsNoTracking().ToListAsync(); // For read-only this is faster to get a list
        }

        // Delete method
        //Fetch customer via id (this is not an SQL string), if found, delete customer. The method name Delete is strict, but has to match the HTML asp-page-handler
        public async Task<IActionResult> OnPostDeleteAsync(int id) {           
            var customer = await _db.Customers.FindAsync(id);
            if (customer != null) {
                _db.Customers.Remove(customer);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
