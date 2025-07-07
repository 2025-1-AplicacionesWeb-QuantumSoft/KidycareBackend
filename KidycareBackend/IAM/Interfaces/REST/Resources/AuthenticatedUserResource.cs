namespace KidycareBackend.IAM.Interfaces.REST.Resources;

public record AuthenticatedUserResource(int Id, string Username, string role, string Token);