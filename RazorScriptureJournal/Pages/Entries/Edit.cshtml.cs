using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorScriptureJournal.Data;
using RazorScriptureJournal.Models;

namespace RazorScriptureJournal.Pages.Entries
{
    public class EditModel : PageModel
    {
        private readonly RazorScriptureJournal.Data.RazorScriptureJournalContext _context;

        public EditModel(RazorScriptureJournal.Data.RazorScriptureJournalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ScriptureEntry ScriptureEntry { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ScriptureEntry == null)
            {
                return NotFound();
            }

            var scriptureentry =  await _context.ScriptureEntry.FirstOrDefaultAsync(m => m.Id == id);
            if (scriptureentry == null)
            {
                return NotFound();
            }
            ScriptureEntry = scriptureentry;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ScriptureEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScriptureEntryExists(ScriptureEntry.Id))
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

        private bool ScriptureEntryExists(int id)
        {
          return (_context.ScriptureEntry?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
