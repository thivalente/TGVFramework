using System.Threading.Tasks;

namespace TGV.Framework.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
