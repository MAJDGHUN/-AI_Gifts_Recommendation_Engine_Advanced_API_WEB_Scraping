using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Examen_GUI
{
    /*For test
     * He loves cars
       He likes cars
       little girl it can be car toys
       girl likes cars and cats
       man loves jazz music
       teenager is all about games and ballet
  
     * */
    public partial class Form1 : Form
    {   //My methodes
        private Gifts Get_gifts = new Gifts();
        private List<string> gifts = new List<string>();
        private List<string> gifts_T = new List<string>();
        private Check my_check = new Check();
        private Gifts_Title Get_Title = new Gifts_Title();
        
        public string word_list;
        public Form1()
        {
            
            InitializeComponent();
        }
        private void Find_Gifts(List<string> gifts)
        {
            //Find the images of searches
            label7.Text = "Loading...";
            try
            {


                pictureBox7.ImageLocation = Get_gifts.list_gift(gifts)[0];
                pictureBox2.ImageLocation = Get_gifts.list_gift(gifts)[1];

                pictureBox3.ImageLocation = Get_gifts.list_gift(gifts)[2];

                pictureBox6.ImageLocation = Get_gifts.list_gift(gifts)[3];

                pictureBox5.ImageLocation = Get_gifts.list_gift(gifts)[5];

                pictureBox4.ImageLocation = Get_gifts.list_gift(gifts)[6];
            }
            catch (Exception)
            {

                
            }
            



        }
        private void Find_Gifts_Title(List<string> gifts_T)
        {

            //Find the title of searches
            label7.Text = "Loading...";
            try
            {
                textBox12.Text = String.Join(Environment.NewLine, Get_Title.Titlegift(gifts_T)[0].ToString());

                textBox8.Text = String.Join(Environment.NewLine, Get_Title.Titlegift(gifts_T)[1].ToString());

                textBox10.Text = String.Join(Environment.NewLine, Get_Title.Titlegift(gifts_T)[2].ToString());

                textBox7.Text = String.Join(Environment.NewLine, Get_Title.Titlegift(gifts_T)[3].ToString());

                textBox9.Text = String.Join(Environment.NewLine, Get_Title.Titlegift(gifts_T)[4].ToString());

                textBox11.Text = String.Join(Environment.NewLine, Get_Title.Titlegift(gifts_T)[6].ToString());
            }
            catch (Exception)
            {

             
            }
  
          
        }
        private void RESET_FUN()
        {// restart the app for new try
            Application.Restart();

        }
        private void Test_data()
        {   //AI check textBox1.Text(the input) to see if its a False or a True input
            label7.Text = "Loading...";
       
            my_check = new Check();
            my_check.ReadData("TEST_Sample.txt");//Get  the alogarithm resolution  about our input(True/False)
            string textBox11 = textBox1.Text;
            Debug.WriteLine(textBox11);
            //show the result in  textBox6
            textBox6.Text = String.Join(Environment.NewLine, textBox11 + " is " + my_check.Classify(textBox11));
           

        }
        private void Get_gender()
        { // Get the gender of person->  first word
            label7.Text = "Loading...";
            string words = textBox1.Text;
            List<string> word = words.Split(' ').ToList();
            label6.Text = word[0];


            if (textBox1.Text=="")
            {
                textBox12.Text = String.Join(Environment.NewLine, "You have to write something");
             
            }
            else
            {
                textBox3.Text = String.Join(Environment.NewLine, Genderize.Genderizer.GetGender(word[0]));
            }
            
            if (textBox3.Text!= "Not_Geven")
            {
                textBox2.Text = word[0];
            }

        }
        private void Get_Interests( )
        {// Get interests(tags-nouns) to use it after that of gifts scraping
            Nouns noun = new Nouns();
            string words = textBox1.Text;


            textBox4.Text = String.Join(Environment.NewLine, noun.Check_Nouns(words));

        }


        private void label1_Click(object sender, EventArgs e)
        {
            string words = textBox1.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //When click call these functions
            label7.Text = "Loading...";
            Test_data();
            Get_Interests();
            Get_gender();
            Find_Gifts(gifts);
            Find_Gifts_Title(gifts_T);
            label7.Text = "Done!";


        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Restart App
            RESET_FUN();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
