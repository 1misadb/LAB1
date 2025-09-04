using System;
using System.Collections.Generic;

namespace LAB1.Models;

public partial class User
{
    public int UserId { get; set; }

    public string LoginName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly RegisteredOn { get; set; }

    public string FullName { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
