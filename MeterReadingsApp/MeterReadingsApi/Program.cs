using MeterReadingsApp.Services;

using MeterReadingsDataAccess.DbAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IAccountData, AccountData>();
builder.Services.AddSingleton<IMeterReadingData, MeterReadingData>();

builder.Services.AddScoped<ICSVService, CSVService>();
builder.Services.AddScoped<IMeterReadingService, MeterReadingService>();

builder.Services.AddCors(options => options.AddPolicy("CORS", policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
