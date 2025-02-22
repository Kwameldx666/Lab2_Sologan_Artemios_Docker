using Microsoft.EntityFrameworkCore;
using CategoryService.Data;

var builder = WebApplication.CreateBuilder(args);

// Регистрация сервисов
builder.Services.AddControllers();
builder.Services.AddHttpClient("TaskService", client =>
{
    client.BaseAddress = new Uri("http://taskservice:5001/"); // Имя контейнера TaskService
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CategoryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Конфигурация middleware
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

// Автоматическое создание БД
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CategoryDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();