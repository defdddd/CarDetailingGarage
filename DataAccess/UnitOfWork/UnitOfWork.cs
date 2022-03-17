using CDG.DataAccess.Data;
using CDG.DataAccess.Data.Interface;
using DataAccess.Data;
using DataAccess.Data.Interface;
using DataAccess.SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISqlDataAccess _sqlDataAccess;
        public IAppointmentRepository AppointmentRepository => new AppointmentRepository(_sqlDataAccess);
        public IGaragePictureRepository GaragePictureRepository => new GaragePictureRepository(_sqlDataAccess);
        public IPersonRepository PersonRepository => new PersonRepository(_sqlDataAccess);
        public IReviewRepository ReviewRepository => new ReviewRepository(_sqlDataAccess);
        public IReviewerPictureRepository ReviewerPictureRepository => new ReviewerPictureRepository(_sqlDataAccess);
        public IProfilePictureRepository ProfilePictureRepository => new ProfilePictureRepository(_sqlDataAccess);
        public UnitOfWork(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }
    }
}
