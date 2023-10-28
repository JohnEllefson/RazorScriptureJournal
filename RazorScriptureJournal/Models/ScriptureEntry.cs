using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorScriptureJournal.Models
{
    public class ScriptureEntry
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string? Book { get; set; }

        [Display(Name = "Chapter/Verse")]
        public string? ChapterVerse { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [StringLength(1000, MinimumLength = 3)]
        [Required]
        public string? Notes { get; set; }
    }
}
