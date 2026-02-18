using System;
using Bookify.Domain.Bookings;
using Microsoft.Extensions.DependencyInjection;

namespace Bookify.Appication;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add application services to the dependency injection container.
    /// </summary> <param name="services">The service collection to which application services will be added.</param>
    /*
    IServiceCollection is an interface that represents a collection of service descriptors. It is used in the .NET dependency injection framework to
    register services and their implementations. By adding services to the IServiceCollection, you can configure how dependencies are resolved throughout
    your application. In this code snippet, we are adding MediatR and a custom PricingService to the service collection, allowing them to be injected
    into other parts of the application where needed.

    The 'this' in AddApplication(this IServiceCollection services) means that this method is an extension method for the IServiceCollection interface. This allows us
    to call AddApplication() on any instance of IServiceCollection, making it easier to register application services in a clean and organized way.
    */
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // AddMeiatR uses a Action, The Action in C# is a delegate that represents a method that takes a single parameter and does not return a value.
        // In this case, the Action is used to configure the MediatR services by registering them from the specified assembly. The lambda expression
        // provided to the AddMediatR method allows you to specify which assembly contains the MediatR handlers that should be registered with the
        // dependency injection container.
        services.AddMediatR(configuration =>
        {
            // Register MediatR handlers from the current assembly. This allows MediatR to find and use the handlers defined in this assembly for
            // processing requests. The typeof(DependencyInjection).Assembly expression is used to specify the assembly where the handlers are located.
            // in this case it is the same assembly as the DependencyInjection class.
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly); //Application assembly
        });

        // Register the PricingService as a transient service in the dependency injection container. This means that a new instance of PricingService will
        // be created each time it is requested. This allows for better performance and resource management, as the service will only be instantiated when
        // needed and will not be shared across different parts of the application.
        services.AddTransient<PricingService>();
        return services;
    }
}
