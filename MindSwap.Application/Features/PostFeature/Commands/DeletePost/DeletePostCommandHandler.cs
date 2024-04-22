using AutoMapper;
using MediatR;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Exceptions;
using MindSwap.Application.Features.CategoryFeature.Commands.DeleteCategory;
using MindSwap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Application.Features.PostFeature.Commands.DeletePost
{
    public class DeletePostCommandHandler: IRequestHandler<DeletePostCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public DeletePostCommandHandler(IPostRepository postRepository) =>
            _postRepository = postRepository;

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
           var postToDelete = await _postRepository.GetByIdAsync(request.Id) ??
                      throw new NotFoundException(nameof(Post), request.Id);

           await _postRepository.DeleteAsync(postToDelete);
            return Unit.Value;
        }
    }
}
