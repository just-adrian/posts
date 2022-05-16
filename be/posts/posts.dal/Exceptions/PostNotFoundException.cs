using System;
using System.Collections.Generic;
using System.Text;

namespace posts.dal.Exceptions
{
    public class PostNotFoundException : Exception
    {
        public PostNotFoundException(int postId):base($"Not found post with id: {postId}!")
        {
        }
    }
}
