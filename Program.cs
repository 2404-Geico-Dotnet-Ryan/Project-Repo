class Program
{
    static UserService us = new();
    static VendingMachineServices vs = new();
    static void Main(string[] args)

    {
        MainMenu();
    }

    public static void MainMenu()
    {
        while (true)

        {
            Console.WriteLine("Gayle's Vending Machine!");
            Console.WriteLine("Select user type:");
            Console.WriteLine("1. Guest");
            Console.WriteLine("2. Maintenance");
            Console.WriteLine("3. Exit");

            int choice = int.Parse(Console.ReadLine() ?? "0");

            switch (choice)

            {
                case
            1:
                    GuestMode();
                    break;
                case
            2:
                    MaintenanceMode();
                    break;
                case
            3:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    private static void GuestMode()
    {
        Console.WriteLine("Available Items:");


        List<VendingMachine> vendingMachine = vs.GetItemsToDisplay();

        //System.Console.WriteLine("=== List of Avilable Movies ===");
        foreach (VendingMachine v in vendingMachine)
        {
            //System.Console.WriteLine(v);
            System.Console.WriteLine("Item Number = " + v.Id + " Item Name = " + v.Item + " Price = $" + v.Price + "0");
        }

        System.Console.WriteLine("Please select an id number of the item you would like to buy.");
        int userItem = int.Parse(Console.ReadLine() ?? "0");

        System.Console.WriteLine("Please enter quantity you would like to purchase.");
        int userQuantity = int.Parse(Console.ReadLine() ?? "0");

        VendingMachine g = vs.GetItem(userItem);

        g.Sold = g.Sold + userQuantity;   //increases sold value
        g.Quantity = g.Quantity - userQuantity; //deccreased quantity

        vs.PurchasedItems(g);  //dispenses item, updates the counts in the table. 

    }
//*********************************************************************************
    private static void MaintenanceMode()
    {
        Console.WriteLine("Please enter your PIN");

        int PIN = int.Parse(Console.ReadLine() ?? "0");

        if (us.Login != null)

        {
            List<VendingMachine> vendingMachine = vs.GetItemsToDisplay();

            System.Console.WriteLine("Items sold");
            foreach (VendingMachine v in vendingMachine)
            {
                if (v.Sold > 0)
                {
                    System.Console.WriteLine(v);
                }
            }

            System.Console.WriteLine("Items low in stock");
            foreach (VendingMachine v in vendingMachine)
            {
                if (v.Quantity < 5)
                {
                    System.Console.WriteLine(v);
                }
            }

            System.Console.WriteLine("Total Sales");
            double totalEarnings = 0;
            foreach (VendingMachine v in vendingMachine)
            {
                if (v.Sold > 0)
                {
                    totalEarnings = totalEarnings + v.Sold * v.Price;
                }
            }
            System.Console.WriteLine("Your total Earnings for this week is $" + totalEarnings);
        }
        else
        {
            System.Console.WriteLine("Invalid PIN");
        }
    }
}

