using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationRypYNP.Domain.Entities;

namespace WebApplicationRypYNP.Models.ProjectRequestModel
{
    public class ParseModel
    {


        public async Task<Payer> GetModelParseAsync(string searchText)
        {
            Payer payer;

            var payerFromTheServer = await GetResponseAsync(searchText);

            if (payerFromTheServer == "" || payerFromTheServer == null) { return null; }


            payer = new Payer();

            var json = JObject.Parse(payerFromTheServer);
            var row = json["ROW"];

            payer.VUNP = row["VUNP"].ToString();
            payer.VNAIMP = row["VNAIMP"].ToString();
            payer.VNAIMK = row["VNAIMK"].ToString();
            payer.NMNS = row["NMNS"].ToString();
            payer.VMNS = row["VMNS"].ToString();
            payer.CKODSOST = row["CKODSOST"].ToString();
            payer.VKODS = row["VKODS"].ToString();
            payer.DLIKV = row["DLIKV"] == null ? Convert.ToDateTime(row["DLIKV"]) : new DateTime();
            payer.VLIKV = row["VLIKV"].ToString();


            return payer;
        }


        //public async Task<Payer> GetModelParseAsync(string searchText)
        //{
        //    var payerFromTheServer = await GetResponseAsync(searchText);
        //    if(payerFromTheServer is null) { return null; }
        //    //Payer payer = payerFromTheServer["ROW"].ToObject<Payer>();

        //    var json = JObject.Parse(payerFromTheServer);
        //    var row = json["ROW"];

        //    Payer payer = row.ToObject<Payer>();


        //    return payer;
        //}


        private async Task<string> GetResponseAsync(string vunpModel)
        {
            string vunp = "";
            string response = "";

            if (vunpModel != null)
            {
                try
                {
                    vunp = vunpModel;

                    string url = $"http://www.portal.nalog.gov.by/grp/getData?unp={vunp}&charset=UTF-8&type=json";

                    RequestModel request = new RequestModel(url);
                    await request.RunAsync();
                    response = request.Response;
                }
                catch (Exception) { }
            }

            return response;
        }
    }
}
