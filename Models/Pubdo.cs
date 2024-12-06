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
    static public string WorkCatMaker(List<WorkCategory> cats)
    {
        string result = "";
        foreach (WorkCategory cat in cats)
        {
            result += $@"<li>
    <a class=""btn-details"" href='#'
        data-filter='.category-{cat.Id}'>{cat.WorkCatName}<span
            class=""filter-count""></span></a>
</li>";
        }
        return result;
    }

    static public string WorkPostMaker(List<WorkPost> posts)
    {
        string result = "";
        foreach (WorkPost post in posts)
        {
            result += $@"<div class=""project-item {WorkPostCat(post.Categories)} "">
<div class=""projects-box"">
    <div class=""projects-thumbnail""
        data-src=""{post.mainImg}""
        data-sub-html=""{post.Title}"">
        <a
            href=""/works/details?id={post.Id}"">
            <img loading=""lazy"" decoding=""async"" width=""720""
                height=""720""
                src=""{post.mainImg}""
                class=""attachment-theratio-portfolio-thumbnail-grid size-theratio-portfolio-thumbnail-grid wp-post-image""
                alt=""""
                srcset=""{post.mainImg} 720w, https://media.tenor.com/hBV2DeZaNiUAAAAM/loading-icon.gif 150w, https://media.tenor.com/hBV2DeZaNiUAAAAM/loading-icon.gif 100w""
                sizes=""(max-width: 720px) 100vw, 720px""> </a>

        <span class=""overlay"">
            <h5>{post.Title}</h5>
            <i class=""ot-flaticon-add""></i>
        </span>
    </div>
    <div class=""portfolio-info"">
        <div class=""portfolio-info-inner"">
            <h5><a class=""title-link""
                    href=""/works/details?id={post.Id}""
                    data-src=""{post.mainImg}""
                    data-sub-html=""{post.Title}"">{post.Title}</a></h5>
            <p class=""portfolio-cates"">
                {WorkPostCatName(post.Categories)}
            </p>
        </div>
        <a class=""overlay""
            href=""/works/details?id={post.Id}""></a>
    </div>
</div>
</div>";
        }
        return result;
    }

    static private string WorkPostCat(List<WorkPC> Pcs)
    {
        string result = "";
        foreach (WorkPC pc in Pcs)
        {
            result += @$"category-{pc.WorkCatId} ";
        }
        return result;
    }
    static private string WorkPostCatName(List<WorkPC> Pcs)
    {
        string result = "";
        foreach (WorkPC pc in Pcs)
        {
            result += @$"<a>{pc.WorkCat.WorkCatName}</a>
            ";
        }
        return result;
    }
}