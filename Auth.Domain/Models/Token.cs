
namespace Auth.Domain.Models
{
    public class Token
    {
        public int Id { get; set; }

        public string? TokenData { get; set; }

        public DateTime ExpiredAt { get; set; }

        public User? User { get; set; }

    }
}
