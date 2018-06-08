using System.Data.Entity;

namespace TestTask.Web.Models
{
    public class TestTaskContext : DbContext
    {
        public TestTaskContext() : base("name=TestTask")
        {
        }

        static TestTaskContext()
        {
            Database.SetInitializer(new TestTaskContextInitializer());
        }

        public virtual DbSet<Folder> Folders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>()
                .HasOptional(g => g.Parent)
                .WithMany(s => s.Childrens);
        }
    }
}
