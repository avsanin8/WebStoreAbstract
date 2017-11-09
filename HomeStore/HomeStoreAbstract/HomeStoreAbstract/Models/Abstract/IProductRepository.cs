using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeStoreAbstract.Models.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> Products { get; }
    }
}
