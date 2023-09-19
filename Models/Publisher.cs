using System;
using System.Collections.Generic;

namespace AzureBookManagement.Models;

public partial class Publisher
{
    public string PublisherName { get; set; } = null!;

    public string? Address { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
