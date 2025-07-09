using KidycareBackend.IAM.Domain.Model.Aggregates;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.IAM.Domain.Repositories;

/**
 * <summary>
 *     The user repository interface.
 * </summary>
 * <remarks>
 *     This interface defines the contract for user repository operations.
 * </remarks>
 */
public interface IUserRepository : IBaseRepository<User>
{
 
    /**
     * <summary>
     *     Finds a user by their username.
     * </summary>
     * <param name="username">The username of the user to find.</param>
     * <returns>A task that represents the asynchronous operation,
     *          containing the user if found, otherwise null.
     * </returns>
     */
    Task<User?> FindByUsernameAsync(string username);
    
    /**
     * <summary>
     *     Checks if a user exists by their username.
     * </summary>
     * <param name="username">The username to check for existence.</param>
     * <returns>A boolean indicating whether the user exists.</returns>
     */
    bool ExistsByUsername(string username);
}