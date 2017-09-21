using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Models.Domain
{
    public class Images
    {
        public int Id { get; set; }
        public string Keyword { get; set; }
        public List<string> ImageList { get; set; }
    }
}
