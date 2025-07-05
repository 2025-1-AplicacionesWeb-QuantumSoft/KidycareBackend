using System.Net.Mime;
using KidycareBackend.Profiles.Domain.Model.Queries;
using KidycareBackend.Profiles.Domain.Services;
using KidycareBackend.Profiles.Interfaces.REST.Resources;
using KidycareBackend.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KidycareBackend.Profiles.Interfaces.REST;

[ApiController] // Indicates that this class is an API controller
[Route("api/v1/[controller]")] // Defines the route for the controller
[Produces(MediaTypeNames.Application.Json)] // Specifies that the API produces JSON responses
[Tags("Babysitter")] // Adds a tag for grouping in Swagger documentation
public class BabysitterController(
    IBabysitterCommandService babysitterCommandService, IBabysitterQueryService babysitterQueryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a Babysitter",
        Description = "Creates a specific Babysitter with.....",
        OperationId = "CreateBabysitterSource")]
    [SwaggerResponse(201, 
        "The Babysitter was created.", typeof(BabysitterResource))]
    [SwaggerResponse(400, 
        "The Babysitter was not created.")]
    public async Task<ActionResult> CreateBabysitterSource([FromBody] CreateBabysitterResource resource)
    {
        var createBabysitterCommand =
            CreateBabysitterCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await babysitterCommandService.Handle(createBabysitterCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetBabysitterById), new { id = result.id },
            BabysitterResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a Babysitter by ID",
        Description = "Retrieves a specific Babysitter using its unique identifier.",
        OperationId = "GetBabysitterById")]
    [SwaggerResponse(StatusCodes.Status200OK, 
        "The Babysitter was found and returned successfully.", typeof(BabysitterResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "The Babysitter with the specified ID was not found.")]
    public async Task<ActionResult> GetBabysitterById(int id)
    {
        var getBabysitterByIdQuery = new GetBabysitterByIdQuery(id);
        var result = await babysitterQueryService.Handle(getBabysitterByIdQuery);
        if (result is null) return NotFound();
        var resource =
            BabysitterResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all babysitters",
        Description = "Retrieves a list of all babysitters available.",
        OperationId = "GetAllBabysitters")
    ]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns all available tutorials", typeof(IEnumerable<BabysitterResource>))]        
    public async Task<IActionResult> GetAllBabysitters()
    {
        var babysitters = await babysitterQueryService.Handle(new GetAllBabysitterQuery());
        var tutorialsResources = babysitters.Select(BabysitterResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(tutorialsResources);
    }
}