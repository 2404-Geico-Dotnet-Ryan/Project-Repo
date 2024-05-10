class VendingStorage
{

    public Dictionary<int, Vending> Item;
    public int idCounter = 1;

    public VendingStorage()
    {
        Item item1 = new(idCounter, "Ruffles", 2.50, true, 0); idCounter++;
        Item item2 = new(idCounter, "Peppermint Patties", 2.00, true, 0); idCounter++;
        Item item3 = new(idCounter, "Cherry Pepsi", 1.50, true, 0); idCounter++;

        Item = []; //Sets the Dictionary to an empty collection.
        Item.Add(item1.ID, item1);
        Item.Add(item2.ID, item2);
        Item.Add(item3.ID, item3);
    }

}