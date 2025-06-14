using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Commands;

namespace KidycareBackend.Pay.Domain.Services;

public interface ICardCommandService
{
    public Task<Card?> Handle(CreateCardCommand command);
}