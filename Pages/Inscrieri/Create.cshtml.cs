﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AplicatieManagementStudenti.Data;
using AplicatieManagementStudenti.Models;

namespace AplicatieManagementStudenti.Pages.Inscrieri
{
    public class CreateModel : PageModel
    {
        private readonly AplicatieManagementStudenti.Data.SchoolContext _context;

        public CreateModel(AplicatieManagementStudenti.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CursID"] = new SelectList(_context.Cursuri, "CursID", "CursID");
        ViewData["StudentID"] = new SelectList(_context.Studenti, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Inscriere Inscriere { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Inscrieri.Add(Inscriere);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
