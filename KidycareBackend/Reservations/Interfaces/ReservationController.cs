using System.Net.Mime;
using KidycareBackend.Reservations.Domain.Model.Commands;
using KidycareBackend.Reservations.Domain.Model.Queries;
using KidycareBackend.Reservations.Domain.Services;
using KidycareBackend.Reservations.Interfaces.Resources;
using KidycareBackend.Reservations.Interfaces.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KidycareBackend.Reservations.Interfaces;

[ApiController] // Indicates that this class is an API controller
[Route("api/v1/[controller]")] // Defines the route for the controller
[Produces(MediaTypeNames.Application.Json)] // Specifies that the API produces JSON responses
[Tags("Favorite Sources")] // Adds a tag for grouping in Swagger documentation
public class ReservationController(
    IReservationCommandService reservationCommandService, IReservationQueryService reservationQueryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a reservation",
        Description = "Creates a specific reservation with.....",
        OperationId = "CreateReservationSource")]
    [SwaggerResponse(201, 
        "The reservation was created.", typeof(ReservationResource))]
    [SwaggerResponse(400, 
        "The reservation was not created.")]
    public async Task<ActionResult> CreateFavoriteSource([FromBody] CreateReservationResource resource)
    {
        var createReservationCommand =
            CreateReservationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await reservationCommandService.handle(createReservationCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetReservationById), new { id = result.Id },
            ReservationResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a reservation by ID",
        Description = "Retrieves a specific reservation using its unique identifier.",
        OperationId = "GetReservationById")]
    [SwaggerResponse(StatusCodes.Status200OK, 
        "The reservation was found and returned successfully.", typeof(ReservationResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "The reservation with the specified ID was not found.")]
    public async Task<ActionResult> GetReservationById(int id)
    {
        var getReservationByIdQuery = new GetReservationByIdQuery(id);
        var result = await reservationQueryService.handle(getReservationByIdQuery);
        if (result is null) return NotFound();
        var resource =
            ReservationResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet("{babysitterId}")]
    [SwaggerOperation(
        Summary = "Get all reservations by Babysitter ID",
        Description = "Retrieves a list of all reservations by Babysitter ID.",
        OperationId = "GetAllReservations")]
    [SwaggerResponse(StatusCodes.Status200OK, 
        "Returns all available reservations", typeof(IEnumerable<ReservationResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "No reservations were found.")]
    public async Task<ActionResult<IEnumerable<ReservationResource>>> GetAllReservationsByBabysitterId(int babysitterId)
    {
        var getAllReservationsQuery = new GetAllReservationByBabysitterIdQuery(babysitterId);
        var result = await reservationQueryService.handle(getAllReservationsQuery);
        if (result is null) return NotFound();
        var resources = result.Select(ReservationResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{parentId}")]
    [SwaggerOperation(
        Summary = "Get all reservations by Parent ID",
        Description = "Retrieves a list of all reservations by Parent ID.",
        OperationId = "GetAllReservations")]
    [SwaggerResponse(StatusCodes.Status200OK, 
        "Returns all available reservations", typeof(IEnumerable<ReservationResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "No reservations were found.")]
    public async Task<ActionResult<IEnumerable<ReservationResource>>> GetAllReservationsByParentId(int parentId)
    {
        var getAllReservationsQuery = new GetAllReservationByParentIdQuery(parentId);
        var result = await reservationQueryService.handle(getAllReservationsQuery);
        if (result is null) return NotFound();
        var resources = result.Select(ReservationResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update a reservation by ID",
        Description = "Updates a specific reservation using its unique identifier.",
        OperationId = "UpdateReservationById")]
    [SwaggerResponse(StatusCodes.Status200OK, 
        "The reservation was successfully updated.", typeof(ReservationResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "The reservation with the specified ID was not found.")]
    public async Task<ActionResult> UpdateReservationById(int id)
    {
        var getReservationByIdQuery = new GetReservationByIdQuery(id);
        var result = await reservationQueryService.handle(getReservationByIdQuery);
        if (result is null) return NotFound();
        var updateReservationCommand = new UpdateReservationByIdCommand(result);
        var updatedResult = await reservationCommandService.handle(updateReservationCommand);
        
        if (updatedResult is null) return BadRequest();
        var resource = ReservationResourceFromEntityAssembler.ToResourceFromEntity(updatedResult);
        return Ok(resource);
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a reservation by ID",
        Description = "Deletes a specific reservation using its unique identifier.",
        OperationId = "DeleteReservationById")]
    [SwaggerResponse(StatusCodes.Status204NoContent, 
        "The reservation was successfully deleted.")]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "The reservation with the specified ID was not found.")]
    public async Task<ActionResult> DeleteReservationById(int id)
    {
        var getReservationByIdQuery = new GetReservationByIdQuery(id);
        var result = await reservationQueryService.handle(getReservationByIdQuery);
        if (result is null) return NotFound();
        
        var deleteReservationCommand = new DeleteReservationByIdCommand(result.Id);
        var deleteResult = await reservationCommandService.handle(deleteReservationCommand);
        
        if (!deleteResult) return BadRequest();
        
        return NoContent(); // 204 No Content
    }
}