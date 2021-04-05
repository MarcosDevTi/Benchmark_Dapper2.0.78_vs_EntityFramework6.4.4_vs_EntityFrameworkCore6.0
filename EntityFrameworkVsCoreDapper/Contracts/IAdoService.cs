using System;
using System.Threading.Tasks;

namespace EntityFrameworkVsCoreDapper.Contracts
{
    public interface IAdoService
    {
        Task<TimeSpan> InsertSingleProducts(int interactions);
    }
}
