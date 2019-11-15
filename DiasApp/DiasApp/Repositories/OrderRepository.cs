using DiasApp.Data;
using DiasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DiasApp.Interfaces;

namespace DiasApp.Repositories
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        private PharmacyContext context;

        public OrderRepository(PharmacyContext context)
        {
            this.context = context;
        }

        public Task<List<Order>> GetOrders()
        {
            return context.Order.ToListAsync();
        }

        public Order GetOrderByID(int id)
        {
            return context.Order.Find(id);
        }

        public void InsertOrder(Order order)
        {
            context.Order.Add(order);
        }

        public void DeleteOrder(Order order)
        {
            //Order order = context.Order.Find(orderID);
            context.Order.Remove(order);
        }

        public void UpdateOrder(Order order)
        {
            context.Entry(order).State = EntityState.Modified;
        }

        public Task Save()
        {
            return context.SaveChangesAsync();
        }

        public bool OrderExists(int id)
        {
            return context.Order.Any(e => e.Id == id);
        }

        public Task<List<Order>> GetOrderWithPredicate(Expression<Func<Order, bool>> predicate)
        {
            return context.Order.Where(predicate).ToListAsync();
        }

        //DISPOSING

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
