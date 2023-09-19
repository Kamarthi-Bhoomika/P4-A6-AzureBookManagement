using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AzureBookManagement.Models;

public partial class BookStoreDbContext : DbContext
{
    public BookStoreDbContext()
    {
    }

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookAuthor> BookAuthors { get; set; }

    public virtual DbSet<BookCategory> BookCategories { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:bookdb2023.database.windows.net,1433;Initial Catalog=BookStoreDb;User Id=bhoomika; Password=bhoomi@123; Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__Author__70DAFC34743BEB20");

            entity.ToTable("Author");

            entity.Property(e => e.AuthorId).ValueGeneratedNever();
            entity.Property(e => e.AuthorName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Book__3DE0C207BD964967");

            entity.ToTable("Book");

            entity.Property(e => e.BookId).ValueGeneratedNever();
            entity.Property(e => e.BookName).HasMaxLength(50);
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .HasColumnName("category");
            entity.Property(e => e.PublisherName).HasMaxLength(50);

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.Category)
                .HasConstraintName("FK__Book__category__70DDC3D8");

            entity.HasOne(d => d.PublisherNameNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.PublisherName)
                .HasConstraintName("FK__Book__PublisherN__71D1E811");
        });

        modelBuilder.Entity<BookAuthor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BookAuthor");

            entity.HasOne(d => d.Author).WithMany()
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__BookAutho__Autho__74AE54BC");

            entity.HasOne(d => d.Book).WithMany()
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__BookAutho__BookI__73BA3083");
        });

        modelBuilder.Entity<BookCategory>(entity =>
        {
            entity.HasKey(e => e.Category).HasName("PK__BookCate__F7F53CC37C8ACFCE");

            entity.ToTable("BookCategory");

            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .HasColumnName("category");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.PublisherName).HasName("PK__Publishe__5F0E2248A2B139DF");

            entity.ToTable("Publisher");

            entity.Property(e => e.PublisherName).HasMaxLength(50);
            entity.Property(e => e.Address).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
