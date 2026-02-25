using Microsoft.EntityFrameworkCore;
using Src.Infra.Persistence.Model;

public class AppDbContext : DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
    public  DbSet<UserPersist> User{get;set;}

    
}