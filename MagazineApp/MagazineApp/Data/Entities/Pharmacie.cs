
namespace MagazineApp.Data.Entities
{
    public  class Pharmacie: EntityBase
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string DateOfAuthorisation { get; set; }
        public string Locality { get; set; }
        public string Owner { get; set; }
    }
}
