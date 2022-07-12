using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestBook.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
