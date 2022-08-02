using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using teen_patti.common.Models.ViewModel;
using teen_patti.service;
using teen_patti.service.Interefaces;
#region app-setup
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddAuthorization();

//Add Db
builder.Services.AddDbContext<teen_patti.data.postgres.TeenPattiDbContext>();

//Add dependencies
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IUserService, UserService>();

// Add Swagger
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
#endregion

#region teen-patti
app.MapPost("teenpatti/intialize/{playerId}", 
    async ([FromQuery]Guid playerId, [FromBody]ICollection<teen_patti.common.Models.ViewModel.CardView> deck, IGameService service) => 
        await service.InitializeGame(deck, playerId))
    .WithName("Initialize")
    .WithTags("TeenPatti");

app.MapPost("teenpatti/{gameId}/player/{playerId}/add", 
    async ([FromQuery] Guid gameId, [FromQuery] Guid playerId, IGameService service) => 
        await service.AddPlayer(gameId, playerId))
    .WithName("AddPlayer")
    .WithTags("TeenPatti");

app.MapGet("teenpatti/{gameId}/deal", 
    async ([FromQuery] Guid gameId, IGameService service) => 
        await service.Deal(gameId, 3))
    .WithName("Deal")
    .WithTags("TeenPatti");

app.MapGet("teenpatti/{gameId}/player/{playerId}/state",
    async ([FromQuery] Guid gameId, [FromQuery] Guid playerId, IGameService service) =>
        await service.GetState(gameId, playerId))
    .WithName("GetHand")
    .WithTags("TeenPatti");

app.MapGet("teenpatti/{gameId}/player/{playerId}/hand/see",
    async ([FromQuery] Guid gameId, [FromQuery] Guid playerId, IGameService service) =>
        await service.SeeHand(gameId, playerId))
    .WithName("SeeHand")
    .WithTags("TeenPatti");

app.MapPost("teenpatti/{gameId}/player/{playerId}/bet",
    async ([FromQuery] Guid gameId, [FromQuery] Guid playerId, [FromQuery] long betAmount, IGameService service) =>
        await service.Bet(gameId, playerId, betAmount))
    .WithName("SeenBet")
    .WithTags("TeenPatti");
#endregion

#region deck

app.MapGet("deck/create", ([FromQuery] int count) => teen_patti.common.Models.Engine.Card.CreateDeck(count).Select(x => x.MapToSeenView()))
.WithName("DeckCreate")
.WithTags("Deck");
#endregion

#region user

app.MapGet("users", async (IUserService service) => await service.GetUsers()).WithName("GetPlayers").WithTags("user");

#endregion

app.Run();
