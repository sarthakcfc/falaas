using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using teen_patti.service;
using teen_patti.service.Interefaces;

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

#region teen-patti
app.MapPost("teenpatti/intiialize", 
    ([FromBody]ICollection<teen_patti.common.Models.ViewModel.CardView> deck, IGameService service) => service.InitializeGame(deck, Guid.NewGuid())
).WithName("Initialize")
.WithTags("TeenPatti");
//.RequireAuthorization();

//app.MapPost("teenpatti/deal", (Guid gameStateId) =>
//{
//    var state = new GameState(view);
//    for (int i = 0; i < 6; i++)
//    {
//        var move = MoveFactory.CreateMove(state);
//        state = move.Execute();
//    }
//    var returnVal =  state.MapToView();
//    return returnVal;
//})
//.WithName("Deal")
//.WithTags("TeenPatti");
#endregion

#region deck

app.MapGet("deck/create", ([FromQuery] int count) =>
{
    return teen_patti.common.Models.Engine.Card.CreateDeck(count);
})
.WithName("DeckCreate")
.WithTags("Deck");
#endregion

app.Run();
