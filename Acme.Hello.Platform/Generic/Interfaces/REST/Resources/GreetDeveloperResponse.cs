namespace Acme.Hello.Platform.Generic.Interfaces.REST.Resources;
/// <summary>
/// A record representing the response for a greeting request.
/// </summary>
/// <param name="Id"> The unique identifier for the greeting, may be null</param>
/// <param name="FullName"> The full name of the developer, may be null</param>
/// <param name="Message"> The greeting message.</param>
public record GreetDeveloperResponse(Guid? Id, string? FullName, string Message)
{
    /// <summary>
    /// Constructs a response with only a message, used for anonymous greetings.
    /// </summary>
    /// <param name="message"> The greeting message.</param>
    public GreetDeveloperResponse(string message) : this(Id: null, FullName: null, message)
    {
    }

}