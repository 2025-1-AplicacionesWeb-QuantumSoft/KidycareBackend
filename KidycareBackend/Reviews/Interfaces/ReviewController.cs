using System.Net.Mime;
using KidycareBackend.Reviews.Domain.Model.Aggregates;
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
    [SwaggerOperation(Summary = "Crea una review", Description = "Crea una nueva review para un usuario", OperationId = "CreateReview")]
    [SwaggerResponse(201, "La review fue creada", typeof(ReviewResource))]
    [SwaggerResponse(400, "La review no fue creada")]
    public async Task<ActionResult> CreateReview([FromBody] CreateReviewResource resource)
    {
        var createCommand = CreateReviewCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _reviewCommandService.Handle(createCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetReviewById), new { id = result.reviewId },
            ReviewResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obtiene una review por ID", Description = "Recupera una review usando su identificador único", OperationId = "GetReviewById")]
    [SwaggerResponse(200, "La review fue encontrada", typeof(ReviewResource))]
    public async Task<ActionResult> GetReviewById(string id)
    {
        var query = new GetReviewByIdQuery(id);
        var result = await _reviewQueryService.Handle(query);
        if (result is null) return NotFound();
        var resource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [NonAction]
    private async Task<ActionResult> GetAllReviewsByReviewApiKey(string reviewApiKey)
    {
        var query = new GetAllReviewsByParentIdQuery(reviewApiKey);
        var result = await _reviewQueryService.Handle(query);
        var resources = result.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [NonAction]
    private async Task<ActionResult> GetReviewByApiKeyAndReviewId(string reviewApiKey, string reviewId)
    {
        var query = new GetReviewsByBabysitterIdQuery(reviewApiKey, reviewId);
        var result = await _reviewQueryService.Handle(query);
        if (result is null) return NotFound();
        var resource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Obtiene reviews según parámetros de consulta",
        Description = "Consulta reviews por API key o por API key y reviewId",
        OperationId = "GetReviewFromQuery")]
    [SwaggerResponse(200, "Review(s) encontrada(s)", typeof(ReviewResource))]
    public async Task<ActionResult> GetReviewFromQuery([FromQuery] string? reviewApiKey = null, [FromQuery] string? reviewId = null)
    {
        if (string.IsNullOrEmpty(reviewApiKey)) return BadRequest("Falta reviewApiKey");

        return string.IsNullOrEmpty(reviewId)
            ? await GetAllReviewsByReviewApiKey(reviewApiKey)
            : await GetReviewByApiKeyAndReviewId(reviewApiKey, reviewId);
    }
}