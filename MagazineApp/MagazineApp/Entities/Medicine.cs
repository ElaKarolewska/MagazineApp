using System.Text;

namespace MagazineApp.Entities;

public class Medicine : EntityBase
{
    public string? Name { get; set; }
    public string? Dose { get; set; }
    public bool PrescriptionDrug { get; set; }

    public override string ToString() 
    {
        StringBuilder sb = new();
        
        sb.AppendLine($"Id: {Id}");
        sb.AppendLine($"Name and dose: {Name} {Dose}");

        if (PrescriptionDrug is true)
        {
            sb.AppendLine($"Rx");
        }
        else 
        {
            sb.AppendLine($"OTC");
        }
       
        return sb.ToString();
    }     
}


   