using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;
    [EmailAddress]

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;
    [StringLength(15, ErrorMessage = "Your FirstName is to much long")]

    public string LastName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

}
