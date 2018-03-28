using Microsoft.AspNetCore.Identity;

namespace TestePratico.Models
{
    public class ApplicationUser : IdentityUser
    {
        //Nova propriedade a classe ApplicationUser
        public string Name { get; internal set; }
    }
}
