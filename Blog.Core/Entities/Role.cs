namespace Blog.Core.Entities;

public class Role
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public List<User> Users { get; set; } = new();
}