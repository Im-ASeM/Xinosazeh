using System.Globalization;

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

    static public string BlogPostMaker(List<blogPost> posts)
    {
        string result = "";
        foreach (blogPost post in posts)
        {
            result += @$"<article id=""post-{post.Id}""
class=""post-box masonry-post-item post-102 post type-post status-publish format-standard has-post-thumbnail hentry category-interior tag-exterior tag-interior tag-trends"">
<div class=""post-inner"">

    <div class=""entry-media post-cat-abs"">
        <a href=""/blogs/details?id={post.Id}"">
            <img loading=""lazy"" width=""790"" height=""510""
                src=""{post.mainImg}""
                class=""attachment-post-thumbnail size-post-thumbnail wp-post-image""
                alt="""" decoding=""async""
                srcset=""{post.mainImg} 790w, {post.mainImg} 300w, {post.mainImg} 768w, {post.mainImg} 435w, {post.mainImg} 720w""
                sizes=""(max-width: 790px) 100vw, 790px""> </a>
        <div class=""post-cat"">
            <div class=""posted-in"">
                {(post.KeyWords != null ? BlogPostKeyWord(post.KeyWords) : "")}
            </div>
        </div>
    </div>


    <div class=""inner-post"">
        <div class=""entry-header"">

            <div class=""entry-meta"">
                <span class=""posted-on""><a
                        href=""/blogs/details?id={post.Id}""
                        rel=""bookmark""><time class=""entry-date published""
                            datetime=""{PersianDate(post.CreateDate)}"">{PersianDate(post.CreateDate)}</time></a></span><span class=""byline""><a
                        class=""url fn n"" href=""../author/theratio/index.htm"">مدیر
                        سایت</a></span><span class=""comment-num""><a
                        href=""/blogs/details?id={post.Id}#comments"">{(post.Comments != null ? post.Comments.Count : 0)}
                        دیدگاه</a></span>
            </div><!-- .entry-meta -->

            <h4 class=""entry-title""><a class=""title-link""
                    href=""/blogs/details?id={post.Id}""
                    rel=""bookmark"">{post.Title}</a>
            </h4>
        </div><!-- .entry-header -->

        <div class=""entry-summary the-excerpt"">

            <p>{post.Discription}</p>

        </div><!-- .entry-content -->
        <div class=""entry-footer"">
            <a href=""/blogs/details?id={post.Id}""
                class=""btn-details""> بیشتر بخوانید</a>
        </div>
    </div>
</div>
</article>";
        }
        return result;
    }

    static public string BlogPostKeyWord(List<string> keys)
    {
        string result = "";
        foreach (string key in keys)
        {
            result += @$"<a rel=""category tag"">{key}</a>
            ";
        }
        return result;
    }

    static public string PersianDate(DateTime date)
    {
        PersianCalendar pc = new PersianCalendar();
        return $"{pc.GetYear(date)}/{pc.GetMonth(date)}/{pc.GetDayOfMonth(date)}";
    }

    static public string BlogSideNewPosts(List<blogPost> posts)
    {
        string result = "";
        foreach (blogPost post in posts)
        {
            result += $@"<li class=""clearfix"">
<div class=""thumb"">
    <a href=""/blogs/details?id={post.Id}"">
        <img loading=""lazy"" width=""150"" height=""150""
            src=""{post.mainImg}""
            class=""attachment-thumbnail size-thumbnail wp-post-image"" alt=""""
            decoding=""async""
            srcset=""{post.mainImg} 150w, {post.mainImg} 100w""
            sizes=""(max-width: 150px) 100vw, 150px""> </a>
</div>
<div class=""entry-header"">
    <h6>
        <a href=""/blogs/details?id={post.Id}"">{post.Title}</a>
    </h6>
    <span class=""post-on"">
        <span class=""entry-date"">{PersianDate(post.CreateDate)}</span>
    </span>
</div>
</li>";
        }
        return result;
    }

    static public string BlogDetailPicture(List<string> images)
    {
        string result = "";
        foreach (string img in images)
        {
            result += $@"<figure class='gallery-item'>
    <div class='gallery-icon landscape'>
        <img loading=""lazy"" decoding=""async""
            width=""421"" height=""360""
            src=""{img}""
            class=""attachment-full size-full""
            alt=""""
            srcset=""{img} 421w, {img} 300w""
            sizes=""(max-width: 421px) 100vw, 421px"">
    </div>
</figure>"
;
        }
        return result;
    }
    static public string BlogDetailFooterPosts(List<blogPost> posts)
    {
        string result = "";
        foreach (blogPost post in posts)
        {
            result += @$"<div class=""col-sm-6"">
<div class=""post-box post-item"">
    <div class=""post-inner"">
        <div class=""entry-media post-cat-abs"">
            <a
                href=""/blogs/details?id={post.Id}""><img
                    width=""790"" height=""510""
                    src=""{post.mainImg}""
                    class=""attachment-theratio-grid-post-thumbnail size-theratio-grid-post-thumbnail wp-post-image""
                    alt="""" decoding=""async""
                    srcset=""{post.mainImg} 790w, {post.mainImg} 300w,{post.mainImg} 768w, {post.mainImg} 435w, {post.mainImg} 720w""
                    sizes=""(max-width: 790px) 100vw, 790px""></a>
            <div class=""post-cat"">
                <div class=""posted-in"">
                {BlogPostKeyWord(post.KeyWords)}
                </div>
            </div>
        </div>
        <div class=""inner-post"">
            <div class=""entry-header"">

                <div class=""entry-meta"">
                    <span class=""posted-on""><a
                            href=""/blogs/details?id={post.Id}""
                            rel=""bookmark""><time
                                class=""entry-date published""
                                datetime=""{PersianDate(post.CreateDate)}"">{PersianDate(post.CreateDate)}</time></a></span><span
                        class=""byline""><span class=""author vcard""><a
                                class=""url fn n"">مدیر
                                سایت</a></span></span>
                </div><!-- .entry-meta -->

                <h5 class=""entry-title""><a class=""title-link""
                        href=""../use-pastel-colors-natural-materials/index.htm""
                        rel=""bookmark"">{post.Title}</h5>
            </div><!-- .entry-header -->

            <div class=""the-excerpt"">
                {GetShortDescription(post.Discription, 40)}
            </div><!-- .entry-content -->
        </div>
    </div>
</div>
</div>";
        }
        return result;
    }
    public static string GetShortDescription(string description, int maxLength)
    {
        if (description.Length > maxLength)
        {
            return description.Substring(0, maxLength) + "...";
        }
        else
        {
            return description;
        }
    }

    public static string PageMaker(int PageNumber, int AllPage, string url)
    {
        string result = "";
        if (PageNumber > 1)
        {
            result += $@"<li><a class=""perv page-numbers""
                                href=""{url}{PageNumber - 1}"">
                                <i class=""ot-flaticon-right-arrow""></i></a>
                        </li>
                        <li><a class=""page-numbers""
                                href=""{url}{PageNumber - 1}"">{PageNumber - 1}</a>
                        </li>
                        ";
        }
        result += $@"<li>
                        <a aria-current=""page"" class=""page-numbers current"">{PageNumber}</a>
                    </li>
                    ";
        if (PageNumber <= AllPage -1)
        {
            result += $@"<li><a class=""page-numbers""
                                href=""{url}{PageNumber + 1}"">{PageNumber + 1}</a></li>
                        <li><a class=""next page-numbers""
                                href=""{url}{PageNumber + 1}""><i
                                    class=""ot-flaticon-right-arrow""></i></a>
                        </li>
                        ";
        }
        return result;
    }
}