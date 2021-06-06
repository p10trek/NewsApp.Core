using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace NewsApp.Core.DataBase
{
    class UtilityHelper
    {
        /// <summary>  
        /// User Agent Header in HTTP Request  
        /// </summary>  
        private const string USER_AGENT = "firebase-net/1.0";

        /// <summary>  
        /// Validates a URI  
        /// </summary>  
        /// <param name="url">URI as string</param>  
        /// <returns>True if valid</returns>  
        public static bool ValidateURI(string url)
        {
            Uri locurl;
            if (System.Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out locurl))
            {
                if (
                    !(locurl.IsAbsoluteUri &&
                      (locurl.Scheme == "http" || locurl.Scheme == "https")) ||
                    !locurl.IsAbsoluteUri)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>  
        /// Validates JSON string  
        /// </summary>  
        /// <param name="inJSON">JSON to be validatedd</param>  
        /// <param name="output">Valid JSON or Error Message</param>  
        /// <returns>True if valid</returns>  
        public static bool TryParseJSON(string inJSON, out string output)
        {
            try
            {
                JToken parsedJSON = JToken.Parse(inJSON);
                output = parsedJSON.ToString();
                return true;
            }
            catch (Exception ex)
            {
                output = ex.Message;
                return false;
            }
        }

        /// <summary>  
        /// Makes Asynchronus HTTP requests  
        /// </summary>  
        /// <param name="method">HTTP method</param>  
        /// <param name="uri">URI of resource</param>  
        /// <param name="json">JSON string</param>  
        /// <returns>HTTP Responce as Task</returns>  
        public static Task<HttpResponseMessage> RequestHelper(HttpMethod method, Uri uri, string json = null)
        {
            var client = new HttpClient();
            var msg = new HttpRequestMessage(method, uri);
            msg.Headers.Add("user-agent", USER_AGENT);
            //msg.Headers.Add("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjMwMjUxYWIxYTJmYzFkMzllNDMwMWNhYjc1OTZkNDQ5ZDgwNDI1ZjYiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL3NlY3VyZXRva2VuLmdvb2dsZS5jb20vbmV3c2FwcC0yZWVmNCIsImF1ZCI6Im5ld3NhcHAtMmVlZjQiLCJhdXRoX3RpbWUiOjE2MjI3MzY0NDksInVzZXJfaWQiOiJpblJydTkzb2lnVFByREZXMW85RmRzZ2RlTEIzIiwic3ViIjoiaW5ScnU5M29pZ1RQckRGVzFvOUZkc2dkZUxCMyIsImlhdCI6MTYyMjczNjQ0OSwiZXhwIjoxNjIyNzQwMDQ5LCJlbWFpbCI6InBpb3RycmFkbGFrOTlAZ21haWwuY29tIiwiZW1haWxfdmVyaWZpZWQiOmZhbHNlLCJmaXJlYmFzZSI6eyJpZGVudGl0aWVzIjp7ImVtYWlsIjpbInBpb3RycmFkbGFrOTlAZ21haWwuY29tIl19LCJzaWduX2luX3Byb3ZpZGVyIjoicGFzc3dvcmQifX0.UFAtQZHxO2HeQSXgChKE-FGQUcyDRyQhyqJdWwofv4vdr0p1b4hcm64iLolIicFn9DZwx661nAyYtrgaruU-uiTcuz-4bsK_BaEkDKkkDNpsvLZWZWPOLgMjSD5UP89CWIDDsIM9trbuDZuxwS1d0kom7IOREL_1oCiy2yVWQAuN6yanUCHi_BOmL_GmlzJzoXn-sJ-hIQuv6m2RXKwrVbsY6nLy-R_UGtopyQW-rK5jwEpWuTK4lPmuM6Mr2_zxb9gWLmx9dAhMBnRakjdjBirChKl-fUlPTypSDo2r8kYB1EOYebcF-2aYSfnj-gur4GrG_KSkxLJ0I9PRC-8bJw");
            if (json != null)
            {
                msg.Content = new StringContent(
                    json,
                    UnicodeEncoding.UTF8,
                    "application/json");
            }

            return client.SendAsync(msg);
        }
    }
}

