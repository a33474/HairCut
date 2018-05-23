using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HairCut.ViewModels
{
    public class AddOrUpdateClientVm
    {
        public int Id { get; set; }
        public string ContactMobile { get; set; }
        public string ContactMail { get; set; }
       // public IEnumerable<AppointmentVm> Appointments { get; set; }
        public string Name { get; set; }
    }
}
