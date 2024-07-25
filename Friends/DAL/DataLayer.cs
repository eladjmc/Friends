using Friends.Models;
using Microsoft.EntityFrameworkCore;

namespace Friends.DAL
{
    public class DataLayer : DbContext
    {
        public DataLayer(string ConnectionString) : base(GetOptions(ConnectionString))
        {
            Database.EnsureCreated();
            Seed();
        }
        private void Seed()
        {
            if (Friends.Any()) return;
            Friend friend = new Friend { FirstName = "בני", LastName = "גולשטיין", Email = "jerbimatan@gmail.com", Phone = "054-856-1556" };
            Friends.Add(friend);
            SaveChanges();
        }
        private static  DbContextOptions GetOptions(string ConnectionString)
        {
            return new DbContextOptionsBuilder().UseSqlServer(ConnectionString).Options;
        }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}
