using System;
using System.Collections.Generic;

namespace Domain;

public partial class Post
{
    public int Id { get; set; }

    public Guid? UserId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Tel { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public string? Disease { get; set; }

    public string? Location { get; set; }

    public DateOnly? StartTime { get; set; }

    public DateOnly? EndTime { get; set; }

    public int? Status { get; set; }

    public DateOnly? WorkingDate { get; set; }

    public virtual ICollection<AcceptedWork> AcceptedWork { get; set; } = new List<AcceptedWork>();

    public virtual ICollection<Payment> Payment { get; set; } = new List<Payment>();

    public virtual Users? User { get; set; }
}
