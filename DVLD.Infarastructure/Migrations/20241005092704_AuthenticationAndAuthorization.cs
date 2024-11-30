using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DVLD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AuthenticationAndAuthorization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationTypes",
                columns: table => new
                {
                    ApplicationTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationTypeTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ApplicationFees = table.Column<decimal>(type: "smallmoney", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationTypes", x => x.ApplicationTypeID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryNameAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryNameEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Countrie__10D160BFDBD6933F", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "LicenseClasses",
                columns: table => new
                {
                    LicenseClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClassDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MinimumAllowedAge = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)18, comment: "Minmum age allowed to apply for this license"),
                    DefaultValidityLength = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1, comment: "How many years the licesnse will be valid."),
                    ClassFees = table.Column<decimal>(type: "smallmoney", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseClasses", x => x.LicenseClassID);
                });

            migrationBuilder.CreateTable(
                name: "TestTypes",
                columns: table => new
                {
                    TestTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestTypeTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TestTypeDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TestTypeFees = table.Column<decimal>(type: "smallmoney", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTypes", x => x.TestTypeID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRefreshToken_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstNameAr = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstNameEn = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SecondNameAr = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SecondNameEn = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ThirdNameAr = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ThirdNameEn = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastNameAr = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastNameEn = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    Gendor = table.Column<byte>(type: "tinyint", nullable: false, comment: "0 Male , 1 Femail"),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NationalityCountryID = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_People_Countries1",
                        column: x => x.NationalityCountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    UserNameAr = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserNameEn = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_People",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantPersonID = table.Column<int>(type: "int", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ApplicationTypeID = table.Column<int>(type: "int", nullable: false),
                    ApplicationStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 1, comment: "1-New 2-Cancelled 3-Completed"),
                    LastStatusDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PaidFees = table.Column<decimal>(type: "smallmoney", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationID);
                    table.ForeignKey(
                        name: "FK_Applications_ApplicationTypes",
                        column: x => x.ApplicationTypeID,
                        principalTable: "ApplicationTypes",
                        principalColumn: "ApplicationTypeID");
                    table.ForeignKey(
                        name: "FK_Applications_People",
                        column: x => x.ApplicantPersonID,
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Applications_Users",
                        column: x => x.CreatedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers_1", x => x.DriverID);
                    table.ForeignKey(
                        name: "FK_Drivers_People",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK_Drivers_Users",
                        column: x => x.CreatedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "LocalDrivingLicenseApplications",
                columns: table => new
                {
                    LocalDrivingLicenseApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationID = table.Column<int>(type: "int", nullable: false),
                    LicenseClassID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrivingLicsenseApplications", x => x.LocalDrivingLicenseApplicationID);
                    table.ForeignKey(
                        name: "FK_DrivingLicsenseApplications_Applications",
                        column: x => x.ApplicationID,
                        principalTable: "Applications",
                        principalColumn: "ApplicationID");
                    table.ForeignKey(
                        name: "FK_DrivingLicsenseApplications_LicenseClasses",
                        column: x => x.LicenseClassID,
                        principalTable: "LicenseClasses",
                        principalColumn: "LicenseClassID");
                });

            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    LicenseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationID = table.Column<int>(type: "int", nullable: false),
                    DriverID = table.Column<int>(type: "int", nullable: false),
                    LicenseClass = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PaidFees = table.Column<decimal>(type: "smallmoney", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IssueReason = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1, comment: "1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost."),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.LicenseID);
                    table.ForeignKey(
                        name: "FK_Licenses_Applications",
                        column: x => x.ApplicationID,
                        principalTable: "Applications",
                        principalColumn: "ApplicationID");
                    table.ForeignKey(
                        name: "FK_Licenses_Drivers",
                        column: x => x.DriverID,
                        principalTable: "Drivers",
                        principalColumn: "DriverID");
                    table.ForeignKey(
                        name: "FK_Licenses_LicenseClasses",
                        column: x => x.LicenseClass,
                        principalTable: "LicenseClasses",
                        principalColumn: "LicenseClassID");
                    table.ForeignKey(
                        name: "FK_Licenses_Users",
                        column: x => x.CreatedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "TestAppointments",
                columns: table => new
                {
                    TestAppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestTypeID = table.Column<int>(type: "int", nullable: false),
                    LocalDrivingLicenseApplicationID = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    PaidFees = table.Column<decimal>(type: "smallmoney", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAppointments", x => x.TestAppointmentID);
                    table.ForeignKey(
                        name: "FK_TestAppointments_LocalDrivingLicenseApplications",
                        column: x => x.LocalDrivingLicenseApplicationID,
                        principalTable: "LocalDrivingLicenseApplications",
                        principalColumn: "LocalDrivingLicenseApplicationID");
                    table.ForeignKey(
                        name: "FK_TestAppointments_TestTypes",
                        column: x => x.TestTypeID,
                        principalTable: "TestTypes",
                        principalColumn: "TestTypeID");
                    table.ForeignKey(
                        name: "FK_TestAppointments_Users",
                        column: x => x.CreatedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "DetainedLicenses",
                columns: table => new
                {
                    DetainID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseID = table.Column<int>(type: "int", nullable: false),
                    DetainDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    FineFees = table.Column<decimal>(type: "smallmoney", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    IsReleased = table.Column<bool>(type: "bit", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    ReleasedByUserID = table.Column<int>(type: "int", nullable: true),
                    ReleaseApplicationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetainedLicenses", x => x.DetainID);
                    table.ForeignKey(
                        name: "FK_DetainedLicenses_Applications",
                        column: x => x.ReleaseApplicationID,
                        principalTable: "Applications",
                        principalColumn: "ApplicationID");
                    table.ForeignKey(
                        name: "FK_DetainedLicenses_Licenses",
                        column: x => x.LicenseID,
                        principalTable: "Licenses",
                        principalColumn: "LicenseID");
                    table.ForeignKey(
                        name: "FK_DetainedLicenses_Users",
                        column: x => x.CreatedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_DetainedLicenses_Users1",
                        column: x => x.ReleasedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "InternationalLicenses",
                columns: table => new
                {
                    InternationalLicenseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationID = table.Column<int>(type: "int", nullable: false),
                    DriverID = table.Column<int>(type: "int", nullable: false),
                    IssuedUsingLocalLicenseID = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternationalLicenses", x => x.InternationalLicenseID);
                    table.ForeignKey(
                        name: "FK_InternationalLicenses_Applications",
                        column: x => x.ApplicationID,
                        principalTable: "Applications",
                        principalColumn: "ApplicationID");
                    table.ForeignKey(
                        name: "FK_InternationalLicenses_Drivers",
                        column: x => x.DriverID,
                        principalTable: "Drivers",
                        principalColumn: "DriverID");
                    table.ForeignKey(
                        name: "FK_InternationalLicenses_Licenses",
                        column: x => x.IssuedUsingLocalLicenseID,
                        principalTable: "Licenses",
                        principalColumn: "LicenseID");
                    table.ForeignKey(
                        name: "FK_InternationalLicenses_Users",
                        column: x => x.CreatedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestAppointmentID = table.Column<int>(type: "int", nullable: false),
                    TestResult = table.Column<bool>(type: "bit", nullable: false, comment: "0 - Fail 1-Pass"),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestID);
                    table.ForeignKey(
                        name: "FK_Tests_TestAppointments",
                        column: x => x.TestAppointmentID,
                        principalTable: "TestAppointments",
                        principalColumn: "TestAppointmentID");
                    table.ForeignKey(
                        name: "FK_Tests_Users",
                        column: x => x.CreatedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicantPersonID",
                table: "Applications",
                column: "ApplicantPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationTypeID",
                table: "Applications",
                column: "ApplicationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CreatedByUserID",
                table: "Applications",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DetainedLicenses_CreatedByUserID",
                table: "DetainedLicenses",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_DetainedLicenses_LicenseID",
                table: "DetainedLicenses",
                column: "LicenseID");

            migrationBuilder.CreateIndex(
                name: "IX_DetainedLicenses_ReleaseApplicationID",
                table: "DetainedLicenses",
                column: "ReleaseApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_DetainedLicenses_ReleasedByUserID",
                table: "DetainedLicenses",
                column: "ReleasedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_CreatedByUserID",
                table: "Drivers",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_PersonID",
                table: "Drivers",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_InternationalLicenses_ApplicationID",
                table: "InternationalLicenses",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_InternationalLicenses_CreatedByUserID",
                table: "InternationalLicenses",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_InternationalLicenses_DriverID",
                table: "InternationalLicenses",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_InternationalLicenses_IssuedUsingLocalLicenseID",
                table: "InternationalLicenses",
                column: "IssuedUsingLocalLicenseID");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_ApplicationID",
                table: "Licenses",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_CreatedByUserID",
                table: "Licenses",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_DriverID",
                table: "Licenses",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_LicenseClass",
                table: "Licenses",
                column: "LicenseClass");

            migrationBuilder.CreateIndex(
                name: "IX_LocalDrivingLicenseApplications_ApplicationID",
                table: "LocalDrivingLicenseApplications",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_LocalDrivingLicenseApplications_LicenseClassID",
                table: "LocalDrivingLicenseApplications",
                column: "LicenseClassID");

            migrationBuilder.CreateIndex(
                name: "IX_People_NationalityCountryID",
                table: "People",
                column: "NationalityCountryID");

            migrationBuilder.CreateIndex(
                name: "IX_TestAppointments_CreatedByUserID",
                table: "TestAppointments",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TestAppointments_LocalDrivingLicenseApplicationID",
                table: "TestAppointments",
                column: "LocalDrivingLicenseApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_TestAppointments_TestTypeID",
                table: "TestAppointments",
                column: "TestTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_CreatedByUserID",
                table: "Tests",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_TestAppointmentID",
                table: "Tests",
                column: "TestAppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshToken_UserId",
                table: "UserRefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonID",
                table: "Users",
                column: "PersonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DetainedLicenses");

            migrationBuilder.DropTable(
                name: "InternationalLicenses");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "UserRefreshToken");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.DropTable(
                name: "TestAppointments");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "LocalDrivingLicenseApplications");

            migrationBuilder.DropTable(
                name: "TestTypes");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "LicenseClasses");

            migrationBuilder.DropTable(
                name: "ApplicationTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
