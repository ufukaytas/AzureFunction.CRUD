using Microsoft.EntityFrameworkCore;
using CRUD.Function.Model;

namespace CRUD.Function.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){}

        public DbSet<User> Users { get; set; }
    }
}