var builder = WebApplication.CreateBuilder(args).Inject();
builder.Host.UseSerilogDefault().ConfigureAppConfiguration((hostingContext, config) =>
{
	config.AddJsonFile("applicationsettings.json", optional: true, reloadOnChange: true);
});


var app = builder.Build();

app.Run();