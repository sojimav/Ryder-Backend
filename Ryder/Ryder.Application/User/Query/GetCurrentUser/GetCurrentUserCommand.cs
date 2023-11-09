using AspNetCoreHero.Results;
using FluentValidation;
using MediatR;

namespace Ryder.Application.User.Query.GetCurrentUser
{
    public class GetCurrentUserCommand : IRequest<IResult<GetCurrentUserResponse>>
    {
    }

    public class GetCurrentUserCommandValidator : AbstractValidator<GetCurrentUserCommand>
    {
        public GetCurrentUserCommandValidator()
        {
        }
    }
}