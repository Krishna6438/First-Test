using System.Diagnostics;

class MediSure
{
    // Function to show menu to user(All the options are available here///)
    static void ShowMenu()
    {
        Console.WriteLine("================== MediSure Clinic Billing ==================");
        Console.WriteLine("1. Create New Bill (Enter Patient Details)");
        Console.WriteLine("2. View Last Bill");
        Console.WriteLine("3. Clear Last Bill");
        Console.WriteLine("4. Exit");
    }

    // function to parse string input to decimal so there will be no null and type error
    static bool ReadDecimal(string message, out decimal value)
    {
        Console.Write(message);
        return decimal.TryParse(Console.ReadLine(), out value);
    }

    /// <summary>
    /// Function to create Bills
    /// Taking all the necessary input from the user then it will automatically went to DataBank
    /// </summary>

    static void CreateNewBill()
    {
        PatientBill bill = new PatientBill();
        Console.WriteLine("Enter Bill id: ");
        bill.Id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(bill.Id)) // Validation
        {
            Console.WriteLine("Bill Id cannot be empty.");
            return;
        }
        Console.WriteLine("Enter Patient name: ");
        bill.Name = Console.ReadLine();

        Console.WriteLine("Is Patient injured: ");
        bill.HasInsurance = Console.ReadLine()
            .Equals("Y", StringComparison.OrdinalIgnoreCase);
        if (!ReadDecimal("Enter Consultation Fee: ", out decimal consultation) || consultation <= 0) // validation
        {
            Console.WriteLine("Consultation Fee must be > 0.");
            return;
        }

        if (!ReadDecimal("Enter Lab Charges: ", out decimal lab) || lab < 0) // validation
        {
            Console.WriteLine("Lab Charges must be >= 0.");
            return;
        }

        if (!ReadDecimal("Enter Medicine Charges: ", out decimal medicine) || medicine < 0) // validation
        {
            Console.WriteLine("Medicine Charges must be >= 0.");
            return;
        }

        bill.ConsultationFee = consultation;
        bill.LabCharges = lab;
        bill.MedicineCharges = medicine;

        // CALCULATION MOVED TO Calculation.cs
        CalculateCharges.Calculation(bill);

        DataBank.AddBills(bill);

        Console.WriteLine("\nBill created successfully.");
        Console.WriteLine($"Gross Amount: {bill.GrossAmount}");
        Console.WriteLine($"Discount Amount: {bill.DiscountAmount}");
        Console.WriteLine($"Final Payable: {bill.FinalPayable}");
    }
    // Function to view all the details of Last Bill .... fetching data from DataBank
    static void ViewLastBill()
    {
        PatientBill bill = DataBank.GetLastBill();

        if (bill == null)
        {
            Console.WriteLine("No bill available.");
            return;
        }

        Console.WriteLine("\n------ Last Bill ------");
        Console.WriteLine($"Bill Id: {bill.Id}");
        Console.WriteLine($"Patient: {bill.Name}");
        Console.WriteLine($"Insured: {(bill.HasInsurance ? "Yes" : "No")}");
        Console.WriteLine($"Gross Amount: {bill.GrossAmount:F2}");
        Console.WriteLine($"Discount: {bill.DiscountAmount:F2}");
        Console.WriteLine($"Final Payable: {bill.FinalPayable:F2}");
        Console.WriteLine("------------------------");
    }
    
    //Entry point for Medisure
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
                CreateNewBill();
                break;

                case "2":
                ViewLastBill();
                break;

                case "3":
                DataBank.ClearBill();
                Console.WriteLine("Last Bill Cleared");
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