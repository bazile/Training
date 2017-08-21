<Query Kind="Statements" />

string vssettings_path = Path.Combine(
	Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
	@"Visual Studio 2017\Settings\CurrentSettings.vssettings"
).Dump();
if (File.Exists(vssettings_path))
{
	XDocument xdoc = XDocument.Load(vssettings_path);
	xdoc.Save(vssettings_path);
}
