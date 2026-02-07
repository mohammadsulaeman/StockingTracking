using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STOCKTRACKING.DAL.DTO;
using STOCKTRACKING.DAL.DAO;

namespace STOCKTRACKING.BLL
{
    public class SalesBLL : IBLL<SalesDetailDTO, SalesDTO>
    {
        SalesDAO salesDao = new SalesDAO();
        ProductDAO productDao = new ProductDAO();
        CategoryDAO categoryDao = new CategoryDAO();
        CustomerDAO customerDao = new CustomerDAO();

        public bool Delete(SalesDetailDTO entity)
        {
            SALE sale = new SALE();
            sale.ID = entity.SalesID;
            salesDao.Delete(sale);
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            product.StockAmount = entity.StockAmount + entity.SalesAmount;
            productDao.Update(product);
            return true;
        }

        public bool GetBack(SalesDetailDTO entity)
        {
            salesDao.GetBack(entity.SalesID);
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            int temp = entity.StockAmount - entity.SalesAmount;
            product.StockAmount = temp;
            productDao.Update(product);
            return true;
        }

        public bool Insert(SalesDetailDTO entity)
        {
            SALE sales = new SALE();
            sales.CategoryID = entity.CategoryID;
            sales.ProductID = entity.ProductID;
            sales.CustomerID = entity.CustomerID;
            sales.ProductSalesPrice = entity.Price;
            sales.ProductSalesAmount = entity.SalesAmount;
            sales.SalesDate = entity.SalesDate;
            salesDao.Insert(sales);
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            int temp = entity.StockAmount - entity.SalesAmount;
            product.StockAmount = temp;
            productDao.Update(product);
            return true;
        }

        public SalesDTO Select()
        {
            SalesDTO dto = new SalesDTO();
            dto.Products = productDao.Select();
            dto.Customers = customerDao.Select();
            dto.Categories = categoryDao.Select();
            dto.Sales = salesDao.Select();
            return dto;

        }

        public SalesDTO Select(bool isDeleted)
        {
            SalesDTO dto = new SalesDTO();
            dto.Products = productDao.Select(isDeleted);
            dto.Customers = customerDao.Select(isDeleted);
            dto.Categories = categoryDao.Select(isDeleted);
            dto.Sales = salesDao.Select(isDeleted);
            return dto;

        }

        public bool Update(SalesDetailDTO entity)
        {
            SALE sale = new SALE();
            sale.ID = entity.SalesID;
            sale.ProductSalesAmount = entity.SalesAmount;
            salesDao.Update(sale);
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            product.StockAmount = entity.StockAmount;
            productDao.Update(product);
            return true;
        }
    }
}
