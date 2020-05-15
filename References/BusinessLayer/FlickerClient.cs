using System.IO;
using System.Net;
namespace BusinessLayer
{
    public class FlickerClient
    {
        public static string Search(string name)
        {
            WebRequest webRequest = WebRequest.Create($"http://localhost:51536/api/flicker/{name}");
            webRequest.ContentType = "application/json";
            webRequest.Method = "GET";
            WebResponse resp = webRequest.GetResponse();
            if (resp == null)
                return null;
            else
            {
                using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                {
                    return sr.ReadToEnd().Trim();
                }
            }
        }

    }
}
