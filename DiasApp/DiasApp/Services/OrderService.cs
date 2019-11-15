using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiasApp.Models;
using DiasApp.Interfaces;

namespace DiasApp.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _orderRepo.GetOrders();
        }

        public async Task Save(Order order)
        {
            await _orderRepo.Save();
        }

        public async Task Insert(Order order)
        {
            _orderRepo.InsertOrder(order);
            await _orderRepo.Save();
        }

        public async Task Update(Order order)
        {
            _orderRepo.UpdateOrder(order);
            await _orderRepo.Save();
        }

        public Order GetOrderByID(int id)
        {
            return _orderRepo.GetOrderByID(id);
        }

        public async Task Delete(Order order)
        {
            _orderRepo.DeleteOrder(order);
            await _orderRepo.Save();
        }

        public bool OrderExists(int id)
        {
            return _orderRepo.OrderExists(id);
        }

        public async Task<List<Order>> Search(string text)
        {
            text = text.ToLower();
            var searchedOrders = await _orderRepo.GetOrderWithPredicate(order => order.EndTime.ToString().ToLower().Contains(text)
                                            || order.StartTime.ToString().ToLower().Contains(text));

            return searchedOrders;
        }
    }
}
