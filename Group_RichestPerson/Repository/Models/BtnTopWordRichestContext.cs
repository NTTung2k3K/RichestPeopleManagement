using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repository.Models;

public partial class BtnTopWordRichestContext : DbContext
{
    public BtnTopWordRichestContext()
    {
    }

    public BtnTopWordRichestContext(DbContextOptions<BtnTopWordRichestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Industry> Industries { get; set; }

    public virtual DbSet<RichestPerson> RichestPeople { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		 => optionsBuilder.UseSqlServer(GetConnectionString());

	private string GetConnectionString()
	{
		IConfiguration config = new ConfigurationBuilder()
			 .SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json", true, true)
					.Build();
		var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];

		return strConn;
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Country__10D1609FA7D9A727");

            entity.ToTable("Country");

            entity.Property(e => e.CountryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Industry>(entity =>
        {
            entity.HasKey(e => e.IndustryId).HasName("PK__Industry__808DEDCCE87B5C04");

            entity.ToTable("Industry");

            entity.Property(e => e.IndustryName).HasMaxLength(50);
        });

        modelBuilder.Entity<RichestPerson>(entity =>
        {
            entity.HasKey(e => e.RichestPersonId).HasName("PK__RichestP__F69CD0DF4A5E6BEB");

            entity.ToTable("RichestPerson");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NetWorth).HasColumnType("decimal(16, 2)");

            entity.HasOne(d => d.Country).WithMany(p => p.RichestPeople)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__RichestPe__Count__73BA3083");

            entity.HasOne(d => d.Industry).WithMany(p => p.RichestPeople)
                .HasForeignKey(d => d.IndustryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__RichestPe__Indus__74AE54BC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
