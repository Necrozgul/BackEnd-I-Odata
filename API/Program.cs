using API.Helper;
using Microsoft.AspNetCore.OData;
using Model;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<RentalDBContext>();
builder.Services.AddTransient<IContractRepository, ContractRepository>();
builder.Services.AddTransient<IDeviceRepository, DeviceRepository>();
builder.Services.AddTransient<IHistoryRepository, HistoryRepository>();
builder.Services.AddTransient<IContractDeviceRepository, ContractDeviceRepository>();
builder.Services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin()));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddOData(opt => opt.AddRouteComponents("v1", EdmHelper.GetEdmModel()).Select().Filter().OrderBy().Expand());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("corsapp");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
