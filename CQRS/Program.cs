// See https://aka.ms/new-console-template for more information
namespace CqrsNServiceBus;

public class CqrsNserviceBus
{
    private static IEndpointInstance endpointInstance;
    private static String endpointName;

    public static async Task Main()
    {
        Console.Title = "UserNServiceBus";
        var endpointConfiguration = new EndpointConfiguration("UserNServiceBus");
        endpointConfiguration.UsePersistence<LearningPersistence>();
        var transport = endpointConfiguration.UseTransport<LearningTransport>();
        endpointInstance = await Endpoint.Start(endpointConfiguration);
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
        await endpointInstance.Stop();
    }
}