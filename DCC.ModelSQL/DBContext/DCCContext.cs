using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DCC.ModelSQL.Models
{
    public partial class DCCContext : DbContext
    {
        public DCCContext()
        {

        }

        public DCCContext(DbContextOptions<DCCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DccFolder> DccFolders { get; set; }
        public virtual DbSet<DccFolderDetail> DccFolderDetails { get; set; }
        public virtual DbSet<DccOnGoingOld> DccOnGoingOlds { get; set; }
        public virtual DbSet<DccProject> DccProjects { get; set; }
        public virtual DbSet<DccProjectFolder> DccProjectFolders { get; set; }
        public virtual DbSet<DccinComing> DccinComings { get; set; }
        public virtual DbSet<DcconGoing> DcconGoings { get; set; }
        public virtual DbSet<DocInfo> DocInfos { get; set; }
        public virtual DbSet<EmpHistory> EmpHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DccFolder>(entity =>
            {
                entity.ToTable("DCC-Folders");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FolderName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DccFolderDetail>(entity =>
            {
                entity.ToTable("DCC-FolderDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FolderId).HasColumnName("FolderID");

                entity.Property(e => e.Route)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.DccFolderDetails)
                    .HasForeignKey(d => d.FolderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DCC-FolderDetails_DCC-Folders");
            });

            modelBuilder.Entity<DccOnGoingOld>(entity =>
            {
                entity.ToTable("DCC-OnGoing-old");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.CorresType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.FileNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Orign)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reference).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.Subject).IsUnicode(false);

                entity.Property(e => e.Typist).IsUnicode(false);
            });

            modelBuilder.Entity<DccProject>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("DCC-Projects");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Abbr)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DccProjectFolder>(entity =>
            {
                entity.ToTable("DCC-ProjectFolder");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FolderId).HasColumnName("FolderID");

                entity.Property(e => e.ProjectCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.DccProjectFolders)
                    .HasForeignKey(d => d.FolderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DCC-ProjectFolder_DCC-Folders");

                entity.HasOne(d => d.ProjectCodeNavigation)
                    .WithMany(p => p.DccProjectFolders)
                    .HasForeignKey(d => d.ProjectCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DCC-ProjectFolder_DCC-Projects");
            });

            modelBuilder.Entity<DccinComing>(entity =>
            {
                entity.ToTable("DCCInComing");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Distribution).HasMaxLength(255);

                entity.Property(e => e.FileRef).HasMaxLength(255);

                entity.Property(e => e.From).HasMaxLength(255);

                entity.Property(e => e.Keyword).HasMaxLength(255);

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .HasColumnName("path");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Reference).HasMaxLength(255);

                entity.Property(e => e.Remarks).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(255);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DcconGoing>(entity =>
            {
                entity.ToTable("DCCOnGoing");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.CorresType).HasMaxLength(255);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FileNo).HasMaxLength(255);

                entity.Property(e => e.Orign).HasMaxLength(255);

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .HasColumnName("path");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Reference).HasMaxLength(255);

                entity.Property(e => e.Remarks).HasMaxLength(255);

                entity.Property(e => e.Subject)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Typist).HasMaxLength(255);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DocInfo>(entity =>
            {
                entity.ToTable("DocInfo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DocCode)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Project)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmpHistory>(entity =>
            {
                entity.ToTable("EmpHistory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EmpCode).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Path).HasMaxLength(255);

                entity.Property(e => e.Project).HasMaxLength(255);

                entity.Property(e => e.Remarks).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
