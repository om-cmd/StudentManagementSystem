using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.ViewModels
{
    public class LoginViewModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
