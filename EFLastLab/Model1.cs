namespace EFLastLab
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EFLastLab.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public Model1()
            : base("name=Model1")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        //public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserVisits> UserVisits { get; set; }
        public virtual DbSet<Department> department { get; set; }
        public virtual DbSet<Employee> employees { get; set; }
        public virtual DbSet<Book> books { get; set; }
        public virtual DbSet<President> president { get; set; }
        public virtual DbSet<University> university { get; set; }
        public virtual DbSet<Cover> cover { get; set; }
        //public virtual DbSet<Person> person { get; set; }
        public virtual DbSet<Home> home { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                  .ToTable("Department")
                  .HasKey(d => d.Id)
                  .Property(d => d.Name)
                  .IsRequired()
                  .HasMaxLength(50);
            modelBuilder.Entity<Employee>()
                .ToTable("Employee")
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.loe)
                .WithRequired(e => e.department)
                .HasForeignKey(e => e.Fk_Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.employees)
                .WithMany(e => e.books)
                .Map(e => e.ToTable("Employee_Books")
                .MapLeftKey("Fk_book").MapRightKey("FK_employee"));

            modelBuilder.Entity<University>()
                .HasOptional(u => u.president)
                .WithRequired(p => p.university);
            modelBuilder.Entity<Cover>()
                .HasRequired(c => c.book)
                .WithRequiredDependent(b => b.cover);


        }



    }
      

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}