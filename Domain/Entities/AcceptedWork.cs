using System;
using System.Collections.Generic;

namespace Domain;

public partial class AcceptedWork
{
    public int Id { get; set; }

    public int? PostId { get; set; }

    public Guid? CaretakerId { get; set; }

    public int? Rating { get; set; }

    public virtual Caretaker? Caretaker { get; set; }

    public virtual Post? Post { get; set; }

    public virtual ICollection<WorkDetail> WorkDetail { get; set; } = new List<WorkDetail>();
}
