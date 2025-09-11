using Microsoft.Extensions.Logging;
using TaskManagerApp.Services;

namespace TaskManagerApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Register HTTP clients and services
		builder.Services.AddHttpClient<TaskService>(client =>
		{
			// For development: use localhost, for Docker: use service names
			var baseAddress = DeviceInfo.Platform == DevicePlatform.Android && DeviceInfo.DeviceType == DeviceType.Virtual
				? "http://10.0.2.2:5001/" // Android emulator localhost
				: "http://taskservice:5001/"; // Docker service name
			client.BaseAddress = new Uri(baseAddress);
		});

		builder.Services.AddHttpClient<CategoryService>(client =>
		{
			// For development: use localhost, for Docker: use service names  
			var baseAddress = DeviceInfo.Platform == DevicePlatform.Android && DeviceInfo.DeviceType == DeviceType.Virtual
				? "http://10.0.2.2:5000/" // Android emulator localhost
				: "http://categoryservice:5000/"; // Docker service name
			client.BaseAddress = new Uri(baseAddress);
		});

		// Register pages
		builder.Services.AddTransient<MainPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
