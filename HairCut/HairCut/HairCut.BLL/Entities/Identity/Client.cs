using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HairCut.BLL.Entities.Identity
{
    public class Client : User
    {
        public string ContactMobile { get; set; }
        public string  ContactMail { get; set; }
        [InverseProperty("Client")]
        public ICollection<Appointment> Appointments { get; set; }

    }
}
