using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.Models
{
    public class ProfilePictureModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }    
    }
}
