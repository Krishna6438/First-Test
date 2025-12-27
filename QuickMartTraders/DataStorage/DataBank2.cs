// Static storage
static class DataBank2
{
    public static List<SalesTransaction> Last = new List<SalesTransaction>(); // List for storing Trasactions Details

    public static bool HasLastTransaction = true; // Use to store status of Last Transaction

    public static void AddTransaction(SalesTransaction sale) // Function to add data into list
    {
        Last.Add(sale);
    }

    public static SalesTransaction GetLastTransaction() // function to get last transaction details
    {
        if(Last.Count == 0)
        {
            HasLastTransaction = false;
            return null;
        }
        else
        {
            return Last[Last.Count - 1];
        }
    }

}
