using System;
using System.Collections.Generic;

namespace AzureBookManagement.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? BookName { get; set; }

    public double? Price { get; set; }

    public string? Category { get; set; }

    public string? PublisherName { get; set; }

    public virtual BookCategory? CategoryNavigation { get; set; }

    public virtual Publisher? PublisherNameNavigation { get; set; }
}
