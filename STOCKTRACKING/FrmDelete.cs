using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STOCKTRACKING
{
    public partial class FrmDelete : Form
    {
        public FrmDelete()
        {
            InitializeComponent();
        }

        private void FrmDelete_Load(object sender, EventArgs e)
        {
            cmbDeleteData.Items.Add("Category");
            cmbDeleteData.Items.Add("Product");
            cmbDeleteData.Items.Add("Customer");
            cmbDeleteData.Items.Add("Sales");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
