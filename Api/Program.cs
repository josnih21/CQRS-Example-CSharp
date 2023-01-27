using CQRS.Command;

public class Program
{
    public static Task Main()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Host.UseNServiceBus(context =>
        {
            var endpointConfiguration = new EndpointConfiguration("API-Sender");
            var transport = endpointConfiguration.UseTransport(new LearningTransport());
            transport.RouteToEndpoint(assembly: typeof(CreateUserCommand).Assembly, destination: "UserNServiceBus");
            endpointConfiguration.SendOnly();
            return endpointConfiguration;
        });
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app.RunAsync();
    }
}