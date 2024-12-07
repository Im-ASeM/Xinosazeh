using System.ComponentModel.DataAnnotations;

public class blogComment
{
    [Key]
    public int Id { get; set; }
    public string Profile { get; set; }
    public string Username { get; set; }
    public string Text { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsActive { get; set; }

    public int BlogPostId { get; set; }
    public blogPost BlogPost { get; set; }
}