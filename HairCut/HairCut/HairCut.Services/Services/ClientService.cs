using DataAccessLayer.Core.Interfaces.UoW;
using HairCut.BLL.Entities;
using HairCut.BLL.Entities.Identity;
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
        public ClientService(IUnitOfWork uow) : base(uow)
        {
        }
        public IEnumerable<ClientVm> GetClients(Expression<Func<Client, bool>> filterPredicate = null)
        {
            IEnumerable<Client> clients = _uow.Repository<Client>().GetRange(filterPredicate: filterPredicate, orderByPredicate: x => x.OrderBy(p => p.FirstName),
                                                                        tablePredicate: p => p.Appointments,
                                                                        enableTracking: false);
            IEnumerable<ClientVm> clientVm = AutoMapper.Mapper.Map<IEnumerable<ClientVm>>(clients);
            return clientVm;
        }

        public ClientVm GetClient(Expression<Func<Client, bool>> filterPredicate = null)
        {
            Client client = _uow.Repository<Client>().Get(filterPredicate: filterPredicate);
            ClientVm clientVm = Mapper.Map<ClientVm>(client);
            return clientVm;
        }

        public void AddOrUpdateClient(ClientVm clientVm)
        {
            var client = Mapper.Map<Client>(clientVm);
            client.DateOfCreating = DateTime.Now;
            _uow.Repository<Client>().AddOrUpdate(x => x.FirstName == client.FirstName, client);
            _uow.Save();
        }
    }
}
}
