using Microsoft.EntityFrameworkCore;
using OrderFood.BL;
using OrderFood.DL;

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
builder.Services.AddScoped<ICategoriesBL, CategoriesBL>();
builder.Services.AddScoped<ICategoriesDL, CategoriesDL>();
builder.Services.AddScoped<IRoleBL, RoleBL>();
builder.Services.AddScoped<IRoleDL, RoleDL>();
builder.Services.AddScoped<IOrderBL, OrderBL>();
builder.Services.AddScoped<IOrderDL, OrderDL>();
builder.Services.AddScoped<IFoodImageBL, FoodImageBL>();
builder.Services.AddScoped<IFoodImageDL, FoodImageDL>();
builder.Services.AddScoped<IBookBL, BookBL>();
builder.Services.AddScoped<IBookDL, BookDL>();
builder.Services.AddScoped<ICartBL, CartBL>();
builder.Services.AddScoped<ICartDL, CartDL>();

// Add DB context
builder.Services.AddDbContext<AppDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
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
