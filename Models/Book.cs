using System;
using System.Collections.Generic;

namespace LAB1.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Article { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public string Status { get; set; } = null!;

    public int? CurrentReaderId { get; set; }

    public virtual User? CurrentReader { get; set; }
}
