﻿using AutoMapper;
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
        //private ApplicationDbContext<User, Role, int> _context;

        public ClientService(IUnitOfWork uow /*ApplicationDbContext<User, Role, int> context*/) : base(uow)
        {
            //_context = context;
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
            client.FirstName = string.Empty;
            _uow.Repository<Client>().AddOrUpdate(x => x.FirstName == client.FirstName, client);
            _uow.Save();
        }
    }
}

