﻿using System;
using System.Collections.Generic;

namespace EKART_Application.Models;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
