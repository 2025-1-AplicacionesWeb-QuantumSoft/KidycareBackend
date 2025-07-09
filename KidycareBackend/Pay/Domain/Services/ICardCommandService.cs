using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Commands;

namespace KidycareBackend.Pay.Domain.Services;

public interface ICardCommandService
{
    Task<Card?> Handle(CreateCardCommand command);
    Task<bool> Handle(DeleteCardByIdCommand byIdCommand);
    Task<Card> Handle(UpdateCardByIdCommand command, long cardId);

    
}