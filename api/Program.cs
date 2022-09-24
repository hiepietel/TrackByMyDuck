using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapGet("/", () => $"Hello World!{Environment.NewLine}I am TruckByMyDuck");
app.MapGet("/ping", () => DateTime.Now);

app.Run();