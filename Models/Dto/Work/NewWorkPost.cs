public class NewWorkPost
{
    public string? Title { get; set; }
    public string? Discription { get; set; }
    public string? body { get; set; }
    public List<string>? images { get; set; }
    public string? mainImg { get; set; }
    public string? footer { get; set; }

    public List<int>? CategoriesId { get; set; }

    public bool isNullOrEmpty()
    {
        bool result = false;

        if(String.IsNullOrEmpty(Title)) result = true;
        if(String.IsNullOrEmpty(Discription)) result = true;
        if(String.IsNullOrEmpty(body)) result = true;
        if(images?.Count == 0) result = true;
        if(String.IsNullOrEmpty(mainImg)) result = true;
        if(String.IsNullOrEmpty(footer)) result = true;

        return result;
    }
}