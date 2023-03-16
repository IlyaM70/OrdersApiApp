using OrdersApiAppSPD011.Model.Entity;
using OrdersApiAppSPD011.Service;
using OrdersApiAppSPD011.Service.ClientService;
using OrdersApiAppSPD011.Service.ProductService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddTransient<IDao<Client>, DbDaoClient>();
builder.Services.AddTransient<IDao<Product>, DbDaoProduct>();

var app = builder.Build();

app.MapGet("/ping", () => new {Time = DateTime.Now, Message = "pong"});


//обработчики тестирования бизнес-логики для работы с клиентом
app.MapGet("/client/all", async (IDao<Client> daoClient) =>
{
    return await daoClient.GetAllAsync();
});

app.MapGet("/client/{id:int}", async (int id, IDao<Client> daoClient) =>
{
    return await daoClient.GetAsync(id);
});


app.MapPost("/client/add", async (Client client, IDao<Client> daoClient) =>
{
    return await daoClient.AddAsync(client);
});

app.MapPut("/client/update/{id:int}", async (int id, Client client, IDao<Client> daoClient) =>
{
    client.Id = id;
    return await daoClient.UpdateAsync(client);
});

app.MapDelete("/client/delete/{id:int}", async (int id, IDao<Client> daoClient) =>
{
   return await daoClient.DeleteAsync(id);
});


//Product CRUD  
app.MapGet("/product/all", async (IDao<Product> daoProduct) =>
{
    return await daoProduct.GetAllAsync();
});

app.MapGet("/product/{id:int}", async (int id, IDao<Product> daoProduct) =>
{
    return await daoProduct.GetAsync(id);
});


app.MapPost("/product/add", async (Product product, IDao<Product> daoProduct) =>
{
    return await daoProduct.AddAsync(product);
});

app.MapPut("/product/update/{id:int}", async (int id, Product product, IDao<Product> daoProduct) =>
{
    product.Id = id;
    return await daoProduct.UpdateAsync(product);
});

app.MapDelete("/product/delete/{id:int}", async (int id, IDao<Product> daoProduct) =>
{
    return await daoProduct.DeleteAsync(id);
});

app.Run();
