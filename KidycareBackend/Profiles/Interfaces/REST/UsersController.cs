using System.Net.Mime;
using KidycareBackend.Profiles.Domain.Model.Commands;
using KidycareBackend.Profiles.Domain.Model.Queries;
using KidycareBackend.Profiles.Domain.Services;
using KidycareBackend.Profiles.Interfaces.REST.Resources;
using KidycareBackend.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KidycareBackend.Profiles.Interfaces.REST;

[Controller]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available User endpoints.")]
public class UsersController(
    IUserQueryService  userQueryService,
    IUserCommandService userCommandService
    ): ControllerBase
{
    
    [HttpGet("{userId:int}")]
    [SwaggerOperation(
        Summary    = "Get User By Id",
        Description = "Get User By Id",
        OperationId = "GetUserById"
        )
    ]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns User By Id", typeof(UserResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No User Found")]
    public async Task<IActionResult> GetUsersById(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var user = await userQueryService.Handle(getUserByIdQuery);
        if (user == null)
            return NotFound();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary    = "Get Users",
        Description = "Get Users",
        OperationId = "GetAllUsersQuery"
        )
    ]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns Users List",typeof(IEnumerable<UserResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No User Found")]
    public async Task<IActionResult> GetAllUser(int userId)
    {
        var getAllUsersQuery =  new GetAllUsersQuery();
        var users = await userQueryService.Handle(getAllUsersQuery);
        var userResource  = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary    = "Create User",
        Description = "Create User",
        OperationId = "CreateUserCommand"
        )
    ]
    [SwaggerResponse(StatusCodes.Status201Created, "Created User", typeof(UserResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No User Found")]
    public async Task<IActionResult> CreateUser(CreateUserResource resource)
    {
        var createUserCommand = CreateUserCommandFromResourceAssembler.toCommandFromResource(resource);
        var user = await userCommandService.Handle(createUserCommand);
        if (user == null)
            return BadRequest();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return CreatedAtAction(nameof(GetUsersById), new { userId = userResource.userId }, userResource);
    }

    [HttpPut("{userId:int}")]
    [SwaggerOperation( 
        Summary    = "Update User",
        Description = "Update User",
        OperationId = "UpdateUserCommand"
        )
    ]
    [SwaggerResponse(StatusCodes.Status200OK, "Update User", typeof(UserResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No User Found")]
    public async Task<IActionResult> UpdateUser(int userId,[FromBody]UpdateUserResource resource)
    {

        var updateUserCommand = UpdateUserCommandFromResourceAssembler.toCommandFromResource(resource);
        var user = await userCommandService.Handle(updateUserCommand,userId);
        if (user == null)
            return BadRequest();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }
}