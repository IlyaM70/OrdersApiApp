namespace OrdersApiAppSPD011.Service.CheckService
{
    public interface IDaoCheck
    {
        Task<object> GetAsync(int id);
    }
}
