using System.Diagnostics.CodeAnalysis;

namespace FPTeeth_BE.Dtos
{
    public class LoginDto
    {
        [NotNull]
        public string Email { get; set; }
        [NotNull]
        public string Password { get; set; }
    }
}
