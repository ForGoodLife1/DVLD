namespace DVLD.Data.Entities;
public partial class DriversView
{
    public int DriverId { get; set; }

    public int PersonId { get; set; }

    public string NationalNo { get; set; } = null!;

    public string FullNameAr { get; set; } = null!;
    public string FullNameEn { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int? NumberOfActiveLicenses { get; set; }
}
