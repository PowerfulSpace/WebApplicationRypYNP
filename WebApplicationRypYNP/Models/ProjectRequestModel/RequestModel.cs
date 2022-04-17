using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApplicationRypYNP.Models.ProjectRequestModel
{
    public class RequestModel
    {
        HttpWebRequest _request;
        string _address;

        public string Response { get; set; }


        public RequestModel(string address)
        {
            _address = address;
        }

        public async Task RunAsync()
        {
            _request = (HttpWebRequest)WebRequest.Create(_address);
            _request.Method = "Get";

            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null) Response = await new StreamReader(stream).ReadToEndAsync();
            }
            catch (Exception) { }
        }
    }
}
