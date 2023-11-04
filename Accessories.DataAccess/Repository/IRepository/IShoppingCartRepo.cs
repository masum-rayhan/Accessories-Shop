using Accessories.Models.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessories.DataAccess.Repository.IRepository;

public interface IShoppingCartRepo
{
    Task<ShoppingCart> GetAsync(string userId);
    Task<ShoppingCart> CreateOrUpdateItemInCartAsync(string userId, int menuItemId, int updateQuantityBy);
}
