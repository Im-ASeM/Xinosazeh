using Microsoft.AspNetCore.Http.HttpResults;

public class NewWorkPost
{
    public string? Title { get; set; }
    public string? Discription { get; set; }
    public string? body { get; set; }
    public List<IFormFile>? images { get; set; }
    public IFormFile? mainImg { get; set; }

    public string? CategoriesIdString { get; set; }
    public List<int>? CategoriesId { get; set; }

    public bool isNullOrEmpty()
    {
        bool result = false;

        if (String.IsNullOrEmpty(Title)) result = true;
        if (String.IsNullOrEmpty(Discription)) result = true;
        if (String.IsNullOrEmpty(body)) result = true;
        if (images?.Count == 0) result = true;
        if (mainImg == null) result = true;
        if (CategoriesId.Count == 0) result = true;

        return result;
    }
    public bool CanConvertToInt()
    {
        if (!string.IsNullOrWhiteSpace(CategoriesIdString))
        {
            CategoriesId = CategoriesIdString.Split(',')
                                 .Select(id => int.TryParse(id.Trim(), out int result) ? result : (int?)null)
                                 .Where(id => id.HasValue)
                                 .Select(id => id.Value)
                                 .ToList();
            return true;
        }
        else
        {
            CategoriesId = new List<int>();
            return false;
        }
    }
}