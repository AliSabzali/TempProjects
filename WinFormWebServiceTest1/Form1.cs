using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormWebServiceTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var ws = new ship.ship();
                var list = new List<ship.Input>()
                {
                    new ship.Input(){ Number = 0, FirstName = "ali" },
                    new ship.Input(){ Number = 100, FirstName = "azam" },
                    new ship.Input(){ Number = 200, FirstName = "arielle" },
                };
                var data = ws.HelloWorld(list.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
