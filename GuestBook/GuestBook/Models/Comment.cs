using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestBook.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [DisplayName("Name")]
        [Required(ErrorMessage ="This field is required")]
        [RegularExpression("^[A-Za-z ]+$" ,ErrorMessage = "The name must contains only letters")]
        [MinLength(5, ErrorMessage = "Minimum 5 characters")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [DisplayName("Email")]
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Wrong email format")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Description")]
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters only")]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
