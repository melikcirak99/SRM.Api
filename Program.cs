using FluentValidation.AspNetCore;
using SRM.Api.Extensions;
using SRM.Api.Filters;
using SRM.Api.Validations;

var builder = WebApplication.CreateBuilder(args);

//dependecy injection nesnelerini yüklüyoruz.
builder.Services.AddServices();
///

//fluent validation yüklüyoruz.
//diðer validation nesnelerinin burada tanýmlanasýna gerek yoktur.
//validation kontrolü için ValidationFilter sýnýfýný kullanýlýyoruz.
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<StudentValidator>())
    .ConfigureApiBehaviorOptions(option => option.SuppressModelStateInvalidFilter = true);
///


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

app.MapControllers();

app.Run();
