using Microsoft.AspNet.Identity.EntityFramework;
using SimpleWebAPI.API.Identity;
using System.Data.Entity;

namespace SimpleWebAPI.API.Identity
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext()
            : base("MyConnection", throwIfV1Schema: false)
        {
        }

        public static IdentityContext Create()
        {
            IdentityContext contexto = new IdentityContext();
            return contexto;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}