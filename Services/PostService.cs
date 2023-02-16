using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopoServices.Domain;

namespace TopoServices.Services
{
    public class PostService : IPostService
    {
        private readonly List<PostEntity> _posts;

        public PostService()
        {
            _posts = new List<PostEntity>()
            {
                new PostEntity{ PostId=Guid.NewGuid(), Title= "Post 1" },
                new PostEntity{ PostId=Guid.NewGuid(), Title= "Post 2" },
                new PostEntity{ PostId=Guid.NewGuid(), Title= "Post 3" },
            };
        }

        public List<PostEntity> GetAllPosts()
        {
            return _posts;
        }

        public PostEntity GetPostById(Guid postId)
        {
            return _posts.SingleOrDefault(item => item.PostId == postId);
        }

        public Guid CreatePost(PostEntity post)
        {
            if (post.PostId != null)
                post.PostId = Guid.NewGuid();
            _posts.Add(post);
            return post.PostId;
        }

        public bool UpdatePost(PostEntity postToUpdate)
        {
            var index = _posts.FindIndex(item => item.PostId == postToUpdate.PostId);
            if (index > 0)
            {
                _posts[index] = postToUpdate;
                return true;
            }
            else return false;
        }

        public bool DeletePost(Guid postId)
        {
            var index = _posts.FindIndex(item => item.PostId == postId);
            if (index >= 0)
            {
                _posts.RemoveAt(index);
                return true;
            }
            else return false;
        }
    }
}
