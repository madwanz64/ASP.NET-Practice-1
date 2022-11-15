using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Practice_1.Models
{
    public class Homework
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        [Range(minimum: 0, maximum:100, ErrorMessage = "Input untuk {0} harus berada di antara {1} dan {2}")]
        public int Score { get; set; }
    }
}
