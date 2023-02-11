using POS.Api.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace POS.Api.DTOs.Request
{
    public abstract class AddonRequest
    {
        public decimal Price { get; set; }
    }
}
