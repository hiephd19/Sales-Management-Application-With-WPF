using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void CreateOrderDetail(OrderDetail newOrderDetail)
        {
            try
            {
                using var context = new Prn221FstoreContext();
                context.OrderDetails.Add(newOrderDetail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while inserting order: " + ex.Message);
            }
        }

        public void DeleteOrderDetailById(int id)
        {
            try
            {
                using var context = new Prn221FstoreContext();
                OrderDetail? deleteOrderDetail = context.OrderDetails.FirstOrDefault(p => p.OrderId == id) ?? throw new Exception("Order Detail not found!");
                context.OrderDetails.Remove(deleteOrderDetail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting order: " + ex.Message);
            }
        }

        public List<OrderDetail> GetAllOrderDetail()
        {
            try
            {
                using var context = new Prn221FstoreContext();
                return context.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting all order detail: " + ex.Message);
            }
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            try
            {
                using var context = new Prn221FstoreContext();
                OrderDetail? orderDetail = context.OrderDetails.FirstOrDefault(p => p.OrderId == id);
                return orderDetail ?? throw new Exception("Order detail not found!");
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching order detail: " + ex.Message);
            }
        }

        public void UpdateOrderDetail(OrderDetail updateOrderDetail)
        {
            try
            {
                using var context = new Prn221FstoreContext();
                OrderDetail? existingOrderDetail = context.OrderDetails.FirstOrDefault(p => p.OrderId == updateOrderDetail.OrderId)
                    ?? throw new Exception("Order detail not found!");
                existingOrderDetail.Quantity = updateOrderDetail.Quantity;
                existingOrderDetail.UnitPrice = updateOrderDetail.UnitPrice;
                existingOrderDetail.Discount = updateOrderDetail.Discount;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating order detail: " + ex.Message);
            }
        }
    }
}
