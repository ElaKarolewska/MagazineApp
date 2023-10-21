namespace MagazineApp.Entities;

public class Medicine : EntityBase
{
    public string? Name { get; set; }
    public string Dose { get; set; }
    public bool PrescriptionDrug { get; set; }

    public override string ToString() => $"Id: {Id}, Name and dose: {Name} {Dose}, Prescription: {PrescriptionDrug}";
    
}


   