class VendingMachineRepo

{

    VendingMachineStorage vendingMachineStorage = new();  //Pascal case 


    public VendingMachine? GetItem(int id)
    {
        // Alternative approach that breaks each step down.
        if (vendingMachineStorage.item.ContainsKey(id))
        {
        return vendingMachineStorage.item[id];
        }
        else
        {
            System.Console.WriteLine("Invalid item selection - Please Try Again");
            return null;
        }
    }

    public List<VendingMachine> GetAllitems()
    {
        return vendingMachineStorage.item.Values.ToList();
    }


    public VendingMachine? Updateditem(VendingMachine updatedItem)
    {
        
        try
        {
            vendingMachineStorage.item[updatedItem.Id] = updatedItem;
          
          return updatedItem;
        }
        catch (Exception)
        {
            System.Console.WriteLine("System Error, Maintenance needed");
        return null;
        }
    }

    

}

//How to interact with the data (abstracts the data layer) CRUD operations - create, read, update, delete