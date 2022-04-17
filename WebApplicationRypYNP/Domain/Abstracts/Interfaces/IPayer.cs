using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationRypYNP.Domain.Entities;
using WebApplicationRypYNP.Models;

namespace WebApplicationRypYNP.Domain.Abstracts.Interfaces
{
    public interface IPayer
    {
        Task<IEnumerable<Payer>> GetItems(string searchText = "");

        Task<Payer> GetPayerAsync(Guid id);

        InfoModel GetInfoModel(InfoModel infoModel);

        Task SendMessage();

    }
}
