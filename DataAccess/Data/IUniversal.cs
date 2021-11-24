using System.Threading.Tasks;

namespace DataAccess.Data
{
    public interface IUniversal
    {
        Task<int> Count();
    }
}