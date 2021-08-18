using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;

namespace ListasLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Auto> automoviles = new List<Auto>()
            {
                new Auto { Marca="Toyota", Modelo="Hilux", Año=2019 },
                new Auto { Marca="Chevrolet", Modelo="Onix", Año=2014 },
                new Auto { Marca="Fiat", Modelo="Cronos", Año=2015 },
                new Auto { Marca="Volkswagen", Modelo="Gol", Año=2020 },
                new Auto { Marca="Volkswagen", Modelo="Amarok", Año=2020 },
                new Auto { Marca="Volkswagen", Modelo="T-Cross", Año=2018 },
                new Auto { Marca="Ford", Modelo="Ranger", Año=2018 },
                new Auto { Marca="Peugeot", Modelo="208", Año=2017 },
                new Auto { Marca="Ford", Modelo="Ka", Año=2015 },
                new Auto { Marca="Toyota", Modelo="Etios", Año=2020 }
            };

            //Imprimir(automoviles);

            //where

            //notacion fluent
            var resultadoFluent = automoviles.Where(x => x.Año == 2020 && x.Marca == "Toyota");

            //Imprimir(resultadoFluent, "Where - Fluent");

            //notacion query
            var resultadoQuery = from x in automoviles
                                 where x.Año == 2020 && x.Marca == "Toyota"
                                 select x;

            //Imprimir(resultadoQuery, "Where - Query");

            var resultado = automoviles.Where(x => x.Marca.EndsWith("t") && x.Año % 2 != 0);

            //Imprimir(resultado, "Autos que terminen con letra 't'");

            //select

            var marcasFluent = automoviles.Where(x => x.Año == 2020).Select(x => x.Marca);

            //marcasFluent.ToList().ForEach(x => System.Console.WriteLine(x));

            var marcasQuery = from x in automoviles
                              where x.Año == 2020
                              select x.Marca;

            //marcasQuery.ToList().ForEach(x => System.Console.WriteLine(x));

            //order by

            var autosOrdenadosAsc = automoviles.OrderBy(x => x.Año);

            var autosOrdenadosAscQuery = from x in automoviles orderby x.Año select x;

            //Imprimir(autosOrdenadosAsc, "Order By - Asc");
            //Imprimir(autosOrdenadosAscQuery, "Order By - Asc");

            var autosOrdenadosDesc = automoviles.OrderByDescending(x => x.Año);

            var autosOrdenadosDescQuery = from x in automoviles orderby x.Año descending select x;

            //Imprimir(autosOrdenadosDesc, "Order By - Desc");
            //Imprimir(autosOrdenadosDescQuery, "Order By - Desc");

            var autosVolkswagen = automoviles.Where(x => x.Marca == "Volkswagen").OrderBy(x => x.Modelo);

            //Imprimir(autosVolkswagen, "Autos Volkswagen");

            //first - caso :)
            Auto auto1 = automoviles.First(x => x.Año == 2020);
            Imprimir(auto1, "First - auto1");

            //first - caso :(
            //Auto auto2 = automoviles.First(x => x.Año == 2030);

            //first - caso :)
            Auto auto3 = automoviles.FirstOrDefault(x => x.Año == 2018);
            Imprimir(auto3, "FirstOrDefault - auto3");

            //first - caso :(
            Auto auto4 = automoviles.FirstOrDefault(x => x.Año == 2030);

            if (auto4 != null)
                Imprimir(auto4, "FirstOrDefault - auto4");
            else
                System.Console.WriteLine("El auto4 no se encuentra en la lista");

        }

        private static void Imprimir(IEnumerable<Auto> automoviles, string functionName = "")
        {
            Console.WriteLine($"==  {functionName}  ==============");
            var table = new ConsoleTable("Marca", "Modelo", "Año");
            automoviles.ToList().ForEach(x => table.AddRow(x.Marca, x.Modelo, x.Año));
            table.Write();
            Console.WriteLine();
        }

        private static void Imprimir(Auto automovil, string functionName = "")
        {
            Console.WriteLine($"==  {functionName}  ==============");
            var table = new ConsoleTable("Marca", "Modelo", "Año");
            table.AddRow(automovil.Marca, automovil.Modelo, automovil.Año);
            table.Write();
            Console.WriteLine();
        }

        static void ImprimirClasico(List<Auto> automoviles) =>
            automoviles.ForEach(x => Console.WriteLine($"Marca: {x.Marca} | Modelo: {x.Modelo} | Año: {x.Año}"));
    }
}
