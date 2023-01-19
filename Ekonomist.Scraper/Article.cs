namespace Ekonomist.Scraper;

public class Article
{
    public string Title { get; set; }
    public string Url { get; set; }
    public DateTime Time { get; set; }
    public List<string> Contents { get; set; }
    public string Content { get; set; }
}