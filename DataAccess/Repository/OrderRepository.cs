using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void CreateOrder(Order newOrder)
        {
            try
            {
                using var context = new Prn221FstoreContext();
                context.Orders.Add(newOrder);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while inserting order: " + ex.Message);
            }
        }

        public void DeleteOrderById(int id)
        {
            try
            {
                using var context = new Prn221FstoreContext();
                Order? deleteOrder = context.Orders.FirstOrDefault(p => p.OrderId == id) ?? throw new Exception("Order not found!");
                context.Orders.Remove(deleteOrder);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting order: " + ex.Message);
            }
        }

        public List<Order> GetAllOrder()
        {
            try
            {
                using var context = new Prn221FstoreContext();
                return context.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting all order: " + ex.Message);
            }
        }

        public Order GetOrderById(int id)
        {
            try
            {
                using var context = new Prn221FstoreContext();
                Order? order = context.Orders.FirstOrDefault(p => p.OrderId == id);
                return order ?? throw new Exception("Order not found!");
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching order by ID: " + ex.Message);
            }
        }

        public void UpdateOrder(Order updateOrder)
        {
            try
            {
                using var context = new Prn221FstoreContext();
                Order? existingOrder = context.Orders.FirstOrDefault(p => p.OrderId == updateOrder.OrderId)
                    ?? throw new Exception("Order not found!");              
                existingOrder.RequiredDate = updateOrder.RequiredDate;
                existingOrder.ShippedDate = updateOrder.ShippedDate;
                existingOrder.Freight = updateOrder.Freight;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating member: " + ex.Message);
            }
        }
    }
}
