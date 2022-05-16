using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace posts.dal
{
    public class PostRepository : IPostRepository
    {
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Post> Get(PaginationValues paginationValues)
        {
            var fakeResult = PostSeed.Posts
                .Skip((paginationValues.Number - 1) * paginationValues.Size)
                .Take(paginationValues.Size)
                .ToList();

            return fakeResult;
        }
    }
}
