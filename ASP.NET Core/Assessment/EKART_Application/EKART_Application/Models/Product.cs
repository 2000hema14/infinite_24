using System;
using System.Collections.Generic;

namespace EKART_Application.Models;

public partial class Product
{
    public int Productid { get; set; }

    public string? Productname { get; set; }

    public decimal? Price { get; set; }

    public int? QuantityAvailable { get; set; }
}
