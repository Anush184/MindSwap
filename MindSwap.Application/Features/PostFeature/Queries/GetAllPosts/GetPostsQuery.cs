﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Queries.GetAllPosts
{
    public class GetPostsQuery:IRequest<List<PostDto>>
    {
    }
}
