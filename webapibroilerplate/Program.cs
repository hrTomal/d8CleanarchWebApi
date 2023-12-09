using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using webapibroilerplate.Configurations.DBConnection;
using webapibroilerplate.Configurations.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PGSQLDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PGSQLDBConnection")), ServiceLifetime.Scoped);

builder.Services.ConfigureDependecyInjections();

builder.Services.AddAuthentication();
builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<PGSQLDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<IdentityUser>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
