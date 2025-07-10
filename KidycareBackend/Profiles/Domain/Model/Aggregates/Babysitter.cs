using KidycareBackend.Profiles.Domain.Model.Commands;
using KidycareBackend.Profiles.Domain.Model.ValueObjects;

namespace KidycareBackend.Profiles.Domain.Model.Aggregates;

public partial class Babysitter
{
    public int id { get; private set; }

    public UserId UserId { get; private set; }
    
    public string name { get; set; }
    
    public string phone { get; set; }
    
    public string description { get; set; }
    
    public string languages { get; set; }
    
    public int rating { get; set; } 
    
    public string location { get; set; } 
    
    public string accountBank { get; set; } 
    public string bankName { get; set; } 
    
    public string typeAccountBank { get; set; } 
    
    public string dni { get; set; } 

    public string ExperienceLevel { get; set; }

    public bool IsAvailable { get; set; }
    

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

    public void UpdateBabysitter(UpdateBabysitterCommand command)
    {
        description = command.Description;
        name = command.Name;
        phone = command.Phone;
        languages = command.Languages;
        rating = command.Rating;
        location = command.Location;
        accountBank = command.AccountBank;
        bankName = command.BankName;
        typeAccountBank = command.TypeAccountBank;
        dni = command.Dni;
    }
}