using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public int PersonId { get; set; }
        public bool IsDone { get; set; }

    }
}
