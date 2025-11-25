using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles(); // tìm index.html trong wwwroot
app.UseStaticFiles();

app.Run();
