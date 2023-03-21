using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using SDETAPI_CSharp.Core;
using System.IO;

namespace SDETAPI_CSharp.Features.NasaOpenAPI
{
    public class NasaRequest
    {
        static public RestRequest Request(string method, string fileName, string date)
        {
            RestRequest restRequest = new RestRequest();
            Core.JsonReader dataTest = new Core.JsonReader();
            JToken testToken = dataTest.NasaDAta(fileName);


            switch (method.ToUpper())
            {

                case "GET":
                    restRequest = new RestRequest(testToken.SelectToken("URL").Value<string>(), Method.Get);
                    restRequest.AddQueryParameter("api_key", testToken.SelectToken("ApiKey").Value<string>()).AddQueryParameter("date", date);
                    break;

                case "POST":
                    
                    try
                    {

                        string completePath = Path.Combine("C:\\Users\\Vera\\source\\repos\\SDETAPI_CSharp\\Requests\\HealtcareGov\\Gets", fileName + ".json");
                        String myJsonString = File.ReadAllText(completePath);
                        JToken jsonObject = JToken.Parse(myJsonString);
                        int idBody = jsonObject.SelectToken("id").Value<int>();
                        string firstName = jsonObject.SelectToken("name").Value<string>();
                        string lastName = jsonObject.SelectToken("lastname").Value<string>();

                        postIni body = new postIni
                        {
                            id = idBody,
                            name = firstName,
                            lastName = lastName
                        };
                        RestClient client = new RestClient("www.dummyURL.com / doSomething");

                        restRequest = new RestRequest();
                        restRequest.Method = Method.Post;
                        restRequest.AddBody(body);
                        restRequest.AddBody(firstName);
                        restRequest.AddBody(lastName);         
                        return restRequest;
                    }
                    catch (Exception)
                    {

                        return null;
                    }

                    //restRequest = new RestRequest(testToken.SelectToken("URL").Value<string>(), Method.Post);


                    //restRequest.AddQueryParameter("api_key", testToken.SelectToken("ApiKey").Value<string>()).AddQueryParameter("date", date);
                    break;

                case "PUT":
                    restRequest = new RestRequest(testToken.SelectToken("URL").Value<string>(), Method.Put);
                    restRequest.AddQueryParameter("api_key", testToken.SelectToken("ApiKey").Value<string>()).AddQueryParameter("date", date);
                    break;

                case "DELETE":
                    restRequest = new RestRequest(testToken.SelectToken("URL").Value<string>(), Method.Delete);
                    restRequest.AddQueryParameter("api_key", testToken.SelectToken("ApiKey").Value<string>()).AddQueryParameter("date", date);
                    break;

                default:
                    throw new NotImplementedException($"Rest Method not valid. Must specifiy correctly. Current value: [{method}]" +
                                                      $"Current valid types: Get and Post");
            }
            restRequest.RequestFormat = DataFormat.Json;
            return restRequest;
        }

    }
}
