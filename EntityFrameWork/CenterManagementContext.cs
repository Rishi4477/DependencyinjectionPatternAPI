using System;
using System.Collections.Generic;
using EntityFrameWork.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWork;

public partial class CenterManagementContext : DbContext
{
    public CenterManagementContext(DbContextOptions<CenterManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Center> Centers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Center>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Centers__3214EC077EF0E734");

            entity.Property(e => e.AreaType).HasMaxLength(50);
            entity.Property(e => e.AssemblyConstituency).HasMaxLength(100);
            entity.Property(e => e.Block).HasMaxLength(50);
            entity.Property(e => e.CentreName).HasMaxLength(100);
            entity.Property(e => e.CentreSpocname)
                .HasMaxLength(100)
                .HasColumnName("CentreSPOCName");
            entity.Property(e => e.District).HasMaxLength(50);
            entity.Property(e => e.Landmark).HasMaxLength(100);
            entity.Property(e => e.Latitude).HasMaxLength(50);
            entity.Property(e => e.Longitude).HasMaxLength(50);
            entity.Property(e => e.MonitoringAgency).HasMaxLength(50);
            entity.Property(e => e.ParliamentaryConstituency).HasMaxLength(100);
            entity.Property(e => e.PinCode).HasMaxLength(6);
            entity.Property(e => e.PoliceStation).HasMaxLength(50);
            entity.Property(e => e.PostOffice).HasMaxLength(50);
            entity.Property(e => e.Scheme).HasMaxLength(50);
            entity.Property(e => e.Spocemail)
                .HasMaxLength(100)
                .HasColumnName("SPOCEmail");
            entity.Property(e => e.SpocmobileNo)
                .HasMaxLength(10)
                .HasColumnName("SPOCMobileNo");
            entity.Property(e => e.SponsoredAgency).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.SubScheme).HasMaxLength(50);
            entity.Property(e => e.Village).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
