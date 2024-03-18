using System.Diagnostics.Eventing.Reader;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
/*
app.MapGet("/shirts", () =>
{
    return "reading all shirts";
});
app.MapGet("/shirts/{id}",(int id) =>
    {
    return $"reading the shirt id:{id}";
});
app.MapPost("/shirts", () =>
{
    return "Creating shirt";
});
app.MapPut("/shirts/{id}", (int id) =>
{
    return $"put the sirt id:{id}";
});
app.MapDelete("/shirts/{id}", (int id) =>
{
    return $"Delete the shirt id:{id}";
});
*/
app.Run();
