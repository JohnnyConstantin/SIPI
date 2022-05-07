using NotificationSystemWeb.Data;

namespace NotificationSystemWeb;

public static class RegisterServices
{
    /// <summary>
    /// Method to register all services.
    /// </summary>
    /// <param name="builder"></param>
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DataContext>();
        builder.Services.AddMemoryCache();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
    }
}