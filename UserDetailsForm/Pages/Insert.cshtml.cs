using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserDetailsForm.Data;
using UserDetailsForm.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UserDetailsForm.Pages
{
    public class InsertModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public InsertModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserDetails UserDetails { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check if the email already exists in the database
            var existingUser = await _context.UserDetails
                .FirstOrDefaultAsync(u => u.Email == UserDetails.Email);

            if (existingUser != null)
            {
                // Add an error to the model state and return the page
                ModelState.AddModelError("UserDetails.Email", "The email address is already in use.");
                return Page();
            }

            // Capitalize the first letter of name fields before saving
            UserDetails.FirstName = CapitalizeFirstLetter(UserDetails.FirstName);
            UserDetails.MiddleName = CapitalizeFirstLetter(UserDetails.MiddleName);
            UserDetails.LastName = CapitalizeFirstLetter(UserDetails.LastName);

            // Add new user entry to the database
            _context.UserDetails.Add(UserDetails);
            await _context.SaveChangesAsync();

            TempData["InsertMessage"] = "Your details have been successfully submitted.";
            return RedirectToPage();
        }

        private string CapitalizeFirstLetter(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return char.ToUpper(value[0]) + value.Substring(1).ToLower();
        }
    }
}
