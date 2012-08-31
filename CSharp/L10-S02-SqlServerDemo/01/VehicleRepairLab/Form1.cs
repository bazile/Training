using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;


namespace VehicleRepairLab
{
    public partial class Form1 : Form
    {
        private const string xsdFile = "VehiclesRepairs.xsd";
        private const string xmlFile = "VehiclesRepairs.xml";
        private DataSet ds;
        private string cnString;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cnString = ConfigurationManager
                .ConnectionStrings["db"]
                .ConnectionString;
            CheckConnectivity();
            PopulateDataSet();
            dgVehicles.DataSource = ds;
            dgVehicles.DataMember = "Vehicles";
            dgRepairs.DataSource = ds;
            dgRepairs.DataMember = "Vehicles.vehicles_repairs";
        }

        private void PopulateDataSet()
        {
            if (File.Exists(xsdFile))
            {
                ds = new DataSet();
                ds.ReadXmlSchema(xsdFile);
            }
            else
            {
                CreateSchema();
            }
            if (File.Exists(xmlFile))
            {
                ds.ReadXml(xmlFile, XmlReadMode.IgnoreSchema);
            };
        }


        private bool CheckConnectivity()
        {
            try
            {
                using (var cn = new SqlConnection(cnString))
                {
                    cn.Open();
                    var version = cn.ServerVersion;
                    MessageBox.Show("Connectivity established! " + version);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

         private void CreateSchema()
        {
            ds = new DataSet("VehiclesRepairs");

            var vehicles = ds.Tables.Add("Vehicles");
            vehicles.Columns.Add("VIN", typeof(string));
            vehicles.Columns.Add("Make", typeof(string));
            vehicles.Columns.Add("Model", typeof(string));
            vehicles.Columns.Add("Year", typeof(int));
            vehicles.PrimaryKey = new DataColumn[] { vehicles.Columns["VIN"] };

            var repairs = ds.Tables.Add("Repairs");
            var pk = repairs.Columns.Add("ID", typeof(int));
            pk.AutoIncrement = true;
            pk.AutoIncrementSeed = -1;
            pk.AutoIncrementStep = -1;
            repairs.Columns.Add("VIN", typeof(string));
            repairs.Columns.Add("Description", typeof(string));
            repairs.Columns.Add("Cost", typeof(decimal));
            repairs.PrimaryKey = new DataColumn[] { repairs.Columns["Id"] };

            ds.Relations.Add(
                "vehicles_repairs",
                vehicles.Columns["VIN"],
                repairs.Columns["VIN"]);

            ds.WriteXmlSchema(xsdFile);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ds.WriteXml(xmlFile, XmlWriteMode.DiffGram);
        }

        private void gridError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }




    }
}
