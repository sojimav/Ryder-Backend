namespace Ryder.Infrastructure.Interface
{
    public interface ICurrentUserService
    {
        string? UserId { get; }
        string? UserRole { get; }
        string? UserEmail { get; }
        string? UserPhoneNumber { get; set; }
        string FullName { get; }
    }
}