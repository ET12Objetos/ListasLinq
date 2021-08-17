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
                new Auto { Marca="Fias", Modelo="Cronos", Año=2015 },
                new Auto { Marca="Volkswagen", Modelo="Gol", Año=2020 },
                new Auto { Marca="Volkswagen", Modelo="Amarok", Año=2020 },
                new Auto { Marca="Volkswagen", Modelo="T-Cross", Año=2018 },
                new Auto { Marca="Ford", Modelo="Ranger", Año=2018 },
                new Auto { Marca="Peugeout", Modelo="208", Año=2017 },
                new Auto { Marca="Ford", Modelo="Ka", Año=2015 },
                new Auto { Marca="Toyota", Modelo="Etios", Año=2020 }
            };

            //Imprimir(automoviles);

            //notacion fluent
            var resultadoFluent = automoviles.Where(x => x.Año == 2020 && x.Marca == "Toyota");

            Imprimir(resultadoFluent, "Where - Fluent");

            //notacion query
            var resultadoQuery = from x in automoviles
                                 where x.Año == 2020 && x.Marca == "Toyota"
                                 select x;

            Imprimir(resultadoQuery, "Where - Query");

        }

        private static void Imprimir(IEnumerable<Auto> automoviles, string functionName = "")
        {
            Console.WriteLine($"==  {functionName}  ==============");
            var table = new ConsoleTable("Marca", "Modelo", "Año");
            automoviles.ToList().ForEach(x => table.AddRow(x.Marca, x.Modelo, x.Año));
            table.Write();
            Console.WriteLine();
        }

        static void ImprimirClasico(List<Auto> automoviles) =>
            automoviles.ForEach(x => Console.WriteLine($"Marca: {x.Marca} | Modelo: {x.Modelo} | Año: {x.Año}"));
    }
}
