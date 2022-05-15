﻿using System;

namespace posts.dal
{
    public class Post
    {
        public Guid Id { get; }

        public string Author { get; }

        public string Title { get; }

        public string Content { get; }

        public Post(Guid id, string author, string title, string content)
        {
            Id = id;
            Author = author;
            Title = title;
            Content = content;
        }
    }
}
