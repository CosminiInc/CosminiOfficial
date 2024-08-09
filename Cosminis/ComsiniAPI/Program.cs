using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

using DataAccess.Entities;
using CustomExceptions;

using System.Data.SqlClient;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services;
using Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowAllHeadersPolicy",
        builder =>
        {
            builder.WithOrigins("*")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Configuration.AddUserSecrets<Program>();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddDbContext<CosminisOfficialDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CosminiDBConnectionString")));

var connectionString = builder.Configuration.GetConnectionString("CosminiDBConnectionString");

// Set up dependency injection
var serviceProvider = new ServiceCollection()
    .AddLogging(configure => configure.AddConsole())
    .BuildServiceProvider();

// Resolve services
var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
logger.LogInformation($"ConnectionString from Azure App Service: {connectionString}");

builder.Services.AddScoped<ICompanionDAO, CompanionRepo>();
builder.Services.AddScoped<IFriendsDAO, FriendsRepo>();
builder.Services.AddScoped<IUserDAO, UserRepo>();
builder.Services.AddScoped<IPostDAO, PostRepo>();
builder.Services.AddScoped<ICommentDAO, CommentRepo>();
builder.Services.AddScoped<IResourceGen, ResourceRepo>();
builder.Services.AddScoped<ILikeIt, LikeRepo>();
builder.Services.AddScoped<Interactions, InteractionRepo>();

builder.Services.AddScoped<ResourceServices>();
builder.Services.AddScoped<CompanionServices>();
builder.Services.AddScoped<FriendServices>();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<PostServices>();
builder.Services.AddScoped<CommentServices>();
builder.Services.AddScoped<LikeServices>();
builder.Services.AddScoped<InteractionService>();
builder.Services.AddScoped<LotteryService>();
builder.Services.AddScoped<BattleServices>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("MyAllowAllHeadersPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
