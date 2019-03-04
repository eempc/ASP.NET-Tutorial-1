using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

//Index was repurposed to the display page and requires the database stuff you see here

namespace WebApplication1.Pages {
    public class IndexModel : PageModel {

        private readonly AppDbContext _db; // Database context required here, private so it cannot be access via inheritance

        // Constructor
        public IndexModel(AppDbContext db) {
            _db = db;
        }

        public IList<Customer> Customers { get; private set; }

        public async Task OnGetAsync() {
            Customers = await _db.Customers.AsNoTracking().ToListAsync(); // For read-only this is faster to get a list
        }
    }
}
