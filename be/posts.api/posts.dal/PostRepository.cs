using System;
using System.Collections.Generic;
using System.Text;

namespace posts.dal
{
    public class PostRepository : IPostRepository
    {
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Post> GetAll()
        {
            var fakeResult = PostSeed.Posts;
            return fakeResult;
        }
    }
}
