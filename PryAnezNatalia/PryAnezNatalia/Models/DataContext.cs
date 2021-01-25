namespace PryAnezNatalia.Models
{
    using System.Data.Entity;
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<PryAnezNatalia.Models.Test> Tests { get; set; }

        public System.Data.Entity.DbSet<PryAnezNatalia.Models.Geo> Geos { get; set; }

        public System.Data.Entity.DbSet<PryAnezNatalia.Models.Address> Addresses { get; set; }

        public System.Data.Entity.DbSet<PryAnezNatalia.Models.Company> Companies { get; set; }
    }
}