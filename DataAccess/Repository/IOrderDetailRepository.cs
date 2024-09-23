using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        public List<OrderDetail> GetAllOrderDetail();
        public OrderDetail GetOrderDetailById(int id);
        public void DeleteOrderDetailById(int id);
        public void CreateOrderDetail(OrderDetail newOrderDetail);
        public void UpdateOrderDetail(OrderDetail updateOrderDetail);
    }
}
