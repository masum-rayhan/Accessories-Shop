﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessories.Models.DataTables;

public class ShoppingCart
{
    [Key]
    public int Id { get; set; }
    public string UserId { get; set; }

    public string StripePaymentIntentId { get; set; }
    public string ClientSecret { get; set; }

    public ICollection<CartItem> CartItems { get; set; }

    [NotMapped]
    public double CartTotal { get; set; }
}
