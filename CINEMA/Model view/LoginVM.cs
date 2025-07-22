using System.ComponentModel.DataAnnotations;

namespace CINEMA.Model_view
{
    public class LoginVM
    {
        public int Id { get; set; }
        [Required]
        public String EmailOrUserName { get; set; } = string.Empty;
        [Required,DataType(DataType.Password)]
        public string Password { get; set; } = String.Empty;
        public bool RememberMe { get; set; }
    }
}
