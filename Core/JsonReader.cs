using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SDETAPI_CSharp.Core
{
    public class JsonReader
    {
        public JsonReader()
        {

        }

        public JToken exData(string fileName)
        {
            //string completePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName + ".json");
            string completePath = Path.Combine("C:\\Users\\Vera\\source\\repos\\SDETAPI_CSharp\\Requests\\HealtcareGov\\Gets", fileName + ".json");
            try
            {
                String myJsonString = File.ReadAllText(completePath);
                JToken jsonObject = JToken.Parse(myJsonString);
                return jsonObject;
            }
            catch(Exception)
            {

                return null;
            }
        }

        public JToken NasaDAta(string fileName)
        {
            //string completePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName + ".json");
            string completePath = Path.Combine("C:\\Users\\Vera\\source\\repos\\SDETAPI_CSharp\\Requests\\NasaOpenAPI\\Gets", fileName + ".json");
            try
            {
                String myJsonString = File.ReadAllText(completePath);
                JToken jsonObject = JToken.Parse(myJsonString);
                return jsonObject;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
