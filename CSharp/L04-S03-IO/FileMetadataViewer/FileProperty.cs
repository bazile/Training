namespace FileMetadataViewer
{
	class FileProperty
	{
		private string _groupName, _shortName;
		private string _canonicalName;

		public FileProperty(string canonicalName, string displayName, string value)
		{
			CanonicalName = canonicalName;
			DisplayName = string.IsNullOrWhiteSpace(displayName) ? "" : displayName;
			Value = string.IsNullOrWhiteSpace(value) ? "" : value;
		}

		public string CanonicalName
		{
			get { return _canonicalName; }
			private set
			{
				_canonicalName = value ?? "";
				int lastDot = _canonicalName.LastIndexOf('.');
				_shortName = lastDot != -1 ? _canonicalName.Substring(lastDot + 1) : _canonicalName;
				_groupName = lastDot != -1 ? _canonicalName.Substring(0, lastDot) : "";
			}
		}

		public string GroupName
		{
			get { return _groupName; }
		}

		public string ShortName
		{
			get { return _shortName; }
		}

		public string DisplayName { get; private set; }
		public string Value { get; private set; }

		public override string ToString()
		{
			return string.Format("{0} = {1}", DisplayName.Length > 0 ? DisplayName : _shortName, Value);
		}
	}
}
