using System.ComponentModel.DataAnnotations;

namespace CINEMA.Model_view
{
    public class ResetPasswordVM
    {
        public int Idroperty { get; set; }
        [Required]
        public string Code { get; set; } = string.Empty;
        public string UserId { get; internal set; }
    }
}
