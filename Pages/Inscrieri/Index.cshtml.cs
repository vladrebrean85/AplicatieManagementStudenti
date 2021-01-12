using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicatieManagementStudenti.Data;
using AplicatieManagementStudenti.Models;

namespace AplicatieManagementStudenti.Pages.Inscrieri
{
    public class IndexModel : PageModel
    {
        private readonly AplicatieManagementStudenti.Data.SchoolContext _context;

        public IndexModel(AplicatieManagementStudenti.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Inscriere> Inscriere { get;set; }

        public async Task OnGetAsync()
        {
            Inscriere = await _context.Inscrieri
                .Include(i => i.Curs)
                .Include(i => i.Student).ToListAsync();
        }
    }
}
