namespace Blog.Core.Entities;

public class Post
{
    public int Id { get; set; } = 0;
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    public DateTime LastUpdateDate { get; set; } = DateTime.UtcNow;
    public Category Category { get; set; } = new();
    public User Author { get; set; } = new();
    public List<Tag> Tags { get; set; } = new();
}