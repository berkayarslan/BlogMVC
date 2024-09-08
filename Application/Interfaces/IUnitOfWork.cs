using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IArticleRepository Articles { get; }
        ITopicRepository Topics { get; }
        Task<int> SaveAsync();
    }
}
