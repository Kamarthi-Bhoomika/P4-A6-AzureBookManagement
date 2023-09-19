using System;
using System.Collections.Generic;

namespace AzureBookManagement.Models;

public partial class BookCategory
{
    public string Category { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
