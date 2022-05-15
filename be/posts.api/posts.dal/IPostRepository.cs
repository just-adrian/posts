using System;
using System.Collections.Generic;

namespace posts.dal
{
    public interface IPostRepository
    {
        IList<Post> GetAll();

        bool Delete(Guid id);
    }
}
