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
[Tags("Parent")] // Adds a tag for grouping in Swagger documentation
public class ParentController(
    IParentCommandService parentCommandService, IParentQueryService parentQueryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a Parent",
        Description = "Creates a specific Parent with.....",
        OperationId = "CreateParentSource")]
    [SwaggerResponse(201, 
        "The Parent was created.", typeof(ParentResource))]
    [SwaggerResponse(400, 
        "The Parent was not created.")]
    public async Task<ActionResult> CreateParentSource([FromBody] CreateParentResource resource)
    {
        var createParentCommand =
            CreateParentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await parentCommandService.Handle(createParentCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetParentById), new { id = result.Id },
            ParentResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a Parent by ID",
        Description = "Retrieves a specific Parent using its unique identifier.",
        OperationId = "GetParentById")]
    [SwaggerResponse(StatusCodes.Status200OK, 
        "The Parent was found and returned successfully.", typeof(ParentResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "The Parent with the specified ID was not found.")]
    public async Task<ActionResult> GetParentById(int id)
    {
        var getParentByIdQuery = new GetParentByIdQuery(id);
        var result = await parentQueryService.Handle(getParentByIdQuery);
        if (result is null) return NotFound();
        var resource =
            ParentResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
}