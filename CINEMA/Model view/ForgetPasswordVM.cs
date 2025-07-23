using System.ComponentModel.DataAnnotations;

namespace CINEMA.Model_view
{
    public class ForgetPasswordVM
    {
        public int Id { get; set; }
        [Required]
        public string EmailOrUserName { get; set; } = string.Empty;
    }
}
