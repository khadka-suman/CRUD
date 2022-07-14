using CRUD.Models;

namespace CRUD.Repository
{
    public interface IOrderListRepository
    {
        Task<List<OrderList>> GetOrders();
        Task<OrderList> AddOrders(OrderList orderList);
        Task<OrderList> UpdateOrder(OrderList orderList);
        Task<OrderList> DeleteOrder(int id);
    }
}
