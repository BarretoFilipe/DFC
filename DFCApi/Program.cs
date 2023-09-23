using API.Extensions;
using API.Models;
using DFCApi.Persistences;
using DFCApi.Persistences.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerDocumentation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();

builder.Services.AddAuthentication();
builder.Services.AddAuthorizationJWT(builder.Configuration);

builder.Services.AddDbContext<DFCContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("DFCDatabase"))
);

builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DFCContext>()
    .AddSignInManager<SignInManager<User>>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.AddDependencyInjection();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DFCContext>();
    var userManager = services.GetRequiredService<UserManager<User>>();
    context.Database.EnsureCreated();
    DatabaseSeeder.Initialize(context, userManager);
}

app.UseHttpsRedirection();
app.UseCors(cors =>
    cors.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
    );
app.UseAuthentication();
app.UseAuthorizationJWT();
app.MapControllers();
app.UseSwaggerDocumentation();

app.Run();