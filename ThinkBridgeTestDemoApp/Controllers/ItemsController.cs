using BAL.IBusinessManager;
using DATA.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkBridgeTestDemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ILogger<ItemsController> _iLogger;
        private readonly IGenericManager<Items> _itemsManager;
        public ItemsController(ILogger<ItemsController> _ilogger, IGenericManager<Items> _itemsManager)
        {
            _iLogger = _ilogger;
            this._itemsManager = _itemsManager;
        }
        [HttpGet]
        [Route("GetItems")]
        public async Task<ICollection<Items>> GetItems()
        {
            try
            {
                _iLogger.LogInformation("List Items Called");
                return await _itemsManager.GetAllAsync();
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation("Error =" + ex.StackTrace + "Time =" + DateTime.Now);
                _iLogger.LogError(ex.InnerException.ToString());
                return null;
            }
        }

        [HttpGet]
        [Route("GetItemsById")]
        public async Task<Items> GetItemsById(int? id)
        {
            try
            {
                _iLogger.LogInformation("Find Items By Id Called");
                return await _itemsManager.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation("Error =" + ex.StackTrace + "Time =" + DateTime.Now);
                _iLogger.LogError(ex.InnerException.ToString());
                return null;
            }
        }

        [HttpPost]
        [Route("AddItem")]
        public async Task<Items> AddItem(Items items = null)
        {
            try
            {
                items.CreatedAt = DateTime.Now;
                _iLogger.LogInformation("Add Item Called");
                return await _itemsManager.InsertAsync(items);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation("Error =" + ex.StackTrace + "Time =" + DateTime.Now);
                _iLogger.LogError(ex.InnerException.ToString());
                return null;
            }
        }

        [HttpPost]
        [Route("AddItems")]
        public async Task<Items> AddItemS(ICollection<Items> items = null)
        {
            try
            {
                foreach (var item in items)
                {
                    item.CreatedAt = DateTime.Now;
                }
                _iLogger.LogInformation("Add Item Called");
                return await _itemsManager.InsertAllAsync(items);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation("Error =" + ex.StackTrace + "Time =" + DateTime.Now);
                _iLogger.LogError(ex.InnerException.ToString());
                return null;
            }
        }

        [HttpPatch]
        [Route("UpdateItem")]
        public async Task<Items> UpdateItem(Items items = null)
        {
            try
            {
                items.ModifiedAt = DateTime.Now;
                _iLogger.LogInformation("Update Item Called");
                return await _itemsManager.UpdateAsync(items, items.Id);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation("Error =" + ex.StackTrace + "Time =" + DateTime.Now);
                _iLogger.LogError(ex.InnerException.ToString());
                return null;
            }
        }
        [HttpDelete]
        [Route("DeleteItem")]
        public async Task<int> DeleteItem(Items items = null)
        {
            try
            {
                _iLogger.LogInformation("Delete Item Called at " + DateTime.Now);
                return await _itemsManager.DeleteAsync(items);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation("Error =" + ex.StackTrace + "Time =" + DateTime.Now);
                _iLogger.LogError(ex.InnerException.ToString());
                return 0;
            }
        }
    }
}