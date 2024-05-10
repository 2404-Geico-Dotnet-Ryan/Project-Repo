class Vending
{
    public int ID { get; set; }
    public required string Item { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public bool Available { get; set; }

    public required string User { get; set; }
    public int? PIN { get; set; }

    public Vending()
    {
        Item = "";
    }

    public Vending(int ID, string Item, double Price, bool Available)
    {
        ID = ID;
        Item = Item; 
        Price = Price; 
        Available = Available;
    }

    public override string ToString()
    {
      return 
      "{id:" + ID
        + ",item:'" + Item
        + "',price:" + Price
        + ",available:" + Available + "}";
    }
    
}