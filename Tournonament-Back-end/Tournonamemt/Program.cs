using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tournonamemt.Repository.Interface;
using Tournonamemt.Repository.Mock;
using Tournonamemt.Security;
using Tournonamemt.Security.Interface;
using Tournonamemt.Services;
using Tournonamemt.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region DI
var key = "lectureTest1234$$$";

builder.Services.AddScoped<ITournamentService, TournamentService>();
builder.Services.AddScoped<IBracketService, BracketService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IAuthorizationService>(_ => new AuthorizationService("lectureTest1234$$$"));
builder.Services.AddScoped<IMatchRepository, MatchRepositoryMock>();
builder.Services.AddScoped<ITournamentRepository, TournamentRepositoryMock>();
builder.Services.AddScoped<IUserRepository, UserRepositoryMock>();
builder.Services.AddScoped<IRegistrationManager, RegistrationManager>();


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false,

    };
});
#endregion
builder.Services.AddControllers();
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


app.UseAuthorization();

app.MapControllers();

app.Run();
