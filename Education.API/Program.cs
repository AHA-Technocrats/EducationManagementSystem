using Education.API.Contexts;
using Education.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inject DbContext
builder.Services.AddDbContext<EducationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));

builder.Services.AddTransient<ICourse,ClsCourse>();
builder.Services.AddTransient<IGrades, ClsGrades>();
builder.Services.AddTransient<IStudent, ClsStudent>();
builder.Services.AddTransient<ISubject, ClsSubject>();
builder.Services.AddTransient<ITeacher, ClsTeacher>();

builder.Services.AddCors ((setup) =>
{
    setup.AddPolicy("default", (Options) =>
    {
        Options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    }
    );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
