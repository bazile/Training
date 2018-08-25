namespace TrainingCenter.LinqToObjectsDemo.Titanic
{
    public enum Class
    {
        First, Second, Third,

        /// <summary>
        /// Офицеры и матросы
        /// </summary>
		DeckCrew,

        /// <summary>
        /// Инженерный персонал
        /// </summary>
        EngineeringCrew,

        /// <summary>
        /// Прислуга
        /// </summary>
        VictuallingCrew
    }

    public enum Sex { Male, Female }

    public enum City { Belfast, Southampton, Cherbourg, Queenstown }

    public enum AgeGroup { Unknown, Infant, Child, Teenager, Adult, Senior }

    /// <summary>
    /// Номер палубы. A - самая верхняя палуба, G - самая нижняя
    /// </summary>
    public enum Deck { Unknown, A, B, C, D, E, F, G }
}
