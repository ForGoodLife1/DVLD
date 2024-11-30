namespace DVLD.Data.Entities;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryNameAr { get; set; } = null!;
    public string CountryNameEn { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
