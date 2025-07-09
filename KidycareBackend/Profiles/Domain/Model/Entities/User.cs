using KidycareBackend.Profiles.Domain.Model.Commands;
using KidycareBackend.Profiles.Domain.Model.ValueObjects;

namespace KidycareBackend.Profiles.Domain.Model.Entities;

public partial class User
{
    public int Id  { get; }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get;private  set; }
    public string Password { get;private set; }
    public string Phone { get;private  set; }
    public RoleType Role { get;private  set; }
    
    
    public string FullName => Name.FullName;
    public string EmailAddress => Email.Address;

    public User()
    {
        Name = new PersonName();
        Email = new EmailAddress();
        Password = String.Empty;
        Phone = String.Empty;
    }

    public User(string firstName, string lastName, string emailAddress, string password, string phone, RoleType role)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(emailAddress);
        Password = password;
        Phone = phone;
        Role = role;
    }

    public User(CreateUserCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.EmailAddress);
        Password = command.Password;
        Phone = command.Phone;
        Role = command.Role;
    }

    public void Update(UpdateUserCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.EmailAddress);
        Password = command.Password;
        Phone = command.Phone;
        Role = command.Role;
    }
}