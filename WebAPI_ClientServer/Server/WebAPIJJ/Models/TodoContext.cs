using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace WebAPIJJ.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptbionsBuilder)
        //{
        //    dbContextOptbionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        //public DbSet<TodoItem> TodoItems { get; set; } = null!;

        public DbSet<Data> Datas { get; set; } = null!;
        //public DbSet<LotItem> LotItems { get; set; } = null!;
        //public DbSet<TestProgram> TestProgramItems { get; set; } = null!;
        //public DbSet<BindDetail> BindDetailItems { get; set; } = null!;
        //public DbSet<TestBin> TestBinItems { get; set; } = null!;

        //public DbSet<string> Carriers { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<List<string>>().HasNoKey();
            //modelBuilder.Entity<BindDetail>().HasNoKey();
            //modelBuilder.Entity<TestBin>().HasNoKey();
        }
    }
}
