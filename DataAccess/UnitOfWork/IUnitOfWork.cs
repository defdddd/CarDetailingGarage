using CDG.DataAccess.Data.Interface;
using DataAccess.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAppointmentRepository AppointmentRepository { get; }
        IGaragePictureRepository GaragePictureRepository { get; }
        IPersonRepository PersonRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IReviewerPictureRepository ReviewerPictureRepository { get; }
        IProfilePictureRepository ProfilePictureRepository { get; }
    }
}
