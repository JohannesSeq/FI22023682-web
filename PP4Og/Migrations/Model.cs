using Microsoft.EntityFrameworkCore;
public class bibliotecaContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TItleTag> TitleTags { get; set; }

    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
        var path = "../Data/books.db";
        optionsBuilder.UseSqlite($"Data Source={path}");
    }    
}

public class Author
{
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
    public List<Title> Titles{ get; set; } = [];
}

public class Title
{
    public int TitleId { get; set; }
    public string TitleName { get; set; }
    //public int AuthorId { get; set; }
    public Author author { get; set; }
    public List<TItleTag> TitleTags { get; set; } = [];
}

public class Tag
{

    public int TagId { get; set; }
    public string TagName { get; set; }
    public List<TItleTag> TitleTags { get; set; } = [];
}


public class TItleTag
{
    public int TItleTagId { get; }
    public Tag tag { get; set; }
    public Title title{ get; set; }
    
}