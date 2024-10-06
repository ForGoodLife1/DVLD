namespace DVLD.Data.Entities;

public partial class LocalDrivingLicenseApplicationsView
{
    public int LocalDrivingLicenseApplicationId { get; set; }

    public string ClassNameAr { get; set; } = null!;
    public string ClassNameEn { get; set; } = null!;

    public string NationalNo { get; set; } = null!;

    public string FullNameAr { get; set; } = null!;
    public string FullNameEn { get; set; } = null!;

    public DateTime ApplicationDate { get; set; }

    public int? PassedTestCount { get; set; }

    public string? Status { get; set; }
}
