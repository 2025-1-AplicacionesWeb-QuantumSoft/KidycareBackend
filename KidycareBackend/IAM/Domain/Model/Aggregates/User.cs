using System.Text.Json.Serialization;

namespace KidycareBackend.IAM.Domain.Model.Aggregates;

/**
 * <summary>
 *      Represents a user in the IAM system.
 * </summary>
 * <remarks>
 *      This class is used to represent a user within the Identity and Access Management (IAM)
 *      system of the Learning Center Platform.
 * </remarks>
 */
public class User(string username, string passwordHash, string role)
{
    public User() : this(String.Empty, String.Empty, String.Empty)
    {
    }
    
    public int Id { get; }

    public string Username { get; private set; } = username;
    
    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;

    public string role { get; set; } = role;
    
    /**
     * <summary>
     *      Updates the username of the user.
     * </summary>
     * <param name="username">The new username</param>
     * <returns>Te updated user</returns>
     */
    public User UpdateUsername(string username)
    {
        Username = username;
        return this;
    }
    public User UpdateRole(string role)
    {
        role = ValidateRole(role);
        return this;
    }
    private string ValidateRole(string role)
    {
        if (role != "babysitter" && role != "parent")
            throw new ArgumentException("Role must be 'babysitter' or 'parent'");
        return role;
    }
    /**
 * <summary>
 *      Updates the password of the user.
 * </summary>
 * <param name="passwordHash">The new password hash</param>
 * <returns>Te updated user</returns>
 */
    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }
}