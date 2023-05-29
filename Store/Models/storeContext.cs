using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoreASP.Models
{
    public partial class storeContext : DbContext
    {
        public storeContext()
        {
        }

        public storeContext(DbContextOptions<storeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Mark> Marks { get; set; } = null!;
        public virtual DbSet<Postavka> Postavkas { get; set; } = null!;
        public virtual DbSet<PostavkaProduct> PostavkaProducts { get; set; } = null!;
        public virtual DbSet<Pprovider> Pproviders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductSale> ProductSales { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ZENBOOK;Database=store;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK__category__4E840CE509F2D20D");

                entity.ToTable("category");

                entity.Property(e => e.IdCategory)
                    .HasColumnName("Id_category");

                entity.Property(e => e.NazvanieCategory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nazvanie_category");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PK__client__8829B11EDC3CF724");

                entity.ToTable("client");

                entity.Property(e => e.IdClient)
                    .HasColumnName("Id_client");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FioClient)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("FIO_client");

                entity.Property(e => e.Number);
            });

           

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.HasKey(e => e.IdMark)
                    .HasName("PK__mark__A7D6346637B4CB52");

                entity.ToTable("mark");

                entity.Property(e => e.IdMark)
                    .HasColumnName("Id_mark");

                entity.Property(e => e.NazvanieMark)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nazvanie_mark");
            });

            modelBuilder.Entity<Postavka>(entity =>
            {
                entity.HasKey(e => e.IdPostavka)
                    .HasName("PK__postavka__6119CAF6C61C388F");

                entity.ToTable("postavka");

                entity.Property(e => e.IdPostavka)
                    .HasColumnName("Id_postavka");

                entity.Property(e => e.CostZakupki)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("Cost_zakupki");

                entity.Property(e => e.DataPostavka)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_postavka")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdProvider)
                    .HasColumnName("Id_provider");

                entity.Property(e => e.StatusPostavka)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Status_postavka");

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.Postavkas)
                    .HasForeignKey(d => d.IdProvider)
                    .HasConstraintName("pk_post");
            });

            modelBuilder.Entity<PostavkaProduct>(entity =>
            {
                entity.HasKey(e => new { e.IdPostavka, e.IdProduct })
                    .HasName("p_prod");

                entity.ToTable("postavka_product");

                entity.Property(e => e.IdPostavka)
                    .HasColumnName("Id_postavka");

                entity.Property(e => e.IdProduct)
                    .HasColumnName("Id_product");

                entity.Property(e => e.KolVo)
                    .HasColumnName("Kol_vo");

                entity.HasOne(d => d.IdPostavkaNavigation)
                    .WithMany(p => p.PostavkaProducts)
                    .HasForeignKey(d => d.IdPostavka)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("post1");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.PostavkaProducts)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("prod");
            });

            modelBuilder.Entity<Pprovider>(entity =>
            {
                entity.HasKey(e => e.IdProvider)
                    .HasName("PK__pprovide__E8B2F94BAA98B7DB");

                entity.ToTable("pprovider");

                entity.Property(e => e.IdProvider)
                    .HasColumnName("Id_provider");

                entity.Property(e => e.Adress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fio)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("FIO");

                entity.Property(e => e.Nazvanie)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Number);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__product__774C6C3F7096D4C4");

                entity.ToTable("product");

                entity.HasIndex(e => e.Imei, "UQ__product__8DF371FD259D8880")
                    
                    .IsUnique();

                entity.Property(e => e.IdProduct)
                    .HasColumnName("Id_product");

                entity.Property(e => e.CostSales)
                    .HasColumnType("numeric(20)")
                    .HasColumnName("Cost_sales");

                entity.Property(e => e.Foto).HasColumnType("text");

                entity.Property(e => e.IdCategory)
                    .HasColumnName("Id_category");

                entity.Property(e => e.IdMark)
                    .HasColumnName("Id_mark");

                entity.Property(e => e.Imei)
                    .HasColumnType("numeric(15)")
                    .HasColumnName("IMEI");

                entity.Property(e => e.NazvanieProduct)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nazvanie_product");

                entity.Property(e => e.Opisanie).HasColumnType("text");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("fk_cat");

                entity.HasOne(d => d.IdMarkNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdMark)
                    .HasConstraintName("fk_mark");
            });

            modelBuilder.Entity<ProductSale>(entity =>
            {
                entity.HasKey(e => new { e.IdProduct, e.IdSale })
                    .HasName("p_sel");

                entity.ToTable("product_sale");

                entity.Property(e => e.IdProduct)
                    .HasColumnName("Id_product");

                entity.Property(e => e.IdSale)
                    .HasColumnName("Id_sale");

                entity.Property(e => e.KolVo2)
                    .HasColumnName("Kol_vo2");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.ProductSales)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("post2");

                entity.HasOne(d => d.IdSaleNavigation)
                    .WithMany(p => p.ProductSales)
                    .HasForeignKey(d => d.IdSale)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("s_sale");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.IdSale)
                    .HasName("PK__sale__CEFA253531088212");

                entity.ToTable("sale");

                entity.Property(e => e.IdSale)
                    .HasColumnName("Id_sale");

                entity.Property(e => e.DataS)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_s");

                entity.Property(e => e.IdClient)
                    .HasColumnName("Id_client");
                
                entity.Property(e => e.Itogo).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Oplata)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("fk_client");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
