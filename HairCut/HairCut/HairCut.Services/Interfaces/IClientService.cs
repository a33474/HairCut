using HairCut.BLL.Entities.Identity;
using HairCut.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HairCut.Services.Interfaces
{
    public interface IClientService
    {
        IEnumerable<ClientVm> GetClients(Expression<Func<Client, bool>> filterPredicate = null);
        ClientVm GetClient(Expression<Func<Client, bool>> filterPredicate = null);
        void AddOrUpdateClient(ClientVm clientVm);
    }
}
