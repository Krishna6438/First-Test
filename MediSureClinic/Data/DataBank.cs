// Static storage for MediSure
static class DataBank
{
    public static List<PatientBill> patients = new List<PatientBill>(); // List for storing bills

    public static bool HasLastBill; // stores last bill status

    public static void AddBills(PatientBill b) // function to add bill details to list
    {
        patients.Add(b);
    }

    public static PatientBill GetLastBill() // function to retrieve Last bills
    {
        if(patients.Count == 0)
        {
            return null;
        }
        else
        {
            return patients[patients.Count - 1];
        }
    }

    public static void ClearBill() // Function to create Bills
    {
        if(patients.Count == 0)
        {
            Console.WriteLine("There is no bill to clear.");
        }
        else
        {
            patients.Clear();
        }
    }

    
}