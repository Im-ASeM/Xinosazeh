public class NewWorkCat
{
    public string? WorkCatName { get; set; }

    public bool isNullOrEmpty()
    {
        bool result = false;

        if(String.IsNullOrEmpty(WorkCatName)) result = true;

        return result;
    }
}