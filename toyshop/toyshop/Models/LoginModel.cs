using System.ComponentModel.DataAnnotations;

namespace toyshop.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(100, MinimumLength = 3)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn vai trò")]
        public string Role { get; set; }
    }
}
