using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SDETAPI_CSharp.Features.HealtcareGov;
using SDETAPI_CSharp.Features.NasaOpenAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SDETAPI_CSharp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        
        [TestCase("Get", "GetArticles")]
        [TestCase("Get", "GetBlog")]
        [TestCase("Get", "GetGlossary")]
        [Category("HealtCare")]
        public void TestHealtCare(string method, string archivo)
        {
            
            RestClient client = new RestClient();
            RestResponse queryResult = client.Execute(Request.CreateRequest(method, archivo));
            healthResponse featureResponse = JsonConvert.DeserializeObject<healthResponse>(queryResult.Content);
            Console.WriteLine(featureResponse.date);
            Console.WriteLine(featureResponse.explanation);
            Console.WriteLine(featureResponse.copyright);
            Console.WriteLine(featureResponse.url);
            Console.WriteLine(queryResult.StatusCode);
            Console.WriteLine(queryResult.StatusDescription);



            Assert.That(queryResult.IsSuccessStatusCode, Is.True);
            Console.WriteLine(queryResult.Content);
        }

        
        
        
        
        [TestCase("Get", "APOD", "1995-11-27")] //Date must be between Jun 16, 1995 and Feb 28, 2023.
        [TestCase("Get", "APOD", "1995-12-27")]
        [TestCase("Get", "APOD", "1996-01-27")]
        [TestCase("Post", "body", "1996-01-27")]
        [Category("NASA")]
        public void TestNASA(string method, string archivo, string date)
        {
            if (method.Equals("Get"))
            {
                RestClient client = new RestClient();
                RestResponse queryResult = client.Execute(NasaRequest.Request(method, archivo, date));
                Response featureResponse = JsonConvert.DeserializeObject<Response>(queryResult.Content);

                int statuscode = (int)queryResult.StatusCode;

                string explanation = featureResponse.explanation;
                int cont = 0;

                var lique = from teststring in explanation where teststring == 'O' select teststring;


                foreach (int teststring in lique)
                {
                    cont++;
                }
                Console.Write(cont + "\n");

                Console.WriteLine(featureResponse.copyright);
                Console.WriteLine(featureResponse.date);
                Console.WriteLine(explanation);
                Console.WriteLine(featureResponse.url);
                Console.WriteLine(statuscode);
                Console.WriteLine(queryResult.StatusDescription);

                Assert.That(queryResult.IsSuccessStatusCode, Is.True);
            }
            else
            {
                
                RestRequest restRequest = new RestRequest();
                restRequest = NasaRequest.Request(method, archivo, date);
                
                /*Dado que no tengouna API para probar el Post dejo esta parte en comentario
                 * 
                 * RestClient client = new RestClient();
                RestResponse queryResult = client.Execute(restRequest);
                Response featureResponse = JsonConvert.DeserializeObject<Response>(queryResult.Content);*/



                Console.WriteLine("Test");

            }
        }
    }
}