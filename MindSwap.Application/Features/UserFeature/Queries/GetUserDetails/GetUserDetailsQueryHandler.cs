using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Application.Features.PostFeature.Queries.GetPostDetails;

namespace MindSwap.Application.Features.UserFeature.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserDetailsQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task<UserDetailsDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUser(request.Id);
            return _mapper.Map<UserDetailsDto>(user);
        }
    }
}
