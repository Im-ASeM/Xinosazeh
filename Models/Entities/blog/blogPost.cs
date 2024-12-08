using System.ComponentModel.DataAnnotations;

public class blogPost
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Discription { get; set; }
    public string body { get; set; }
    public List<string> images { get; set; }
    public string mainImg { get; set; }
    public List<string> KeyWords { get; set; }

    public List<blogComment> Comments { get; set; }
    public DateTime CreateDate { get; set; }
}