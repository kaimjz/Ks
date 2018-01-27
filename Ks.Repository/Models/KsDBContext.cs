using System.Data.Entity;
using Ks.Models;

namespace Ks.Repository.Models
{
    public partial class KsDBContext : DbContext
    {
        public KsDBContext() : base("name=ConnectionString")
        {
        }

        static KsDBContext()
        {
            //策略一：数据库不存在时重新创建数据库
            //Database.SetInitializer(new CreateDatabaseIfNotExists<KsDBContext>());

            //策略二：每次启动应用程序时创建数据库
            //Database.SetInitializer(new DropCreateDatabaseAlways<KsDBContext>());

            //策略三：模型更改时重新创建数据库
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<KsDBContext>());

            //策略四：从不创建数据库
            Database.SetInitializer<KsDBContext>(null);
        }

        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new UserMap());
        }
    }
}