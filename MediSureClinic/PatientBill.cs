// Class that contains declaration of all the necessary properties of patient
class PatientBill
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool HasInsurance { get; set; } // true if patient is injured
    public decimal ConsultationFee { get; set; }
    public decimal LabCharges { get; set; }
    public decimal MedicineCharges { get; set; }
    public decimal GrossAmount {get; set;}
    public decimal DiscountAmount{get; set;}
    public decimal FinalPayable{get; set;}


}