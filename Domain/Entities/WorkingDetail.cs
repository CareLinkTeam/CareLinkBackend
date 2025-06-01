using System;
using System.Collections.Generic;

namespace Domain;

public partial class WorkingDetail
{
    public int Id { get; set; }

    public Guid? AcceptWorkId { get; set; }

    public string? WorkDetail { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? UpdateDate { get; set; }
}
