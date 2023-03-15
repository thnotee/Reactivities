using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*
 this IServiceCollection services
 확장 메서드이기 때문에 
 확장 메서드란? 기존에 클래스나 인터페이스에 새로운 메서드를 추가하는 것
this IServiceCollection services가 매개 변수로 사용되면, 
이 인스턴스는 확장 메서드가 실행될 때 메서드의 첫 번째 매개 변수로 전달됩니다. 
이를 통해, 확장 메서드 내에서 해당 인스턴스를 사용할 수 있게 됩니다.

즉 this IServiceCollection services는 IServiceCollection 
인터페이스를 구현하는 객체를 받아와 추가로 구현한다
*/
builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try{

    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context);

}catch(Exception ex){
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "마이그레이션중 에러가 발생했습니다.");
}

app.Run();
