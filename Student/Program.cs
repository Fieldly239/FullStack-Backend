using Autofac;
using Autofac.Extensions.DependencyInjection;
using Student.Repositories;
using Student.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    var serviceAssembly = typeof(StudentsTableService).Assembly;
    builder.RegisterAssemblyTypes(serviceAssembly).Where(t => t.Name.EndsWith("Service"))
    .AsImplementedInterfaces()
    .SingleInstance();

    var repositoryAssembly = typeof(StudentsTableRepository).Assembly;
    builder.RegisterAssemblyTypes(repositoryAssembly).Where(t => t.Name.EndsWith("Repository"))
    .AsImplementedInterfaces()
    .SingleInstance();

});

builder.Services.AddCors(options =>

{

    options.AddPolicy(name: MyAllowSpecificOrigins,

                      builder =>

                      {

                          builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

                      });

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
