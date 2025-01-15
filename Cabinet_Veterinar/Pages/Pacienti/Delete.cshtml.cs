using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cabinet_Veterinar.Data;
using Cabinet_Veterinar.Models;

namespace Cabinet_Veterinar.Pages.Pacienti
{
    public class DeleteModel : PageModel
    {
        private readonly Cabinet_Veterinar.Data.Cabinet_VeterinarContext _context;

        public DeleteModel(Cabinet_Veterinar.Data.Cabinet_VeterinarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pacient Pacient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacient.FirstOrDefaultAsync(m => m.ID == id);

            if (pacient == null)
            {
                return NotFound();
            }
            else
            {
                Pacient = pacient;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacient.FindAsync(id);
            if (pacient != null)
            {
                Pacient = pacient;
                _context.Pacient.Remove(Pacient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
