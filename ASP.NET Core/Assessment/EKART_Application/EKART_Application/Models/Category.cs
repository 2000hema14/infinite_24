using System;
using System.Collections.Generic;

namespace EKART_Application.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    public virtual ICollection<Product1> Product1s { get; set; } = new List<Product1>();
}
