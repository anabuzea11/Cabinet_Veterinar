using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cabinet_Veterinar.Data;
using Cabinet_Veterinar.Models;

namespace Cabinet_Veterinar.Pages.Consultatii
{
    public class DeleteModel : PageModel
    {
        private readonly Cabinet_Veterinar.Data.Cabinet_VeterinarContext _context;

        public DeleteModel(Cabinet_Veterinar.Data.Cabinet_VeterinarContext context)
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

            var consultatie = await _context.Consultatie.FirstOrDefaultAsync(m => m.ID == id);

            if (consultatie == null)
            {
                return NotFound();
            }
            else
            {
                Consultatie = consultatie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultatie = await _context.Consultatie.FindAsync(id);
            if (consultatie != null)
            {
                Consultatie = consultatie;
                _context.Consultatie.Remove(Consultatie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
