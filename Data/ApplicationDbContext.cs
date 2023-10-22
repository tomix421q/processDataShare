using Microsoft.EntityFrameworkCore;
using processDataShare.Models;

namespace processDataShare.Data
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {



        }
        public DbSet<OpelArmrestData> OpelArmrestDatas { get; set; }
    }
}
