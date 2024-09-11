using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserDetailsForm.Data;
using System.Threading.Tasks;

namespace UserDetailsForm.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var user = await _context.UserDetails.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.UserDetails.Remove(user);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "User details deleted successfully.";
            return RedirectToPage("Index");
        }
    }
}