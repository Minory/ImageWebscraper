using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebScraper.Services
{
    public class ScrapeService
    {
        public List<string> InsertKeyword(string keyword)
        {
            int id = 0;
            List<string> list = new List<string>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Keyword_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Keyword", keyword);

                    SqlParameter parm = new SqlParameter("@Id", SqlDbType.Int);
                    parm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);

                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@Id"].Value;
                }

                list = Scrape(keyword);
                //List from this webpage only shows images for first 15, so loop set this way
                for (var i = 0; i < 16; i++)
                {
                    using (SqlCommand cmd = new SqlCommand("Images_Insert", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@KeyId", id);
                        cmd.Parameters.AddWithValue("@Image", list[i]);

                        cmd.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }
            return list;
        }

        public List<string> Scrape(string keyword)
        {
            var document = new HtmlWeb().Load("https://pixabay.com/en/photos/" + keyword);
            var urls = document.DocumentNode.Descendants("img")
                                            .Select(e => e.GetAttributeValue("src", null))
                                            .Where(s => !String.IsNullOrEmpty(s));
            List<string> list = urls.ToList();
            List<string> newList = new List<string>();
            for(var i=0; i < 16; i++)
            {
                newList.Add(list[i]);
            }
            return newList;
        }

    }
}
