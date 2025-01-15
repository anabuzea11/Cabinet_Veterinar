using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cabinet_Veterinar.Data;
using Cabinet_Veterinar.Models;

namespace Cabinet_Veterinar.Pages.Consultatii
{
    public class EditModel : PageModel
    {
        private readonly Cabinet_Veterinar.Data.Cabinet_VeterinarContext _context;

        public EditModel(Cabinet_Veterinar.Data.Cabinet_VeterinarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Consultatie Consultatie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultatie =  await _context.Consultatie.FirstOrDefaultAsync(m => m.ID == id);
            if (consultatie == null)
            {
                return NotFound();
            }
            Consultatie = consultatie;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Consultatie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultatieExists(Consultatie.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ConsultatieExists(int id)
        {
            return _context.Consultatie.Any(e => e.ID == id);
        }
    }
}
