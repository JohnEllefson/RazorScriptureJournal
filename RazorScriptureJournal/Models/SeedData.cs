using Microsoft.EntityFrameworkCore;
using RazorScriptureJournal.Data;

namespace RazorScriptureJournal.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorScriptureJournalContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorScriptureJournalContext>>()))
        {
            if (context == null || context.ScriptureEntry == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.ScriptureEntry.Any())
            {
                return;   // DB has been seeded
            }

            context.ScriptureEntry.AddRange(
                new ScriptureEntry
                {
                    Book = "2 Nephi",
                    ChapterVerse = "1:15",
                    Date = DateTime.Parse("2023-2-23"),
                    Notes = "Need to remember this one."
                },

                new ScriptureEntry
                {
                    Book = "Alma",
                    ChapterVerse = "7:11-12",
                    Date = DateTime.Parse("2022-4-21"),
                    Notes = "I love Alma's teachings!"
                },

                new ScriptureEntry
                {
                    Book = "Mosiah",
                    ChapterVerse = "2:17",
                    Date = DateTime.Parse("2023-3-14"),
                    Notes = "Pray about this."
                },

                new ScriptureEntry
                {
                    Book = "1 Nephi",
                    ChapterVerse = "10:19",
                    Date = DateTime.Parse("2023-9-26"),
                    Notes = "I should memorize this scripture."
                },

                new ScriptureEntry
                {
                    Book = "Ether",
                    ChapterVerse = "12:27",
                    Date = DateTime.Parse("2022-11-27"),
                    Notes = "Defenitly my favorite!"
                },

                new ScriptureEntry
                {
                    Book = "2 Nephi",
                    ChapterVerse = "9:51",
                    Date = DateTime.Parse("2023-1-9"),
                    Notes = "This one means a lot to me."
                }
            );
            context.SaveChanges();
        }
    }
}