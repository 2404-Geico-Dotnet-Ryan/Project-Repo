using System;

class OrderServices

{
   
    OrdersRepo or;

    public OrderServices(OrdersRepo or)
    {
        this.or = or;
    }

       
    public List<Orders> GetAllOrders(string username)
    {
       
        List<Orders> allOrders = or.GetAllOrders(username);

        return allOrders;  
    }

    public Orders? AddOrders(Orders v)
    {
        return or.AddAllOrders(v); 
    }

  

    
}

