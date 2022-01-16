using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Examen_GUI
{
    class Nouns
    {//Check nouns to To improve searches and identify the most important names//
        
     
        public List<string> Check_Nouns(string word)
        {
            Check check_words = new Check();

            /////////////////

            check_words.ReadData("TEST_Sample.txt");

            
            //////////////////
            List<string> result = word.Split(' ').ToList();
            string get_value_PV = check_words.Classify(word);
            //keep the first word te use it if the input has negative word
            string first_noun = result[0];
            result.Remove(result[0]);

         

            //I don't like this color 
            //he hates cars 
            //read My_list.txt -> nouns DB
            string[] lines = System.IO.File.ReadAllLines("My_list.txt");
            //N-Verbs.txt contains negative words
            string[] lines_negative = System.IO.File.ReadAllLines("N-Verbs.txt");
            List<string> nouns = new List<string>();
            int count = 0;
            //Extar check after the check of the AI to improve search for Negative 
            if (get_value_PV=="False")
            {
                for (int i = 0; i < result.Count(); i++)
                {
                    for (int k = 0; k < lines_negative.Length; k++)
                    {
                        if (result[i] == lines_negative[k])
                        {
                            TextBox mystr = Application.OpenForms["Form1"].Controls["textBox4"] as TextBox;
                            mystr.Text = ("No tages has been found");
                            
                         

                       
                        }

                    }
                    if (first_noun.ToLower() == "he") nouns.Add("boys");
                    if (first_noun.ToLower() == "she") nouns.Add("girls");
                    if (first_noun.ToLower() != "he" && first_noun.ToLower() != "she") nouns.Add(first_noun);



                }

            }
            //Extar check after the check of the AI to improve search for Positive 
            
            else
            {
                for (int i = 0; i < result.Count(); i++)
                {
                    for (int k = 0; k < lines_negative.Length; k++)
                    {
                        if (result[i].ToLower() == lines_negative[k] && result[i].Length > 1 || (result[i].ToLower() == lines_negative[k])) count++;

                    }
                }
                if (count == 0)
                {
                    for (int i = 0; i < result.Count(); i++)
                    {
                        for (int k = 0; k < lines.Length; k++)
                        {
                            if (result[i].ToLower() == lines[k] && result[i].Length > 1 && result[i].Length > 1 || (result[i].ToLower() == lines[k] + "s" && result[i].Length > 1))
                            {
                                //if (first_noun.ToLower() != "he" && first_noun.ToLower() != "she") nouns.Add(first_noun + " ");

                                if (result[i] != "like" && result[i] != "dont" && result[i] != "doesn't" && result[i] != "doesnt" && result[i] != "hate" && result[i] != "hates" && result[i] != "dislike" && result[i] != "like" && result[i] != "likes" && result[i] != "love" && result[i] != "loves" && nouns.Count()<2) nouns.Add(result[i]);

                            }
                        }
                    }


                }

            }
           
            //Remove duplicates if there and sort list
            List<string> final = nouns.Distinct().ToList<string>();
            


            return final;


        }
    }
}
  

