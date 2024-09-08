using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITopicRepository : IRepository<Topic>
    {
        Task<Topic> GetByNameAsync(string name);
        Task<IEnumerable<Topic>> GetTopicsWithArticlesAsync(Guid? topicId = null);
    }
}
