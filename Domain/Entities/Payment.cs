using System;
using System.Collections.Generic;

namespace Domain;

public partial class Payment
{
    public Guid Id { get; set; }

    public int? PaymentMethod { get; set; }

    public int? Amount { get; set; }

    public int? PaymentStatus { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? UpdateDate { get; set; }

    public int? PostId { get; set; }

    public virtual Post? Post { get; set; }
}
