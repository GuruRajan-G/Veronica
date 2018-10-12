using System.Data.Entity;

namespace Veronica.DAL
{
    public partial class EfContext : DbContext
    {
        static EfContext()
        {
            Database.SetInitializer<EfContext>(null);

        }

        //public EfContext()
        //    : base("Name=LOUSISWTS103")
        //{
        //    this.Configuration.ProxyCreationEnabled = false;
        //    this.Configuration.LazyLoadingEnabled = true;
        //}

        public EfContext(string sConnectionString)
            : base(sConnectionString)
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }
}
