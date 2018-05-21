using AutoMapper;
using DataAccessLayer.Core.Interfaces.UoW;
using HairCut.BLL.Entities;
using HairCut.DAL.EF;
using HairCut.Services.Interfaces;
using HairCut.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HairCut.Services.Services
{
    public class ConcreateAppointmentService : BaseService, IAppointmentService
    {
        private ApplicationDbContext<User, Role, int> _context;

        public ConcreateAppointmentService(IUnitOfWork uow, ApplicationDbContext<User, Role, int> context) : base(uow)
        {
            _context = context;
        }
        public IEnumerable<AppointmentVm> GetAppointments(Expression<Func<Appointment, bool>> filterPredicate = null)
        {
            IEnumerable<Appointment> appointments = _uow.Repository<Appointment>().GetRange(filterPredicate, false,
                             x => x.OrderByDescending(p => p.DateOfCreation), null, null,
                         p => p.Employee, c=>c.Client
                      );
            IEnumerable<AppointmentVm> appointmentVm = AutoMapper.Mapper.Map<IEnumerable<AppointmentVm>>(appointments);
            return appointmentVm;
        }

        public AppointmentVm GetAppointment(Expression<Func<Appointment, bool>> filterPredicate = null)
        {
            Appointment appointment = _uow.Repository<Appointment>().Get(filterPredicate, true, p => p.Employee, c => c.Client);
            AppointmentVm appointmentVm = Mapper.Map<AppointmentVm>(appointment);
            return appointmentVm;
        }

        public void AddOrUpdateAppointment(AppointmentVm appointmentVm)
        {
            var appointment = Mapper.Map<Appointment>(appointmentVm);
            appointment.DateOfCreation = DateTime.Now;
            _uow.Repository<Appointment>().AddOrUpdate(x => x.Id == appointment.Id, appointment);
            _uow.Save();
        }
    }
}

