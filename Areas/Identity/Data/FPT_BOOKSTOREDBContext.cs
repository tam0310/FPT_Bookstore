using FPT_BOOKSTORE.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FPT_BOOKSTORE.Data;

public class FPT_BOOKSTOREDBContext : IdentityDbContext<FPT_BOOKSTOREUser>
{
    public FPT_BOOKSTOREDBContext(DbContextOptions<FPT_BOOKSTOREDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
