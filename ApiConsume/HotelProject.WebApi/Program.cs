using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(
        "Server=Mehmet-Bulut\\SQLEXPRESS;Database=ApiDb;Trusted_Connection=True;TrustServerCertificate=True;");
});

// Business Layer
builder.Services.AddScoped<IRoomService, RoomManager>();
builder.Services.AddScoped<IServiceService, ServiceManager>();
builder.Services.AddScoped<IStaffService, StaffManager>();
builder.Services.AddScoped<ISubscribeService, SubscribeManager>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

// Data Access Layer
builder.Services.AddScoped<IRoomDal, EfRoomDal>();
builder.Services.AddScoped<IServiceDal, EfServiceDal>();
builder.Services.AddScoped<IStaffDal, EfStaffDal>();
builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

// Swagger
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