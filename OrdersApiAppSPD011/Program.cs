using OrdersApiAppSPD011.Model.Entity;
using OrdersApiAppSPD011.Service;
using OrdersApiAppSPD011.Service.ClientService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddTransient<IDaoClient, DbDaoClient>(); 

var app = builder.Build();

app.MapGet("/ping", () => new {Time = DateTime.Now, Message = "pong"});


//обработчики тестирования бизнес-логики для работы с клиентом
app.MapGet("/client/all", async (IDaoClient daoClient) =>
{
    return await daoClient.GetAllAsync();
});

app.MapGet("/client/{id:int}", async (int id, IDaoClient daoClient) =>
{
    return await daoClient.GetAsync(id);
});


app.MapPost("/client/add", async (Client client, IDaoClient daoClient) =>
{
    return await daoClient.AddAsync(client);
});

app.MapPut("/client/update/{id:int}", async (int id, Client client, IDaoClient daoClient) =>
{
    client.Id = id;
    return await daoClient.UpdateAsync(client);
});

app.MapDelete("/client/delete/{id:int}", async (int id, IDaoClient daoClient) =>
{
   return await daoClient.DeleteAsync(id);
});


app.Run();
