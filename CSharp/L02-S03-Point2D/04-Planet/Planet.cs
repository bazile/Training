using System.Collections.Generic;

namespace BelhardTraining.PlanetDemo
{
    class Planet
    {
        /// <summary>Астрономическая единица (а.е.) в метрах</summary>
        /// <remarks>а.е. это приблизительное среднеее расстоянию от Земли до Солнца.</remarks>
        private const long AstronomicalUnit = 149597870700L;

        public readonly string Name;
        public ulong DistanceFromSun;

        static bool hasAtmosphere;
         public bool HasAtmosphere
        {
             get { return hasAtmosphere; }
             set { hasAtmosphere = value; }

        }

        public double DistanceFromSunAU
        {
            get { return (double)DistanceFromSun / AstronomicalUnit; }
            set { DistanceFromSun = (long)(value*AstronomicalUnit); }
        }


        public Planet(string name, ulong distanceFromSun)
        {
            Name = name;
            DistanceFromSun = distanceFromSun;
        }

       
    }
}
