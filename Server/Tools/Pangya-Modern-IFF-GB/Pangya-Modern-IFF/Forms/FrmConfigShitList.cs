using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PangyaSuiteFiles.Forms
{
    public partial class FrmConfigShitList : Form
    {
        public FrmConfigShitList()
        {
            InitializeComponent();
        }

        private void cmbTypeChooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbTypeChooser.SelectedIndex == 0)
            {
                this.int_0 = 30;
                this.int_1 = 4;
            }
            else if (this.cmbTypeChooser.SelectedIndex == 1)
            {
                this.int_0 = 0x1f;
                this.int_1 = 5;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
