using Accessories.Models.Data_Tables;
using Accessories.Models.DataTables.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessories.DataAccess.Repository.IRepository;

public interface IMenuItemRepo : IRepository<MenuItem>
{
    Task<MenuItem> CreateMenuItemAsync(MenuItemCreateDTO menuItemCreateDTO);
    Task<MenuItem> UpdateMenuItemAsync(int id, MenuItemUpdateDTO menuItemUpdateDTO);
    Task<bool> DeleteMenuItemAsync(int id);
}
