using MagazineApp.Components.CsvReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineApp.Components.DataProviders
{
    public interface IPharmaceriesProvider
    {
        public List<Pharmacies> OrderByName(List<Pharmacies> pharmacies);
    }
}
