using MongoDB.Driver;
using sampleWebAPI;
using sampleWebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//tell application to load MonogDbSettings from appSettings into MonogDbSettings class
builder.Services.Configure<MonogDbSettings>(builder.Configuration.GetSection(nameof(MonogDbSettings)));

//add singleton object in services
builder.Services.AddSingleton<IMongoDatabase>(serviceProvider =>
{
    //this code will call when someone ask object of IMongoDatabase
    //TODO: if we AddTransient then every time will it call this place?
    var mongoDBSettings = builder.Configuration.GetSection(nameof(MonogDbSettings)).Get<MonogDbSettings>();
    var mongoclient = new MongoClient(mongoDBSettings.ConnectionString);
    return mongoclient.GetDatabase(mongoDBSettings.DatabaseName);
});

//builder.Services.AddSingleton<UserModel>(sp=>
//{
//    return new UserModel(sp.GetService<IMongoDatabase>());
//});


//var userModel = builder.Configuration.Get<UserModel>();

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
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
