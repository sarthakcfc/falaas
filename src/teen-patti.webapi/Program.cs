using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using teen_patti.common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Microsoft identity setup. TODO: Create login endpoint. later we should move to a oauth centric model
app.UseAuthentication();
app.UseAuthorization();

var scopeRequiredByApi = app.Configuration["AzureAd:Scopes"];

app.MapGet("teenpatti/initgame", (HttpContext httpContext) =>
{
    Builder builder = new Builder();
    builder
        .InitDeck(Card.NewTeenPattiDeck)
        .InitPlayers(Player.InitPlayers);
    return builder.Build().MapToView();
})
.WithName("CreateTeenPattiBuilder");
//.RequireAuthorization();

app.MapPost("teenpatti/dealtoplayers", (GameStateView view) =>
{
    var state = new GameState(view);
    for (int i = 0; i < 6; i++)
    {
        var move = MoveFactory.CreateMove(state);
        state = move.Execute();
    }
    return state;
});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}