public class Pubdo
{
    static public string SlideMaker(List<string> images)
    {
        string result = "";
        foreach (string img in images)
        {
            result += $@"<div class=""swiper-slide"">
    <div class=""img-item"">
        <figure><img decoding=""async""
                src=""{img}""
                alt=""""></figure>
    </div>
</div>";
        }
        return result;
    }
}