using System;
using System.Collections.Generic;

namespace Domain;

public partial class WorkPeriod
{
    public int Id { get; set; }

    public Guid? CaretakerId { get; set; }

    public DateOnly? StartTime { get; set; }

    public DateOnly? EndTime { get; set; }

    public DateOnly? WorkingDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual Caretaker? Caretaker { get; set; }
}
