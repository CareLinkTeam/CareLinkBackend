using System;
using System.Collections.Generic;

namespace Domain;

public partial class Users
{
    public Guid Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public string? Image { get; set; }

    public int? Age { get; set; }

    public virtual ICollection<Caretaker> Caretaker { get; set; } = new List<Caretaker>();

    public virtual ICollection<Posting> Posting { get; set; } = new List<Posting>();

    public virtual ICollection<RoleMapping> RoleMapping { get; set; } = new List<RoleMapping>();
}
