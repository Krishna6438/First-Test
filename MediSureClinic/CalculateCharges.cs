// class to calculate all the amounts
class CalculateCharges
{
    public static void Calculation(PatientBill bill)
    {
        bill.GrossAmount = bill.ConsultationFee + bill.LabCharges + bill.MedicineCharges; // calculating gross amount
 
        if (bill.HasInsurance) // checking insurance status
        {
            bill.DiscountAmount = 0.10m * bill.GrossAmount; // calculating discount amount
        }
        else
        {
            bill.DiscountAmount = 0; // if no insurance then discount = 0
        }

        bill.FinalPayable = bill.GrossAmount - bill.DiscountAmount; // calculating final amount
    }
}