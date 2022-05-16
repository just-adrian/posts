using System;
using System.Collections.Generic;

namespace posts.dal
{
    public interface IPostRepository
    {
        IList<Post> Get(PaginationValues paginationValues);

        bool Delete(int id);
    }
}
