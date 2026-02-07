using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STOCKTRACKING.DAL.DTO;
using STOCKTRACKING.DAL.DAO;
using STOCKTRACKING.DAL;

namespace STOCKTRACKING.BLL
{
    public class ProductBLL : IBLL<ProductDetailDTO, ProductDTO>
    {
        CategoryDAO categorydao = new CategoryDAO();
        ProductDAO productdao = new ProductDAO();
        SalesDAO salesDao = new SalesDAO();
        public bool Delete(ProductDetailDTO entity)
        {
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            productdao.Delete(product);
            SALE sale = new SALE();
            sale.ProductID = entity.ProductID;
            salesDao.Delete(sale);
            return true;
        }

        public bool GetBack(ProductDetailDTO entity)
        {
            return productdao.GetBack(entity.ProductID);
        }

        public bool Insert(ProductDetailDTO entity)
        {
            PRODUCT product = new PRODUCT();
            product.ProductName = entity.ProductName;
            product.CategoryID = entity.CategoryID;
            product.Price = entity.Price;
            return productdao.Insert(product);
        }

        public ProductDTO Select()
        {
            ProductDTO dto = new ProductDTO();
            dto.Categories = categorydao.Select();
            dto.products = productdao.Select();
            return dto;
        }

        public bool Update(ProductDetailDTO entity)
        {
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            product.Price = entity.Price;
            product.ProductName = entity.ProductName;
            product.StockAmount = entity.StockAmount;
            product.CategoryID = entity.CategoryID;
            return productdao.Update(product);
        }
    }
}
