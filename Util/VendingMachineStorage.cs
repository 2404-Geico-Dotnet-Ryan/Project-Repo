class VendingMachineStorage  //[GayleVendingMachine].[dbo].[vendingMachine]
{
public Dictionary <int, VendingMachine> item;

public int idCounter=1;  

public VendingMachineStorage()  //same name as class it's in.
{
        VendingMachine item1 = new VendingMachine (idCounter, "Coke", 2.50, 0, 20); idCounter++; //sets idcounter=1 and then idcounter ++ moves the counter to the next number 2.
        VendingMachine item2 = new VendingMachine (idCounter, "candy", 2.50, 3, 17); idCounter++;
        VendingMachine item3 = new VendingMachine (idCounter, "chips", 1.50, 16, 4); idCounter++;
       
       item = [];
       item.Add(item1.Id, item1);
       item.Add(item2.Id, item2);
       item.Add(item3.Id, item3);

}
    

    
}

//The place where the data is stored. Writes to the database or file system.
/*Data Access Layer - Repository Layer
    - is responsible for data(base) interaction. These objects that we create will perform any amount of retrieval, manipulation, destruction to our data. 
        - These Objects are referred as Data Access Objects: DAOs*/