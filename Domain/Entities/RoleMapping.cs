using System;
using System.Collections.Generic;

namespace Domain;

public partial class RoleMapping
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public Guid? UserId { get; set; }

    public virtual Role? Role { get; set; }

    public virtual Users? User { get; set; }
}
