using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplicationRypYNP.Domain.Abstracts.Interfaces;
using WebApplicationRypYNP.Domain.Data;
using WebApplicationRypYNP.Domain.Entities;
using WebApplicationRypYNP.Models;
using WebApplicationRypYNP.Models.EmailModel;
using WebApplicationRypYNP.Models.ProjectRequestModel;

namespace WebApplicationRypYNP.Domain.Abstracts.Repositories
{
    public class PayerRepository : IPayer
    {

        private readonly AppDbContext _context;

        private bool LocalDB;
        private bool ServerDB;

        public PayerRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Payer> GetPayerAsync(Guid id) => await _context.Payers.FirstOrDefaultAsync(p => p.Id == id);



        private List<Payer> ValidPayers(IEnumerable<Payer> payers, Payer payer)
        {

            List<Payer> validPayers = new List<Payer>();

            foreach (Payer item in payers)
            {
                if (item.VUNP == payer.VUNP)
                {
                    validPayers.Add(payer);
                }
            }


            if (payer != null) { ServerDB = true; }
            if (validPayers.Count > 0) { LocalDB = true; }


            if (validPayers.Count == 0 && payer != null)
            {
                validPayers.Add(payer);
            }



            return validPayers;
        }



        public async Task<IEnumerable<Payer>> GetItems(string searchText = "" )
        {
            ParseModel parseModel = new ParseModel();
            Payer payer = await parseModel.GetModelParseAsync(searchText);

            IEnumerable<Payer> payers;

            if (searchText != "" && searchText != null)
                payers = _context.Payers.Where(n => n.VUNP.Contains(searchText) || n.Email.Contains(searchText));
            else
                payers = _context.Payers;


            if (payer != null)
            {
                payers = ValidPayers(payers, payer);
            }
            

            return payers;
        }




        public InfoModel GetInfoModel(InfoModel infoModel)
        {
            infoModel.IsInTheLocalDb = LocalDB;
            infoModel.IsInTheServerDb = ServerDB;

            return infoModel;
        }





        public async Task SendMessage()
        {

            IEnumerable<Payer> payers = _context.Payers;

            int poyerCount = 0;

            AlertMessageModel messageModel = new AlertMessageModel();

            foreach (Payer payer in payers)
            {

                if (poyerCount == 100) { Thread.Sleep(5000); }

                if (payer.Email != "" && payer.Email != null)
                {
                    await messageModel.SendMessageAsync(payer.Email);
                }

                poyerCount++;
            }

            poyerCount = 0;
        }



    }
}
