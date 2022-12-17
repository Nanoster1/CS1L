namespace CS1L.Server.Hubs;

public static class HubMapping
{
    public static void MapHubs(this WebApplication app)
    {
        app.MapHub<SessionHub>("session");
    }
}
