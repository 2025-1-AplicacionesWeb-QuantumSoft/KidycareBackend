using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Commands;
using KidycareBackend.Pay.Domain.Model.ValueObjects;
using KidycareBackend.Pay.Domain.Repositories;
using KidycareBackend.Pay.Domain.Services;
using KidycareBackend.Profiles.Interfaces.ACL;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Pay.Application.Internal.CommandServices;

public class CardCommandService(ICardRepository cardRepository, IProfilesContextFacade profilesContextFacade, IUnitOfWork unitOfWork): ICardCommandService
{
    public async Task<Card?> Handle(CreateCardCommand command)
    {
        // Validación: Solo uno de ParentId o BabysitterId debe ser no nulo
        if (command.ParentId.HasValue && command.BabysitterId.HasValue)
        {
            throw new InvalidOperationException("Only one of ParentId or BabysitterId can be provided. este mensaje es de CardCOmmandService");
        }

        // Validación: Al menos uno de ParentId o BabysitterId debe ser no nulo
        if (!command.ParentId.HasValue && !command.BabysitterId.HasValue)
        {
            throw new InvalidOperationException("Either ParentId or BabysitterId must be provided.");
        }
        
        if (command.ParentId.HasValue)
        {
            var parentExists = await profilesContextFacade.ExistsParentWithIdAsync(command.ParentId.Value);
            if (!parentExists)
            {
                throw new InvalidOperationException("The provided ParentId does not exist.");
            }
        }
        else if (command.BabysitterId.HasValue)
        {
            var babysitterExists = await profilesContextFacade.ExistsBabysitterWithIdAsync(command.BabysitterId.Value);
            if (!babysitterExists)
            {
                throw new InvalidOperationException("The provided BabysitterId does not exist.");
            }
        }
        
        var card = new Card(command);
        try
        {
            await cardRepository.AddAsync(card);
            await unitOfWork.CompleteAsync();
            return card;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error creating card: {e.Message}");
            throw new Exception("An error occurred while creating the card.", e);
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

    public async Task<Card> Handle(UpdateCardByIdCommand command, long cardId)
    {
        var cardExisting = await cardRepository.GetCardById(cardId);
        if (cardExisting == null)
            throw new Exception("Card not found");

        try
        {
            if (!string.IsNullOrEmpty(command.NumberCard) && command.NumberCard.Length == 16)
            {
                // Asignar el número de tarjeta si tiene 16 dígitos
                cardExisting.CardNumber = new RCardNumber(command.NumberCard);
            }
            
            if (!string.IsNullOrEmpty(command.CardHolder))
            {
                cardExisting.CardHolder = command.CardHolder;
            }
            
            if (command.Year != 0 && command.Month != 0)
            {
                cardExisting.ExpirationDate = new ExpirationDateCard(command.Month, command.Year);
            }
            
            await cardRepository.UpdateCard(cardExisting);
            await unitOfWork.CompleteAsync();
            return cardExisting;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

}