using KidycareBackend.Profiles.Domain.Model.Commands;
using KidycareBackend.Profiles.Domain.Model.ValueObjects;

namespace KidycareBackend.Profiles.Domain.Model.Aggregates;

public partial class Babysitter
{
    public int id { get; private set; }

    public UserId UserId { get; private set; }
    
    public string name { get; private set; }
    
    public string phone { get; private set; }
    
    public string description { get; private set; }
    
    public string languages { get; private set; }
    
    public int rating { get; private set; } 
    
    public string location { get; private set; } 
    
    public string accountBank { get; private set; } 
    public string bankName { get; private set; } 
    
    public string typeAccountBank { get; private set; } 
    
    public string dni { get; private set; } 

    public string ExperienceLevel { get; private set; }

    public bool IsAvailable { get; private set; }
    

    protected Babysitter() { }
    
    public Babysitter(UserId userId, string name, string phone, string description, string languages, int rating, string location,
        string accountBank, string bankName, string typeAccountBank, string dni, string experienceLevel)
    {
        UserId = userId;
        this.name = name;
        this.phone = phone;
        this.description = description;
        this.languages = languages;
        this.rating = rating;
        this.location = location;
        this.accountBank = accountBank;
        this.bankName = bankName;
        this.typeAccountBank = typeAccountBank;
        this.dni = dni;
        ExperienceLevel = experienceLevel;
        IsAvailable = true;
    }

    public Babysitter(CreateBabysitterCommand command)
    {
        UserId = command.UserId;
        description = command.description;
        name = command.name;
        phone = command.phone;
        languages = command.languages;
        rating = command.rating;
        location = command.location;
        accountBank = command.accountBank;
        bankName = command.bankName;
        typeAccountBank = command.typeAccountBank;
        dni = command.dni;
        ExperienceLevel = command.experienceLevel;
        IsAvailable = true;
    }
    
    public void SetAvailability(bool available)
    {
        IsAvailable = available;
    }
}