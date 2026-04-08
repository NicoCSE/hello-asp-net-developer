using Acme.Hello.Platform.Generic.Domain.Model.Entities;
using Acme.Hello.Platform.Generic.Interfaces.REST.Resources;

namespace Acme.Hello.Platform.Generic.Interfaces.REST.Assemblers;
/// <summary>
/// Assembler class to convert a GreetDeveloperRequest into a Developer entity.
/// </summary>
public class DeveloperAssembler
{
    /// <summary>
    /// Converts a GreetDeveloperRequest into a Developer entity.
    /// </summary>
    /// <param name="request">The GreetDeveloperRequest to convert.</param>
    /// <returns> A developer entity if the request is valid, otherwise, null. </returns>
    public static Developer? ToEntityFromRequest(GreetDeveloperRequest? request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.FirstName) || string.IsNullOrWhiteSpace(request.LastName))
        
            return null;
        return new Developer(request.FirstName, request.LastName);   
        
    }
}