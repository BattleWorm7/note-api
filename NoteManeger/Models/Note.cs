using Microsoft.VisualBasic;

namespace NoteManeger.Models
{
    public class Note
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
