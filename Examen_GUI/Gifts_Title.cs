using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Windows.Forms;


namespace Examen_GUI
{
    class Gifts_Title
    {
        //web scraper for Gifts titles
        private Nouns get_nouns = new Nouns();

   
        public List<string> Titlegift(List<string> gifts_Title)
        {//get  textBox1 and applay Check_Nouns() to get the important nouns
            TextBox mystr = Application.OpenForms["Form1"].Controls["textBox1"] as TextBox;
            //join the  returned list of nouns
            string link_rest = string.Join(" ", get_nouns.Check_Nouns(mystr.Text));



            // HtmlDocument it is a . NET code library that allows you to parse “out of the web” files (be it HTML, PHP or aspx)
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb web = new HtmlWeb();



            doc = web.Load("https://www.bol.com/be/nl/s/?searchtext="+ link_rest+" gifts");

            //Get Attribute Value by class
            var Rows = doc.DocumentNode.Descendants("a")
                  .Where(node => node.GetAttributeValue("class", "").Equals("product-title px_list_page_product_click")).ToList();



            foreach (var item in Rows)
            {
                gifts_Title.Add(item.InnerText.Trim());
            }
            


            //System.Threading.Thread.Sleep(5);
            return gifts_Title;
        }
    }
}
