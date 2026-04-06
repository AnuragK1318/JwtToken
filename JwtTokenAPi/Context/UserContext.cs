using JwtTokenAPi.Domain;
using Microsoft.EntityFrameworkCore;

namespace JwtTokenAPi.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        { }  
        
        public DbSet<User> Users { get; set; }
    }
}
