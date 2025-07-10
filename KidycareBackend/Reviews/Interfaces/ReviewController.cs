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

        return CreatedAtAction(nameof(GetReviewById), new { id = result },
            ReviewResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Obtiene una review por ID",
        Description = "Recupera una review usando su identificador único",
        OperationId = "GetReviewById")]
    [SwaggerResponse(200, "La review fue encontrada", typeof(ReviewResource))]
    [SwaggerResponse(404, "No se encontró la review")]
    public async Task<ActionResult> GetReviewById(int id)
    {
        var query = new GetReviewByIdQuery(id);
        var result = await _reviewQueryService.Handle(query);
        if (result is null) return NotFound();

        var resources = result.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    private async Task<ActionResult> GetAllReviewsByParentId(int parentId)
    {
        var query = new GetAllReviewsByParentIdQuery(parentId);
        var result = await _reviewQueryService.Handle(query);
        var resources = result.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    private async Task<ActionResult> GetReviewsByBabysitterId(int babysitterId)
    {
        var query = new GetReviewsByBabysitterIdQuery(babysitterId);
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
        [FromQuery] int? parentId = 0,
        [FromQuery] int? babysitterId = 0)
    {
        if (parentId.HasValue)
            return await GetAllReviewsByParentId(parentId.Value);

        if (babysitterId.HasValue)
            return await GetReviewsByBabysitterId(babysitterId.Value);

        return BadRequest("Debe proporcionar 'parentId' o 'babysitterId'");
    }
}