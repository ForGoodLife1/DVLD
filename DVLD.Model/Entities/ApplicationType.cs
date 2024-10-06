using System;
using System.Collections.Generic;

namespace DVLD.Data.Entities;

public partial class ApplicationType
{
    public int ApplicationTypeId { get; set; }

    public string ApplicationTypeTitle { get; set; } = null!;

    public decimal ApplicationFees { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
