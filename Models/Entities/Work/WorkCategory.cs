using System.ComponentModel.DataAnnotations;

public class WorkCategory
{
    [Key]
    public int Id { get; set; }
    public string WorkCatName { get; set; }
    public List<WorkPC> Subs { get; set; }
}