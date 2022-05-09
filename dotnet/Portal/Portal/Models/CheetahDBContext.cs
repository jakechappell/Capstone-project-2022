using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Portal.Models
{
    public partial class CheetahDBContext : DbContext
    {
        public CheetahDBContext()
        {
        }

        public CheetahDBContext(DbContextOptions<CheetahDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<Endpoint> Endpoints { get; set; }
        public virtual DbSet<Parameter> Parameters { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Response> Responses { get; set; }
        public virtual DbSet<SchemaReference> SchemaReferences { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.Property(e => e.CollectionName).IsUnicode(false);
            });

            modelBuilder.Entity<Endpoint>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EditDateTime).IsUnicode(false);

                entity.Property(e => e.EditUser).IsUnicode(false);

                entity.Property(e => e.EndpointName).IsUnicode(false);

                entity.Property(e => e.Urlsuffix)
                    .IsUnicode(false)
                    .HasColumnName("URLSuffix");

                entity.HasOne(d => d.Collection)
                    .WithMany(p => p.Endpoints)
                    .HasForeignKey(d => d.CollectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Endpoints__Colle__267ABA7A");
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EditDateTime).IsUnicode(false);

                entity.Property(e => e.EditUser).IsUnicode(false);

                entity.Property(e => e.ParameterName).IsUnicode(false);

                entity.Property(e => e.Values).IsUnicode(false);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Parameters)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Parameter__Reque__48CFD27E");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasOne(d => d.Endpoint)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.EndpointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Requests__Endpoi__29572725");
            });

            modelBuilder.Entity<Response>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ExampleValue).IsUnicode(false);

                entity.HasOne(d => d.Endpoint)
                    .WithMany(p => p.Responses)
                    .HasForeignKey(d => d.EndpointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Responses__Endpo__2C3393D0");
            });

            modelBuilder.Entity<SchemaReference>(entity =>
            {
                entity.Property(e => e.Jsonstring)
                    .IsUnicode(false)
                    .HasColumnName("JSONString");

                entity.Property(e => e.SchemaReferenceName).IsUnicode(false);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.SchemaReferences)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SchemaRef__Reque__300424B4");

                entity.HasOne(d => d.Response)
                    .WithMany(p => p.SchemaReferences)
                    .HasForeignKey(d => d.ResponseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SchemaRef__Respo__2F10007B");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Token).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
