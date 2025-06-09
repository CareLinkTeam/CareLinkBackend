using System;
using System.Collections.Generic;

namespace Domain;

public partial class Caretaker
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string? Education { get; set; }

    public string? WorkHistory { get; set; }

    public string? Skill { get; set; }

    public virtual ICollection<AcceptedWork> AcceptedWork { get; set; } = new List<AcceptedWork>();

    public virtual Users? User { get; set; }

    public virtual ICollection<WorkPeriod> WorkPeriod { get; set; } = new List<WorkPeriod>();
}
