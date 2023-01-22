using AccountOwnerServer.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;

var builder = WebApplication.CreateBuilder(args);

//config logging
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));


/// configure iis and cors
/// 


builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

///



// Add services to the container.


///add by me to use logs call an extension methods
///

builder.Services.ConfigureLoggerService();

////


builder.Services.ConfigureSqlContext(builder.Configuration);

//inject mapper

builder.Services.AddAutoMapper(typeof(Program));

//inject repository inside wrapper
builder.Services.ConfigureRepositoryWrapper();
/////////////


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

//add my me
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");
    //
app.UseAuthorization();

app.MapControllers();

app.Run();
