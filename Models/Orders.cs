public class Orders
{
    public int Id { get; set; }
    public string Item { get; set; }
    public int Quantity { get; set; }
    public string Username { get; set; }
    public DateTime PurchaseDate { get; set; }

    public Orders()
    {
        Username = "";
    }


    public Orders(int ID, string item, int quantity)
    {
        Id = ID;
        Item = item;
        Quantity = quantity;
        PurchaseDate = PurchaseDate;
    }

    public override string ToString()
    {
      return 
      "{ID:'" + Id
        + ",username:" + Username
        + "', item:'" + Item
        + ",available:" + Quantity
        + ",purchsedate:" + PurchaseDate + "}";
    
    }

}
//       FROM [GayleVendingMachine].[dbo].[Purchasehistory]
//       ,[Id]
//       ,[Username]
//       ,[Item]
//       ,[Quantity]
//       ,[Purchasedate]

