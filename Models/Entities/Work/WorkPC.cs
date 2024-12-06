using System.ComponentModel.DataAnnotations;

public class WorkPC
{
    [Key]
    public int Id { get; set; }
    
    public int WorkCatId { get; set; }
    public WorkCategory WorkCat { get; set; }

    public int WorkPostId { get; set; }
    public WorkPost WorkPost { get; set; }
}