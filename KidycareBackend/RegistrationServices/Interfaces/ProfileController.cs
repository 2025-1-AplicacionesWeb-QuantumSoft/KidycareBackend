using System.Net.Mime;
using KidycareBackend.RegistrationServices.Domain.Model.Commands;
using KidycareBackend.RegistrationServices.Domain.Model.Queries;
using KidycareBackend.RegistrationServices.Domain.Services;
using KidycareBackend.RegistrationServices.Interfaces.Resources;
using KidycareBackend.RegistrationServices.Interfaces.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KidycareBackend.RegistrationServices.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Profiles")]
public class ProfileController(
    IProfileQueryService profileQueryService,
    IProfileCommandService profileCommandService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a profile",
        Description = "Creates a new profile for a user",
        OperationId = "CreateProfile")]
    [SwaggerResponse(201, "The profile was created", typeof(ProfileResource))]
    [SwaggerResponse(400, "The profile was not created")]
    public async Task<ActionResult> CreateProfile([FromBody] CreateProfileResource resource)
    {
        var createCommand = CreateProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await profileCommandService.Handle(createCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetProfileById), new { id = result.Id },
            ProfileResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a profile by ID",
        Description = "Retrieves a specific profile using its unique identifier",
        OperationId = "GetProfileById")]
    [SwaggerResponse(200, "The profile was found", typeof(ProfileResource))]
    public async Task<ActionResult> GetProfileById(int id)
    {
        var query = new GetProfileByIdQuery(id);
        var result = await profileQueryService.Handle(query);
        if (result is null) return NotFound();
        var resource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    private async Task<ActionResult> GetAllProfilesByProfileApiKey(string profileApiKey)
    {
        var query = new GetAllProfileByProfileApiKeyQuery(profileApiKey);
        var result = await profileQueryService.Handle(query);
        var resources = result.Select(ProfileResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    private async Task<ActionResult> GetProfileByApiKeyAndSourceId(string profileApiKey, string sourceId)
    {
        var query = new GetProfileByProfileApiKeyAndSourceIdQuery(profileApiKey, sourceId);
        var result = await profileQueryService.Handle(query);
        if (result is null) return NotFound();
        var resource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets a profile based on query parameters",
        Description = "Query profile by API key or both API key and Source ID",
        OperationId = "GetProfileFromQuery")]
    [SwaggerResponse(200, "Profile(s) found", typeof(ProfileResource))]
    public async Task<ActionResult> GetProfileFromQuery(
        [FromQuery] string? profileApiKey = null,
        [FromQuery] string? sourceId = null)
    {
        return string.IsNullOrEmpty(sourceId)
            ? await GetAllProfilesByProfileApiKey(profileApiKey!)
            : await GetProfileByApiKeyAndSourceId(profileApiKey!, sourceId);
    }
}
