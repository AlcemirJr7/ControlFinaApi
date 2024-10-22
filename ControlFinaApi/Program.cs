using ControlFinaApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApiVersionConfiguration();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfiguration();

builder.Services.AddServices();

builder.Services.AddRepositories();

builder.Services.ConfigureDatabase(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();
                        
if (app.Environment.IsDevelopment())
    app.UseSwaggerConfiguration();
            
app.ApplyMigrations();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();
                        
app.MapControllers();
                        
app.Run();
