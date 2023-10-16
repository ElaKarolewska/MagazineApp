namespace MagazineApp.Entities;

public class Medicine : EntityBase
{
    public string? Name { get; set; }
    
    public bool PrescriptionDrug { get; set; }
    
    public override string ToString() => $"Id: {Id}, Name: {Name}, Prescription: {PrescriptionDrug}";
    
}


   