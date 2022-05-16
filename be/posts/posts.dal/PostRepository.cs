using posts.dal.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace posts.dal
{
    public class PostRepository : IPostRepository
    {
        public bool Delete(int id)
        {
            var post = PostSeed.Posts.FirstOrDefault(x => x.Id == id);

            if (post == null)
            {
                throw new PostNotFoundException(id);
            }

            return PostSeed.Posts.Remove(post);
        }

        public IList<Post> Get(PaginationValues paginationValues)
        {
            var fakeResult = new List<Post>();

            if (paginationValues.Filter != null)
            {
                fakeResult = PostSeed.Posts
                                .Where(x => x.Author.ToLower().Contains(paginationValues.Filter.ToLower())
                                            || x.Content.ToLower().Contains(paginationValues.Filter.ToLower())
                                            || x.Title.ToLower().Contains(paginationValues.Filter.ToLower()))
                                .Skip((paginationValues.Number - 1) * paginationValues.Size)
                                .Take(paginationValues.Size)
                                .ToList();
                return fakeResult;
            }

            fakeResult = PostSeed.Posts
                     .Skip((paginationValues.Number - 1) * paginationValues.Size)
                     .Take(paginationValues.Size)
                     .ToList();

            return fakeResult;
        }
    }
}
