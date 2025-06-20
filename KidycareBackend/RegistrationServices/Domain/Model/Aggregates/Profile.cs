using KidycareBackend.RegistrationServices.Domain.Model.Commands;

namespace KidycareBackend.RegistrationServices.Domain.Model.Aggregates;

public class Profile
{
    public int Id { get; set; }
    public int UserId { get; private set; }
    public string Name { get; private set; }
    public string Lastname { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Location { get; private set; }
    public int Experience { get; private set; }
    public string Biography { get; private set; }
    public string About { get; private set; }
    public double Rating { get; private set; }
    
    public string ProfileApiKey { get; private set; }
    public string SourceId { get; private set; }

    protected Profile()
    {
        ProfileApiKey = string.Empty;
        SourceId = string.Empty;
        Name = string.Empty;
        Lastname = string.Empty;
        Email = string.Empty;
        Phone = string.Empty;
        Location = string.Empty;
        Biography = string.Empty;
        About = string.Empty;
    }
    
    public Profile(int userId, string name, string lastname, string email, string phone, string location, int experience, string biography, string about, double rating)
    {
        UserId = userId;
        Name = name;
        Lastname = lastname;
        Email = email;
        Phone = phone;
        Location = location;
        Experience = experience;
        Biography = biography;
        About = about;
        Rating = rating;
        
        ProfileApiKey = string.Empty;
        SourceId = string.Empty;
    }

    public Profile(CreateProfileCommand command)
        : this(
            command.UserId,
            command.Name,
            command.Lastname,
            command.Email,
            command.Phone,
            command.Location,
            command.Experience,
            command.Biography,
            command.About,
            command.Rating)
    {
    }

    public void Update(UpdateProfileCommand command)
    {
        Name = command.Name;
        Lastname = command.Lastname;
        Email = command.Email;
        Phone = command.Phone;
        Location = command.Location;
        Experience = command.Experience;
        Biography = command.Biography;
        About = command.About;
        Rating = command.Rating;
    }
}