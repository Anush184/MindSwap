using AutoMapper;
using MindSwap.Application.Features.CategoryFeature.Commands.CreateCategory;
using MindSwap.Application.Features.CategoryFeature.Commands.UpdateCategory;
using MindSwap.Application.Features.CategoryFeature.Queries.GetAllCategories;
using MindSwap.Application.Features.CategoryFeature.Queries.GetCategoryDetails;
using MindSwap.Application.Features.CommentFeature.Commands.CreateComment;
using MindSwap.Application.Features.CommentFeature.Commands.UpdateComment;
using MindSwap.Application.Features.CommentFeature.Queries.GetAllComments;
using MindSwap.Application.Features.CommentFeature.Queries.GetCommentDetails;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.MappingProfiles
{
    public class CommentProfile: Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentDto, Comment>().ReverseMap();
            CreateMap<CommentDetailsDto, Comment>().ReverseMap();
            CreateMap<CreateCommentCommand, Comment>();
            CreateMap<UpdateCommentCommand, Comment>();
        }
    }
}
