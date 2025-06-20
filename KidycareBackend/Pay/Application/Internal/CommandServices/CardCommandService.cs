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
        try
        {
            await cardRepository.AddAsync(card);
            await unitOfWork.CompleteAsync();
            return card;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> Handle(DeleteCardByIdCommand command)
    {
        var card = await cardRepository.GetCardById(command.Id);
        if (card == null)
            throw new Exception("No Card found");
        try
        {
            await cardRepository.DeleteCard(card.Id);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        return true;
    }

    public async Task<Card> Handle(UpdateCardByIdCommand byIdCommand)
    {
        var card = await cardRepository.GetCardById(byIdCommand.Id);
        if (card == null)
        {
            throw new Exception("No Card found");
        }

        try
        {
            await cardRepository.UpdateCard(card);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
        return card;
    }
}