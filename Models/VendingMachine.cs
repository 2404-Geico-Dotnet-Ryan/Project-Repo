
public class VendingMachine
{
    public int Id { get; set; }
    public string Item { get; set; }
    public double Price { get; set; }
    public int Sold { get; set; }
    public int Quantity { get; set; }

    public VendingMachine()
    {
        Item = "";
    }


    public VendingMachine(int ID, string item, double price, int sold, int quantity)
    {
        Id = ID;
        Item = item;
        Price = price;
        Sold = sold;
        Quantity = quantity;
    }

    public override string ToString()
    {
      return 
      "{ID:'" + Id
        + "', item:'" + Item
        + "',price:" + Price
        + "',sold:" + Sold
        + ",available:" + Quantity +
         "}";
    }

}

//Data entities in the application