using System.Data.Entity.ModelConfiguration;
using Ks.Models;

namespace Ks.Repository.Models.Mapping
{
    public partial class UserMap : EntityTypeConfiguration<Users>
    {
        public UserMap()
        {
            // table
            ToTable("Users", "dbo");

            // keys
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName("Id")
                .IsRequired();
            Property(t => t.Account)
                .HasColumnName("Account")
                .HasMaxLength(255)
                .IsRequired();
            Property(t => t.Password)
                .HasColumnName("Password")
                .HasMaxLength(255)
                .IsRequired();
            Property(t => t.Name)
                .HasColumnName("Name")
                .HasMaxLength(255)
                .IsRequired();
            Property(t => t.Sex)
                .HasColumnName("Sex")
                .IsRequired();
            Property(t => t.Status)
                .HasColumnName("Status")
                .IsRequired();
            Property(t => t.Type)
                .HasColumnName("Type")
                .IsRequired();
            Property(t => t.CreateTime)
                .HasColumnName("CreateTime")
                .IsRequired();
            Property(t => t.CreateId)
                .HasColumnName("CreateId")
                .IsOptional();
        }
    }
}