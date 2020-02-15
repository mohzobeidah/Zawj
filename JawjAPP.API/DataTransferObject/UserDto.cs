using System.ComponentModel.DataAnnotations;

namespace JawjAPP.API.DataTransferObject
{
    public class UserDto
    {
        [Required(ErrorMessage="هذا العنصر مطلوب")]
        public string username { get; set; }
        [StringLength(8 , MinimumLength=4,ErrorMessage="لايقل عن اربع ولا يزيد عن 8")]    
        public string password { get; set; }
    }
    public class UserForLoginDTO{

       [Required(ErrorMessage="هذا العنصر مطلوب")]
        public string username { get; set; }
        [StringLength(8 , MinimumLength=4,ErrorMessage="لايقل عن اربع ولا يزيد عن 8")]    
        public string password { get; set; }
    }
}