﻿using System;
using System.Collections.Generic;

namespace DVLD.Data.Entities;

public partial class TestAppointment
{
    public int TestAppointmentId { get; set; }

    public int TestTypeId { get; set; }

    public int LocalDrivingLicenseApplicationId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public decimal PaidFees { get; set; }

    public int CreatedByUserId { get; set; }

    public bool IsLocked { get; set; }

    public virtual User CreatedByUser { get; set; } = null!;

    public virtual LocalDrivingLicenseApplication LocalDrivingLicenseApplication { get; set; } = null!;

    public virtual TestType TestType { get; set; } = null!;

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
