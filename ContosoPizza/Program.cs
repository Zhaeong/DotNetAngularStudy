using Microsoft.EntityFrameworkCore;

using ContosoPizza.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.


var AllowAllCors = "_allowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name:AllowAllCors, builder => {
        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        });

});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = "Server=tcp:firstdatabaseserver.database.windows.net,1433;Initial Catalog=TheFoundation;Persist Security Info=False;User ID=ozhang;Password=FirstLoginPW01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
builder.Services.AddDbContext<myDBContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseHttpLogging();

app.UseCors(AllowAllCors);
app.UseAuthorization();

app.MapControllers();

app.Run();
