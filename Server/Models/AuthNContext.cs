using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Server.Models;

public partial class AuthNContext : DbContext
{
    public AuthNContext()
    {
    }

    public AuthNContext(DbContextOptions<AuthNContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=AuthN;TrustServerCertificate=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.ToTable("Application");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.IsPkceenabled).HasColumnName("IsPKCEEnabled");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
