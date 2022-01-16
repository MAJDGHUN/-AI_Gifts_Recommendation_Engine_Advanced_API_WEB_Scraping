using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;// Get request// sending data to and receiving data from a resource identified by a URI
using Newtonsoft.Json;//Converts an object to and from JSON// JsonConverterAttribute//jsonsubtype lib

namespace Examen_GUI
{
    class Genderize
    {
        //Calling Genderize.io API with GET method request to get the gender of an person
        public enum Gender
        {
            Male,
            Female,
            Not_Geven

        }
        //Properties for response 
        public class GenderizeResponse
        {
            public string name { get; set; }
            public Gender gender { get; set; }

            //method so that it returns a string
            public override string ToString() { return string.Format("{0}", name); }

        }

        public static class Genderizer
        {
            //gets looked up at runtime
            private static readonly string API_PREFORMATTED = "https://api.genderize.io/?name={0}";


            public static Gender GetGender(string name)
            {
                //insert the value of the  object or  into another string
                var requestURL = String.Format(API_PREFORMATTED, name);
                //WebClient is class for sending data or receiving data
                WebClient wc = new WebClient();
                
                try
                { //Get web response and deserializes the JSON to object
                    var webResponse = wc.DownloadString(requestURL);
                    var result = JsonConvert.DeserializeObject<GenderizeResponse>(webResponse);
                    return result.gender;
                }
                catch (Exception)
                {
                    return Gender.Not_Geven;
                }
                
                
            }
        }
    }
}
