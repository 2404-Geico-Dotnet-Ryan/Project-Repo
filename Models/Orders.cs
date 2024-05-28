public class Orders
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Item { get; set; }
    public int Quantity { get; set; }
    public DateTime Purchasedate { get; set; }

    public Orders()
    {
        Username = "";
    }


    public Orders(int ID, string username, string item, int quantity, DateTime date)
    {
        Id = ID;
        Username = username;
        Item = item;
        Quantity = quantity;
        Purchasedate = date;
    }

    public override string ToString()
    {
      return 
          "Guest:" + Username
        + ", Purchased Item:" + Item
        + ", Amount:" + Quantity
        + ", Purchase Date:" + Purchasedate;
    
    }

}
//       FROM [GayleVendingMachine].[dbo].[Purchasehistory]
//       ,[Id]
//       ,[Username]
//       ,[Item]
//       ,[Quantity]
//       ,[Purchasedate]

