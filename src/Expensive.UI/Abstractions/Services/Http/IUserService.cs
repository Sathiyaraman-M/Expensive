using Expensive.Common.Contracts.Users;
using Expensive.Common.Wrappers;
using Expensive.Common.Wrappers.Abstractions;

namespace Expensive.UI.Abstractions.Services.Http;

public interface IUserService
{
    Task<PaginatedResult<UserResponse>> GetAllUsersAsync(int pageNumber, int pageSize, string searchText, CancellationToken cancellationToken = default);
    
    Task<IResult<UserResponse>> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<IResult<List<string>>> GetUserPermissionsAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<IResult> CreateUserAsync(CreateUserRequest model);
    
    Task<IResult> UpdateUserAsync(Guid id, UpdateUserRequest model);
    
    Task<IResult> UpdateUserPermissionsAsync(Guid id, UpdateUserPermissionsRequest model);
    
    Task<IResult> DeleteUserAsync(Guid id);
}