using Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DbContext;

public class HostelManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public HostelManagementIdentityDbContext(
        DbContextOptions<HostelManagementIdentityDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HostelManagementIdentityDbContext).Assembly);
    }
}
