namespace FENParser
{
	class Notation
	{
		public string Text { get; set; }
		public string Name { get; set; }

		public override string ToString()
		{
			return Name + ": " + Text;
		}
	}
}
