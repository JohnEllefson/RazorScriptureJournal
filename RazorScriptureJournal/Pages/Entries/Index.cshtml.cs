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
    public class IndexModel : PageModel
    {
        private readonly RazorScriptureJournal.Data.RazorScriptureJournalContext _context;

        public IndexModel(RazorScriptureJournal.Data.RazorScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<ScriptureEntry> ScriptureEntry { get;set; } = default!;

        [BindProperty(SupportsGet = true)] 
        public string? NotesSearchString { get; set; }

        public SelectList? Books { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ScriptureBook { get; set; }


        public SelectList? SortOptions { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SortOption { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of books.
            IQueryable<string> bookQuery = from m in _context.ScriptureEntry
                                            orderby m.Book
                                            select m.Book;

            SortOptions = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Text = "Book", Value = "Book" },
                new SelectListItem { Text = "Date", Value = "Date" }
            }, "Value", "Text");


            var entries = from m in _context.ScriptureEntry
                         select m;

            if (!string.IsNullOrEmpty(NotesSearchString))
            {
                entries = entries.Where(s => s.Notes.Contains(NotesSearchString));
            }

            if (!string.IsNullOrEmpty(ScriptureBook))
            {
                entries = entries.Where(x => x.Book == ScriptureBook);
            }


            if (SortOption == "Book")
            {
                entries = entries.OrderBy(x => x.Book);
            }
            else if (SortOption == "Date")
            {
                entries = entries.OrderBy(x => x.Date);
            }

            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            ScriptureEntry = await entries.ToListAsync();
        }
    }
}
