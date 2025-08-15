using E_CommerceAPI.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace E_CommerceAPI.Models.Classes
{
    public class User : IdentityUser<Guid>, IEntity
    {

    }
}
