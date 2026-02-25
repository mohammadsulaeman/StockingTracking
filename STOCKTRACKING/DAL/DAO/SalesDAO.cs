using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STOCKTRACKING.DAL.DTO;
using STOCKTRACKING.DAL.DAO;

namespace STOCKTRACKING.DAL.DAO
{
    public class SalesDAO : StockContext, IDAO<SALE, SalesDetailDTO>
    {
        public bool Delete(SALE entity)
        {
            try
            {
                if(entity.ID != 0)
                {
                    SALE sale = db.SALEs.First(x => x.ID == entity.ID);
                    sale.isDeleted = true;
                    sale.DeletedDate = DateTime.Today;
                    db.SaveChanges();
                }else if(entity.ProductID != 0)
                {
                    List<SALE> sales = db.SALEs.Where(x => x.ProductID == entity.ProductID).ToList();
                    foreach(var item in sales)
                    {
                        item.isDeleted = true;
                        item.DeletedDate = DateTime.Today;
                    }
                    db.SaveChanges();
                }else if(entity.CustomerID != 0)
                {
                    List<SALE> sales = db.SALEs.Where(x => x.CustomerID == entity.CustomerID).ToList();
                    foreach (var item in sales)
                    {
                        item.isDeleted = true;
                        item.DeletedDate = DateTime.Today;
                    }
                    db.SaveChanges();
                }
                
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool GetBack(int ID)
        {
            try
            {
                SALE sale = db.SALEs.First(x => x.ID == ID);
                sale.isDeleted = false;
                sale.DeletedDate = null;
                db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(SALE entity)
        {
            try
            {
                db.SALEs.Add(entity);
                db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<SalesDetailDTO> Select()
        {
            try
            {
                List<SalesDetailDTO> sales = new List<SalesDetailDTO>();
                var list = (from s in db.SALEs.Where(x => x.isDeleted == false)
                            join p in db.PRODUCTs on s.ProductID equals p.ID
                            join c in db.CUSTOMERs on s.CustomerID equals c.ID
                            join category in db.CATEGORies on s.CategoryID equals category.ID
                            select new
                            {
                                productName = p.ProductName,
                                customerName = c.CustomerName,
                                categoryName = category.CategoryName,
                                productID = s.ProductID,
                                customerID = s.CustomerID,
                                salesID = s.ID,
                                categoryID = s.CategoryID,
                                salesPrice = s.ProductSalesPrice,
                                salesAmount = s.ProductSalesAmount,
                                salesDate = s.SalesDate,
                                CategoryDeleted = category.isDeleted,
                                CustomerDeleted = c.isDeleted,
                                ProductDeleted = p.isDeleted
                            }).OrderBy(x => x.salesDate).ToList();

                foreach(var item in list)
                {
                    SalesDetailDTO dto = new SalesDetailDTO();
                    dto.ProductName = item.productName;
                    dto.CustomerName = item.customerName;
                    dto.CategoryName = item.categoryName;
                    dto.ProductID = item.productID;
                    dto.CustomerID = item.customerID;
                    dto.CategoryID = item.categoryID;
                    dto.SalesID = item.salesID;
                    dto.Price = item.salesPrice;
                    dto.SalesAmount = item.salesAmount;
                    dto.SalesDate = item.salesDate;
                    dto.isCategoryDeleted = item.CategoryDeleted;
                    dto.isCustomerDeleted = item.CustomerDeleted;
                    dto.isProductDeleted = item.ProductDeleted;
                    sales.Add(dto);

                }
                return sales;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<SalesDetailDTO> Select(bool isDeleted)
        {
            try
            {
                List<SalesDetailDTO> sales = new List<SalesDetailDTO>();
                var list = (from s in db.SALEs.Where(x => x.isDeleted == isDeleted)
                            join p in db.PRODUCTs on s.ProductID equals p.ID
                            join c in db.CUSTOMERs on s.CustomerID equals c.ID
                            join category in db.CATEGORies on s.CategoryID equals category.ID
                            select new
                            {
                                productName = p.ProductName,
                                customerName = c.CustomerName,
                                categoryName = category.CategoryName,
                                productID = s.ProductID,
                                customerID = s.CustomerID,
                                salesID = s.ID,
                                categoryID = s.CategoryID,
                                salesPrice = s.ProductSalesPrice,
                                salesAmount = s.ProductSalesAmount,
                                salesDate = s.SalesDate
                            }).OrderBy(x => x.salesDate).ToList();

                foreach (var item in list)
                {
                    SalesDetailDTO dto = new SalesDetailDTO();
                    dto.ProductName = item.productName;
                    dto.CustomerName = item.customerName;
                    dto.CategoryName = item.categoryName;
                    dto.ProductID = item.productID;
                    dto.CustomerID = item.customerID;
                    dto.CategoryID = item.categoryID;
                    dto.SalesID = item.salesID;
                    dto.Price = item.salesPrice;
                    dto.SalesAmount = item.salesAmount;
                    dto.SalesDate = item.salesDate;
                    sales.Add(dto);

                }
                return sales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(SALE entity)
        {
            try
            {
                SALE sale = db.SALEs.First(x => x.ID == entity.ID);
                sale.ProductSalesAmount = entity.ProductSalesAmount;
                db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
