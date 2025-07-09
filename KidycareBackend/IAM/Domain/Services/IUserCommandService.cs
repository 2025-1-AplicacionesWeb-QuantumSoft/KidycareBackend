using KidycareBackend.IAM.Domain.Model.Aggregates;
using KidycareBackend.IAM.Domain.Model.Commands;

namespace KidycareBackend.IAM.Domain.Services;
/**
 * <summary>
 *      The user command service interface.
 * </summary>
 * <remarks>
 *      The interface is used to handle user commands in the system.
 * </remarks>
 */
public interface IUserCommandService
{
    /**
     * <summary>
     *      Handles the sign-in command.
     * </summary>
     * <param name="command">The sign-in command.</param>
     * <returns>The authenticated user and the JWT token</returns>
     */
    Task<(User user, string token)> Handle(SignInCommand command);
    
    
    /**
     * <summary>
     *      Handles the sign-up command.
     * </summary>
     * <param name="command">The sign-up command.</param>
     * <returns>A task representing the asynchronous operation.</returns>
     */
    Task Handle(SignUpCommand command);
}