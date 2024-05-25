using System;

class OrderServices

{
   
    OrdersRepo or;

    public OrderServices(OrdersRepo or)
    {
        this.or = or;
    }

       
    public List<Orders> GetAllOrders(int id)
    {
       
        List<Orders> allOrders = or.GetAllOrders(id);

        return allOrders;  
    }

    public Orders? AddOrders(Orders v)
    {
        return or.AddAllOrders(v); 
    }
}