using System.Net.Mime;
using KidycareBackend.Pay.Domain.Model.Aggregates;
using KidycareBackend.Pay.Domain.Model.Commands;
using KidycareBackend.Pay.Domain.Model.Queries;
using KidycareBackend.Pay.Domain.Services;
using KidycareBackend.Pay.Interfaces.REST.Resources;
using KidycareBackend.Pay.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KidycareBackend.Pay.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Operations available for card management on the KidyCare Platform.")]
public class CardsController(
    ICardQueryService cardQueryService,
    ICardCommandService cardCommandService
    ) : ControllerBase
{
    
    [HttpGet("{CardId:int}")]
    [SwaggerOperation(
        Summary = "Get Card by UserId",
        Description = "Retrieves a Card available in the KidyCare Platform.",
        OperationId = "GetCardById")
    ]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a Card", typeof(CardResource))]
    public async Task<IActionResult> GetCardById(int cardId)
    {
        var getCardByIdQuery = new GetCardByIdQuery(cardId);
        var card = await cardQueryService.Handle(getCardByIdQuery);
        if (card == null)
        {
            return NotFound();
        }
        var cardResource = CardResourceFromEntityAssembler.ToResourceFromEntity(card);
        return Ok(cardResource);
    }
    
    [HttpGet()]
    [SwaggerOperation(
        Summary = "Get all cards",
        Description = "Retrieves a list of all cards",
        OperationId = "GetAllCards"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns all available cards ",typeof(IEnumerable<CardResource>))]
    [SwaggerResponse(404, "The profiles were not found")]
    public async Task<IActionResult> GetAllCards()
    {
        var getAllCardsQuery = new GetAllCardQuery();
        var cards= await cardQueryService.Handle(getAllCardsQuery);
        var cardsResource=cards.Select(CardResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(cardsResource);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new card",
        Description = "Create a new card",
        OperationId = "CreateCard")
    ]
    [SwaggerResponse(StatusCodes.Status201Created, "The Card was created", typeof(CardResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Card could not be created")]
    public async Task<IActionResult> CreateCard([FromBody]CreateCardResource resource)
    {
        var createCardCommand = CreateCardCommandFromResourceAssembler.toCommandFromResource(resource);
        var card = await cardCommandService.Handle(createCardCommand);
        if (card == null) return BadRequest();
        var cardResource = CardResourceFromEntityAssembler.ToResourceFromEntity(card);
        return CreatedAtAction(nameof(GetCardById), new { cardid = cardResource.Id }, cardResource);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update a card by ID",
        Description = "Updates a specific card using its unique identifier.",
        OperationId = "UpdateCardById")]
    [SwaggerResponse(StatusCodes.Status200OK, 
        "The card was successfully updated.", typeof(CardResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "The card with the specified ID was not found.")]
    public async Task<ActionResult> UpdateCardById(int id)
    {
        var getCardByIdQuery = new GetCardByIdQuery(id);
        var result = await cardQueryService.Handle(getCardByIdQuery);
        if (result is null) return NotFound();
        var updateCardCommand = new UpdateCardByIdCommand(result.Id);
        var updatedResult = await cardCommandService.Handle(updateCardCommand);
        
        if (updatedResult is null) return BadRequest();
        var resource = CardResourceFromEntityAssembler.ToResourceFromEntity(updatedResult);
        return Ok(resource);
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a card by ID",
        Description = "Deletes a specific card using its unique identifier.",
        OperationId = "DeleteCardById")]
    [SwaggerResponse(StatusCodes.Status204NoContent, 
        "The card was successfully deleted.")]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "The card with the specified ID was not found.")]
    public async Task<ActionResult> DeleteCardById(int id)
    {
        var getCardByIdQuery = new GetCardByIdQuery(id);
        var result = await cardQueryService.Handle(getCardByIdQuery);
        if (result is null) return NotFound();
        var deleteCardCommand = new DeleteCardByIdCommand(result.Id);
        var deleteResult = await cardCommandService.Handle(deleteCardCommand);
        
        if (!deleteResult) return BadRequest();
        
        return NoContent(); // 204 No Content
    }
    
}