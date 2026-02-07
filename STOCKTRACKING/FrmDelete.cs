using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using STOCKTRACKING.BLL;
using STOCKTRACKING.DAL.DTO;

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
            dto = salesBLL.Select(true);
            dataGridView1.DataSource = dto.Sales;
            dataGridView1.Columns[0].HeaderText = "Customer Name";
            dataGridView1.Columns[1].HeaderText = "Product Name";
            dataGridView1.Columns[2].HeaderText = "Category Name";
            dataGridView1.Columns[6].HeaderText = "Sales Name";
            dataGridView1.Columns[7].HeaderText = "Price ";
            dataGridView1.Columns[8].HeaderText = "Sales Date";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        SalesDetailDTO salesDetail = new SalesDetailDTO();
        ProductDetailDTO productDetail = new ProductDetailDTO();
        CategoryDetailDTO categoryDetail = new CategoryDetailDTO();
        CustomerDetailDTO customerDetail = new CustomerDetailDTO();
        SalesDTO dto = new SalesDTO();
        SalesBLL salesBLL = new SalesBLL();
        CategoryBLL categoryBLL = new CategoryBLL();
        ProductBLL productBLL = new ProductBLL();
        CustomerBLL customerBLL = new CustomerBLL();
        private void cmbDeleteData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbDeleteData.SelectedIndex == 0)
            {
                dataGridView1.DataSource = dto.Categories;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Category Name";
            }
            else if(cmbDeleteData.SelectedIndex == 1)
            {
                dataGridView1.DataSource = dto.Products;
                dataGridView1.Columns[0].HeaderText = "Product Name";
                dataGridView1.Columns[1].HeaderText = "Category Name";
                dataGridView1.Columns[2].HeaderText = "Stock Amount";
                dataGridView1.Columns[3].HeaderText = "Price";
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;

            }
            else if(cmbDeleteData.SelectedIndex == 2)
            {
                dataGridView1.DataSource = dto.Customers;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Customer Name";
            }
            else if(cmbDeleteData.SelectedIndex == 3)
            {
                dataGridView1.DataSource = dto.Sales;
                dataGridView1.Columns[0].HeaderText = "Customer Name";
                dataGridView1.Columns[1].HeaderText = "Product Name";
                dataGridView1.Columns[2].HeaderText = "Category Name";
                dataGridView1.Columns[6].HeaderText = "Sales Name";
                dataGridView1.Columns[7].HeaderText = "Price ";
                dataGridView1.Columns[8].HeaderText = "Sales Date";
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(cmbDeleteData.SelectedIndex == 0)
            {
                categoryDetail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                categoryDetail.CategoryName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
              
            }
            else if(cmbDeleteData.SelectedIndex == 1)
            {
                productDetail.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                productDetail.CategoryID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                productDetail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                productDetail.Price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                productDetail.isCategoryDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
            }
            else if(cmbDeleteData.SelectedIndex == 2)
            {
                customerDetail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                customerDetail.CustomerName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }else
            {
                salesDetail = new SalesDetailDTO();
                salesDetail.SalesID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
                salesDetail.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                salesDetail.CustomerName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                salesDetail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                salesDetail.Price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
                salesDetail.SalesAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
                salesDetail.isCategoryDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[11].Value);
                salesDetail.isCustomerDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[12].Value);
                salesDetail.isProductDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[13].Value);
            }
        }

        private void btnGetBack_Click(object sender, EventArgs e)
        {
            if (cmbDeleteData.SelectedIndex == 0)
            {
               if(categoryBLL.GetBack(categoryDetail))
                {

                    MessageBox.Show("Category was Get back");
                    dto = salesBLL.Select(true);
                    dataGridView1.DataSource = dto.Categories;
                }

            }
            else if (cmbDeleteData.SelectedIndex == 1)
            {
                if (productDetail.isCategoryDeleted)
                    MessageBox.Show("Category was delete first get back category");
               else if(productBLL.GetBack(productDetail))
                {
                    MessageBox.Show("Product was Get back");
                    dto = salesBLL.Select(true);
                    dataGridView1.DataSource = dto.Products;
                }
            }
            else if (cmbDeleteData.SelectedIndex == 2)
            {
                if (customerBLL.GetBack(customerDetail)){
                    MessageBox.Show("Customer was Get back");
                    dto = salesBLL.Select(true);
                    dataGridView1.DataSource = dto.Customers;
                }
            }
            else
            {
                if(salesDetail.isCategoryDeleted || salesDetail.isCustomerDeleted || salesDetail.isProductDeleted)
                {
                    if(salesDetail.isCategoryDeleted)
                        MessageBox.Show("Category was delete first get back category");
                    else if (salesDetail.isCustomerDeleted)
                        MessageBox.Show("Customer was delete first get back Customer");
                    else if (salesDetail.isProductDeleted)
                        MessageBox.Show("Product was delete first get back Product");
                }
                else if(salesBLL.GetBack(salesDetail))
                {
                    MessageBox.Show("Sales was Get back");
                    dto = salesBLL.Select(true);
                    dataGridView1.DataSource = dto.Sales;
                }
            }
        }
    }
}
