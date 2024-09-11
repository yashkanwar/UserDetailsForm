using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using UserDetailsForm.Data;
using UserDetailsForm.Models;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UserDetailsForm.Pages
{
    public class UpdateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UpdateModel> _logger;

        public UpdateModel(ApplicationDbContext context, ILogger<UpdateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public UserDetails UserDetails { get; set; }

        public List<string> GetAvailableStates()
        {
            var allStates = new List<string>
        {
            "Maharashtra",
            "Gujrat",
            "Delhi",
            "Punjab",
            "West Bengal",
            "Karnataka"
        };

            // Exclude the currently selected state
            allStates.Remove(UserDetails.State);

            return allStates;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            UserDetails = await _context.UserDetails.FindAsync(id);

            if (UserDetails == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                var userId = UserDetails.Id; // Check this value in the debugger

                var userInDb = await _context.UserDetails.FindAsync(userId);

                if (userInDb == null)
                {
                    return NotFound();
                }

                if (userInDb.Email != UserDetails.Email)
                {
                    // Check if the new email already exists in the database
                    var existingUser = await _context.UserDetails
                        .FirstOrDefaultAsync(u => u.Email == UserDetails.Email);

                    if (existingUser != null)
                    {
                        // Add an error to the model state and return the page
                        ModelState.AddModelError("UserDetails.Email", "The email address is already in use.");
                        return Page();
                    }
                }

                userInDb.FirstName = CapitalizeFirstLetter(UserDetails.FirstName);
                userInDb.MiddleName = CapitalizeFirstLetter(UserDetails.MiddleName);
                userInDb.LastName = CapitalizeFirstLetter(UserDetails.LastName);
                userInDb.Email = UserDetails.Email;
                userInDb.State = UserDetails.State;
                userInDb.City = UserDetails.City;
                userInDb.DOB = UserDetails.DOB;

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "User updated successfully!";

                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Error occurred while updating user");
                return StatusCode(500, "Internal server error");
            }
        }
        private string CapitalizeFirstLetter(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return char.ToUpper(value[0]) + value.Substring(1).ToLower();
        }
    }
}
