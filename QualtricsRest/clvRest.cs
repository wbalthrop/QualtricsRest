using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QualtricsRest
{
    public class clvRest
    {

        public static string listSurveysURL = "https://yourdatacenterid.qualtrics.com/API/v3/surveys";
        public static string createMailingListURL = "https://yourdatacenterid.qualtrics.com/API/v3/mailinglists";
        public static string createContactImportURL = "https://yourdatacenterid.qualtrics.com/API/v3/mailinglists/:mailingListId/contactimports";
        public static string createSurveyDistributionURL = "https://yourdatacenterid.qualtrics.com/API/v3/distributions";

        public RestClient restClient = new RestClient();

        public List<Survey> getSurveys()
        {
            restClient.BaseUrl = new Uri(listSurveysURL);
            var request = new RestRequest();
            request.AddHeader("X-API-TOKEN", "T60biob0NJLOxOYGxq3iDd7J4EkRLDmiK4GndvZm");

            IRestResponse response = restClient.Execute(request);
            //string resp = @response.Content;
            //var r = JObject.Parse(resp).SelectToken("result").ToString();
            //var r2 = JObject.Parse(JObject.Parse(@response.Content).SelectToken("result").ToString()).SelectToken("elements").ToString();

            //List<Survey> res = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<Survey>>(JObject.Parse(JObject.Parse(@response.Content).SelectToken("result").ToString()).SelectToken("elements").ToString());
            //SortedList<string, object> re = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<SortedList<string, object>>(r);
            //var a = res.ElementAt(0);
            //var res = JsonConvert.DeserializeObject<>(r);
            return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<Survey>>(JObject.Parse(JObject.Parse(@response.Content).SelectToken("result").ToString()).SelectToken("elements").ToString());
        }

        public class Surveys
        {
            public List<Survey> survey { get; set; }
        }

        [JsonObject]
        public class Survey
        {
            [JsonProperty("id")]
            public string id { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("ownerid")]
            public string ownerId { get; set; }

            [JsonProperty("lastmod")]
            public DateTime lastModified { get; set; }

            [JsonProperty("isactive")]
            public bool isActive { get; set; }
        }

    }
}
