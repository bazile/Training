using System;

namespace BelhardTraining.PlanetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Planet[] solarSystemPlanets = new Planet[] {
                new Planet("Меркурий",   57909100000),
                new Planet("Венера"  ,  108208000000),
                new Planet("Земля"   ,  149598261000) { HasAtmosphere = true },
                new Planet("Марс"    ,  227939100000),
                new Planet("Юпитер"  ,  778547200000),
                new Planet("Сатурн"  , 1433449370000)  { HasAtmosphere = false },
                new Planet("Уран"    , 2876679082000),
                new Planet("Нептун"  , 4503443661000),
            };
            foreach (Planet planet in solarSystemPlanets)
            {
                Console.WriteLine(
                    "{0}: Расстояние от Солнца {1:N0} км или {2:F2} а.е. {3}",
                    planet.Name,
                    planet.DistanceFromSun / 1000,
                    planet.DistanceFromSunAU , planet.HasAtmosphere
                );
            }
            DateTime d= new DateTime();
        }
    }
}
