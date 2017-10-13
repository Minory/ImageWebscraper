using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebScraper.Services;

namespace WebScraper.Web.Controllers.API
{
    [RoutePrefix("api/scrape")]
    public class ScrapeApiController : ApiController
    {
        ScrapeService scrapeService = new ScrapeService();

        //GET method scrapes target website based on keyword string
        [Route("{keyword}"), HttpGet]
        public HttpResponseMessage GetById(string keyword)
        {
            List<string> response = new List<string>();
            response = scrapeService.Scrape(keyword);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        //POST method enters list of image links based on keyword
        [Route("{keyword}"), HttpPost]
        public HttpResponseMessage PostByKeyword(string keyword)
        {
            List<string> response = new List<string>();
            response = scrapeService.InsertKeyword(keyword);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}