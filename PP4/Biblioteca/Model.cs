using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class bibliotecaContext : DbContext
{
    public DbSet<Author> Author { get; set; }
    public DbSet<Title> Title { get; set; }
    public DbSet<Tag> Tag { get; set; }
    public DbSet<TitleTag> TitleTag { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var path = "../Data/books.db";
        optionsBuilder.UseSqlite($"Data Source={path}");
    } 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TitleTag>().ToTable("TitleTags");

        modelBuilder.Entity<Title>((entityTitle) =>
        {
            entityTitle.Property(prop => prop.TitleId).HasColumnOrder(1);
            //entityTitle.Property(prop => prop.author).HasColumnOrder(2);
            entityTitle.Property(prop => prop.TitleName).HasColumnOrder(999);
        });
        
    }
}

public class Author
{
    [NotNull]
    public int AuthorId { get; set; }
    [NotNull]
    public string AuthorName { get; set; }
    [NotNull]
    public List<Title> Titles{ get; set; } = [];
}

public class Title
{
    [NotNull]
    public int TitleId { get; set; }
    [NotNull]
    public string TitleName { get; set; }
    [NotNull]
    public Author author { get; set; }
    [NotNull]
    public List<TitleTag> TitleTags { get; set; } = [];
}

public class Tag
{
    [NotNull]
    public int TagId { get; set; }
    [NotNull]
    public string TagName { get; set; }
    [NotNull]
    public List<TitleTag> TitleTags { get; set; } = [];
}


public class TitleTag
{
    [NotNull]
    public int TitleTagId { get; set; }
    [NotNull]
    public Tag tag { get; set; }
    [NotNull]
    public Title title{ get; set; }
    
}