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
        IEnumerable<AddOrUpdateClientVm> GetClients(Expression<Func<Client, bool>> filterPredicate = null);
        AddOrUpdateClientVm GetClient(Expression<Func<Client, bool>> filterPredicate = null);
        void AddOrUpdateClient(AddOrUpdateClientVm clientVm);
        void DeleteClient(int clientId);
    }
}
