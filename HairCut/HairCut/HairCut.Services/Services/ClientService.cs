using AutoMapper;
using DataAccessLayer.Core.Interfaces.UoW;
using HairCut.BLL.Entities;
using HairCut.BLL.Entities.Identity;
using HairCut.DAL.EF;
using HairCut.Services.Interfaces;
using HairCut.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HairCut.Services.Services
{
    public class ClientService : BaseService, IClientService
    {
        

        public ClientService(IUnitOfWork uow ) : base(uow)
        {
            
        }

        public IEnumerable<AddOrUpdateClientVm> GetClients(Expression<Func<Client, bool>> filterPredicate = null)
        {
            IEnumerable<Client> clients = _uow.Repository<Client>().GetRange(filterPredicate: filterPredicate, orderByPredicate: x => x.OrderBy(p => p.FirstName),
                                                                        tablePredicate: p => p.Appointments,
                                                                        enableTracking: false);
            IEnumerable<AddOrUpdateClientVm> clientVm = AutoMapper.Mapper.Map<IEnumerable<AddOrUpdateClientVm>>(clients);
            return clientVm;
        }

        public AddOrUpdateClientVm GetClient(Expression<Func<Client, bool>> filterPredicate = null)
        {
            Client client = _uow.Repository<Client>().Get(filterPredicate: filterPredicate);
            AddOrUpdateClientVm clientVm = Mapper.Map<AddOrUpdateClientVm>(client);
            return clientVm;
        }

        public void AddOrUpdateClient(AddOrUpdateClientVm clientVm)
        {
            var client = Mapper.Map<Client>(clientVm);
            client.FirstName = string.Empty;
            _uow.Repository<Client>().AddOrUpdate(x => x.FirstName == client.FirstName, client);
            _uow.Save();
        }

        public void DeleteClient(int clientId)
        {
            Client client = _uow.Repository<Client>().Get(clientId);
            if (client != null)
            {
                _uow.Repository<Client>().Delete(client);
                _uow.Save();
            }
        }   
    }
}

