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

namespace MindSwap.Application.Features.CommentFeature.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler: IRequestHandler<DeleteCommentCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository) =>
            _commentRepository = commentRepository;

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
           var commentToDelete = await _commentRepository.GetByIdAsync(request.Id) ??
                      throw new NotFoundException(nameof(Comment), request.Id);
           await _commentRepository.DeleteAsync(commentToDelete);
           return Unit.Value;
        }
    }
}
