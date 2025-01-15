using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cabinet_Veterinar.Data;
using Cabinet_Veterinar.Models;
using System.Security.Policy;

namespace Cabinet_Veterinar.Pages.Pacienti
{
    public class CreateModel : PageModel
    {
        private readonly Cabinet_Veterinar.Data.Cabinet_VeterinarContext _context;

        public CreateModel(Cabinet_Veterinar.Data.Cabinet_VeterinarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProprietarID"] = new SelectList(_context.Set<Proprietar>(), "ID", "Nume");
            ViewData["ConsultatieID"] = new SelectList(_context.Set<Consultatie>(), "ID", "Data_Consultatie", "Diagnostic", "Pret");
            return Page();
        }

        [BindProperty]
        public Pacient Pacient { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pacient.Add(Pacient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
