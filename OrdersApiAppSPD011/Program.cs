using OrdersApiAppSPD011.Model.Entity;
using OrdersApiAppSPD011.Service;
using OrdersApiAppSPD011.Service.ClientService;
using OrdersApiAppSPD011.Service.ProductService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddTransient<IDaoClient, DbDaoClient>(); 
builder.Services.AddTransient<IDaoProduct, DbDaoProduct>(); 

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


//Product CRUD  
app.MapGet("/product/all", async (IDaoProduct daoProduct) =>
{
    return await daoProduct.GetAllAsync();
});

app.MapGet("/product/{id:int}", async (int id, IDaoProduct daoProduct) =>
{
    return await daoProduct.GetAsync(id);
});


app.MapPost("/product/add", async (Product product, IDaoProduct daoProduct) =>
{
    return await daoProduct.AddAsync(product);
});

app.MapPut("/product/update/{id:int}", async (int id, Product product, IDaoProduct daoProduct) =>
{
    product.Id = id;
    return await daoProduct.UpdateAsync(product);
});

app.MapDelete("/product/delete/{id:int}", async (int id, IDaoProduct daoProduct) =>
{
    return await daoProduct.DeleteAsync(id);
});

app.Run();
