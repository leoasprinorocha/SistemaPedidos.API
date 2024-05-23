using SistemaPedidos.API.Configurations;
using SistemaPedidos.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.SetAuthenticationServiceSetup(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
}
app.UseExceptionMiddleware();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("EnableCORS");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
