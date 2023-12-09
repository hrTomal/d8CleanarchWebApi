using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace webapibroilerplate.Configurations.DBConnection
{
    public class PGSQLDBContext : IdentityDbContext
    {
        public PGSQLDBContext(DbContextOptions<PGSQLDBContext> options) : base(options)
        {
        }
    }
}
