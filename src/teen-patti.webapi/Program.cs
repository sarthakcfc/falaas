using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
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

#region teen-patti
app.MapPost("teenpatti/init", ([FromBody]ICollection<Card> deck) =>
{
    Builder builder = new Builder();
    builder
        .AssignDeck(deck.ToList())
        .InitPlayers(Player.InitPlayers);
    return builder.Build().MapToView();
})
.WithName("Initiate")
.WithTags("TeenPatti");
//.RequireAuthorization();

app.MapPost("teenpatti/deal", (GameStateView view) =>
{
    var state = new GameState(view);
    for (int i = 0; i < 6; i++)
    {
        var move = MoveFactory.CreateMove(state);
        state = move.Execute();
    }
    var returnVal =  state.MapToView();
    return returnVal;
})
.WithName("Deal")
.WithTags("TeenPatti");
#endregion

#region deck

app.MapGet("deck/create", ([FromQuery] int count, [FromQuery] bool shuffle) =>
{
    return Card.CreateDeck(count, shuffle);
})
.WithName("DeckCreate")
.WithTags("Deck");
#endregion

app.Run();
