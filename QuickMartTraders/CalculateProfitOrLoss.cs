using System.Net;

// Class for calculating profit and loss

class CalculateProfitOrLoss
{

    
    public static void Calculation(SalesTransaction t)
    {
        

        if(t.SellingAmount > t.PurchaseAmount) // Calculating Profit
        {
            t.ProfitOrLossStatus = "PROFIT";
            t.ProfitOrLossAmount = t.SellingAmount - t.PurchaseAmount;
        }
        else if(t.SellingAmount < t.PurchaseAmount) // Calculating Loss
        {
            t.ProfitOrLossStatus = "LOSS";
            t.ProfitOrLossAmount = t.PurchaseAmount - t.SellingAmount;
        }
        else
        {
            t.ProfitOrLossStatus = "BREAK-EVEN"; // Calculating Break Even
            t.ProfitOrLossAmount = 0;
        }
        t.ProfitMarginPercent = (t.ProfitOrLossAmount / t.PurchaseAmount) * 100;  // Calculating %
 
        
        
    }

        
    

}