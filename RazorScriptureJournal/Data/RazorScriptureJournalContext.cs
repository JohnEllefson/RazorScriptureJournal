using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorScriptureJournal.Models;

namespace RazorScriptureJournal.Data
{
    public class RazorScriptureJournalContext : DbContext
    {
        public RazorScriptureJournalContext (DbContextOptions<RazorScriptureJournalContext> options)
            : base(options)
        {
        }

        public DbSet<RazorScriptureJournal.Models.ScriptureEntry> ScriptureEntry { get; set; } = default!;
    }
}
