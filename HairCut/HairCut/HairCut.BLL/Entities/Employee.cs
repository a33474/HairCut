using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HairCut.BLL.Entities
{
    public class Employee : User
    {
        [InverseProperty("Employee")]
        public ICollection<Appointment> BookedAppointments{ get; set; }
       // public ICollection<Service> PerformedServices { get; set; }
    }
}
