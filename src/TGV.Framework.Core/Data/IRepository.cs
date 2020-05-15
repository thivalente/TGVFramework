using System;
using TGV.Framework.Core.ValueObject;

namespace TGV.Framework.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
