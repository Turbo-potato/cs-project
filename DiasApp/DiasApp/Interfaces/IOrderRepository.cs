using DiasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiasApp.Interfaces
{
    public interface IOrderRepository : IDisposable
    {
        Task<List<Order>> GetOrders();
        Order GetOrderByID(int OrderId);
        void InsertOrder(Order order);
        void DeleteOrder(Order order);
        void UpdateOrder(Order order);
        bool OrderExists(int id);
        Task Save();
        Task<List<Order>> GetOrderWithPredicate(Expression<Func<Order, bool>> predicate);
    }
}
