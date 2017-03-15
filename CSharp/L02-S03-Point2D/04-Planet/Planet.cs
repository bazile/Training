namespace TrainingCenter.PlanetDemo
{
    class Planet
    {
        /// <summary>Астрономическая единица (а.е.) в метрах</summary>
        /// <remarks>а.е. это приблизительное среднеее расстоянию от Земли до Солнца.</remarks>
        private const long AstronomicalUnit = 149597870700L;

        public readonly string Name;
        public readonly long DistanceFromSun;

        public Planet(string name, long distanceFromSun)
        {
            Name = name;
            DistanceFromSun = distanceFromSun;
        }

        public double DistanceFromSunAU
        {
            get { return (double)DistanceFromSun / AstronomicalUnit; }
        }
    }
}
