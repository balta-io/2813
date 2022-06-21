namespace Blog.Core.Entities;

public class Tag
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public List<Post> Posts { get; set; } = new();
}