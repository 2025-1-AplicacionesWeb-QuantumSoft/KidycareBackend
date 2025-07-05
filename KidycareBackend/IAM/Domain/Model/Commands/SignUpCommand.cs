namespace KidycareBackend.IAM.Domain.Model.Commands;

/**
 * <summary>
 *     The sign up command.
 * </summary>
 * <remarks>
 *     This command is used to sign up a new user with their username and password.
 * </remarks>
 */
public record SignUpCommand(string Username, string Password);
