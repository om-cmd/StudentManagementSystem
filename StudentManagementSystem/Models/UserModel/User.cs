using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models.UserModel
{
    public class User: IdentityUser
    {
        //[Key]
        //public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage ="password should be same")]
        //public string ConfirmPassword { get; set;}

        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address {  get; set; }
    }
}
