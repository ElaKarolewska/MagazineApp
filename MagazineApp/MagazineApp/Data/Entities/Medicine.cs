using System.Text;

namespace MagazineApp.Data.Entities;

public class Medicine : EntityBase
{
    public string? Name { get; set; }
    public string? Dose { get; set; }
    public bool PrescriptionDrug { get; set; }
    public int NumberOfTablets { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }


    public override string ToString()
    {
        StringBuilder sb = new();

        sb.AppendLine($" Id: {Id}");
        sb.AppendLine($" Name and dose: {Name} {Dose}    Number of tablets {NumberOfTablets}");
        sb.AppendLine($" Price: {Price}    Quantity in stock: {QuantityInStock}");

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


