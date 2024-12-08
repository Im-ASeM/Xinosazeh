using Microsoft.AspNetCore.Http.HttpResults;

public class NewBlogPost
{
    public string? Title { get; set; }
    public string? Discription { get; set; }
    public string? body { get; set; }
    public List<IFormFile>? images { get; set; }
    public required IFormFile mainImg { get; set; }

    public string? StringKeyWords { get; set; }
    public List<string>? KeyWords { get; set; }

    public bool isNullOrEmpty()
    {
        bool result = false;

        if (String.IsNullOrEmpty(Title)) result = true;
        if (String.IsNullOrEmpty(Discription)) result = true;
        if (String.IsNullOrEmpty(body)) result = true;
        if (images?.Count == 0) result = true;
        if (mainImg == null) result = true;
        if (KeyWords?.Count == 0) result = true;

        return result;
    }
    public bool HaveKeyWords()
    {
        if (!string.IsNullOrWhiteSpace(StringKeyWords))
        {
            KeyWords = StringKeyWords.Split(',').ToList();
            return true;
        }
        else
        {
            KeyWords = [];
            return false;
        }
    }
}