using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course.Models
{
    public class Lessons
    {
        public int id { get; set; }
        public int subject_id { get; set; }
        public DateTime date { get; set; }
    }
}
