using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

using System.Windows.Forms;

namespace Examen_GUI
{
    class Gifts
    {
        //web scraper for images 
        private Nouns get_nouns = new Nouns();
        // Get images of gifts
        public List<string> list_gift(List<string> mylist)
        {
            //get  textBox1 and applay Check_Nouns() to get the important nouns
            TextBox mystr = Application.OpenForms["Form1"].Controls["textBox1"] as TextBox;
            //join the  returned list of nouns
            string link_rest = string.Join(" ", get_nouns.Check_Nouns(mystr.Text));


            // HtmlDocument it is a . NET code library that allows you to parse “out of the web” files (be it HTML, PHP or aspx)

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb web = new HtmlWeb();



            doc = web.Load("https://www.bol.com/be/nl/s/?searchtext=" + link_rest+ " gifts");

            /*
            var Rows = doc.DocumentNode.Descendants("span")
           .Where(node => node.GetAttributeValue("class", "").Equals("a-size-base-plus a-color-base a-text-normal"))
           .ToList();

            *///Get Attribute Value of images through nodes
            var Rows2 = doc.DocumentNode.SelectNodes("//div//img")
           .Select(node => node.GetAttributeValue("src", ""))
           .ToList();



            /*
               foreach (var item in Rows2)
               {
                   mylist.Add(Rows[i].InnerText.Trim());
               }
               */
            //add to list
            foreach (var item in Rows2)
            {
                if (item!="")
                {
                    mylist.Add(item);
                }
                
            }
          



            //System.Threading.Thread.Sleep(5);
            return mylist;
        }

        

       
    }
}
