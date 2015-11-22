using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace BelhardTraining.Windows.Forms
{
    public partial class LinkLabelForm : DemoFormBase
    {
        public LinkLabelForm()
        {
            InitializeComponent();
        }

        private void HandleFormLoad(object sender, EventArgs e)
        {
            lnkLongText.Links.Clear();
            lnkLongText.Links.Add(14, 7, "http://tc.belhard.com");
            lnkLongText.Links.Add(33, 11, "http://www.tc.belhard.com/courselist/kursy-C-sharp.php");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel ll = (LinkLabel)sender;
            Process.Start(ll.Text);
        }

        private void lnkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel ll = (LinkLabel)sender;
            Process.Start("mailto:" + ll.Text);
        }

        private void lnkLongText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start((string)e.Link.LinkData);
            e.Link.Visited = true;
        }
    }
}
