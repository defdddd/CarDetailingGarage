using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Pictures
{
    public class ReviewerPictureModel
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int AppointmentId { get; set; }
        public string FileName { get; set; }
        public string ImagePath { get; set; }
    }
}
