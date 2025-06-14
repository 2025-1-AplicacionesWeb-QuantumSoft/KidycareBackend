using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Commands;
using KidycareBackend.Pay.Domain.Repositories;
using KidycareBackend.Pay.Domain.Services;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Pay.Application.Internal.CommandServices;

public class CardCommandService(ICardRepository cardRepository, IUnitOfWork unitOfWork): ICardCommandService
{
    public async Task<Card?> Handle(CreateCardCommand command)
    {
        var card = new Card(command);
        await cardRepository.AddAsync(card);
        await unitOfWork.CompleteAsync();
        return card;
    }
}