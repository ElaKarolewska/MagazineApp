namespace MagazineApp.Entities;

public class Medicine: EntityBase
{
  public string? NameOfTheMedicine { get; set; }
  public override string ToString() => $"Id: {Id}, NameOfTheMedicine: {NameOfTheMedicine}";
  
  //bool prescriptionDrug = true;

}
