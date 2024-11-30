namespace DVLD.Data.Entities;

public partial class Person
{
    public int PersonId { get; set; }

    public string NationalNo { get; set; } = null!;

    public string FirstNameAr { get; set; } = null!;
    public string FirstNameEn { get; set; } = null!;

    public string SecondNameAr { get; set; } = null!;
    public string SecondNameEn { get; set; } = null!;

    public string? ThirdNameAr { get; set; }
    public string? ThirdNameEn { get; set; }

    public string LastNameAr { get; set; } = null!;
    public string LastNameEn { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// 0 Male , 1 Femail
    /// </summary>
    public byte Gendor { get; set; }

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public int NationalityCountryId { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();

    public virtual Country NationalityCountry { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
