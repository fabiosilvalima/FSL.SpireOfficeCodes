using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSL.SpireOffice.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PdfDocument doc = new PdfDocument();

            var url = "http://www.e-iceblue.com/";
            doc.LoadFromHTML(url, false, true, true);
            doc.SaveToFile(@"C:\inetpub\wwwroot\TFS\FabioSilvaLima\GitHub\FSL.SpireOfficeCodes\FSL.SpireOffice.Mvc\App_Data\fabiosilvalima.pdf");
            doc.Close();
        }
    }
}
