namespace XmlSamples.Sample01
{
	internal class Customer
	{
		public string CustomerId { get; set; }
		public string CompanyName { get; set; }
		public string Country { get; set; }

		public Customer()
		{
			Country = "Unknown";
		}
	}
}
