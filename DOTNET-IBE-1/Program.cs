using DOTNET_IBE_1.Middlewares;
using DOTNET_IBE_1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .ConfigureServices(builder.Configuration)
    .ConfigureDatabaseConnection(builder.Configuration)
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//using middleware for exception handling
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseCors("AllowSpecificOrigins");


app.UseAuthorization();

app.MapControllers();

app.Run();
