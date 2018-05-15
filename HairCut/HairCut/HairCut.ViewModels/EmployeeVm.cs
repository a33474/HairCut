using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HairCut.ViewModels
{
    public class EmployeeVm
    {
        [InverseProperty("Employee")]
        public IEnumerable<AppointmentVm> BookedAppointments { get; set; }
    }
}
