using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorScriptureJournal.Data;
using RazorScriptureJournal.Models;

namespace RazorScriptureJournal.Pages.Entries
{
    public class DetailsModel : PageModel
    {
        private readonly RazorScriptureJournal.Data.RazorScriptureJournalContext _context;

        public DetailsModel(RazorScriptureJournal.Data.RazorScriptureJournalContext context)
        {
            _context = context;
        }

      public ScriptureEntry ScriptureEntry { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ScriptureEntry == null)
            {
                return NotFound();
            }

            var scriptureentry = await _context.ScriptureEntry.FirstOrDefaultAsync(m => m.Id == id);
            if (scriptureentry == null)
            {
                return NotFound();
            }
            else 
            {
                ScriptureEntry = scriptureentry;
            }
            return Page();
        }
    }
}
