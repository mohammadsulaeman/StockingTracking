using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STOCKTRACKING.DAL.DAO;
using STOCKTRACKING.DAL.DTO;

namespace STOCKTRACKING.DAL.DTO
{
    public class CustomerDTO
    {
        public List<CustomerDetailDTO> Customers { get; set; }
    }
}
