// using Api.Data.Mapping;
// using Api.Domain.Entities;

// namespace Register.Data.Context
// {
// 	public class MyContext : DbContext
// 	{
// 		public DbSet<UserEntity> Users { get; set; }
		
// 		public MyContext(DbContextOptions options) : base(options)
// 		{

// 		}

// 	    protected override void OnModelCreating(ModelBuilder modelBuilder)
// 	    {
// 		   base.OnModelCreating(modelBuilder);
// 		   modelBuilder.Entity<UserEntity> (new UserMap().Configure);
// 	    }

// 	}
// }