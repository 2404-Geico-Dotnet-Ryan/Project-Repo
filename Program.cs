using System.Dynamic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
class Program

{
    static UserService us;
    static VendingMachineServices vs;
    static OrderServices or;
    static User? loggedInUser = null;
    static void Main(string[] args)

    {
        string path = @"C:\Users\U1C066\OneDrive - Government Employees Insurance Company\Claims Referral\Desktop\VendingMachine Database Connection.txt";
        string connectionString = File.ReadAllText(path);

        UserRepo up = new(connectionString);
        us = new(up);

        VendingMachineRepo vmr = new(connectionString);
        vs = new(vmr);

        OrdersRepo phs = new(connectionString);
        or = new(phs);


        Console.Clear();
        MainMenu();
    }


    public static void MainMenu()
    {
        while (true)

        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Gayle's Vending Machine!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("************************");
            Console.WriteLine();
            Console.WriteLine("[1]. Customer");
            Console.WriteLine("[2]. Maintenance");
            Console.WriteLine("[3]. Exit");


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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    private static void GuestMode()
    //login username and password (Collect Username and Password. Verify using existing [USER] table.)
    {
        Console.WriteLine("Please enter your Username");
        string Username = Console.ReadLine();



        Console.WriteLine("Please enter your Password");
        string Password = Console.ReadLine();

        User loggedInUser = us.Login(Username, Password);

        if (loggedInUser != null)

        //Add Options in GuestMode (Purchase - same flow but add a Save to [Purchasehistory] table for the logged in USER.

        {
            bool KeepPurchasing = true;
            while (KeepPurchasing)
            {


                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("************************");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Welcome " + loggedInUser.Username);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("************************");
                Console.WriteLine();
                Console.WriteLine("1: Make Purchase");
                Console.WriteLine("2: Review Purchase History");
                Console.WriteLine("3: Exit");


                //Purchase history will use the [Purchasehistory] table to retrieve the logged in USERs individual history. 
                int choice = int.Parse(Console.ReadLine() ?? "0");

                switch (choice)

                {
                    case
                1:
                        MakePurchase(loggedInUser.Username);
                        break;
                    case
                2:

                        PurchaseHistory(loggedInUser.Username);
                        break;
                    case
               3:
                        KeepPurchasing = false;
                        Environment.Exit(0);
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

    private static void PurchaseHistory(string username)
    {
        List<Orders> allOrders = or.GetAllOrders(username);
        foreach (Orders order in allOrders)
        {
            System.Console.WriteLine(order);
            System.Console.WriteLine();
        }
    }

    public static void MakePurchase(string username)


    {


        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Available Items:");


            List<VendingMachine> vendingMachine = vs.GetItemsToDisplay();

            //System.Console.WriteLine("=== List of Avilable Items ===");
            foreach (VendingMachine v in vendingMachine)
            {
                //System.Console.WriteLine(v);
                Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.WriteLine(v.Id + ": " + v.Item + " $" + v.Price + "0");
            }

            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("Please enter the number of the item you would like to buy.");
            int userItem = int.Parse(Console.ReadLine() ?? "0");

            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("Please enter the quantity you would like to purchase.");
            int userQuantity = int.Parse(Console.ReadLine() ?? "0");

            VendingMachine g = vs.GetItem(userItem);

            g.Sold = g.Sold + userQuantity;   //increases sold value
            g.Quantity = g.Quantity - userQuantity; //decreases quantity

            vs.PurchasedItems(g);  //dispenses item, updates the counts in the table. 
            Orders currentOrder = new Orders(0, username, g.Item, userQuantity, DateTime.Now);

            //writes orders to the table
            or.AddOrders(currentOrder);

            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine();
            System.Console.Write("Total Amount Due: ");
            double totalDue = 0;

            foreach (VendingMachine v in vendingMachine)
            {
                if (g.Quantity > 0)
                {
                    totalDue = userQuantity * g.Price;

                }
            }

            _ = totalDue.ToString("F2");
            Console.Write(totalDue.ToString("F2"));





            double expectedAmount = totalDue;
            double paymentAmount;

            do
            {
                Console.WriteLine();
                Console.Write("Enter payment amount (dollars and cents): ");
                if (double.TryParse(Console.ReadLine(), out paymentAmount))
                {
                    if (paymentAmount < expectedAmount)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Payment amount is too low. Please insert exact change.");
                    }
                    else if (paymentAmount > expectedAmount)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Payment amount is too high. Please insert exact change.");
                    }
                    else
                    {
                        System.Console.WriteLine();
                        Console.WriteLine("***************************");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Thank you for your Purchase!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("***************************");
                        Console.WriteLine();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid amount.");
                }
            } while (true);


        }



        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Press Enter to return to the Main Menu.");
        Console.ReadKey();

    }

    //*********************************************************************************
    private static void MaintenanceMode()
    {
        Console.WriteLine("Please enter your Password");

        string Password = Console.ReadLine();

        if (us.Login != null)
        {
            if (Password == "12345")

            {
                List<VendingMachine> vendingMachine = vs.GetItemsToDisplay();

                Console.WriteLine();
                Console.WriteLine("Count of Items Sold: ");
                foreach (VendingMachine v in vendingMachine)
                {
                    if (v.Sold > 0)
                    {

                        Console.Write(v.Item + " - " + v.Sold);
                        Console.WriteLine();

                    }
                }

                foreach (VendingMachine v in vendingMachine)
                {
                    if (v.Quantity < 5)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Items Low in Stock:");
                        Console.Write(v.Item + " Quantity: " + v.Quantity);
                        Console.WriteLine();

                    }
                }

                //Console.WriteLine("Total Sales:");
                double totalEarnings = 0;
                foreach (VendingMachine v in vendingMachine)
                {
                    if (v.Sold > 0)
                    {
                        totalEarnings = totalEarnings + v.Sold * v.Price;
                    }
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your total Earnings for this week is $" + totalEarnings + "0");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter to Return to Main Menu.");

                Console.ReadLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Password");
                Console.ForegroundColor = ConsoleColor.White;

            }
        }
    }
}




