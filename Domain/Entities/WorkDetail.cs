using System;
using System.Collections.Generic;

namespace Domain;

public partial class WorkDetail
{
    public int Id { get; set; }

    public int? AcceptWorkId { get; set; }

    public int? WorkPeriodId { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? UpdateDate { get; set; }

    public virtual AcceptedWork? AcceptWork { get; set; }

    public virtual WorkPeriod? WorkPeriod { get; set; }
}
