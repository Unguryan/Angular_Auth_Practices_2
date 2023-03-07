using System.ComponentModel.DataAnnotations;

namespace Auth.EF_Core.Dbo
{
    public class UserDbo
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? PasswordHash { get; set; }

    }
}
