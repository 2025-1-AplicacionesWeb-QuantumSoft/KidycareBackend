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
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all cards",
        Description = "Retrieves a list of all cards",
        OperationId = "GetAllCards"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns all available cards ",typeof(IEnumerable<CardResource>))]
    public async Task<IActionResult> GetAllCards()
    {
        var cards = await cardQueryService.Handle(new GetAllCardQuery());
        var cardsResources = cards.Select(CardResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(cardsResources);
    }
    
    [HttpGet("{CardId:int}")]
    [SwaggerOperation(
        Summary = "Get Card by UserId",
        Description = "Retrieves a Card available in the KidyCare Platform.",
        OperationId = "GetCardByUserId")
    ]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a Card", typeof(CardResource))]
    public async Task<IActionResult> GetCardByUserId(int userId)
    {
        var getCardByUserIdQuery = new GetAllCardByUserIdQuery(userId);
        var cards = await cardQueryService.Handle(getCardByUserIdQuery);
        var card = cards.FirstOrDefault();
        if (card is null)
        {
            return NotFound();
        }

        var cardResource = CardResourceFromEntityAssembler.ToResourceFromEntity(card);
        return Ok(cardResource);
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
        var createCardCommand = CreateCardCommandFromResourceAssembler.ToCommandFromResource(resource);
        var card = await cardCommandService.Handle(createCardCommand);
        if(card is null) return BadRequest();
        var cardResource = CardResourceFromEntityAssembler.ToResourceFromEntity(card);
        return CreatedAtAction("GetCard", new { id = card.Id }, cardResource);
    }

    
    
}