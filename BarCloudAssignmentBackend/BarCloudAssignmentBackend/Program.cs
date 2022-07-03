using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Repositories.AddressRepo;
using Repositories.PersonRepo;
using Services.Addresses;
using Services.Mapping;
using Services.PersonServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options
                    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ));

builder.Services.AddScoped<IPersonReposiory, PersonReposiory>()
                .AddScoped<IAddressRepository, AddressRepository>()
                .AddScoped<IPersonService, PersonService>()
                .AddScoped<IAddressService, AddressService>();

builder.Services.AddAutoMapper(typeof(PersonAddressProfile));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(option =>
{
    option.AllowAnyHeader()
          .AllowAnyMethod()
          .AllowAnyOrigin();
});
app.MapControllers();

app.Run();
