using BusinessLogic;
using EntityFrameWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddTransient(typeof(IDBLayer), typeof(DBLayer));
builder.Services.AddDbContext<RamayaMedicalCartContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("Avinyaconnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // React app URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddScoped<DBLayer>();
builder.Services.AddTransient<IBusinessLogic, BsinessLogic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI();
}
app.UseCors("AllowLocalhost3000"); //rishi edhi kuda ..addchesukovali 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
