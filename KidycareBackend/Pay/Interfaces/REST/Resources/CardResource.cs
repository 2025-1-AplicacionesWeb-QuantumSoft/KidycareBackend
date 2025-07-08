using KidycareBackend.Pay.Domain.Model.ValueObjects;
using KidycareBackend.Profiles.Domain.Model.ValueObjects;

namespace KidycareBackend.Pay.Interfaces.REST.Resources;

public record CardResource(
    long Id,
    int UserId,
    string NumberCard,
    string CardHolder,
    int Code,
    int Month,   
    int Year
    );