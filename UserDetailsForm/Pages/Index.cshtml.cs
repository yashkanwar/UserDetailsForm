using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserDetailsForm.Data;
using UserDetailsForm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UserDetailsForm.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UserDetails> UsersList { get; set; }

        public async Task OnGetAsync()
        {
            UsersList = await _context.UserDetails.ToListAsync();
        }

        // Handler for delete operation
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await _context.UserDetails.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.UserDetails.Remove(user);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "User details have been deleted successfully.";
            return RedirectToPage();  // Refresh the page after deletion
        }

    }
}
