using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using STOCKTRACKING.DAL;
using STOCKTRACKING.BLL;
using STOCKTRACKING.DAL.DTO;

namespace STOCKTRACKING
{
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        CategoryBLL bll = new CategoryBLL();
        public CategoryDetailDTO detail = new CategoryDetailDTO();
        public bool isUpdate = false;
        private void FrmCategory_Load(object sender, EventArgs e)
        {
            if (isUpdate)
                txtCategory.Text = detail.CategoryName;
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCategory.Text.Trim() == "")
                MessageBox.Show("Category name is empty");
            else
            {
                if (!isUpdate)
                {
                    CategoryDetailDTO category = new CategoryDetailDTO();
                    category.CategoryName = txtCategory.Text;
                    if (bll.Insert(category))
                    {
                        MessageBox.Show("Category was added");
                        txtCategory.Clear();
                    }
                }else if(isUpdate)
                {
                    if (detail.CategoryName == txtCategory.Text.Trim())
                        MessageBox.Show("There is No Change");
                    else
                    {
                        DialogResult result = MessageBox.Show("Are you sure update this category ?", "Warning", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            detail.CategoryName = txtCategory.Text;
                            if (bll.Update(detail))
                            {
                                MessageBox.Show("Category was updated");
                                this.Close();
                            }
                        }
                    }
                    
                   
                }
                
            }
        }
    }
}
