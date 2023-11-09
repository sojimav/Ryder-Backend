namespace Ryder.Application.User.Query.GetCurrentUser
{
    public class GetCurrentUserResponse
    {
        public string UserId { get; init; }
        public string UserRole { get; init; }
        public string UserEmail { get; init; }
        public string FullName { get; init; }
        public string UserPhoneNumber { get; set; }
    }
}