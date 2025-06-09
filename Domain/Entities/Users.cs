using System;
using System.Collections.Generic;

namespace Domain;

public partial class Users
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public string? Image { get; set; }

    public int? Age { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Caretaker> Caretaker { get; set; } = new List<Caretaker>();

    public virtual ICollection<Post> Post { get; set; } = new List<Post>();

    public virtual ICollection<RoleMapping> RoleMapping { get; set; } = new List<RoleMapping>();
}
