using HairCut.BLL.Entities;
using HairCut.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HairCut.Services.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentVm> GetAppointments(Expression<Func<Appointment, bool>> filterPredicate = null);
        AppointmentVm GetAppointment(Expression<Func<Appointment, bool>> filterPredicate = null);
        void AddOrUpdateAppointment(AppointmentVm appointmentVm);
        void DeleteAppointment(AppointmentVm appointmentVm);


    }
}
