using Accessories.DataAccess.Data;
using Accessories.DataAccess.Repository.IRepository;
using Accessories.DataAccess.Repository.IRepository.Services;
using Accessories.DataAccess.Repository.Services;
using Accessories.DataAccess.Utils;
using Accessories.Models.DataTables;
using Accessories.Models.DataTables.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessories.DataAccess.Repository;

public class MenuItemRepo : Repository<MenuItem>, IMenuItemRepo
{
    private readonly ApplicationDbContext _db;
    private readonly IBlobService _blobService;

    public MenuItemRepo(ApplicationDbContext db, IBlobService blobService) : base(db)
    {
        _db = db;
        _blobService = blobService;
    }

    public async Task<MenuItem> CreateMenuItemAsync(MenuItemCreateDTO menuItemCreateDTO)
    {
        try
        {
            if(menuItemCreateDTO.File == null || menuItemCreateDTO.File.Length == 0)
                throw new ArgumentException("Image is required");
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(menuItemCreateDTO.File.FileName)}";

            MenuItem menuItemToCreate = new()
            {
                Name = menuItemCreateDTO.Name,
                Price = menuItemCreateDTO.Price,
                Category = menuItemCreateDTO.Category,
                SpecialTag = menuItemCreateDTO.SepcialTag,
                Description = menuItemCreateDTO.Description,
                Image = await _blobService.UploadBlob(fileName, SD.SD_Storage_Container, menuItemCreateDTO.File)
            };

            _db.MenuItems.Add(menuItemToCreate);
            await _db.SaveChangesAsync();

            return menuItemToCreate;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to create MenuItem.", ex);
        }
    }

    public async Task<MenuItem> UpdateMenuItemAsync(int id, MenuItemUpdateDTO menuItemUpdateDTO)
    {
        try
        {
            if (menuItemUpdateDTO == null || id != menuItemUpdateDTO.Id)
                throw new ArgumentException("Invalid data");

            MenuItem menuItemToUpdate = await _db.MenuItems.FindAsync(id);

            if (menuItemToUpdate == null)
                return null;

            menuItemToUpdate.Name = menuItemUpdateDTO.Name;
            menuItemToUpdate.Description = menuItemUpdateDTO.Description;
            menuItemToUpdate.Price = menuItemUpdateDTO.Price;
            menuItemToUpdate.Description = menuItemUpdateDTO.Description;

            if (menuItemUpdateDTO.File != null && menuItemUpdateDTO.File.Length > 0)
            {
                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(menuItemUpdateDTO.File.FileName)}";

                await _blobService.DeleteBlob(menuItemToUpdate.Image, SD.SD_Storage_Container);

                menuItemToUpdate.Image = await _blobService.UploadBlob(fileName, SD.SD_Storage_Container, menuItemUpdateDTO.File);
            }

            _db.MenuItems.Update(menuItemToUpdate);
            await _db.SaveChangesAsync();

            return menuItemToUpdate;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to update MenuItem.", ex);
        }
    }

    public async Task<bool> DeleteMenuItemAsync(int id)
    {
        try
        {
            if (id == 0)
                throw new ArgumentException("Invalid data");

            MenuItem menuItemToDelete = await _db.MenuItems.FindAsync(id);

            await _blobService.DeleteBlob(menuItemToDelete.Image.Split('/').Last(), SD.SD_Storage_Container);

            _db.MenuItems.Remove(menuItemToDelete);
            await _db.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to delete MenuItem.", ex);
        }
    }
}
