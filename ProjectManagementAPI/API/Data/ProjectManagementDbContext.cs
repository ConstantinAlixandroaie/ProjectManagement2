using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPI.Data
{
    public class ProjectManagementDbContext:DbContext
    {
        public ProjectManagementDbContext([NotNull] DbContextOptions options):base(options)
        {
        }
        public DbSet<CheckList> CheckLists { get; set; }
        public DbSet<CheckListItem> CheckListItems { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
