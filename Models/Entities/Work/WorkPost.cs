using System.ComponentModel.DataAnnotations;

public class WorkPost
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Discription { get; set; }
    public string body { get; set; }
    public List<string> images { get; set; }
    public string mainImg { get; set; }
    public string footer { get; set; }
    
    public List<WorkPC> Categories { get; set; }
}