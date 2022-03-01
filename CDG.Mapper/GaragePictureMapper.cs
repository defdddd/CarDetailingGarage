using CDG.DTO;
using Models.Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CDG.Mapper
{
    public static class GaragePictureMapper
    {
        public static GaragePictureModel GetModel(GaragePictureDTO value)
        {
            return new GaragePictureModel()
            {
                AppointmentId = value.AppointmentId,
                FileName = value.FileName,
                Id = value.Id,
                Image = Encoding.Default.GetBytes(value.Image)
            };
        }
    }
}
