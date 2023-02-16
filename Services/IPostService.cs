using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopoServices.Domain;

namespace TopoServices.Services
{
    public interface IPostService
    {
        List<PostEntity> GetAllPosts();

        PostEntity GetPostById(Guid postId);

        Guid CreatePost(PostEntity newPost);

        bool UpdatePost(PostEntity postToUpdate);

        bool DeletePost(Guid postId);
    }
}
