using MagazineApp.Components.CsvReader.Models;
using System.Globalization;

namespace MagazineApp.Components.CsvReader.Extensions;

public static class MedicinesExtensions
{
    public static IEnumerable<Medicines> ToMedicines(this IEnumerable<string> source)
    {
        foreach (var line in source)
        {
            var colums = line.Split(';');

            yield return new Medicines
            {
                Id = long.Parse(colums[0]),
                Name = colums[1],
                Substance = colums[2],
                Packaging = colums[3],
                Power = colums[4],
                Manufacturer = colums[5],
                Country = colums[6],
            };
        }
    }
}
