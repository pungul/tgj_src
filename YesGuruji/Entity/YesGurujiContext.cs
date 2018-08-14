namespace YesGuruji.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class YesGurujiContext : DbContext
    {
        public YesGurujiContext()
            : base("name=YesGurujiContext")
        {
        }

        public virtual DbSet<tblFeedBack> tblFeedBacks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
