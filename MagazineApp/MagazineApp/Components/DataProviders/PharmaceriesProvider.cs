using MagazineApp.Components.CsvReader.Models;
using MagazineApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineApp.Components.DataProviders
{
    public class PharmaceriesProvider : IPharmaceriesProvider
    {
        public List<Pharmacies> OrderByName(List<Pharmacies> pharmacies)
        {
            return pharmacies.OrderBy(x => x.Name).ToList();
        }
    }
}
