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
    public class IndexModel : PageModel
    {
        private readonly Cabinet_Veterinar.Data.Cabinet_VeterinarContext _context;

        public IndexModel(Cabinet_Veterinar.Data.Cabinet_VeterinarContext context)
        {
            _context = context;
        }

        public IList<Pacient> Pacient { get;set; } = default!;
        public string SearchString { get; set; } = string.Empty;

        public async Task OnGetAsync(string? searchString)
        {
            SearchString = searchString;

            Pacient = await _context.Pacient
                .Include(b=>b.Proprietar)
                .Include(b=>b.Consultatie)
                .ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                Pacient = Pacient.Where(p => p.Nume.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                Pacient = Pacient;
            }
        }
    }
}
