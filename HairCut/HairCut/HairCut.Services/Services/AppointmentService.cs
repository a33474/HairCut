using AutoMapper;
using DataAccessLayer.Core.Interfaces.UoW;
using HairCut.BLL.Entities;
using HairCut.Services.Interfaces;
using HairCut.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HairCut.Services.Services
{
    public class AppointmentService : BaseService, IAppointmentService
    {

        public AppointmentService(IUnitOfWork uow) : base(uow)
        {
        }
        public IEnumerable<AppointmentVm> GetAppointments(Expression<Func<Appointment, bool>> filterPredicate = null)
        {
            IEnumerable<Appointment> appointments= _uow.Repository<Appointment>().GetRange(filterPredicate: filterPredicate, orderByPredicate: x => x.OrderByDescending(p => p.DateOfCreation),
                                                                        tablePredicate: p => p.Client,
                                                                        enableTracking: false);
            IEnumerable<AppointmentVm> appointmentVm = AutoMapper.Mapper.Map<IEnumerable<AppointmentVm>>(appointments);
            return appointmentVm;
        }

        public AppointmentVm GetAppointment(Expression<Func<Appointment, bool>> filterPredicate = null)
        {
            Appointment appointment = _uow.Repository<Appointment>().Get(filterPredicate: filterPredicate);
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

