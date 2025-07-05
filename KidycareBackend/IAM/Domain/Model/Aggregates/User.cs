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
public class User(string username, string passwordHash)
{
    public User() : this(String.Empty, String.Empty)
    {
    }
    
    public int Id { get; }

    public string Username { get; private set; } = username;
    
    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;
    
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