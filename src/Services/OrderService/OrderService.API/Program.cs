using OrderService.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddControllers();

//builder.Services.AddOpenApi();
builder.Services.AddSwaggerOpenApi();
// Add Dependencies
builder.Services.AddRedisCaching(builder.Configuration);



var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderService API V1");
        // c.RoutePrefix = string.Empty; // اگر می‌خواهی Swagger UI در ریشه نمایش داده شود
    });
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();

