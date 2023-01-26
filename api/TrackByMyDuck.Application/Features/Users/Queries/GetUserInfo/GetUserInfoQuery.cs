using MediatR;

namespace TrackByMyDuck.Application.Features.Users.Queries.GetUserInfo
{
    public class GetUserInfoQuery : IRequest<UserInfoVm>
    {
    }
}