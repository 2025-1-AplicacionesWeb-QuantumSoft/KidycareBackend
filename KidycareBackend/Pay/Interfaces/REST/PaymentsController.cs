using System.Net.Mime;
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
[SwaggerTag("Operations available for Payment management on the KidyCare Platform.")]
public class PaymentsController(IPaymentQueryService paymentQueryService,
    IPaymentCommandService paymentCommandService):ControllerBase
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all payments",
        Description = "Retrieves a list of all Payments",
        OperationId = "GetAllPayment"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns all available Payments ",typeof(IEnumerable<PaymentResource>))]
    public async Task<IActionResult> GetAllPayments()
    {
        var payments = await paymentQueryService.Handle(new GetAllPaymentQuery());
        var paymentsResources = payments.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(paymentsResources);
    }
    
    [HttpGet("{PaymentId:int}")]
    [SwaggerOperation(
        Summary = "Get Payment by UserId",
        Description = "Retrieves a Card available in the KidyCare Platform.",
        OperationId = "GetPaymentByUserId")
    ]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a Payment", typeof(PaymentResource))]
    public async Task<IActionResult> GetPaymentByUserId(int userId)
    {
        var getPaymentByUserIdQuery = new GetAllPaymentByUserIdQuery(userId);
        var payments = await paymentQueryService.Handle(getPaymentByUserIdQuery);
        var payment = payments.FirstOrDefault();
        if (payment is null)
        {
            return NotFound();
        }

        var paymentResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return Ok(paymentResource);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Payment",
        Description = "Create a new Payment",
        OperationId = "CreatePayment")
    ]
    [SwaggerResponse(StatusCodes.Status201Created, "The Payment was created", typeof(CardResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Payment could not be created")]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentResource resource)
    {
        var createPaymentCommand = CreatePaymentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var payment = await paymentCommandService.Handle(createPaymentCommand);
        if (payment is null) return BadRequest();
        var paymentResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return CreatedAtAction("GetPayment", new {id= payment.Id},paymentResource);
    }
    
}