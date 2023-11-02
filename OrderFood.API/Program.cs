using Microsoft.EntityFrameworkCore;
using OrderFood.BL;
using OrderFood.BL.BillBL;
using OrderFood.BL.BillDetailBL;
using OrderFood.BL.FoodBL;
using OrderFood.DL;
using OrderFood.DL.BillDetailDL;
using OrderFood.DL.BillDL;
using OrderFood.DL.FoodDL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Dependency Injection
builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
builder.Services.AddScoped<IAuthDL, AuthDL>();
builder.Services.AddScoped<IAuthBL, AuthBL>();
builder.Services.AddScoped<IFoodBL, FoodBL>();
builder.Services.AddScoped<IFoodDL, FoodDL>();
builder.Services.AddScoped<IBillBL, BillBL>();
builder.Services.AddScoped<IBillDL, BillDL>();
builder.Services.AddScoped<IBillDetailBL, BillDetailBL>();
builder.Services.AddScoped<IBillDetailDL, BillDetailDL>();
// Add DB context
builder.Services.AddDbContext<AppDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("MyCors", build =>
{
    build.WithOrigins("http://127.0.0.1:5173").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyCors");
app.UseAuthorization();
app.MapControllers();

app.Run();
