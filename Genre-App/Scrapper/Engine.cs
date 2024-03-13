using HtmlAgilityPack;
using Microsoft.AspNetCore.Http.Features;
class Engine
{
    public Engine()
    {
        
    }



    public HtmlDocument configureEngine(string url){

        var web = new HtmlWeb();
        var webDocument = web.Load(url);
        return webDocument;
       
    }

    public List<string> QueryData(HtmlDocument document){
            //get list of nodes
            var genreList = document.DocumentNode.QuerySelectorAll("ul li")
            .Skip(11).Take(20)
            .Select(x => x.InnerText)
            .ToList();
            return genreList;
            
    }
}