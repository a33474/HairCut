using HairCut.BLL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HairCut.BLL.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime DateOfCreation { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal Price { get; set; }

        public bool Canceled { get; set; }
        
        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        public int ClientId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
