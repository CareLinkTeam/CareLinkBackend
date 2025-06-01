using System;
using System.Collections.Generic;

namespace Domain;

public partial class Role
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<RoleMapping> RoleMapping { get; set; } = new List<RoleMapping>();
}
