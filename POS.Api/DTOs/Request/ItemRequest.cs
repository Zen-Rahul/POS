using POS.Api.Data.Enums;
using POS.Api.DTOs.Base;

namespace POS.Api.DTOs.Request
{
    public class ItemRequest: ItemBase
    {
        public InventoryType Type { get; set; }
        public string Name { get; set; }
    }
}
