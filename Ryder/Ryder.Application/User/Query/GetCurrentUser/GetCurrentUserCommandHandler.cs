using AspNetCoreHero.Results;
using MediatR;
using Ryder.Infrastructure.Interface;

namespace Ryder.Application.User.Query.GetCurrentUser
{
    public class GetCurrentUserCommandHandler : IRequestHandler<GetCurrentUserCommand, IResult<GetCurrentUserResponse>>
    {
        private readonly ICurrentUserService _currentUserService;

        public GetCurrentUserCommandHandler(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<IResult<GetCurrentUserResponse>> Handle(GetCurrentUserCommand request,
            CancellationToken cancellationToken)
        {
            return await Result<GetCurrentUserResponse>.SuccessAsync(new GetCurrentUserResponse()
            {
                UserPhoneNumber = _currentUserService.UserPhoneNumber,
                UserId = _currentUserService.UserId,
                UserRole = _currentUserService.UserRole,
                UserEmail = _currentUserService.UserEmail,
                FullName = _currentUserService.FullName,
            });
        }
    }
}