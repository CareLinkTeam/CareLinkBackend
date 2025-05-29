using System;
using System.Collections.Generic;

namespace Domain;

public partial class AcceptedWork
{
    public int Id { get; set; }

    public int? PostingId { get; set; }

    public Guid? CaretakerId { get; set; }

    public int? Rating { get; set; }

    public int? WorkingDetailId { get; set; }

    public virtual Caretaker? Caretaker { get; set; }

    public virtual Posting? Posting { get; set; }

    public virtual WorkingDetail? WorkingDetail { get; set; }
}
