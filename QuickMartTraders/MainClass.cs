
class QuickMart
{
    // Function to show the menu to the users (All options are listed here)
    static void ShowMenu()
    {
        Console.WriteLine("================== QuickMart Traders ==================");
        Console.WriteLine("1. Create New Transaction(Enter Purchase & Selling Details)");
        Console.WriteLine("2. View Last Transaction");
        Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
        Console.WriteLine("4. Exit");
    }

    // Function to display calculation
    static void PrintCalculation(SalesTransaction t)
    {
        Console.WriteLine($"Status: {t.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {t.ProfitOrLossAmount:F2}");
        Console.WriteLine($"Profit Margin (%): {t.ProfitMarginPercent:F2}");
    }

    // function to parse string input to decimal so there will be no null and type error
    static bool ReadDecimal(string message, out decimal value)
    {
        Console.Write(message);
        return decimal.TryParse(Console.ReadLine(), out value);
    }

    // function to parse string input to int so there will be no null and type error
    static bool ReadInt(string message, out int value)
    {
        Console.Write(message);
        return int.TryParse(Console.ReadLine(), out value);
    }

    /// <summary>
    /// Function to create Transaction 
    /// Taking all the necessary input from the user then it will automatically went to DataBank2
    /// </summary>
    static void CreateTransaction()
    {
        SalesTransaction t = new SalesTransaction();

        Console.Write("Enter Invoice No: ");
        t.InvoiceNo = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(t.InvoiceNo))
        {
            Console.WriteLine("Invoice No cannot be empty.");
            return;
        }

        Console.Write("Enter Customer Name: ");
        t.CustomerName = Console.ReadLine();

        Console.Write("Enter Item Name: ");
        t.ItemName = Console.ReadLine();

        if (!ReadInt("Enter Quantity: ", out int qty) || qty <= 0) // Validation
        {
            Console.WriteLine("Quantity must be greater than 0.");
            return;
        }

        if (!ReadDecimal("Enter Purchase Amount (total): ", out decimal purchase) || purchase <= 0)
        {
            Console.WriteLine("Purchase Amount must be greater than 0.");
            return;
        }

        if (!ReadDecimal("Enter Selling Amount (total): ", out decimal selling) || selling < 0) // Validation
        {
            Console.WriteLine("Selling Amount must be 0 or greater.");
            return;
        }

        t.Quantity = qty;
        t.PurchaseAmount = purchase;
        t.SellingAmount = selling;

        CalculateProfitOrLoss.Calculation(t);
        DataBank2.AddTransaction(t);

        Console.WriteLine("\nTransaction saved successfully.");
        PrintCalculation(t);
    }

    // Function to view all the details of Last Transaction .... fetching data from DataBank2
    static void ViewLastTransaction()
    {
        SalesTransaction t = DataBank2.GetLastTransaction();

        if (t == null)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }

        // Displaying the Last Transaction Details

        Console.WriteLine("\n-------------- Last Transaction --------------");
        Console.WriteLine($"InvoiceNo: {t.InvoiceNo}");
        Console.WriteLine($"Customer: {t.CustomerName}");
        Console.WriteLine($"Item: {t.ItemName}");
        Console.WriteLine($"Quantity: {t.Quantity}");
        Console.WriteLine($"Purchase Amount: {t.PurchaseAmount:F2}");
        Console.WriteLine($"Selling Amount: {t.SellingAmount:F2}");
        Console.WriteLine($"Status: {t.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {t.ProfitOrLossAmount:F2}");
        Console.WriteLine($"Profit Margin (%): {t.ProfitMarginPercent:F2}");
        Console.WriteLine("--------------------------------------------");
    }
    /// <summary>
    /// We already calculate the profit and loss in CalculateProfitOrLoss.cs
    /// Here we are just presenting it
    /// </summary>
    static void RecalculateProfitLoss()
    {
        SalesTransaction t = DataBank2.GetLastTransaction();

        if (t == null)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }

        CalculateProfitOrLoss.Calculation(t);
        PrintCalculation(t);
    }

    // Main Function -> Entry Point for QuickMart
    public static void Run()
    {
        bool process = true;
        while (process)
        {
            ShowMenu();
            Console.WriteLine("Choose your option: ");
            string ? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                CreateTransaction();
                break;

                case "2":
                ViewLastTransaction();
                break;

                case "3":
                RecalculateProfitLoss();
                
                break;

                case "4":
                Console.WriteLine("Thanks for giving chance....");
                process = false;
                break;

                default:
                Console.WriteLine("Invalid Input... Please choose correct option.");
                break;
            }
        }
    }
}