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
using System.Security.Policy;

namespace Cabinet_Veterinar.Pages.Pacienti
{
    public class EditModel : PageModel
    {
        private readonly Cabinet_Veterinar.Data.Cabinet_VeterinarContext _context;

        public EditModel(Cabinet_Veterinar.Data.Cabinet_VeterinarContext context)
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

            var pacient =  await _context.Pacient.FirstOrDefaultAsync(m => m.ID == id);
            if (pacient == null)
            {
                return NotFound();
            }
            Pacient = pacient;
            ViewData["ProprietarID"] = new SelectList(_context.Set<Proprietar>(), "ID", "Nume");
            ViewData["ConsultatieID"] = new SelectList(_context.Set<Consultatie>(), "ID", "Data_Consultatie", "Diagnostic", "Pret");
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

            _context.Attach(Pacient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacientExists(Pacient.ID))
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

        private bool PacientExists(int id)
        {
            return _context.Pacient.Any(e => e.ID == id);
        }
    }
}
