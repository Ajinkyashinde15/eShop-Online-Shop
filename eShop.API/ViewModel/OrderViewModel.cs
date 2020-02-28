  
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eShop.API.ViewModel
{
    public class OrderViewModel
    {
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    [Required]
    [MinLength(4)]
    public string OrderNumber { get; set; }
    public ICollection<OrderItemViewModel> Items { get; set; }
    }
}