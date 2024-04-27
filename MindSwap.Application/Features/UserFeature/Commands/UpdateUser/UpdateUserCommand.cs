using MediatR;
using MindSwap.Application.Features.UserFeature.Shared;

namespace MindSwap.Application.Features.PostFeature.Commands.UpdatePost
{
    public class UpdateUserCommand: BaseUser, IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
