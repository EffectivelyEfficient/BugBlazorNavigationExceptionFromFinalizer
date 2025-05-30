using BlazorApp1;

TaskScheduler.UnobservedTaskException += (sender, e) => {
	Console.WriteLine("Unhandled caught: " + e.Exception.ToString());
	e.SetObserved();
};

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents();
var app = builder.Build();
app.UseAntiforgery();
app.MapRazorComponents<App>();
app.Run();
