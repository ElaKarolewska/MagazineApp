using MagazineApp.Components.CsvReader.Models;
using System.Reflection.Metadata.Ecma335;

namespace MagazineApp.Components.CsvReader.Extensions;

public static class PharmaciesExtensions
{
    public static IEnumerable<Pharmacies> ToPharmacies(this IEnumerable<string> source) 
    {
         foreach(var line in source) 
         {
            var columns = line.Split(';');

            yield return new Pharmacies
            {
                Id = int.Parse(columns[0]),
                Name = columns[1],
                Type = columns[2],
                DateOfAuthorisation = int.Parse(columns[3]),
                Locality = columns[4],
                Owner = columns[5],

            };
            
         }
    
    }
     
}
