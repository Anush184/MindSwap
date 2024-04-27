using MediatR;
using MindSwap.Application.Features.UserFeature.Shared;

namespace MindSwap.Application.Features.UserFeature.Commands.CreateUser
{
    public class CreateUserCommand: BaseUser, IRequest<Unit>
    {
  
    }
}
