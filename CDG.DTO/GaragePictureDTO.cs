using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.DTO
{
    public class GaragePictureDTO
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string FileName { get; set; }
        public string Image { get; set; }
    }
}
