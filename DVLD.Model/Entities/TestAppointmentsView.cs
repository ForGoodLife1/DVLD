namespace DVLD.Data.Entities;

public partial class TestAppointmentsView
{
    public int TestAppointmentId { get; set; }

    public int LocalDrivingLicenseApplicationId { get; set; }

    public string TestTypeTitle { get; set; } = null!;

    public string ClassNameAr { get; set; } = null!;
    public string ClassNameEn { get; set; } = null!;

    public DateTime AppointmentDate { get; set; }

    public decimal PaidFees { get; set; }

    public string FullNameAr { get; set; } = null!;
    public string FullNameEn { get; set; } = null!;

    public bool IsLocked { get; set; }
}
