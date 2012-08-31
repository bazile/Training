using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace VehicleRepairLab
{
	public partial class MainForm : Form
	{
		private readonly string _xsdFile;
		private readonly string _xmlFile;
		private DataSet _ds;

		public MainForm()
		{
			string applicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			_xsdFile = Path.Combine(applicationDataPath, "VehiclesRepairs.xsd");
			_xmlFile = Path.Combine(applicationDataPath, "VehiclesRepairs.xml");

			InitializeComponent();
		}

		private void OnMainFormLoad(object sender, EventArgs e)
		{
			PopulateDataSet();

			var vehicles = _ds.Tables["Vehicles"];
			DataView view = new DataView(vehicles);
			//view.Sort = "Make ASC, Year DESC";
			//view.RowFilter = "Make like 'B%' and Year > 2003";
			dgVehicles.DataSource = view;
			
			//dgVehicles.DataSource = _ds;
			//dgVehicles.DataMember = "Vehicles";
			dgRepairs.DataSource = _ds;
			dgRepairs.DataMember = "Vehicles.vehicles_repairs";
		}

		private void PopulateDataSet()
		{
			if (File.Exists(_xsdFile))
			{
				_ds = new DataSet();
				_ds.ReadXmlSchema(_xsdFile);
			}
			else
			{
				CreateSchema();
			}
			if (File.Exists(_xmlFile))
			{
				_ds.ReadXml(_xmlFile, XmlReadMode.IgnoreSchema);

				/*
				DataTable vehicles = _ds.Tables["Vehicles"];
				DataRow newCar = vehicles.NewRow();
				newCar["Vin"] = "123456789ABCD";
				newCar["Make"] = "Ford";
				newCar["Year"] = 2002;
				vehicles.Rows.Add(newCar);

				//Add New DataRow by simply adding the values
				vehicles.Rows.Add("987654321XYZ", "Buick", 2001);

				//Load DataRow, replacing existing contents, if existing
				vehicles.LoadDataRow(new object[] { "987654321XYZ", "Jeep", 2002 }, LoadOption.OverwriteChanges);
				*/
			}
		}

		private void CreateSchema()
		{
			_ds = new DataSet("VehiclesRepairs");

			var vehicles = _ds.Tables.Add("Vehicles");
			vehicles.Columns.Add("VIN", typeof(string));
			vehicles.Columns.Add("Make", typeof(string));
			vehicles.Columns.Add("Model", typeof(string));
			vehicles.Columns.Add("Year", typeof(int));
			vehicles.PrimaryKey = new DataColumn[] { vehicles.Columns["VIN"] };

			var repairs = _ds.Tables.Add("Repairs");
			var pk = repairs.Columns.Add("ID", typeof(int));
			pk.AutoIncrement = true;
			pk.AutoIncrementSeed = -1;
			pk.AutoIncrementStep = -1;
			repairs.Columns.Add("VIN", typeof(string));
			repairs.Columns.Add("Description", typeof(string));
			repairs.Columns.Add("Cost", typeof(decimal));
			repairs.PrimaryKey = new DataColumn[] { repairs.Columns["ID"] };

			_ds.Relations.Add(
				"vehicles_repairs",
				vehicles.Columns["VIN"],
				repairs.Columns["VIN"]);

			_ds.WriteXmlSchema(_xsdFile);
		}

		private void OnMainFormClosing(object sender, FormClosingEventArgs e)
		{
			_ds.WriteXml(_xmlFile, XmlWriteMode.DiffGram);
		}

		private string GetDataRowInfo(DataRow row, string columnName)
		{
			string retVal = string.Format(
				"RowState: {0} \r\n",
				row.RowState);
			foreach (string versionString in Enum.GetNames(typeof (DataRowVersion)))
			{
				DataRowVersion version = (
				                         DataRowVersion) Enum.Parse(
					                         typeof (DataRowVersion), versionString);
				if (row.HasVersion(version))
				{
					retVal += string.Format(
						"Version: {0} Value: {1} \r\n",
						version, row[columnName, version]);
				}
				else
				{
					retVal += string.Format(
						"Version: {0} does not exist.\r\n",
						version);
				}
			}
			return retVal;
		}

		public void EnumerateTable(DataTable cars)
		{
			var buffer = new System.Text.StringBuilder();
			foreach (DataColumn dc in cars.Columns)
			{
				buffer.AppendFormat("{0,15} ", dc.ColumnName);
			}
			buffer.Append("\r\n");
			foreach (DataRow dr in cars.Rows)
			{
				if (dr.RowState == DataRowState.Deleted)
				{
					buffer.Append("Deleted Row");
				}
				else
				{
					foreach (DataColumn dc in cars.Columns)
					{
						buffer.AppendFormat("{0,15} ", dr[dc]);
					}
				}
				buffer.Append("\r\n");
			}
			//textBox1.Text = buffer.ToString();
		}
	}
}
