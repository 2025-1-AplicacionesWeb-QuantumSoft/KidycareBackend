namespace KidycareBackend.IAM.Domain.Model.Commands;

/**
 * <summary>
 *     The sign in command.
 * </summary>
 * <remarks>
 *     This command is used to sign in a user with their username and password.
 * </remarks>
 */
public record SignInCommand(string Username, string Password);