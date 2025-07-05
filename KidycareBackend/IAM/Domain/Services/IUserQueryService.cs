using KidycareBackend.IAM.Domain.Model.Aggregates;
using KidycareBackend.IAM.Domain.Model.Queries;

namespace KidycareBackend.IAM.Domain.Services;

/**
 * <summary>
 *     The user query service interface.
 * </summary>
 * <remarks>
 *     The interface is used to handle user queries in the system.
 * </remarks>
 */
public interface IUserQueryService
{
    /**
     * <summary>
     *     Handles the query to get a user by ID.
     * </summary>
     * <param name="query">The query containing the user ID.</param>
     * <returns>The user with the specified ID, or null if not found.</returns>
     */
    Task<User?> Handle(GetUserByIdQuery query);
    
    /**
     * <summary>
     *     Handles the query to get a user by username.
     * </summary>
     * <param name="query">The query containing the username.</param>
     * <returns>The user with the specified username, or null if not found.</returns>
     */
    Task<User?> Handle(GetUserByUsernameQuery query);
    
    /**
     * <summary>
     *     Handles the query to get all users.
     * </summary>
     * <param name="query">The query to get all users.</param>
     * <returns>A collection of all users.</returns>
     */
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
}