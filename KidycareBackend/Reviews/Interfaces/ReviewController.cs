using System.Net.Mime;
using KidycareBackend.Reviews.Domain.Model.Commands;
using KidycareBackend.Reviews.Domain.Model.Queries;
using KidycareBackend.Reviews.Domain.Services;
using KidycareBackend.Reviews.Interfaces.Resources;
using KidycareBackend.Reviews.Interfaces.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KidycareBackend.Reviews.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Reviews")]
public class ReviewController : ControllerBase
{
    private readonly IReviewQueryService _reviewQueryService;
    private readonly IReviewCommandService _reviewCommandService;

    public ReviewController(IReviewQueryService reviewQueryService, IReviewCommandService reviewCommandService)
    {
        _reviewQueryService = reviewQueryService;
        _reviewCommandService = reviewCommandService;
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Crea una review",
        Description = "Crea una nueva review para un usuario",
        OperationId = "CreateReview")]
    [SwaggerResponse(201, "La review fue creada", typeof(ReviewResource))]
    [SwaggerResponse(400, "La review no fue creada")]
    public async Task<ActionResult> CreateReview([FromBody] CreateReviewResource resource)
    {
        var command = CreateReviewCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _reviewCommandService.Handle(command);
        if (result is null) return BadRequest();

        return CreatedAtAction(nameof(GetReviewById), new { Id = result },
            ReviewResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id:int}")]
    [SwaggerOperation(
        Summary = "Obtiene una review por ID",
        Description = "Recupera una review usando su identificador único",
        OperationId = "GetReviewById")]
    [SwaggerResponse(200, "La review fue encontrada", typeof(ReviewResource))]
    [SwaggerResponse(404, "No se encontró la review")]
    public async Task<ActionResult> GetReviewById(int Id)
    {
        var query = new GetReviewByIdQuery(Id);
        var result = await _reviewQueryService.Handle(query);
        if (result is null) return NotFound();

        var resources = ReviewResourceFromEntityAssembler.ToResourceFromEntity;
        return Ok(resources);
    }

    private async Task<ActionResult> GetAllReviewsByParentId(int parentId)
    {
        var query = new GetAllReviewsByParentIdQuery(parentId);
        var result = await _reviewQueryService.Handle(query);
        var resources = result.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    

    [HttpGet]
    [SwaggerOperation(
        Summary = "Consulta reviews por parámetros",
        Description = "Consulta reviews por ParentId o por BabysitterId",
        OperationId = "GetReviewsFromQuery")]
    [SwaggerResponse(200, "Se encontraron reviews", typeof(IEnumerable<ReviewResource>))]
    public async Task<ActionResult> GetReviewsFromQuery(
        [FromQuery] int? parentId = null,
        [FromQuery] int? babysitterId = null)
    {
        if (parentId.HasValue)
            return await GetAllReviewsByParentId(parentId.Value);

        // Puedes agregar lógica similar para babysitterId si lo necesitas

        return BadRequest("Debe proporcionar 'parentId' o 'babysitterId'");
        
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Actualiza una review por ID",
        Description = "Actualiza una review usando su identificador único.",
        OperationId = "UpdateReviewById")]
    [SwaggerResponse(StatusCodes.Status200OK, 
        "La review fue actualizada exitosamente.", typeof(ReviewResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "No se encontró la review con el ID especificado.")]
    public async Task<ActionResult> UpdateReviewById(int Id, [FromBody] UpdateReviewResource resource)
    {
        var getReviewByIdQuery = new GetReviewByIdQuery(Id);
        var result = await _reviewQueryService.Handle(getReviewByIdQuery);
        if (result is null) return NotFound();

        var updateReviewCommand = UpdateReviewByIdCommandFromResourceAssembler.ToCommandFromResource(resource, Id);
        var updatedResult = await _reviewCommandService.Handle(updateReviewCommand, Id);

        if (updatedResult is null) return BadRequest();
        var updateResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(updatedResult);
        return Ok(updateResource);
    }
    
    
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Elimina una review por ID",
        Description = "Elimina una review usando su identificador único.",
        OperationId = "DeleteReviewById")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "La review fue eliminada exitosamente.")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontró la review con el ID especificado.")]
    
    public async Task<ActionResult> DeleteReviewById(int Id)
    {
        var getReviewByIdQuery = new GetReviewByIdQuery(Id);
        var result = await _reviewQueryService.Handle(getReviewByIdQuery);
        if (result is null) return NotFound();

        var deleteReviewCommand = new DeleteReviewByIdCommand(Id);
        var deleteResult = await _reviewCommandService.Handle(deleteReviewCommand);

        if (deleteResult is null) return BadRequest();
        
        return NoContent();
    }
    
    
}