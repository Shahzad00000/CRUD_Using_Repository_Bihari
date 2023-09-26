using System.ComponentModel.DataAnnotations;

namespace CRUD_Using_Repository_Bihari.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage ="Please Enter Name")]
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        [Display(Name ="Pin Code")]
        public int  PinCode { get; set; }
        [Display(Name ="Active")]
        public bool IsActive { get; set; }
    }
}
