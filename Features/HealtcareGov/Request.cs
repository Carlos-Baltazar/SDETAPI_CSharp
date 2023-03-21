using Newtonsoft.Json.Linq;
using RestSharp;
using SDETAPI_CSharp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDETAPI_CSharp.Features.HealtcareGov
{
    public class Request
    {
        static public RestRequest CreateRequest(string method, string fileName)
        {
            RestRequest restRequest = new RestRequest();
            JsonReader dataTest = new JsonReader();
            JToken testToken =  dataTest.exData(fileName);
            

            switch (method.ToUpper())
                {

                case "GET":
                    restRequest = new RestRequest(testToken.SelectToken("URL").Value<string>(), Method.Get);
                    break;

                case "POST":
                    restRequest = new RestRequest(testToken.SelectToken("URL").Value<string>(), Method.Post);
                    break;

                case "PUT":
                    restRequest = new RestRequest(testToken.SelectToken("URL").Value<string>(), Method.Put);
                    break;

                case "DELETE":
                    restRequest = new RestRequest(testToken.SelectToken("URL").Value<string>(), Method.Delete);
                    break;

                default:
                    throw new NotImplementedException($"Rest Method not valid. Must specifiy correctly. Current value: [{method}]" +
                                                      $"Current valid types: Get and Post");
            }
            restRequest.RequestFormat = DataFormat.Json;
            
            restRequest.AddParameter("application/json; charset=utf-8", ParameterType.RequestBody);

            return restRequest;
        }
       
    }

}
