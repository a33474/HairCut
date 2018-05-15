using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HairCut.ViewModels
{
    public class AppointmentVm
    {
        public int Id { get; set; }

        public DateTime DateOfCreation { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal Price { get; set; }

        public bool Canceled { get; set; }

        [ForeignKey("ClientId")]
        public ClientVm Client { get; set; }
        public int ClientId { get; set; }

        [ForeignKey("EmployeeId")]
        public EmployeeVm Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
