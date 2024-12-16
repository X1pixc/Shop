using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebRegister.BLL;
using WebRegister.BLL.Basket;
using WebRegister.BLL.Profile;
using WebRegister.DAL;
using WebRegister.DAL.Models;
using WebRegister.DAL.Product;
using WebRegister.DAL.Profile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<IUserDAL, UserDAL>();
builder.Services.AddScoped<IUserBLL, UserBLL>();
builder.Services.AddSingleton<ISessionDAL, SessionDAL>();
builder.Services.AddScoped<ISessionBLL, SessionBLL>();
builder.Services.AddSingleton<IProductDAL, ProductDAL>();
builder.Services.AddScoped<IProductBLL, ProductBLL>();
builder.Services.AddSingleton<IProfileDAL, ProfileDAL>();
builder.Services.AddScoped<IProfileBLL, ProfileBLL>();
builder.Services.AddSingleton<IBasketProductsDAL, BasketProductsDAL>();
builder.Services.AddScoped<IBasketProductsBLL, BasketProductsBLL>();
builder.Services.AddSingleton<IBasketDAL, BasketDAL>();
builder.Services.AddScoped<IBasketBLL, BasketBLL>();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "WebRegister",
            ValidAudience = "WebRegister",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hJ3r85MpN4Xq7V3kGr2ZwH6lS1dY9tZc"))
        };
    });

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

