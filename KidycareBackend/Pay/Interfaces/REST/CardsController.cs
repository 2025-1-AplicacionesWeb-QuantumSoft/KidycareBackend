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
    
    [HttpGet("{cardId:long}")]
    [SwaggerOperation(
        Summary = "Get Card by CardId",
        Description = "Retrieves a Card available in the KidyCare Platform.",
        OperationId = "GetCardById")
    ]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a Card", typeof(CardResource))]
    [SwaggerResponse(statusCode:400, "The card was not found")]
    public async Task<IActionResult> GetCardById(long cardId)
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
    
    [HttpGet("parent/{parentId:int}")]
    [SwaggerOperation(
        Summary = "Get all parentId",
        Description = "Retrieves a list of all cards by ParentId",
        OperationId = "GetAllCardsByParentId"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns all available cards ",typeof(IEnumerable<CardResource>))]
    [SwaggerResponse(404, "The parentID were not found")]
    public async Task<IActionResult> GetAllCardsByParentId(int parentId)
    {
        var getAllCardsByParentIdQuery = new GetAllCardByParentIdQuery(parentId);
        var cards= await cardQueryService.Handle(getAllCardsByParentIdQuery);
        var cardsResource=cards.Select(CardResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(cardsResource);
    }
    
    [HttpGet("babysitter/{babysitterId:int}")]
    [SwaggerOperation(
        Summary = "Get all babysitterId",
        Description = "Retrieves a list of all cards by BabysitterId",
        OperationId = "GetAllCardsByBabysitterId"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns all available cards ",typeof(IEnumerable<CardResource>))]
    [SwaggerResponse(404, "The BabysitterId were not found")]
    public async Task<IActionResult> GetAllCardsByBabysitterId(int babysitterId)
    {
        var getAllCardsByBabysitterIdQuery = new GetAllCardByBabysitterIdQuery(babysitterId);
        var cards= await cardQueryService.Handle(getAllCardsByBabysitterIdQuery);
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
        int? parentId = resource.ParentId == 0 ? (int?)null : resource.ParentId;
        int? babysitterId = resource.BabysitterId == 0 ? (int?)null : resource.BabysitterId;
        
        // Validamos que solo uno de los dos (ParentId o BabysitterId) sea no nulo
        if (parentId.HasValue && babysitterId.HasValue)
        {
            return BadRequest("Only one of ParentId or BabysitterId can be provided.");
        }

        // Validamos que al menos uno de los dos valores esté presente
        if (!parentId.HasValue && !babysitterId.HasValue)
        {
            return BadRequest("Either ParentId or BabysitterId must be provided.");
        }
        
        var createCardCommand = CreateCardCommandFromResourceAssembler.ToCommandFromResource(resource);
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
    public async Task<ActionResult> UpdateCardById( long id, [FromBody] UpdateCardResource resource)
    {
        var getCardByIdQuery = new GetCardByIdQuery(id);
        var result = await cardQueryService.Handle(getCardByIdQuery);
        if (result is null) return NotFound();
        var updateCardCommand =  UpdateCardByIdCommandFromResourceAssembler.ToCommandFromResource(resource, id);
        var updatedResult = await cardCommandService.Handle(updateCardCommand,id);
        
        if (updatedResult is null) return BadRequest();
        var updateResource = CardResourceFromEntityAssembler.ToResourceFromEntity(updatedResult);
        return Ok(updateResource);
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