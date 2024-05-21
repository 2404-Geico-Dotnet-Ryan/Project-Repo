class VendingMachineServices

{
VendingMachineRepo vr = new ();

/*(Maintenance) 
Require user to enter a PIN 
Validate(PIN) (not needed here, done under services)
Purchase History: 
Return Purchased Items: (Item name/Sold count/Sum of Sold Items/Sum for all sold items.
Return Message for items with count < '5'. "Items low in stock"
Quit or Exit Maintenance mode. "Return to main menu" 

(Guest)
New Purchase: 
Allow user selection(s) from available items (item Quantity >0) 
user will select from program*/ 

public List<VendingMachine>GetItemsToDisplay()
{
    
  List<VendingMachine> allItems = vr.GetAllitems(); 

    /* Filter out only Available Movies */
   List<VendingMachine>availableItems = new();

    foreach (VendingMachine v in allItems)
    {
        if(v.Quantity !=0)
        {
            availableItems.Add(v);
        }
    } 

    /* Return list of filtered Available Movies*/ 
    return availableItems; 
} 

/*Decrease Quantity for purchased Item(s).*/
public VendingMachine PurchasedItems(VendingMachine v)

{
    vr.Updateditem(v);
    return v;
}

public VendingMachine GetItem(int id)

{
    var getItem=vr.GetItem(id);
    return getItem;
}
}

//*Select an additional item? (bool) Yes/No (Program) --future interation


