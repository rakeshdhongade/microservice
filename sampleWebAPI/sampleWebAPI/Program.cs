using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using sampleWebAPI;
using sampleWebAPI.Models;
using sampleWebAPI.src.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));
//tell application to load MonogDbSettings from appSettings into MonogDbSettings class
builder.Services.Configure<MonogDbSettings>(builder.Configuration.GetSection(nameof(MonogDbSettings)));

//add singleton object in services
builder.Services.AddSingleton<IMongoDatabase>(serviceProvider =>
{
    //this code will call when someone ask object of IMongoDatabase
    var mongoDBSettings = builder.Configuration.GetSection(nameof(MonogDbSettings)).Get<MonogDbSettings>();
    var mongoclient = new MongoClient(mongoDBSettings.ConnectionString);
    return mongoclient.GetDatabase(mongoDBSettings.DatabaseName);
});

builder.Services.AddSingleton<IUsersRepository, UsersRepository>();
builder.Services.AddSingleton<IVehicleRepository, VehicleRepository>();


//registering UserModel as singleton
// Trasient will always gives new instance
// AddSocpe will give same intnace for a whithin the request
builder.Services.AddSingleton<UserModel>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//retiving the instance from container
var usermodel = app.Services.GetRequiredService<UserModel>();

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
