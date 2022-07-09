using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using UglyToad.PdfPig;
using UglyToad.PdfPig.AcroForms;
using UglyToad.PdfPig.AcroForms.Fields;
using UglyToad.PdfPig.Content;

namespace WinFormWebServiceTest2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var data = new V2Ship.CertifiedMailLoad()
                {
                    LoadType = V2Ship.CMLoadType.BarCode,
                    CMLoadItems = new List<V2Ship.CMLoadItem>()
                    {
                        new V2Ship.CMLoadItem()
                        {
                            //ShipTypeID = 2,
                            //ToAddress1 = "adddf dsf ff",
                            //ToAddress2 = "#A",
                            //ToCity = "rome",
                            //ToState = "Ga",
                            //ToFirm = "HeadLX",
                            //ToName = "Mr. ADA",
                            //ToZip5 = "30161",
                            //IMbTypeID = V2Ship.IMbRequestType.IMB_WITH_RECIPIENT_ADDRESS
                            ShipTypeID = 50,
                            CustomerRefNo = "1010", // CasefileNumber
                            ClientArticleID = "9999", // ProcessId
                            MailerDocName = "some doc",
                            ToName = "John Doe",
                            ToAddress1 = "13160 Foster Street",
                            ToCity = "Overland Park",
                            ToState = "KS",
                            ToZip5 = "66213",
                            Duplex = true,
                            RetEnvInd = false,
                            RetEnvTypeID = 1,
                            RetEnvToName = "CaseMax",
                            RetEnvToFirm = "",
                            RetEnvToAddress1 = "13160 Foster",
                            RetEnvToAddress2 = "",
                            RetEnvToCity = "OP",
                            RetEnvToState = "KS",
                            RetEnvToZip5 = "66213",
                        }
                    }.ToArray()
                };
                var service = new V2Ship.wsShip();
                var result = service.RequestCMOperation("ED7E77AB-61F5-4386-968A-FEF8321FFBDC", data);
                dataGridView1.DataSource = data.CMLoadItems;
                dataGridView2.DataSource = result.CMLoadItems;
                richTextBox1.Text = result.ProcessMessage;

                foreach (DataGridViewColumn item in dataGridView2.Columns)
                {
                    if(item is DataGridViewImageColumn)
                    {
                        var col = item as DataGridViewImageColumn;
                        col.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Text = ex.ToString();
            }            
        }
    }
}
