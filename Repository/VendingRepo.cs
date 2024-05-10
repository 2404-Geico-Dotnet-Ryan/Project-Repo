class VendingRepo
{
VendingStorage vendingStorage = new();


    public Vending AddMovie(Vending m)
    {

        m.ID = vendingStorage.idCounter++; 

        //Add the movie into our collection.
        vendingStorage.Item.Add(m.ID, m);
        return m;
    }

    public Vending GetItem(int ID)
    {
        // Alternative approach that breaks each step down.
        if (vendingStorage.Item.ContainsKey(ID))
        {
            vendingStorage selectedItem = vendingStorage.Item[ID];
            return vendingStorage;
           
        }
        else
        {
            System.Console.WriteLine("Item not available - Please Try Again");
            return null;
        }
    }

    //THIS IS A NEW METHOD!
    //No Parameters because...get everything is get everything. No options to choose.
    public List<Items> GetAllItems()
    {
        //I am chooseing to return a List because that is a much more common collection to
        //work with. It does mean I have to do a little bit of work here - but its not bad.
        return vendingStorage.Item.Values.ToList();
    }


    public Item? UpdateMovie(Item updatedItems)
    {
        //Assuming that the ID is consistent with an ID that exists
        //then we just have to update the value (aka Movie) for said key (ID) within the Dictionary.
        try
        {
            vendingStorage.Item[updatedMovie.Id] = updated;
            //I choose to send the updated movie back as a "response-feedback" system.
            //"Here is me telling you that I have updated the storage with this movie I send back to you"
            return updatedVending;
        }
        catch (Exception)
        {
            System.Console.WriteLine("Invalid Movie ID - Please Try Again");
            return null;
        }
    }

    public Movie? DeleteMovie(Movie m)
    {
        //If we have the ID -> then simply Remove it from storage
        bool didRemove = movieStorage.movies.Remove(m.Id);

        if (didRemove)
        {
            //now we will return the movie that got deleted.
            return m;
        }
        else
        {
            System.Console.WriteLine("Invalid Movie ID - Please Try Again");
            return null;
        }
    }

}