using AutoMapper;
using MindSwap.Application.Features.CategoryFeature.Commands.CreateCategory;
using MindSwap.Application.Features.CategoryFeature.Commands.UpdateCategory;
using MindSwap.Application.Features.CategoryFeature.Queries.GetAllCategories;
using MindSwap.Application.Features.CategoryFeature.Queries.GetCategoryDetails;
using MindSwap.Application.Features.PostFeature.Commands.CreatePost;
using MindSwap.Application.Features.PostFeature.Commands.UpdatePost;
using MindSwap.Application.Features.PostFeature.Queries.GetAllPosts;
using MindSwap.Application.Features.PostFeature.Queries.GetPostDetails;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.MappingProfiles
{
    public class PostProfile: Profile
    {
        public PostProfile()
        {
            CreateMap<PostDto, Post>().ReverseMap();
            CreateMap<Post, PostDetailsDto>().ReverseMap();
            CreateMap<CreatePostCommand, Post>();
            CreateMap<UpdatePostCommand, Post>();
        }
    }
}
