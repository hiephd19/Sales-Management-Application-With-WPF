using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        public List<Order> GetAllOrder();
        public Order GetOrderById(int id);
        public void DeleteOrderById(int id);
        public void CreateOrder(Order newOrder);
        public void UpdateOrder(Order updateOrder);        
    }
}
