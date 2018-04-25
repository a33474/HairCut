using System;
using System.Collections.Generic;
using System.Text;

namespace HairCut.BLL.Entities
{
    public class Service
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public TimeSpan AvgDuration { get; set; }

        public decimal Price { get; set; }
        public Gender Gender { get; set; }
    }
}
