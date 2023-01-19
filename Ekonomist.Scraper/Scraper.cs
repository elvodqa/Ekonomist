namespace Ekonomist.Scraper;

using HtmlAgilityPack;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using CsvHelper;


public class Scraper
{
    public Scraper()
    {
        
    }
    
    public async Task<Article> GetHtml(string url)
    {
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = await web.LoadFromWebAsync(url);
        
        var article = new Article();
        article.Title = doc.DocumentNode.SelectSingleNode("//h1").InnerText;
        // get paragraphs in Article tag
        var articleNodes = doc.DocumentNode.SelectNodes("//article//p");
        foreach (var node in articleNodes)
        {
            article.Content += node.InnerText;
        }
        article.Contents = doc.DocumentNode.SelectNodes("//p").Select(x => x.InnerText).ToList();
        Console.WriteLine("Hello");
       
        using (var writer = new StreamWriter("./output/output.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(article.Content);
        }
        return article;
    }
}