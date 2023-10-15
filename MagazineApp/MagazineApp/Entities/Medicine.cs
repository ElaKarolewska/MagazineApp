namespace MagazineApp.Entities;

public class Medicine : EntityBase
{
    public string? NameOfTheMedicine { get; set; }
    
    public bool PrescriptionDrug { get; set; }
    
    //public bool NotPrescriptionDrug { get; set; }

    public override string ToString() => $"Id: {Id}, NameOfTheMedicine: {NameOfTheMedicine}, Prescription: {PrescriptionDrug}";
    
}


   