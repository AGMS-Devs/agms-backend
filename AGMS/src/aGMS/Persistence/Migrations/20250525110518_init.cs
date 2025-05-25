using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    From = table.Column<string>(type: "text", nullable: false),
                    To = table.Column<string>(type: "text", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    IsBodyHtml = table.Column<bool>(type: "boolean", nullable: false),
                    IsSentSuccessfully = table.Column<bool>(type: "boolean", nullable: false),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequiredCourseLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredCourseLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentAffairs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OfficeName = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAffairs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ceremonies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CeremonyDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CeremonyLocation = table.Column<string>(type: "text", nullable: false),
                    CeremonyDescription = table.Column<string>(type: "text", nullable: false),
                    CeremonyStatus = table.Column<int>(type: "integer", nullable: false),
                    AcademicYear = table.Column<string>(type: "text", nullable: false),
                    StudentAffairId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ceremonies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ceremonies_StudentAffairs_StudentAffairId",
                        column: x => x.StudentAffairId,
                        principalTable: "StudentAffairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacultyDeansOffices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FacultyName = table.Column<string>(type: "text", nullable: false),
                    StudentAffairId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyDeansOffices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacultyDeansOffices_StudentAffairs_StudentAffairId",
                        column: x => x.StudentAffairId,
                        principalTable: "StudentAffairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rectorates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentAffairId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rectorates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rectorates_StudentAffairs_StudentAffairId",
                        column: x => x.StudentAffairId,
                        principalTable: "StudentAffairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentName = table.Column<string>(type: "text", nullable: false),
                    DepartmentPhone = table.Column<string>(type: "text", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_FacultyDeansOffices_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "FacultyDeansOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseName = table.Column<string>(type: "text", nullable: false),
                    CourseCode = table.Column<string>(type: "text", nullable: false),
                    CourseDescription = table.Column<string>(type: "text", nullable: false),
                    CourseCredit = table.Column<int>(type: "integer", nullable: false),
                    TeoricHours = table.Column<int>(type: "integer", nullable: false),
                    PracticalHours = table.Column<int>(type: "integer", nullable: false),
                    ECTS = table.Column<int>(type: "integer", nullable: false),
                    HalfYear = table.Column<string>(type: "text", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_FacultyDeansOffices_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "FacultyDeansOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequiredCourseListCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequiredCourseListId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredCourseListCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequiredCourseListCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequiredCourseListCourses_RequiredCourseLists_RequiredCours~",
                        column: x => x.RequiredCourseListId,
                        principalTable: "RequiredCourseLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Advisors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advisors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GraduationLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GraduationListNumber = table.Column<string>(type: "text", nullable: false),
                    AdvisorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduationLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GraduationLists_Advisors_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AdvisorId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentNumber = table.Column<string>(type: "text", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Advisors_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UserType = table.Column<int>(type: "integer", nullable: false),
                    AdvisorProfileId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    AuthenticatorType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Advisors_AdvisorProfileId",
                        column: x => x.AdvisorProfileId,
                        principalTable: "Advisors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CeremonyUser",
                columns: table => new
                {
                    CeremonyId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CeremonyUser", x => new { x.CeremonyId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CeremonyUser_Ceremonies_CeremonyId",
                        column: x => x.CeremonyId,
                        principalTable: "Ceremonies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CeremonyUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAuthenticators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActivationKey = table.Column<string>(type: "text", nullable: true),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAuthenticators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAuthenticators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GraduationProcesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdvisorApproved = table.Column<bool>(type: "boolean", nullable: false),
                    AdvisorApprovedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DepartmentSecretaryApproved = table.Column<bool>(type: "boolean", nullable: false),
                    DepartmentSecretaryApprovedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FacultyDeansOfficeApproved = table.Column<bool>(type: "boolean", nullable: false),
                    FacultyDeansOfficeApprovedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StudentAffairsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    StudentAffairsApprovedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    GraduationListId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduationProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GraduationProcesses_GraduationLists_GraduationListId",
                        column: x => x.GraduationListId,
                        principalTable: "GraduationLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GraduationProcesses_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OtpAuthenticators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SecretKey = table.Column<byte[]>(type: "bytea", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpAuthenticators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtpAuthenticators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    ExpiresDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByIp = table.Column<string>(type: "text", nullable: false),
                    RevokedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RevokedByIp = table.Column<string>(type: "text", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "text", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StaffPhone = table.Column<string>(type: "text", nullable: false),
                    StaffRole = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    FacultyId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staffs_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Staffs_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentNumber = table.Column<string>(type: "text", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    EnrollDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StudentStatus = table.Column<int>(type: "integer", nullable: false),
                    GraduationStatus = table.Column<int>(type: "integer", nullable: false),
                    AssignedAdvisorId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequiredCourseListId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Advisors_AssignedAdvisorId",
                        column: x => x.AssignedAdvisorId,
                        principalTable: "Advisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_RequiredCourseLists_RequiredCourseListId",
                        column: x => x.RequiredCourseListId,
                        principalTable: "RequiredCourseLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transcripts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentIdentityNumber = table.Column<string>(type: "text", nullable: false),
                    TranscriptFileName = table.Column<string>(type: "text", nullable: false),
                    TranscriptGpa = table.Column<decimal>(type: "numeric", nullable: false),
                    TranscriptDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TranscriptDescription = table.Column<string>(type: "text", nullable: false),
                    DepartmentGraduationRank = table.Column<string>(type: "text", nullable: false),
                    FacultyGraduationRank = table.Column<string>(type: "text", nullable: false),
                    UniversityGraduationRank = table.Column<string>(type: "text", nullable: false),
                    GraduationYear = table.Column<string>(type: "text", nullable: false),
                    TotalTakenCredit = table.Column<int>(type: "integer", nullable: false),
                    TotalRequiredCredit = table.Column<int>(type: "integer", nullable: false),
                    CompletedCredit = table.Column<int>(type: "integer", nullable: false),
                    RemainingCredit = table.Column<int>(type: "integer", nullable: false),
                    RequiredCourseCount = table.Column<int>(type: "integer", nullable: false),
                    CompletedCourseCount = table.Column<int>(type: "integer", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcripts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transcripts_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    OperationClaimId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopStudentLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TopStudentListType = table.Column<int>(type: "integer", nullable: false),
                    StudentAffairsApproval = table.Column<bool>(type: "boolean", nullable: false),
                    StudentAffairsStaffId = table.Column<Guid>(type: "uuid", nullable: false),
                    RectorateApproval = table.Column<bool>(type: "boolean", nullable: false),
                    RectorateStaffId = table.Column<Guid>(type: "uuid", nullable: false),
                    SendRectorate = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopStudentLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopStudentLists_Staffs_RectorateStaffId",
                        column: x => x.RectorateStaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TopStudentLists_Staffs_StudentAffairsStaffId",
                        column: x => x.StudentAffairsStaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TakenCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Grade = table.Column<int>(type: "integer", nullable: false),
                    TakenDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakenCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TakenCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TakenCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    StorageType = table.Column<int>(type: "integer", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    TranscriptId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileAttachments_Transcripts_TranscriptId",
                        column: x => x.TranscriptId,
                        principalTable: "Transcripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopStudentListStudents",
                columns: table => new
                {
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false),
                    TopStudentListId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopStudentListStudents", x => new { x.StudentsId, x.TopStudentListId });
                    table.ForeignKey(
                        name: "FK_TopStudentListStudents_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopStudentListStudents_TopStudentLists_TopStudentListId",
                        column: x => x.TopStudentListId,
                        principalTable: "TopStudentLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Admin", null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Student", null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "StudentAffairsStaff", null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Advisor", null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "DepartmentSecretary", null },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "DeansOfficeStaff", null }
                });

            migrationBuilder.InsertData(
                table: "RequiredCourseLists",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(2950), null, "Elektrik-Elektronik Mühendisliği bölümü öğrencileri için gerekli zorunlu dersler", "Elektrik-Elektronik Mühendisliği Zorunlu Dersler", null },
                    { new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(2960), null, "Makine Mühendisliği bölümü öğrencileri için gerekli zorunlu dersler", "Makine Mühendisliği Zorunlu Dersler", null },
                    { new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(2960), null, "Kimya bölümü öğrencileri için gerekli zorunlu dersler", "Kimya Bölümü Zorunlu Dersler", null },
                    { new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(2950), null, "Bilgisayar Mühendisliği bölümü öğrencileri için gerekli zorunlu dersler", "Bilgisayar Mühendisliği Zorunlu Dersler", null },
                    { new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(2960), null, "Matematik bölümü öğrencileri için gerekli zorunlu dersler", "Matematik Bölümü Zorunlu Dersler", null },
                    { new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(2960), null, "Fizik bölümü öğrencileri için gerekli zorunlu dersler", "Fizik Bölümü Zorunlu Dersler", null }
                });

            migrationBuilder.InsertData(
                table: "StudentAffairs",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OfficeName", "UpdatedDate" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(6180), null, "İYTE Öğrenci İşleri Daire Başkanlığı", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AdvisorProfileId", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "IsActive", "Name", "PasswordHash", "PasswordSalt", "PhoneNumber", "Surname", "UpdatedDate", "UserType" },
                values: new object[,]
                {
                    { new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7190), null, "20200016@std.iyte.edu.tr", true, "Serkan", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "7788990011", "Bozkurt", null, 0 },
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7270), null, "advisor1@iyte.edu.tr", true, "Ozan Raşit", new byte[] { 106, 13, 171, 251, 91, 192, 27, 75, 78, 103, 68, 23, 219, 167, 248, 59, 72, 190, 133, 42, 175, 245, 158, 241, 173, 225, 7, 30, 158, 168, 236, 96, 105, 145, 228, 120, 229, 38, 94, 114, 3, 23, 197, 101, 16, 156, 231, 152, 235, 192, 196, 209, 99, 125, 210, 68, 15, 176, 132, 239, 153, 197, 236, 252 }, new byte[] { 246, 251, 61, 111, 45, 238, 219, 55, 202, 55, 101, 174, 161, 195, 45, 27, 18, 165, 147, 118, 148, 250, 144, 133, 77, 135, 39, 166, 75, 108, 13, 114, 46, 83, 20, 65, 28, 17, 240, 169, 201, 65, 206, 119, 77, 145, 219, 33, 62, 205, 184, 107, 95, 86, 1, 170, 111, 39, 123, 201, 190, 194, 205, 41, 90, 139, 1, 186, 251, 146, 159, 114, 56, 162, 204, 175, 165, 54, 193, 253, 115, 172, 129, 159, 3, 135, 231, 179, 97, 4, 122, 45, 166, 199, 151, 47, 65, 205, 211, 60, 130, 9, 69, 255, 252, 80, 117, 247, 24, 179, 116, 136, 17, 168, 66, 252, 21, 90, 107, 152, 172, 122, 116, 220, 85, 232, 31, 228 }, "4445556677", "Yürüm", null, 2 },
                    { new Guid("11111111-1111-1111-1111-11111111111a"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7120), null, "admin@iyte.edu.tr", true, "System", new byte[] { 207, 61, 41, 242, 171, 0, 236, 108, 215, 134, 82, 94, 137, 173, 233, 52, 253, 253, 207, 170, 31, 20, 217, 228, 152, 167, 45, 57, 115, 82, 51, 150, 54, 42, 80, 45, 52, 236, 203, 212, 38, 198, 122, 252, 86, 106, 113, 159, 174, 34, 64, 185, 246, 141, 204, 191, 72, 13, 37, 67, 45, 109, 89, 180 }, new byte[] { 204, 195, 68, 78, 149, 141, 23, 135, 179, 15, 206, 140, 87, 136, 113, 24, 78, 105, 159, 88, 137, 4, 156, 149, 59, 220, 230, 26, 116, 115, 250, 166, 204, 146, 178, 114, 122, 251, 34, 186, 187, 9, 215, 55, 36, 251, 90, 236, 66, 223, 19, 126, 183, 218, 27, 206, 69, 168, 26, 64, 84, 34, 147, 21, 142, 198, 117, 29, 183, 108, 131, 67, 48, 25, 48, 134, 64, 224, 52, 152, 94, 115, 194, 49, 157, 84, 37, 114, 180, 107, 176, 128, 74, 176, 77, 130, 214, 229, 7, 77, 198, 149, 57, 46, 2, 1, 234, 233, 86, 103, 126, 178, 127, 41, 58, 83, 75, 176, 209, 98, 7, 226, 145, 200, 91, 82, 229, 226 }, "1234567890", "Admin", null, 3 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7270), null, "advisor2@iyte.edu.tr", true, "Dr. Ayşe", new byte[] { 106, 13, 171, 251, 91, 192, 27, 75, 78, 103, 68, 23, 219, 167, 248, 59, 72, 190, 133, 42, 175, 245, 158, 241, 173, 225, 7, 30, 158, 168, 236, 96, 105, 145, 228, 120, 229, 38, 94, 114, 3, 23, 197, 101, 16, 156, 231, 152, 235, 192, 196, 209, 99, 125, 210, 68, 15, 176, 132, 239, 153, 197, 236, 252 }, new byte[] { 246, 251, 61, 111, 45, 238, 219, 55, 202, 55, 101, 174, 161, 195, 45, 27, 18, 165, 147, 118, 148, 250, 144, 133, 77, 135, 39, 166, 75, 108, 13, 114, 46, 83, 20, 65, 28, 17, 240, 169, 201, 65, 206, 119, 77, 145, 219, 33, 62, 205, 184, 107, 95, 86, 1, 170, 111, 39, 123, 201, 190, 194, 205, 41, 90, 139, 1, 186, 251, 146, 159, 114, 56, 162, 204, 175, 165, 54, 193, 253, 115, 172, 129, 159, 3, 135, 231, 179, 97, 4, 122, 45, 166, 199, 151, 47, 65, 205, 211, 60, 130, 9, 69, 255, 252, 80, 117, 247, 24, 179, 116, 136, 17, 168, 66, 252, 21, 90, 107, 152, 172, 122, 116, 220, 85, 232, 31, 228 }, "5556667788", "Demir", null, 2 },
                    { new Guid("22222222-2222-2222-2222-22222222222a"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7150), null, "20220001@std.iyte.edu.tr", true, "Ali", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "2345678901", "Veli", null, 0 },
                    { new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7180), null, "20220012@std.iyte.edu.tr", true, "Mert", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "3344556677", "Doğan", null, 0 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7270), null, "advisor3@iyte.edu.tr", true, "Dr. Hasan", new byte[] { 106, 13, 171, 251, 91, 192, 27, 75, 78, 103, 68, 23, 219, 167, 248, 59, 72, 190, 133, 42, 175, 245, 158, 241, 173, 225, 7, 30, 158, 168, 236, 96, 105, 145, 228, 120, 229, 38, 94, 114, 3, 23, 197, 101, 16, 156, 231, 152, 235, 192, 196, 209, 99, 125, 210, 68, 15, 176, 132, 239, 153, 197, 236, 252 }, new byte[] { 246, 251, 61, 111, 45, 238, 219, 55, 202, 55, 101, 174, 161, 195, 45, 27, 18, 165, 147, 118, 148, 250, 144, 133, 77, 135, 39, 166, 75, 108, 13, 114, 46, 83, 20, 65, 28, 17, 240, 169, 201, 65, 206, 119, 77, 145, 219, 33, 62, 205, 184, 107, 95, 86, 1, 170, 111, 39, 123, 201, 190, 194, 205, 41, 90, 139, 1, 186, 251, 146, 159, 114, 56, 162, 204, 175, 165, 54, 193, 253, 115, 172, 129, 159, 3, 135, 231, 179, 97, 4, 122, 45, 166, 199, 151, 47, 65, 205, 211, 60, 130, 9, 69, 255, 252, 80, 117, 247, 24, 179, 116, 136, 17, 168, 66, 252, 21, 90, 107, 152, 172, 122, 116, 220, 85, 232, 31, 228 }, "6667778899", "Özkan", null, 2 },
                    { new Guid("33333333-3333-3333-3333-33333333333a"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7240), null, "studentaffairs@iyte.edu.tr", true, "Hafize", new byte[] { 37, 31, 68, 234, 19, 234, 74, 225, 21, 201, 33, 17, 20, 197, 161, 2, 44, 99, 19, 255, 192, 233, 138, 242, 148, 232, 245, 235, 195, 202, 65, 44, 127, 172, 139, 211, 68, 58, 29, 88, 80, 91, 70, 160, 89, 70, 223, 165, 59, 72, 26, 76, 216, 156, 234, 117, 235, 184, 99, 71, 1, 173, 246, 246 }, new byte[] { 1, 251, 156, 194, 165, 122, 27, 95, 239, 102, 10, 16, 59, 64, 234, 25, 19, 55, 63, 159, 63, 108, 63, 68, 108, 167, 119, 73, 55, 25, 0, 219, 251, 214, 229, 219, 186, 134, 173, 2, 175, 107, 20, 18, 13, 189, 219, 2, 175, 217, 38, 137, 170, 212, 222, 34, 70, 216, 202, 202, 143, 121, 50, 233, 4, 246, 183, 231, 107, 223, 158, 72, 176, 230, 84, 251, 87, 115, 170, 237, 55, 91, 8, 103, 207, 240, 48, 63, 27, 145, 209, 114, 131, 195, 20, 94, 148, 83, 182, 189, 2, 56, 169, 83, 78, 44, 238, 147, 245, 43, 71, 246, 86, 51, 144, 67, 217, 71, 9, 34, 225, 11, 169, 19, 9, 136, 213, 215 }, "3334445566", "Kaya", null, 1 },
                    { new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7150), null, "20220002@std.iyte.edu.tr", true, "Ayşe", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "3456789012", "Yılmaz", null, 0 },
                    { new Guid("44444444-4444-4444-4444-444444444444"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7270), null, "advisor4@iyte.edu.tr", true, "Dr. Fatma", new byte[] { 106, 13, 171, 251, 91, 192, 27, 75, 78, 103, 68, 23, 219, 167, 248, 59, 72, 190, 133, 42, 175, 245, 158, 241, 173, 225, 7, 30, 158, 168, 236, 96, 105, 145, 228, 120, 229, 38, 94, 114, 3, 23, 197, 101, 16, 156, 231, 152, 235, 192, 196, 209, 99, 125, 210, 68, 15, 176, 132, 239, 153, 197, 236, 252 }, new byte[] { 246, 251, 61, 111, 45, 238, 219, 55, 202, 55, 101, 174, 161, 195, 45, 27, 18, 165, 147, 118, 148, 250, 144, 133, 77, 135, 39, 166, 75, 108, 13, 114, 46, 83, 20, 65, 28, 17, 240, 169, 201, 65, 206, 119, 77, 145, 219, 33, 62, 205, 184, 107, 95, 86, 1, 170, 111, 39, 123, 201, 190, 194, 205, 41, 90, 139, 1, 186, 251, 146, 159, 114, 56, 162, 204, 175, 165, 54, 193, 253, 115, 172, 129, 159, 3, 135, 231, 179, 97, 4, 122, 45, 166, 199, 151, 47, 65, 205, 211, 60, 130, 9, 69, 255, 252, 80, 117, 247, 24, 179, 116, 136, 17, 168, 66, 252, 21, 90, 107, 152, 172, 122, 116, 220, 85, 232, 31, 228 }, "7778889900", "Şen", null, 2 },
                    { new Guid("55555555-5555-5555-5555-555555555555"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7280), null, "advisor5@iyte.edu.tr", true, "Dr. Ali", new byte[] { 106, 13, 171, 251, 91, 192, 27, 75, 78, 103, 68, 23, 219, 167, 248, 59, 72, 190, 133, 42, 175, 245, 158, 241, 173, 225, 7, 30, 158, 168, 236, 96, 105, 145, 228, 120, 229, 38, 94, 114, 3, 23, 197, 101, 16, 156, 231, 152, 235, 192, 196, 209, 99, 125, 210, 68, 15, 176, 132, 239, 153, 197, 236, 252 }, new byte[] { 246, 251, 61, 111, 45, 238, 219, 55, 202, 55, 101, 174, 161, 195, 45, 27, 18, 165, 147, 118, 148, 250, 144, 133, 77, 135, 39, 166, 75, 108, 13, 114, 46, 83, 20, 65, 28, 17, 240, 169, 201, 65, 206, 119, 77, 145, 219, 33, 62, 205, 184, 107, 95, 86, 1, 170, 111, 39, 123, 201, 190, 194, 205, 41, 90, 139, 1, 186, 251, 146, 159, 114, 56, 162, 204, 175, 165, 54, 193, 253, 115, 172, 129, 159, 3, 135, 231, 179, 97, 4, 122, 45, 166, 199, 151, 47, 65, 205, 211, 60, 130, 9, 69, 255, 252, 80, 117, 247, 24, 179, 116, 136, 17, 168, 66, 252, 21, 90, 107, 152, 172, 122, 116, 220, 85, 232, 31, 228 }, "8889990011", "Güneş", null, 2 },
                    { new Guid("55555555-5555-5555-5555-55555555555a"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7300), null, "comp.deptsecretary@iyte.edu.tr", true, "Emine", new byte[] { 85, 182, 90, 213, 239, 185, 121, 67, 131, 209, 178, 208, 226, 178, 66, 118, 195, 134, 110, 224, 170, 103, 20, 184, 105, 211, 111, 160, 167, 57, 7, 37, 139, 234, 224, 44, 105, 40, 239, 101, 1, 248, 252, 228, 73, 42, 14, 239, 69, 60, 146, 28, 103, 176, 145, 37, 23, 16, 11, 220, 25, 158, 173, 165 }, new byte[] { 214, 147, 183, 204, 169, 113, 226, 224, 174, 1, 19, 26, 16, 116, 79, 57, 41, 143, 251, 90, 69, 49, 198, 142, 124, 65, 164, 209, 42, 144, 224, 54, 152, 22, 64, 40, 164, 98, 10, 95, 230, 184, 26, 185, 113, 22, 137, 25, 95, 84, 47, 105, 23, 254, 13, 120, 187, 47, 159, 85, 225, 30, 162, 152, 98, 148, 114, 96, 242, 96, 102, 40, 228, 98, 69, 60, 203, 120, 84, 233, 222, 249, 237, 63, 166, 220, 89, 96, 95, 6, 166, 217, 8, 111, 15, 220, 143, 80, 33, 124, 146, 75, 92, 113, 213, 199, 16, 225, 194, 151, 157, 226, 70, 244, 75, 221, 75, 71, 59, 5, 203, 34, 139, 91, 248, 178, 220, 171 }, "1111223344", "Arslan", null, 1 },
                    { new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7180), null, "20200013@std.iyte.edu.tr", true, "İrem", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "4455667788", "Kılıç", null, 0 },
                    { new Guid("66666666-6666-6666-6666-666666666666"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7280), null, "advisor6@iyte.edu.tr", true, "Dr. Zeynep", new byte[] { 106, 13, 171, 251, 91, 192, 27, 75, 78, 103, 68, 23, 219, 167, 248, 59, 72, 190, 133, 42, 175, 245, 158, 241, 173, 225, 7, 30, 158, 168, 236, 96, 105, 145, 228, 120, 229, 38, 94, 114, 3, 23, 197, 101, 16, 156, 231, 152, 235, 192, 196, 209, 99, 125, 210, 68, 15, 176, 132, 239, 153, 197, 236, 252 }, new byte[] { 246, 251, 61, 111, 45, 238, 219, 55, 202, 55, 101, 174, 161, 195, 45, 27, 18, 165, 147, 118, 148, 250, 144, 133, 77, 135, 39, 166, 75, 108, 13, 114, 46, 83, 20, 65, 28, 17, 240, 169, 201, 65, 206, 119, 77, 145, 219, 33, 62, 205, 184, 107, 95, 86, 1, 170, 111, 39, 123, 201, 190, 194, 205, 41, 90, 139, 1, 186, 251, 146, 159, 114, 56, 162, 204, 175, 165, 54, 193, 253, 115, 172, 129, 159, 3, 135, 231, 179, 97, 4, 122, 45, 166, 199, 151, 47, 65, 205, 211, 60, 130, 9, 69, 255, 252, 80, 117, 247, 24, 179, 116, 136, 17, 168, 66, 252, 21, 90, 107, 152, 172, 122, 116, 220, 85, 232, 31, 228 }, "9990001122", "Acar", null, 2 },
                    { new Guid("66666666-6666-6666-6666-66666666666a"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7330), null, "deansoffice@iyte.edu.tr", true, "Murat", new byte[] { 93, 30, 255, 123, 85, 149, 64, 27, 254, 211, 91, 242, 3, 29, 208, 49, 192, 246, 162, 234, 245, 106, 220, 253, 120, 241, 202, 199, 232, 169, 135, 243, 151, 146, 196, 245, 94, 15, 149, 85, 174, 81, 146, 241, 44, 169, 188, 237, 68, 157, 84, 196, 67, 89, 157, 32, 150, 212, 88, 143, 143, 12, 5, 147 }, new byte[] { 191, 50, 56, 11, 123, 180, 153, 10, 195, 234, 250, 154, 220, 180, 200, 127, 143, 27, 227, 37, 72, 9, 42, 235, 79, 247, 151, 16, 29, 188, 24, 52, 228, 184, 170, 101, 16, 137, 200, 172, 7, 133, 17, 44, 198, 11, 41, 90, 130, 183, 176, 183, 13, 189, 116, 197, 245, 62, 39, 233, 169, 151, 241, 7, 249, 227, 9, 158, 129, 30, 32, 32, 238, 204, 28, 50, 142, 202, 51, 30, 166, 106, 153, 234, 230, 127, 132, 54, 228, 224, 111, 7, 130, 28, 91, 14, 63, 172, 181, 44, 110, 62, 61, 124, 188, 77, 153, 183, 57, 219, 0, 185, 10, 112, 112, 218, 165, 99, 98, 68, 7, 204, 157, 77, 138, 121, 52, 37 }, "6667778899", "Kurt", null, 1 },
                    { new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7190), null, "20220015@std.iyte.edu.tr", true, "Pınar", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "6677889900", "Altın", null, 0 },
                    { new Guid("77777777-7777-7777-7777-77777777777a"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7330), null, "science.deansoffice@iyte.edu.tr", true, "Ayşe", new byte[] { 93, 30, 255, 123, 85, 149, 64, 27, 254, 211, 91, 242, 3, 29, 208, 49, 192, 246, 162, 234, 245, 106, 220, 253, 120, 241, 202, 199, 232, 169, 135, 243, 151, 146, 196, 245, 94, 15, 149, 85, 174, 81, 146, 241, 44, 169, 188, 237, 68, 157, 84, 196, 67, 89, 157, 32, 150, 212, 88, 143, 143, 12, 5, 147 }, new byte[] { 191, 50, 56, 11, 123, 180, 153, 10, 195, 234, 250, 154, 220, 180, 200, 127, 143, 27, 227, 37, 72, 9, 42, 235, 79, 247, 151, 16, 29, 188, 24, 52, 228, 184, 170, 101, 16, 137, 200, 172, 7, 133, 17, 44, 198, 11, 41, 90, 130, 183, 176, 183, 13, 189, 116, 197, 245, 62, 39, 233, 169, 151, 241, 7, 249, 227, 9, 158, 129, 30, 32, 32, 238, 204, 28, 50, 142, 202, 51, 30, 166, 106, 153, 234, 230, 127, 132, 54, 228, 224, 111, 7, 130, 28, 91, 14, 63, 172, 181, 44, 110, 62, 61, 124, 188, 77, 153, 183, 57, 219, 0, 185, 10, 112, 112, 218, 165, 99, 98, 68, 7, 204, 157, 77, 138, 121, 52, 37 }, "7778889900", "Yılmaz", null, 1 },
                    { new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7180), null, "20210014@std.iyte.edu.tr", true, "Onur", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "5566778899", "Özkan", null, 0 },
                    { new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7170), null, "20220010@std.iyte.edu.tr", true, "Deniz", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "1122334455", "Şahin", null, 0 },
                    { new Guid("88888888-8888-8888-8888-88888888888a"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7350), null, "rectorate@iyte.edu.tr", true, "Yusuf", new byte[] { 29, 255, 209, 226, 110, 66, 255, 199, 229, 201, 60, 252, 155, 157, 191, 42, 197, 78, 248, 167, 41, 35, 14, 114, 240, 119, 162, 242, 155, 153, 53, 243, 168, 33, 44, 222, 98, 33, 52, 31, 155, 93, 44, 241, 250, 38, 113, 230, 89, 183, 167, 152, 201, 204, 185, 149, 36, 226, 51, 187, 62, 140, 230, 2 }, new byte[] { 161, 6, 187, 9, 209, 87, 85, 9, 156, 165, 216, 125, 3, 72, 101, 192, 131, 199, 218, 151, 123, 88, 14, 179, 15, 156, 127, 27, 43, 27, 207, 199, 119, 175, 48, 231, 132, 190, 134, 203, 112, 227, 148, 57, 141, 32, 195, 79, 192, 209, 88, 234, 140, 223, 130, 86, 124, 219, 74, 213, 78, 37, 147, 164, 40, 233, 210, 253, 141, 5, 196, 223, 216, 40, 167, 79, 225, 35, 45, 58, 168, 172, 88, 165, 208, 97, 116, 115, 179, 124, 135, 231, 36, 73, 121, 178, 144, 111, 33, 242, 117, 61, 173, 115, 175, 54, 151, 67, 60, 127, 247, 106, 255, 222, 86, 30, 134, 98, 3, 103, 226, 5, 79, 135, 196, 146, 150, 93 }, "8889990011", "Baran", null, 1 },
                    { new Guid("89e73bfc-718e-49d4-92af-1c576d281cf4"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7310), null, "physics.deptsecretary@iyte.edu.tr", true, "Ayşe", new byte[] { 85, 182, 90, 213, 239, 185, 121, 67, 131, 209, 178, 208, 226, 178, 66, 118, 195, 134, 110, 224, 170, 103, 20, 184, 105, 211, 111, 160, 167, 57, 7, 37, 139, 234, 224, 44, 105, 40, 239, 101, 1, 248, 252, 228, 73, 42, 14, 239, 69, 60, 146, 28, 103, 176, 145, 37, 23, 16, 11, 220, 25, 158, 173, 165 }, new byte[] { 214, 147, 183, 204, 169, 113, 226, 224, 174, 1, 19, 26, 16, 116, 79, 57, 41, 143, 251, 90, 69, 49, 198, 142, 124, 65, 164, 209, 42, 144, 224, 54, 152, 22, 64, 40, 164, 98, 10, 95, 230, 184, 26, 185, 113, 22, 137, 25, 95, 84, 47, 105, 23, 254, 13, 120, 187, 47, 159, 85, 225, 30, 162, 152, 98, 148, 114, 96, 242, 96, 102, 40, 228, 98, 69, 60, 203, 120, 84, 233, 222, 249, 237, 63, 166, 220, 89, 96, 95, 6, 166, 217, 8, 111, 15, 220, 143, 80, 33, 124, 146, 75, 92, 113, 213, 199, 16, 225, 194, 151, 157, 226, 70, 244, 75, 221, 75, 71, 59, 5, 203, 34, 139, 91, 248, 178, 220, 171 }, "5556667790", "Demir", null, 1 },
                    { new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7160), null, "20220006@std.iyte.edu.tr", true, "Zeynep", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "7890123456", "Aydın", null, 0 },
                    { new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7160), null, "20210007@std.iyte.edu.tr", true, "Burak", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "8901234567", "Çelik", null, 0 },
                    { new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7200), null, "20210017@std.iyte.edu.tr", true, "Tuba", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "8899001122", "Karaman", null, 0 },
                    { new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7160), null, "20220005@std.iyte.edu.tr", true, "Emre", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "6789012345", "Demir", null, 0 },
                    { new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7180), null, "20210011@std.iyte.edu.tr", true, "Ece", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "2233445566", "Güneş", null, 0 },
                    { new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7150), null, "20210003@std.iyte.edu.tr", true, "Mehmet", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "4567890123", "Öz", null, 0 },
                    { new Guid("c4e05469-860b-4655-b844-f682a21fca23"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7170), null, "20220008@std.iyte.edu.tr", true, "Selin", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "9012345678", "Yıldız", null, 0 },
                    { new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7160), null, "20190004@std.iyte.edu.tr", true, "Fatma", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "5678901234", "Kaya", null, 0 },
                    { new Guid("e32d7b07-a92e-4dda-83e0-c90ee8cad8e5"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7300), null, "elec.deptsecretary@iyte.edu.tr", true, "Melek", new byte[] { 85, 182, 90, 213, 239, 185, 121, 67, 131, 209, 178, 208, 226, 178, 66, 118, 195, 134, 110, 224, 170, 103, 20, 184, 105, 211, 111, 160, 167, 57, 7, 37, 139, 234, 224, 44, 105, 40, 239, 101, 1, 248, 252, 228, 73, 42, 14, 239, 69, 60, 146, 28, 103, 176, 145, 37, 23, 16, 11, 220, 25, 158, 173, 165 }, new byte[] { 214, 147, 183, 204, 169, 113, 226, 224, 174, 1, 19, 26, 16, 116, 79, 57, 41, 143, 251, 90, 69, 49, 198, 142, 124, 65, 164, 209, 42, 144, 224, 54, 152, 22, 64, 40, 164, 98, 10, 95, 230, 184, 26, 185, 113, 22, 137, 25, 95, 84, 47, 105, 23, 254, 13, 120, 187, 47, 159, 85, 225, 30, 162, 152, 98, 148, 114, 96, 242, 96, 102, 40, 228, 98, 69, 60, 203, 120, 84, 233, 222, 249, 237, 63, 166, 220, 89, 96, 95, 6, 166, 217, 8, 111, 15, 220, 143, 80, 33, 124, 146, 75, 92, 113, 213, 199, 16, 225, 194, 151, 157, 226, 70, 244, 75, 221, 75, 71, 59, 5, 203, 34, 139, 91, 248, 178, 220, 171 }, "2223334455", "Çakır", null, 1 },
                    { new Guid("e8a7af40-b208-430e-967a-e590bab72810"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7220), null, "20220026@std.iyte.edu.tr", true, "Aşkın", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "1123445557", "Durmaz", null, 0 },
                    { new Guid("e8a7af40-b209-430e-967a-e590bab72810"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7220), null, "20220025@std.iyte.edu.tr", true, "Memo", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "1123445556", "Yilik", null, 0 },
                    { new Guid("e8a7af40-b210-430e-967a-e590bab72810"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7210), null, "20220024@std.iyte.edu.tr", true, "Ayşecik", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "1123445555", "Yıldır", null, 0 },
                    { new Guid("e8a7af40-b211-430e-967a-e590bab72810"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7210), null, "20220023@std.iyte.edu.tr", true, "Ayşe", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "1122334454", "Yılmaz", null, 0 },
                    { new Guid("e8a7af40-b212-430e-967a-e590bab72810"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7210), null, "20220022@std.iyte.edu.tr", true, "Aişe", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "1122634455", "Yılgın", null, 0 },
                    { new Guid("e8a7af40-b213-430e-967a-e590bab72810"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7210), null, "20220021@std.iyte.edu.tr", true, "Mehmet", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "1722334455", "Yılmaz", null, 0 },
                    { new Guid("e8a7af40-b214-430e-967a-e590bab72810"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7200), null, "20220020@std.iyte.edu.tr", true, "Kasım", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "1122339455", "Yılmaz", null, 0 },
                    { new Guid("e8a7af40-b215-430e-967a-e590bab72810"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7200), null, "20220019@std.iyte.edu.tr", true, "Yusuf", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "1121334455", "Yılmaz", null, 0 },
                    { new Guid("e8a7af40-b216-430e-967a-e590bab72810"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7200), null, "20220018@std.iyte.edu.tr", true, "Yasin", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "9900112233", "Erdoğan", null, 0 },
                    { new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), null, 0, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(7170), null, "20200009@std.iyte.edu.tr", true, "Can", new byte[] { 44, 46, 75, 157, 176, 222, 43, 15, 126, 225, 173, 176, 76, 14, 236, 57, 217, 53, 211, 185, 168, 170, 82, 100, 128, 174, 193, 181, 182, 185, 136, 164, 107, 169, 191, 241, 200, 8, 175, 209, 97, 160, 227, 252, 40, 28, 78, 85, 236, 217, 229, 99, 173, 209, 249, 131, 243, 32, 36, 147, 169, 18, 177, 204 }, new byte[] { 221, 248, 210, 252, 30, 228, 175, 14, 253, 218, 181, 62, 86, 232, 238, 33, 163, 218, 6, 220, 110, 74, 76, 120, 165, 113, 185, 81, 163, 182, 224, 59, 10, 131, 167, 68, 122, 7, 184, 152, 209, 132, 56, 69, 153, 21, 166, 237, 12, 93, 84, 30, 75, 67, 163, 21, 79, 27, 120, 203, 184, 192, 60, 248, 96, 154, 164, 99, 249, 251, 70, 78, 125, 78, 197, 26, 20, 123, 30, 58, 196, 62, 218, 82, 38, 143, 16, 124, 40, 165, 179, 52, 87, 135, 25, 51, 155, 84, 89, 198, 27, 73, 95, 29, 130, 56, 202, 181, 241, 71, 33, 204, 36, 137, 86, 246, 204, 39, 129, 69, 253, 58, 220, 177, 21, 2, 60, 87 }, "0123456789", "Arslan", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "FacultyDeansOffices",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "FacultyName", "StudentAffairId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2025, 5, 25, 11, 5, 18, 154, DateTimeKind.Utc).AddTicks(7770), null, "Fen Fakültesi", new Guid("11111111-1111-1111-1111-111111111111"), null },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2025, 5, 25, 11, 5, 18, 154, DateTimeKind.Utc).AddTicks(7780), null, "Mühendislik Fakültesi", new Guid("11111111-1111-1111-1111-111111111111"), null }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DepartmentId", "FacultyId", "StaffPhone", "StaffRole", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-33333333333a"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(5680), null, null, null, "232-750-5001", 1, null },
                    { new Guid("66666666-6666-6666-6666-66666666666a"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(5690), null, null, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "232-750-5002", 2, null },
                    { new Guid("77777777-7777-7777-7777-77777777777a"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(5690), null, null, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "232-750-6002", 2, null },
                    { new Guid("88888888-8888-8888-8888-88888888888a"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(5700), null, null, null, "232-750-1001", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Transcripts",
                columns: new[] { "Id", "CompletedCourseCount", "CompletedCredit", "CreatedDate", "DeletedDate", "DepartmentGraduationRank", "FacultyGraduationRank", "GraduationYear", "RemainingCredit", "RequiredCourseCount", "StudentId", "StudentIdentityNumber", "TotalRequiredCredit", "TotalTakenCredit", "TranscriptDate", "TranscriptDescription", "TranscriptFileName", "TranscriptGpa", "UniversityGraduationRank", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("02d80b9f-8a0c-4ab5-bf65-276b970dcddb"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4520), null, "3", "6", "2024", 0, 24, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), "12345678903", 240, 240, new DateTime(2025, 5, 5, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4520), "Mezuniyet transkripti", "transcript_2023003.pdf", 3.75m, "12", null },
                    { new Guid("2ba78b94-7f8a-4039-a910-48181ecfea23"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4520), null, "4", "8", "2024", 0, 24, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), "12345678904", 240, 240, new DateTime(2025, 5, 10, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4520), "Mezuniyet transkripti", "transcript_2023004.pdf", 3.65m, "18", null },
                    { new Guid("3666a6e4-357c-4e9a-a2fa-f1704c7a64cb"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4630), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), "12345678924", 240, 240, new DateTime(2025, 5, 17, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4630), "Mezuniyet transkripti", "transcript_2023024.pdf", 2.73m, "40", null },
                    { new Guid("3fcf846f-da7c-49b3-b580-8508e1d43f57"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4630), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), "12345678923", 240, 240, new DateTime(2025, 5, 17, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4620), "Mezuniyet transkripti", "transcript_2023023.pdf", 2.63m, "40", null },
                    { new Guid("4b6fed7a-6a87-41c1-ae6c-5ded3022a76a"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4540), null, "3", "7", "2024", 0, 24, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), "12345678907", 240, 240, new DateTime(2025, 5, 11, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4540), "Mezuniyet transkripti", "transcript_2023007.pdf", 3.68m, "15", null },
                    { new Guid("514e39aa-32cc-43a9-83d0-e3ecc3084a3f"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4530), null, "1", "2", "2024", 0, 24, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), "12345678905", 240, 240, new DateTime(2025, 5, 3, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4530), "Mezuniyet transkripti", "transcript_2023005.pdf", 3.92m, "2", null },
                    { new Guid("58c98d8a-d80b-40b8-9205-543b5a2babb9"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4580), null, "1", "3", "2024", 0, 24, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), "12345678915", 240, 240, new DateTime(2025, 5, 1, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4580), "Mezuniyet transkripti", "transcript_2023015.pdf", 3.90m, "3", null },
                    { new Guid("5e9776d9-a0f9-4203-aa4c-dda1a9d5dc2f"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4620), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), "12345678921", 240, 240, new DateTime(2025, 5, 17, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4610), "Mezuniyet transkripti", "transcript_2023021.pdf", 2.43m, "40", null },
                    { new Guid("61005379-4076-45db-abd1-64b4ceeb2e44"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4570), null, "4", "12", "2024", 0, 24, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), "12345678912", 240, 240, new DateTime(2025, 5, 16, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4570), "Mezuniyet transkripti", "transcript_2023012.pdf", 3.48m, "35", null },
                    { new Guid("63d80f04-e353-4e4c-beb3-75db8b481e8e"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4600), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), "12345678918", 240, 240, new DateTime(2025, 5, 17, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4600), "Mezuniyet transkripti", "transcript_2023018.pdf", 3.45m, "40", null },
                    { new Guid("661fbe2a-8150-4bf7-a06f-c759db0f481d"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4580), null, "2", "11", "2024", 0, 24, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), "12345678914", 240, 240, new DateTime(2025, 5, 12, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4580), "Mezuniyet transkripti", "transcript_2023014.pdf", 3.58m, "23", null },
                    { new Guid("68340820-6ae5-4cfc-bd65-fa01a4adb967"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4510), null, "2", "3", "2024", 0, 24, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), "12345678902", 240, 240, new DateTime(2025, 4, 30, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4510), "Mezuniyet transkripti", "transcript_2023002.pdf", 3.88m, "5", null },
                    { new Guid("7680a185-7201-4bac-b06b-b7e18a50e70e"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4560), null, "3", "10", "2024", 0, 24, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), "12345678911", 240, 240, new DateTime(2025, 5, 14, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4560), "Mezuniyet transkripti", "transcript_2023011.pdf", 3.62m, "20", null },
                    { new Guid("891d7990-6370-4ef4-aa82-bd12f28b7090"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4640), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), "12345678925", 240, 240, new DateTime(2025, 5, 17, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4640), "Mezuniyet transkripti", "transcript_2023025.pdf", 2.83m, "40", null },
                    { new Guid("8ed52935-639b-48ee-8dae-e527aa891349"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4640), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), "12345678926", 240, 240, new DateTime(2025, 5, 17, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4640), "Mezuniyet transkripti", "transcript_2023026.pdf", 2.93m, "40", null },
                    { new Guid("9ec3b3bf-32fe-4f79-8a0f-e54e9257ff72"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4590), null, "1", "4", "2024", 0, 24, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), "12345678917", 240, 240, new DateTime(2025, 5, 6, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4590), "Mezuniyet transkripti", "transcript_2023017.pdf", 3.77m, "11", null },
                    { new Guid("a5f32bfe-9f67-4013-87df-661cad876417"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4550), null, "4", "9", "2024", 0, 24, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), "12345678908", 240, 240, new DateTime(2025, 5, 13, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4540), "Mezuniyet transkripti", "transcript_2023008.pdf", 3.55m, "25", null },
                    { new Guid("a6bc87e1-a1db-40e9-a2e5-8745b75b5416"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4570), null, "1", "6", "2024", 0, 24, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), "12345678913", 240, 240, new DateTime(2025, 4, 29, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4570), "Mezuniyet transkripti", "transcript_2023013.pdf", 3.82m, "8", null },
                    { new Guid("bab4c2ff-a07c-4b1b-b01a-c69210935166"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4620), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), "12345678922", 240, 240, new DateTime(2025, 5, 17, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4620), "Mezuniyet transkripti", "transcript_2023022.pdf", 2.53m, "40", null },
                    { new Guid("c1cee541-e6d6-4075-8a61-3085e1d936ea"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4600), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), "12345678919", 240, 240, new DateTime(2025, 5, 17, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4600), "Mezuniyet transkripti", "transcript_2023019.pdf", 2.34m, "40", null },
                    { new Guid("c26efab9-2c53-4cc2-9881-11dc3e5ed24d"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4500), null, "1", "1", "2024", 0, 24, new Guid("22222222-2222-2222-2222-22222222222a"), "12345678901", 240, 240, new DateTime(2025, 4, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4490), "Mezuniyet transkripti", "transcript_2023001.pdf", 3.95m, "1", null },
                    { new Guid("e2a6aa43-9611-485e-a65c-b3f0aeadedaa"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4560), null, "2", "8", "2024", 0, 24, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), "12345678910", 240, 240, new DateTime(2025, 5, 9, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4560), "Mezuniyet transkripti", "transcript_2023010.pdf", 3.72m, "14", null },
                    { new Guid("ec1e6a53-9ef6-468e-9e66-ed963fd7f88f"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4540), null, "2", "5", "2024", 0, 24, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), "12345678906", 240, 240, new DateTime(2025, 5, 7, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4530), "Mezuniyet transkripti", "transcript_2023006.pdf", 3.78m, "10", null },
                    { new Guid("f5557c2f-7e5f-4a61-a3a4-cc2cdc8cf5ea"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4610), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), "12345678920", 240, 240, new DateTime(2025, 5, 17, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4610), "Mezuniyet transkripti", "transcript_2023020.pdf", 2.23m, "40", null },
                    { new Guid("fc0c1eed-878c-460e-b985-ebba691ac126"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4550), null, "1", "4", "2024", 0, 24, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), "12345678909", 240, 240, new DateTime(2025, 4, 27, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4550), "Mezuniyet transkripti", "transcript_2023009.pdf", 3.85m, "7", null },
                    { new Guid("fed88c96-c85a-4409-b3a4-135cd3ba22c6"), 24, 240, new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4590), null, "1", "1", "2024", 0, 24, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), "12345678916", 240, 240, new DateTime(2025, 4, 20, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(4590), "Mezuniyet transkripti", "transcript_2023016.pdf", 3.98m, "1", null }
                });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("01ae97be-13b1-4620-b1a4-895d19387172"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8290), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45") },
                    { new Guid("01caf23c-310d-4a6b-a334-82a9f6a1c048"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8290), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307") },
                    { new Guid("04d380d3-0752-4fcd-b430-62a4fa1db7ae"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8360), null, new Guid("33333333-3333-3333-3333-333333333333"), null, new Guid("33333333-3333-3333-3333-33333333333a") },
                    { new Guid("09640738-6888-4843-bdca-e76e913eb9d5"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8350), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d") },
                    { new Guid("15d38817-69c6-41e9-8d61-43076a1a556b"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8380), null, new Guid("44444444-4444-4444-4444-444444444444"), null, new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("1751dfbf-10f7-48fc-bc83-58a5927fb946"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8360), null, new Guid("44444444-4444-4444-4444-444444444444"), null, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("25c4e826-6a03-479b-bbf1-de4c39e64515"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8370), null, new Guid("44444444-4444-4444-4444-444444444444"), null, new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("294bc6d8-ab60-4267-aa78-ae58ba300806"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8280), null, new Guid("11111111-1111-1111-1111-111111111111"), null, new Guid("11111111-1111-1111-1111-11111111111a") },
                    { new Guid("300cc707-68ff-49f4-8a0b-991bed9e0920"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8370), null, new Guid("44444444-4444-4444-4444-444444444444"), null, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("30c98b14-3012-4a46-9e3b-3a4d6a0d3d2b"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8340), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("79cace77-5720-434d-97b6-0d47a61468a3") },
                    { new Guid("3ddd61cd-6c99-4eb2-a529-d8a5c72fd8a5"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8390), null, new Guid("55555555-5555-5555-5555-555555555555"), null, new Guid("89e73bfc-718e-49d4-92af-1c576d281cf4") },
                    { new Guid("42293187-5ed6-4f34-82d7-4579596c7562"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8390), null, new Guid("55555555-5555-5555-5555-555555555555"), null, new Guid("e32d7b07-a92e-4dda-83e0-c90ee8cad8e5") },
                    { new Guid("4ea5e1fc-8e53-4688-ab59-9e073fc5a57c"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8360), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("e8a7af40-b216-430e-967a-e590bab72810") },
                    { new Guid("5df780f5-c300-4037-b3dc-ac488b9d3f5d"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8400), null, new Guid("66666666-6666-6666-6666-666666666666"), null, new Guid("77777777-7777-7777-7777-77777777777a") },
                    { new Guid("65d4f8d5-b6bb-4bb5-9e31-8e1442170102"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8310), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24") },
                    { new Guid("6970fca9-ab59-4810-a752-2914891529d3"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8350), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5") },
                    { new Guid("6b14e846-9aa4-4490-a454-6e8b06180f16"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8330), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257") },
                    { new Guid("6decda83-55c5-42ed-a4c8-b93504693cc2"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8370), null, new Guid("44444444-4444-4444-4444-444444444444"), null, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("7b98d2f0-ccff-475d-8781-348c2848d277"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8340), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8") },
                    { new Guid("7c84189d-f5ad-41c9-84d5-b34758b3cb75"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8400), null, new Guid("66666666-6666-6666-6666-666666666666"), null, new Guid("66666666-6666-6666-6666-66666666666a") },
                    { new Guid("88042dd7-02fa-49c4-b747-2700278e6df4"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8330), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b") },
                    { new Guid("8a4141b0-8dc9-4d41-8df9-df690db69be7"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8290), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("22222222-2222-2222-2222-22222222222a") },
                    { new Guid("91c0719a-54dc-48cf-ac48-1612b99b1bac"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8310), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("9000296e-dd35-476c-8702-cb20fd49c946") },
                    { new Guid("93e72405-9858-4886-befe-9da0869761f4"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8300), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4") },
                    { new Guid("9e3f79bf-0a2d-438a-8441-9f9689cae923"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8340), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4") },
                    { new Guid("a8da35e7-0349-4f1b-87de-8a85d50add28"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8310), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df") },
                    { new Guid("b8960e06-d848-4580-b597-161a5beac4af"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8330), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6") },
                    { new Guid("d433a7f2-f5e9-4e05-8cd0-337ca6dee140"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8320), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8") },
                    { new Guid("d5c20787-a01a-4906-8dfb-55655320aaea"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8380), null, new Guid("55555555-5555-5555-5555-555555555555"), null, new Guid("55555555-5555-5555-5555-55555555555a") },
                    { new Guid("e6dda913-a7e5-41c2-90cc-7d96d5ff7fe4"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8320), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("c4e05469-860b-4655-b844-f682a21fca23") },
                    { new Guid("e81981ad-b6e1-4ccf-8a94-7c1a834a6091"), new DateTime(2025, 5, 25, 11, 5, 18, 161, DateTimeKind.Utc).AddTicks(8380), null, new Guid("44444444-4444-4444-4444-444444444444"), null, new Guid("55555555-5555-5555-5555-555555555555") }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DepartmentName", "DepartmentPhone", "FacultyId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("11111111-2222-3333-4444-555555555555"), new DateTime(2025, 5, 25, 11, 5, 18, 154, DateTimeKind.Utc).AddTicks(6510), null, "Elektrik-Elektronik Mühendisliği", "232-750-7002", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), null },
                    { new Guid("22222222-3333-4444-5555-666666666666"), new DateTime(2025, 5, 25, 11, 5, 18, 154, DateTimeKind.Utc).AddTicks(6510), null, "Makine Mühendisliği", "232-750-7003", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), null },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2025, 5, 25, 11, 5, 18, 154, DateTimeKind.Utc).AddTicks(6480), null, "Fizik Bölümü", "232-750-6001", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), null },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2025, 5, 25, 11, 5, 18, 154, DateTimeKind.Utc).AddTicks(6500), null, "Kimya Bölümü", "232-750-6002", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), null },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2025, 5, 25, 11, 5, 18, 154, DateTimeKind.Utc).AddTicks(6500), null, "Matematik Bölümü", "232-750-6003", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), null },
                    { new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2025, 5, 25, 11, 5, 18, 154, DateTimeKind.Utc).AddTicks(6500), null, "Bilgisayar Mühendisliği", "232-750-7001", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), null }
                });

            migrationBuilder.InsertData(
                table: "Advisors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DepartmentId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 25, 11, 5, 18, 156, DateTimeKind.Utc).AddTicks(1990), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 25, 11, 5, 18, 156, DateTimeKind.Utc).AddTicks(1990), null, new Guid("11111111-2222-3333-4444-555555555555"), null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 5, 25, 11, 5, 18, 156, DateTimeKind.Utc).AddTicks(1990), null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 5, 25, 11, 5, 18, 156, DateTimeKind.Utc).AddTicks(1990), null, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 25, 11, 5, 18, 156, DateTimeKind.Utc).AddTicks(1990), null, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), null },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 25, 11, 5, 18, 156, DateTimeKind.Utc).AddTicks(1990), null, new Guid("22222222-3333-4444-5555-666666666666"), null }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCode", "CourseCredit", "CourseDescription", "CourseName", "CreatedDate", "DeletedDate", "DepartmentId", "ECTS", "FacultyId", "HalfYear", "PracticalHours", "TeoricHours", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), "PHYS121", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(290), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 6, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 4, null },
                    { new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), "PHYS122", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(300), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 6, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 4, null },
                    { new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), "CENG322", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(340), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 8, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 4, null },
                    { new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), "CENG213", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(310), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 6, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 3, null },
                    { new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), "CENG214", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(320), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 4, null },
                    { new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), "MATH144", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(300), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 5, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 3, null },
                    { new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), "MATH141", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(290), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 4, null },
                    { new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), "CENG218", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(330), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 6, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 3, null },
                    { new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), "CENG215", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(310), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 4, null },
                    { new Guid("4777afa3-a512-4353-8109-0674da099cf0"), "CENG424", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(360), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "fourth half year", 0, 3, null },
                    { new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), "CENG112", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(300), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 3, null },
                    { new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), "CENG216", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(330), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 5, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 3, null },
                    { new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), "CENG400", 0, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(350), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 4, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "fourth half year", 0, 0, null },
                    { new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), "CENG315", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(330), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 3, null },
                    { new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), "HIST202", 0, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(320), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 2, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 0, null },
                    { new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), "TURK201", 0, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(310), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 2, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 0, null },
                    { new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), "CENG222", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(330), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 5, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 3, null },
                    { new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), "CENG411", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(350), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 4, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "fourth half year", 0, 3, null },
                    { new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), "CENG323", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(340), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 8, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 3, null },
                    { new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), "MATH142", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(300), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 4, null },
                    { new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), "CENG418", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(360), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 6, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "fourth half year", 0, 3, null },
                    { new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), "MATH255", 3, "Discrete Mathematics course", "Discrete Mathematics", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(360), null, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), 6, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "second half year", 0, 3, null },
                    { new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), "CENG115", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(280), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 5, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 3, null },
                    { new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), "CENG312", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(340), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 3, null },
                    { new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), "CENG211", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(310), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 6, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 3, null },
                    { new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), "CENG212", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(320), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 5, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 3, null },
                    { new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), "CENG318", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(340), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 5, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 3, null },
                    { new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), "CENG311", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(330), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 8, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 4, null },
                    { new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), "CENG415", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(350), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 9, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "fourth half year", 0, 3, null },
                    { new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), "CENG111", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(280), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 4, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 3, null },
                    { new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), "TURK202", 0, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(320), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 2, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 0, null },
                    { new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), "CENG416", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(350), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 9, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "fourth half year", 0, 3, null },
                    { new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), "CENG316", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(340), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 8, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 3, null },
                    { new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), "CENG113", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(280), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 4, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 4, null },
                    { new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), "HIST201", 0, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(300), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 2, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DepartmentId", "FacultyId", "StaffPhone", "StaffRole", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("55555555-5555-5555-5555-55555555555a"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(5680), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), null, "232-750-7004", 3, null },
                    { new Guid("89e73bfc-718e-49d4-92af-1c576d281cf4"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(5690), null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), null, "232-750-6004", 3, null },
                    { new Guid("e32d7b07-a92e-4dda-83e0-c90ee8cad8e5"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(5690), null, new Guid("11111111-2222-3333-4444-555555555555"), null, "232-750-7005", 3, null }
                });

            migrationBuilder.InsertData(
                table: "GraduationLists",
                columns: new[] { "Id", "AdvisorId", "CreatedDate", "DeletedDate", "GraduationListNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 25, 11, 5, 18, 157, DateTimeKind.Utc).AddTicks(8260), null, "ME-2024-001", null },
                    { new Guid("a44b3d2f-ab86-4f4e-92ef-fd61b2894bf1"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 5, 25, 11, 5, 18, 157, DateTimeKind.Utc).AddTicks(8260), null, "PHYS-2024-001", null },
                    { new Guid("abfb59be-9c96-490f-9c4e-100c15c0c337"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 25, 11, 5, 18, 157, DateTimeKind.Utc).AddTicks(8260), null, "EE-2024-001", null },
                    { new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 25, 11, 5, 18, 157, DateTimeKind.Utc).AddTicks(8250), null, "CENG-2024-001", null },
                    { new Guid("c70e2d92-b390-4511-978b-e058c34c9099"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 25, 11, 5, 18, 157, DateTimeKind.Utc).AddTicks(8260), null, "MATH-2024-001", null },
                    { new Guid("d47dc5ec-0974-4ed7-a24d-99bfba1aac06"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 5, 25, 11, 5, 18, 157, DateTimeKind.Utc).AddTicks(8260), null, "CHEM-2024-001", null }
                });

            migrationBuilder.InsertData(
                table: "RequiredCourseListCourses",
                columns: new[] { "Id", "CourseId", "CreatedDate", "DeletedDate", "RequiredCourseListId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("01d1ef7b-5977-4970-b1df-1b67420e5654"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4470), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("02eff077-213e-49c2-97fd-38d5dfab9d87"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4870), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("02fdb659-9739-436c-a4cc-920f0efa0c0a"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4270), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("042ae48f-36b8-4f7b-8edc-70f72c7627b0"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4780), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("060047ac-d861-49e5-9b95-8739999fcc3b"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4150), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("069b40db-5aba-4357-817e-597ae28badd9"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4750), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("070840b8-3255-4f5f-8018-39761a73a967"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4880), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("070d79d6-7ad0-4b6e-ab41-c0113b583ed7"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4900), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("075f079e-6d8e-40a2-ac55-b5a08a0719bf"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4670), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("08ba60c9-a545-4163-a2f5-88dcd433cd2d"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4130), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("0913bc18-45ed-4120-80cb-64a110362160"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4350), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("096a8ef2-564c-466c-a90b-17f8b227537f"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4800), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("0ac0e135-d98d-4f0f-93db-a8a7d7779048"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4590), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("0ac63132-1d20-4a32-bc93-4893d667aee5"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4830), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("0d017d17-6ec6-4bbc-af49-c821087f160e"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4560), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("0ecfc87a-face-4cea-aab6-73940689b843"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4620), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("0efe984a-9b7a-47d5-9f7f-b18df20c195f"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4390), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("104be971-bd6a-4a30-ac91-b499a4cd38c3"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4760), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("10b7aafa-1cf6-49df-8b7b-b7c2693cc94a"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4720), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("10ea2d09-60af-4565-be90-d2f18b1943d2"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4200), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("14559664-9323-451c-8922-fc2e417b1dc8"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4610), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("14fbd8ee-0043-47c1-a32d-0fe7fbf2e078"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4820), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("1564a781-3a43-4f42-9d55-5553449181ea"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4710), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("19a164ac-c977-457f-ab8b-868886a90ef2"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4850), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("19f2c510-14dc-4814-8b36-976e197cfaa4"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4210), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("1b1c5249-0f0e-4364-b142-a8016384f313"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4360), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("1baaabea-6427-4577-b9b0-cb3c608eec48"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4760), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("1c96d851-5e84-4b3a-80f7-ba1a55052b2a"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4660), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("1cb671bb-aa4c-4b7e-bfe6-8f4178b1e29b"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4340), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("1ecc3e54-08d1-4b1d-b40b-2897005a746b"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4980), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("1f42fe18-9dac-427a-88a6-0b10d090cb34"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4450), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("20cc3fd7-6517-4c5a-ba48-b69e4596fa14"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4890), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("22fe6ccb-e0ef-401a-9a41-cd7633295897"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4440), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("233a1214-eb6a-408b-805a-010072ee5591"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4440), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("23d86b56-4ef3-49aa-b6e0-6de995099b1e"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4300), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("256a10f7-3e37-4fa3-87b8-6b7f6af425c9"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4290), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("267d22cd-59a6-4fb8-a4b9-9353333b9563"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4920), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("278e5d21-8463-43d2-87ea-5a7a83b9a142"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4950), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("295a4bde-503f-4128-82dd-25347a47e369"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4610), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("29d0c32a-25c5-49c9-91d8-deb35c4cde17"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4500), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("2b760d52-30aa-498c-a504-31335034d6e5"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4670), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("2bcbaa58-1e4f-4110-9252-8ffbf07c9ab9"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4530), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("2c40f6d6-751d-4ce7-a268-ed236c3bc091"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4840), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("2c6ae054-0e49-4dc5-90d9-e2a0b30e4b48"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4960), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("2cf4c831-8bc8-4e8f-99cc-068a1b368c8e"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4690), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("2d33615e-252d-42d5-977c-c0ce5eb6a8a8"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4320), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("2e02b118-ad85-42c3-aea8-30df9e191b0d"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4630), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("2ef6be2e-83f6-4070-803b-a2f4970a3417"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4300), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("2f45b0d8-5c3e-4a84-abac-66519465ba19"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4680), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("2fc60f5d-1eae-4d88-83c5-7b2b555a73be"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4890), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("31cec59a-9049-48bd-af8a-a36022757687"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4860), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("33673bb8-681e-4a67-86b8-5538996b8984"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4280), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("33c94050-0437-4e24-90df-fb0596f3fc6b"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4420), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("35109aa6-df86-4280-81a6-cbb2eb588027"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4580), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("35e0468c-5d24-4035-861c-a85ccccb7466"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4650), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("38235da6-0616-4905-96e2-6395106953c1"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4590), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("3823774b-0df6-41ad-917e-6ff76c90cdb0"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4400), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("3a91b1db-d816-468b-9a44-3541afddab39"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4750), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("3c0e2c8f-c7f1-4b02-b992-6a4e37fa4a25"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4200), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("3cc0228b-f04c-4dd6-937d-4541581912ab"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4230), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("3cfed599-3e94-4e69-8736-1fbd1862226d"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4190), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("3e3e3f1b-1231-41f5-8ad5-3704ff524421"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4890), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("3fc337f2-89ea-4d53-b7ea-1a869a3c1362"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4170), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("417a186d-4a8b-4723-a676-2add41a2cd2f"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4810), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("41820b81-a12a-44fc-bdce-e31eb2e0b9b0"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4240), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("44110bd5-d2e7-43d3-9df3-5f3a89e31a5c"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4620), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("47ab463c-5175-48e3-a13d-e7b2a81e15b3"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4240), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("48453430-a673-4066-9f28-3b74e408ff83"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4290), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("49e89c16-46ba-49fa-8498-c377af808499"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4130), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("4a0df46c-b231-471d-92a6-f4cab0aac55d"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4910), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("4a4a9ea8-145e-4234-934f-386256cbcea7"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4830), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("4de06fef-bb64-46c3-9567-47d6024634c2"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4780), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("4e85bb46-1e1a-48cf-97f3-be06a3135630"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4740), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("4ee5d945-81ad-4b71-a173-acf98567dd76"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4700), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("4f85237d-5473-4c8e-9e8b-67faf0946234"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4990), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("506db5b6-dda3-4dbe-9901-381c332117b3"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4380), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("524afef2-6b8e-41d6-8507-c2523e34d65f"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4660), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("52b3019b-b138-4a95-a7c8-a8b7c2379e0b"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4220), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("52e724e0-47f7-4113-8846-3dea7a16747e"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4840), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("5556e7ab-1887-4a97-9eb6-00be35911963"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4970), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("564e582b-b6a8-4659-92c2-00f00de50189"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4430), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("565813fb-8a34-4893-b1b9-fddd7f386410"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4140), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("5686d932-4f82-4275-9ec8-7b2b66e5784b"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4160), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("56b9e90c-4cf6-46ee-9ab1-7eaa4d0d9434"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4160), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("589cb8f1-d5f1-4f71-a3fb-69251387347e"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4950), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("592aaf9d-7f4a-4759-b8d1-00926d838157"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4940), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("5a393405-3342-446d-b733-78df79ca0dfd"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4190), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("5b1fb77a-8c60-4e68-b85c-285132424b19"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4490), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("5b599f1a-92b1-4ec6-915d-f05640fa8d16"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4880), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("5e152530-7d7d-4283-b4c5-b1fcd9b9a94a"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4600), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("5faebbf9-59e7-44cf-b784-fd484a9e6d60"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4690), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("60f7f71f-dc90-4f3f-9239-9c42816fdf63"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4480), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("620ab645-df96-40f3-97f3-56d78f4c154a"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4530), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("632c729f-349b-4f00-ab6b-575f17818cb8"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4540), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("64175ec0-b01c-4aeb-86ab-1e6e2968de53"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4400), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("668cb42b-e5a2-4b4b-a15d-535c36b5c2ad"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4390), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("6c18981e-071b-4a98-8e70-3ceac14fdc3f"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4510), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("6e020e39-14f4-420c-b32b-a94d99a5ac94"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4220), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("6e8c49b5-0845-400c-a5a6-615d07b45a64"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4370), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("6eb7d4b2-bb02-4442-8748-ddce255f8159"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4840), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("6f18dc15-986d-4b74-9cbb-a0016352e91f"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4770), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("6f6b9d1d-c8b1-4106-88e8-8763ec470422"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4350), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("702f9987-285d-4028-80a3-9362e58c6362"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4480), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("72f770b2-a32e-4e79-8d9c-1c6d31d7f1d9"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4380), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("7319eaba-5a1c-4c4e-b1ab-07bbec3216d6"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4180), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("73b6752a-2621-487d-ba84-d934ea56942d"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4770), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("746656c6-bd1e-434c-b1bf-f9541b5bab46"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4520), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("762aaa52-cc1f-4040-b907-2a92247962ca"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4690), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("76814298-9ebf-4315-b7a5-691bf33235f3"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4470), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("76db5acc-eec5-4bf9-92a9-265c9e316152"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4560), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("78af01dd-faa1-449c-8170-d6d89f8b2011"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4460), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("79a8e714-ffff-49a1-927d-2464c1df0f8a"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4960), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("7b185d09-6043-4765-b5c3-94c0d4b08271"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4780), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("7bbd90fe-b2c3-4d0d-9fd0-c150e7168604"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4360), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("7c84bb54-de7d-495c-9c9b-a0ff90de5548"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4700), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("80966ba1-83c0-4138-bfc4-466f7c33c4b8"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4950), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("80f9c5fe-f965-4676-9ee3-b2c36ed913f1"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4980), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("81847ab7-276d-4089-bd1a-050f742ca4a3"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4600), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("85a68b1b-a885-484d-8547-d4774a348680"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4260), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("874d68df-2309-4713-916e-933f1a6350c4"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4430), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("87fb8b85-4dee-424b-8531-cade13f65d76"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4900), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("88c0c211-171e-4553-822b-4508c847c5fd"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4660), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("8e099749-225d-4b8e-a8a5-52de08b3cb93"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4140), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("9066c0ed-1f88-4b4b-8811-76f7d3d14a75"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4930), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("918531bb-6337-43c5-863f-a2576bb8c42c"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4250), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("920e0774-e858-436e-b124-812dac6b7d47"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4820), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("940979fb-1eb0-4d37-8711-725c9be3fd40"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4260), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("958a0bdb-5b92-422d-9380-1533eef373b8"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4930), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("9c37e5ac-0e44-4413-a184-aa6f0d7c7901"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4520), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("9e3d5c41-dbd7-40f1-93a6-a906fe1c7f5a"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4720), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("9e73e241-eef1-40b2-8bd2-c1dd03bed0c4"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4860), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("9e7f5b52-181f-4909-984a-21b56f57bbd3"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4880), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("a082c099-c663-431c-b75d-bd8c7492ea60"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4910), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("a32b6031-40f9-4c60-b261-773b8cdea316"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4600), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("a472414f-8cec-4084-984c-5626f79c1539"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4280), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("a8e3bceb-5a20-4b17-8ce0-b2b789510a7e"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4740), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("a8f220d4-94f6-45c5-b3b3-f31944814903"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4710), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("a915e803-86eb-4142-b3f7-6af64c832a67"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4370), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("aa180aa8-d41f-4e99-97f7-9886e6e057b1"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4910), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("aac555e0-8e4e-415b-b299-f37f9a77e3b4"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4720), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("ad746c3c-5514-43b6-b3ef-0c3ffbc5f071"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4730), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("ae4236f9-a2bc-4d6f-82ea-371531cd9e93"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4680), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("afe0cd79-46fb-4dba-8ee3-2c74120bd2f1"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4770), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("b0494564-21cf-467f-b478-b091807e1789"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4470), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("b0a931bb-9a06-48c7-9d95-9601ea071fc3"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4990), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("b0f85204-74de-4075-8594-b76327670b2e"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4970), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("b1b13889-85b6-44c4-ac1e-0a817203d066"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4750), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("b23be075-754d-4642-adb9-89e760435d95"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4410), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("b2f4d76f-3031-4b3e-bbde-92833362b414"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4350), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("b35d2b74-43ed-4d78-94ad-89745c6afa33"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4230), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("b3eeea1b-6f85-40cf-89b1-499da62bef12"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4650), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("b414af23-ecd7-44d1-8b8d-546c3f91a967"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4570), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("b4dc8a15-8de3-4eb2-b462-9c9369475505"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4730), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("b4f2742c-9462-46c6-acb9-be59a5926b85"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4640), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("b6412bde-fca4-4ccf-827a-da3abf9d7911"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4330), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("b992896e-93ce-4205-a291-f72697c40821"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4330), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("bbce13f1-15ec-41a2-9a94-a6a776a83598"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4170), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("bc13fb0a-eeb8-4047-b479-4bdf2d4efc9e"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4320), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("bda8b296-21a5-4193-94b2-21a97a3c1f75"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4630), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("be80a1d2-3c38-41bc-9406-eb1d5b8865cf"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4400), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("c13c3b4c-c1b3-4aa3-bec6-2dee98539c91"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4870), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("c4526388-4920-4066-8116-4c9b2199f84e"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4540), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("c4af466b-07fa-428d-a696-89fd069ed1b6"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4570), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("c4ce552e-75e7-4105-94fa-02ec59005a94"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4150), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("c6ec4404-7c25-474d-bd98-08c2c61001d5"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4500), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("c71bca10-d8d3-4e37-9344-187c0a52bb9d"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4250), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("c8473055-1881-48d7-a185-9e7a6ddc4a03"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4650), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("ca53eb6c-3e9d-4258-b6a9-ec0b6c5ae5bb"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4330), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("ca7da951-613b-4916-b492-abf613fac6ac"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4370), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("ccf288cb-8888-4e79-8efc-779059b95770"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4120), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("cfe24a79-93a3-4ba4-9ef8-b211c6aa3cef"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4940), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("d0191e3d-6724-4032-b73b-d1fb94210ecb"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4340), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("d06ce89c-96a2-419e-b2fa-961904c56de2"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4420), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("d1d53a71-fad2-4a8d-b87d-ff1100374616"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4920), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("d2b00cda-05e5-463c-b25c-d683e24e9e89"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4580), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("d2b630a7-4cc8-4bf7-847c-1239e26a032a"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4530), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("d419d876-7e9f-493e-912a-f2f259fd8e4d"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4240), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("d42929de-3418-48f3-aa97-65d54df831f7"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4800), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("d5744379-81f2-4a94-a794-7fc27db28a06"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4800), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("d5d64117-3a5f-4ead-8cb7-ca610fcfa824"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4790), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("d89b09c6-98ce-4192-be52-8723ebde15a8"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4860), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("d930f0a7-bf0c-4e09-a9a8-cd31cdac49ff"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4810), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("daf7b577-72c9-4e83-87c1-4e7e25def0c8"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4460), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("daff2fb8-4161-46ec-978e-40749627a3b9"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4210), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("db334296-52b8-4df5-b973-a52136a534b3"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4430), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("dd0d7d07-ea5a-4835-9b1b-57f0e87745f3"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4980), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("df73842b-3dbc-43c8-9272-f1f0b17bb02f"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4160), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("dfd52db1-fb73-4202-9708-6af23679e756"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4410), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("e06d6c1c-5be8-4bd9-8c5a-7cb4d81ce8b5"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4550), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("e1c3f012-4695-463f-b1e3-c1cf0aa3287c"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4180), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("e2093cf0-8cd0-422d-ba8d-43e15e48770f"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4450), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("e3787a19-af5b-4086-9ab8-2d4adfc705bf"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4450), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("e477b3eb-7489-4a2c-bcd3-28c3dbf07607"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4200), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("e5dcdc29-bb5f-47b9-b961-897ca10a78f7"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4310), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("e74311a7-f504-402b-bb7d-57d2cdbee40c"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4930), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("ee0ac345-3bac-42db-a0d5-8057b7a8d8f6"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4310), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("eebf89d3-a7fc-4fe7-9a47-71784d0b8fa9"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4510), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("effd7583-ff85-48f7-82a3-6fdd805c7174"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4820), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("f0c95b21-1332-4263-b19e-165b19801b96"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(5000), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("f1e99e43-d90e-4689-b3e4-ab9138997590"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4790), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("f3608c21-05dc-4770-93ca-69e4668802c6"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4620), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("f5e65cb7-93bb-4ae8-8b2b-420e7cc35853"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4510), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("f626e828-7c8e-4fa4-8d0b-6d28be155e51"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4290), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("f76806d1-f73e-4761-bec8-aa6fc6e7829f"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4850), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("f8acffaa-adda-41c4-9db1-cd760a8e8b10"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4640), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("f983aee7-e281-4557-a6b6-18b91897f71c"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4490), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("fc402d5c-e87d-4e16-945f-f7cb1256867a"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4270), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("fe591157-28d9-4d13-8b27-98625aa963e8"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4550), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("fe646d8b-8aee-4d77-afe6-ffb5df73d698"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4570), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("ff75cc2e-2b0d-4e7e-84cd-f5bcc3773100"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 155, DateTimeKind.Utc).AddTicks(4550), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssignedAdvisorId", "CreatedDate", "DeletedDate", "DepartmentId", "EnrollDate", "GraduationStatus", "RequiredCourseListId", "StudentNumber", "StudentStatus", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9770), null, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), "2023016", 0, null },
                    { new Guid("22222222-2222-2222-2222-22222222222a"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9730), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), "2023001", 0, null },
                    { new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9760), null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), "2023012", 0, null },
                    { new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9730), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), "2023002", 0, null },
                    { new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9760), null, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), "2023013", 0, null },
                    { new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9770), null, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), "2023015", 0, null },
                    { new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9770), null, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), "2023014", 0, null },
                    { new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9760), null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), "2023010", 0, null },
                    { new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9740), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), "2023006", 0, null },
                    { new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9750), null, new Guid("11111111-2222-3333-4444-555555555555"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), "2023007", 0, null },
                    { new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9780), null, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), "2023017", 0, null },
                    { new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9740), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), "2023005", 0, null },
                    { new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9760), null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), "2023011", 0, null },
                    { new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9740), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), "2023003", 0, null },
                    { new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9750), null, new Guid("11111111-2222-3333-4444-555555555555"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), "2023008", 0, null },
                    { new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9740), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), "2023004", 0, null },
                    { new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9790), null, new Guid("22222222-3333-4444-5555-666666666666"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), "2023026", 0, null },
                    { new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9790), null, new Guid("22222222-3333-4444-5555-666666666666"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), "2023025", 0, null },
                    { new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9790), null, new Guid("22222222-3333-4444-5555-666666666666"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), "2023024", 0, null },
                    { new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9780), null, new Guid("22222222-3333-4444-5555-666666666666"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), "2023023", 0, null },
                    { new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9780), null, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), "2023022", 0, null },
                    { new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9780), null, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), "2023021", 0, null },
                    { new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9750), null, new Guid("11111111-2222-3333-4444-555555555555"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), "20230081", 0, null },
                    { new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9750), null, new Guid("11111111-2222-3333-4444-555555555555"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), "20230071", 0, null },
                    { new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9780), null, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), "2023018", 0, null },
                    { new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(9760), null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), "2023009", 0, null }
                });

            migrationBuilder.InsertData(
                table: "GraduationProcesses",
                columns: new[] { "Id", "AdvisorApproved", "AdvisorApprovedDate", "CreatedDate", "DeletedDate", "DepartmentSecretaryApproved", "DepartmentSecretaryApprovedDate", "FacultyDeansOfficeApproved", "FacultyDeansOfficeApprovedDate", "GraduationListId", "StudentAffairsApproved", "StudentAffairsApprovedDate", "StudentId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2631eb6f-de37-4e9e-8d03-a5a884fa9145"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(350), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), null },
                    { new Guid("26627b25-c1ab-43d5-9885-c14ba235e293"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(430), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(430), null, true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(430), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(430), new Guid("d47dc5ec-0974-4ed7-a24d-99bfba1aac06"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(430), new Guid("e8a7af40-b211-430e-967a-e590bab72810"), null },
                    { new Guid("31b62f85-15d2-40ed-a94f-1e86154983dc"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(380), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a44b3d2f-ab86-4f4e-92ef-fd61b2894bf1"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), null },
                    { new Guid("391264e0-14d2-470a-8969-f4dd2265712d"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(340), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(340), null, true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(340), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), null },
                    { new Guid("39763dec-ad8b-4525-a240-33259bcd0b4f"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(420), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(420), null, true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(420), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(420), new Guid("a44b3d2f-ab86-4f4e-92ef-fd61b2894bf1"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("e8a7af40-b213-430e-967a-e590bab72810"), null },
                    { new Guid("3fc1a6be-da24-416d-a446-f206a5fa4676"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(350), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(350), null, true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(350), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(350), new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(350), new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), null },
                    { new Guid("4165bcee-29b7-4381-ae74-fdfcc7938b92"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(360), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(360), null, true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(360), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(360), new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(360), new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), null },
                    { new Guid("5a03427d-a258-473a-898a-14ebe5275633"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(410), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("e8a7af40-b216-430e-967a-e590bab72810"), null },
                    { new Guid("5ac0e016-7f36-48cf-9578-479271dfc534"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(370), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(370), null, true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(370), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(370), new Guid("abfb59be-9c96-490f-9c4e-100c15c0c337"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(370), new Guid("c4e05469-860b-4655-b844-f682a21fca23"), null },
                    { new Guid("6db739f5-16b0-437a-86ff-0e0232426b03"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(450), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(450), null, true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(450), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(450), new Guid("c70e2d92-b390-4511-978b-e058c34c9099"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(450), new Guid("e8a7af40-b208-430e-967a-e590bab72810"), null },
                    { new Guid("720cb4b3-f463-4cfd-aeba-c599eb989b1c"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(400), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("c70e2d92-b390-4511-978b-e058c34c9099"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), null },
                    { new Guid("7e6c6720-25df-4d70-a35d-78e6769a3f6a"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(410), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(410), null, true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(410), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(410), new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(410), new Guid("e8a7af40-b215-430e-967a-e590bab72810"), null },
                    { new Guid("8523644a-f0d5-4a1e-af5e-c999a9605059"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(430), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(430), null, true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(430), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(430), new Guid("a44b3d2f-ab86-4f4e-92ef-fd61b2894bf1"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(430), new Guid("e8a7af40-b212-430e-967a-e590bab72810"), null },
                    { new Guid("98227c0c-ea41-41a9-b5b6-96a613ebff27"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(390), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("d47dc5ec-0974-4ed7-a24d-99bfba1aac06"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), null },
                    { new Guid("ac81a9aa-c64e-4f8d-b2be-bdf3870d8356"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(380), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("abfb59be-9c96-490f-9c4e-100c15c0c337"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), null },
                    { new Guid("b47411ad-fdd8-45f9-91dc-ad700535782b"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(330), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(330), null, true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(330), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(330), new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(330), new Guid("22222222-2222-2222-2222-22222222222a"), null },
                    { new Guid("b9933fbe-a91c-4e4c-97d4-3ddad4bac128"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(360), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(360), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("abfb59be-9c96-490f-9c4e-100c15c0c337"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), null },
                    { new Guid("b99adf20-02cf-452d-ba1a-7f540dbd28fe"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(390), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("d47dc5ec-0974-4ed7-a24d-99bfba1aac06"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), null },
                    { new Guid("c09c300f-3562-4d63-bba2-515d7e26ecee"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(410), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), null },
                    { new Guid("c3a662ed-9549-4f64-ba7c-6be5f8e5a072"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(340), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(340), null, true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(340), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(340), new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(340), new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), null },
                    { new Guid("c6795138-832c-43ac-9b0d-2c946dedf668"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(400), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("c70e2d92-b390-4511-978b-e058c34c9099"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), null },
                    { new Guid("c779ed79-b923-4579-aa22-c6944fba5652"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(440), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(440), null, true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(440), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(440), new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(440), new Guid("e8a7af40-b209-430e-967a-e590bab72810"), null },
                    { new Guid("d0cca056-185b-48f2-a2a1-3a6114c5dc7e"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(370), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(370), null, true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(370), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(370), new Guid("abfb59be-9c96-490f-9c4e-100c15c0c337"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(370), new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), null },
                    { new Guid("e75f5910-8d63-47bf-9963-bb7ff927582c"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(440), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(440), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("c70e2d92-b390-4511-978b-e058c34c9099"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("e8a7af40-b210-430e-967a-e590bab72810"), null },
                    { new Guid("f4aaf472-a0bd-4ffd-be24-f5f4d979b50f"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(380), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(390), null, true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(380), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a44b3d2f-ab86-4f4e-92ef-fd61b2894bf1"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), null },
                    { new Guid("f5e4ca81-d41f-4082-9fc2-a927c3081523"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(420), new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(420), null, true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(420), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(420), new Guid("abfb59be-9c96-490f-9c4e-100c15c0c337"), true, new DateTime(2025, 5, 25, 11, 5, 18, 158, DateTimeKind.Utc).AddTicks(420), new Guid("e8a7af40-b214-430e-967a-e590bab72810"), null }
                });

            migrationBuilder.InsertData(
                table: "TakenCourses",
                columns: new[] { "Id", "CourseId", "CreatedDate", "DeletedDate", "Grade", "StudentId", "TakenDate", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("000b9814-740e-4296-bf83-3d806565a23f"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3500), null, 6, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("00b66fb8-1c98-4b07-919f-fc72adb73fc1"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3050), null, 6, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("00e860aa-98f5-4472-9856-52fee76989c6"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1350), null, 5, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("01de8d4d-dee6-4de8-a676-6e09fc3cbea3"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4490), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("02812638-8057-465d-be61-7152fc41752e"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1650), null, 5, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0288667d-bb9e-4038-bf8f-e0fd0c1be024"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1110), null, 7, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("03192c2e-b491-4b63-901a-f411454ae359"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5210), null, 7, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0434b87a-450b-41e4-9092-9a2197eb45e5"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1700), null, 8, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("045ed673-3e94-4ef8-a2fb-10103b243764"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5000), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0461bf11-4f51-43d2-bd2b-0d0a8e987ded"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3940), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("046eecf7-b3b3-45e6-bb62-d914eaf5ec62"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1280), null, 5, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("04897c7c-4da8-401f-950b-6f7356c73520"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1250), null, 8, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0654cee3-c2f2-4a20-95ab-c85106c65000"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5090), null, 7, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("07b10749-6087-495b-8093-b240b0b81223"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(920), null, 8, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("083d171d-3ece-4dd2-9ec2-cc1a69ec15a7"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(890), null, 7, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("09eb1ee6-d249-4142-9770-a02e7cc86b33"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5520), null, 7, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0a5f2f6d-1154-44ca-85de-e8b006ff344a"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2140), null, 6, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0a8f63cd-6cd0-4d88-8638-7a63f30bf913"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1240), null, 5, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0aca7698-bba3-4858-999d-3ea1d744efc5"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5820), null, 6, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0b8b0343-f828-49b6-bd52-aa1816ec0ce4"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5250), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0bdb3ba7-4745-49d1-b11b-5b11320480a2"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2310), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0c290130-a54e-4e85-8317-4948000ba578"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5220), null, 6, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0c35da5f-e52d-4266-964f-a0d2c461ff2f"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3980), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0c36f256-6df0-4d38-8615-dae9784f4bfa"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6050), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0c75254d-2ddd-41f3-8639-bb36c2a3852f"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3370), null, 6, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0cdf8d21-0b1c-4594-aedb-61175165edfa"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5620), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0d667b14-dc31-4414-9d71-6156f7fd2efd"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1480), null, 4, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0e287a36-535b-4036-840d-b3969378d800"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1340), null, 7, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0e628292-d2fb-4fe0-9070-e5b8b191c00d"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3760), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0f689265-51bb-4557-818c-14b844b679d0"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1210), null, 8, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("10f85870-75c9-4d8d-851b-d684ffa5287a"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1800), null, 5, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("11252812-ef16-4e58-a342-caa6f06fef14"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2620), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("122a6134-074a-4cbf-9726-236f1c337314"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1590), null, 6, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("122c97d1-4920-49d8-89a5-6adf623ac875"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6600), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1233ecc1-940a-41bf-81c2-cb2d10e12fb4"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3040), null, 7, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("125b1e70-9320-4707-9149-0a6c6503402d"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4240), null, 5, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("12eff3b5-fd87-488b-bd53-899a7ae9cb72"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4570), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("148b4172-22d4-45fc-bfc4-f8ebedc9fb1d"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1510), null, 6, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("14c3b738-b009-48d9-80af-8701c1fa569e"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3210), null, 7, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("14d5b5e8-aa0e-466d-8391-6ca5c6bcfd4d"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2830), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("14ffec0d-c9f9-4dd2-b87a-e41bc0f153ca"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2020), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1591d7c1-747b-47ed-bc57-9d5a2411efea"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1470), null, 6, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("15ba14f5-c5ce-4d0c-a88d-e0e7881bc5b2"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5490), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("15db12c8-21af-471c-962c-c2a52faf64bc"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3610), null, 5, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("162f8820-8f33-40c0-888c-95b0e077d986"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5050), null, 5, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("16457768-eacb-4fa1-84d1-bc11219781ec"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6570), null, 6, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("16be2a6c-3dcf-4abb-9e54-3210d77dccc0"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3340), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("18627835-74d6-439e-93c7-8924ffc4704c"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5550), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("189daa1f-4f19-4f08-908e-30ae4560cff7"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5730), null, 7, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("18d49497-c29f-4270-ab72-0f8dde911dde"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6610), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("19065cfa-cd40-4cf3-82fd-612ebec2e64f"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4340), null, 6, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1915909c-c465-4d1e-a3b7-80ca623a0ab5"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3190), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1b1d1192-ed3f-49d1-8505-5bd7ed78b743"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2610), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1b4e8b4b-df78-421e-8c94-ca5023d5f52d"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6640), null, 7, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1b7d71b3-c5be-448d-b01f-acc12cc93c8a"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6380), null, 5, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1bfda4b4-27ed-49db-9bf2-99ee904f9ab4"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4070), null, 7, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1cc45449-eba8-4ae8-8a0f-291f6de13c90"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5670), null, 5, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1cc891b0-0cd3-4f32-bdb5-267b4f6372b0"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4970), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1d2a87be-1e6c-4ec8-a7ab-7f2e8fd720ae"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1370), null, 8, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1d7a53fa-3536-40c6-b32a-9964e0492bfb"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2360), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1e0bb81c-4061-46cd-81a0-6f63f67a50ed"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3420), null, 7, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1fdbf40b-3074-4bc3-bd1b-a8ffa6f41e85"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4830), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2115d004-ab09-43c8-8f26-191f33c87d9c"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4700), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2120d78f-d780-4809-bf4d-d7555cd07f88"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1830), null, 6, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("217832b1-dd0d-4f69-b6e9-dfb69096f4a0"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5010), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("219ba77e-96d8-4a56-8ceb-b78e87de8cae"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2190), null, 6, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("223a2682-cd56-4b4d-afcc-113e199122ab"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2930), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2442c153-f421-4abc-90fe-9fd445aca32a"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2170), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("244d0512-1e8f-4aaf-a6bf-db5aef8ad960"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2500), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2534fccc-1d78-47a1-acd8-61cabba1475b"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3470), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("254885a5-938c-4a0d-bd54-6eece1f2ff97"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1080), null, 7, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("255b1f68-22f8-4f4d-9ba0-849603069489"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1620), null, 4, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("25d5fe64-be46-4d79-97b5-3415d85f6c71"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6260), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("268fc320-11e6-481d-86f2-9aeb55b6c2ab"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4220), null, 6, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("26fcb428-9b97-4954-b719-6df821165cc5"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5650), null, 7, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("27531811-2bae-41f3-8738-b25ae660b007"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1000), null, 7, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("288e33ce-be67-4b6b-b9e1-e7e3e2f0110b"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5310), null, 5, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2aa639b7-f6a9-43ed-b1e5-7e8868acb1c9"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2250), null, 6, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2aa63e60-9c35-496e-bfad-3b0e8a9f189e"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3960), null, 6, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2b11c976-dde6-4402-b9e9-4f103b445073"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1150), null, 7, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2b3e871a-0e1a-4b7e-8add-d11cb949793b"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5400), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2c0e2d51-605b-4ae0-be93-45f05ab3074c"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1750), null, 6, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2c10abf2-2682-48b8-a29e-dde01bd311b0"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6400), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2cb4f22e-7bbb-455e-b0f9-6468c0cf4bf9"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1660), null, 4, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2cbc4953-bc90-4bcb-aaeb-449a4a5b9ca8"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4100), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2ce54319-83fa-49d2-87b7-cbc19b1d4855"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1890), null, 7, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2d025740-9130-429d-9305-ea0a07b32783"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1490), null, 8, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2d4b09ad-5482-4ee1-a72a-64b1effab0c0"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3990), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2d691334-000a-4397-8b63-1003b6041792"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4390), null, 7, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2d6f482d-d6c0-4022-b248-f12888a1c2b4"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4140), null, 6, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2dd3659e-7ad0-4495-8936-f3fae871ec92"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1380), null, 7, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2de0fe08-9402-429c-9955-4fe2c4ad11ab"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1570), null, 8, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2e1d1f9c-ad4c-4cc7-8566-696507eda972"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5510), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2e2ae496-5fcb-40f1-9997-cd1d1d9ed63c"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4930), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2ead2599-cecf-4675-a1b3-8a0b49a000a9"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4670), null, 7, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2efec889-8642-4751-b059-d0394634664f"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6210), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2f2e018d-d335-49aa-aa65-68f1a9c5f777"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1900), null, 6, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3052d006-492f-494e-8d0f-5213ceca9bab"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(900), null, 5, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3059d32d-384e-409e-9276-a50f66820519"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2870), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("30b7d58c-1573-4bd4-a7de-043686c21471"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6550), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("312f3be3-b48a-4254-b102-6630e69fc971"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4150), null, 5, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("314d5e38-9d9e-405f-9de0-0f86d516c5b6"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4190), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("315320b6-a08e-465c-b265-67b5c9cca643"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3000), null, 5, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3185fe42-5ec5-4257-b028-5d8d5a74978a"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5710), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3219cc44-4cf7-47e6-90d5-3c93a15b5c07"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2270), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("323b5995-4c1f-4c2d-adb3-2b3299d2e357"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2980), null, 7, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("326749fe-2bf2-402b-865f-8cd6dd036b59"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3240), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("32f24896-3468-4716-a04f-9293b14f365d"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1930), null, 7, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3333306e-9baa-4219-99ca-a7bcc4730346"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1500), null, 7, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("334fdabf-226f-4903-9ec9-7121ddfaf6aa"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2630), null, 6, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("33c96596-5c2d-4c6b-b05e-964565845291"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6110), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3426e5f7-ea60-4ced-94f6-61dac8f4a8c5"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1690), null, 4, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("345be589-0243-47d6-aa50-dd26c4d78087"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4200), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("35340f54-8662-4ca2-9343-287eddb1e232"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2510), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("35c8f509-4f82-46b9-9afe-96dedb28601f"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1140), null, 8, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("36123d59-8188-42af-85fb-b1fdc4bc67a8"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3910), null, 5, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("36293a3f-ec78-45d6-8f51-1849894ed479"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1210), null, 4, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("36379e24-b2f3-41be-a18b-ffd664eea76d"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1630), null, 7, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("369c4d92-31a7-4497-9dc7-9d3c01838e18"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3690), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("36a83e5f-d86d-453b-95e9-c7e532bd2f42"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4510), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("36af2874-e3a9-4925-af49-47c6a876c163"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4900), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("37a1c498-f968-436c-9892-b105541869f5"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2560), null, 5, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("38258ad9-78f5-4973-ae19-ac426d24d6c5"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2640), null, 5, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3890b7a1-b02e-4fab-834b-d845f413feea"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1850), null, 4, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3970307d-fea4-4718-8022-39485ed342ae"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2140), null, 7, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("39a99273-7abc-4632-9a57-be196074128d"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3300), null, 7, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3a35ece8-6905-4047-854e-eb309daeb581"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1870), null, 4, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3b596977-6bf5-4dd0-8a2b-809893f10623"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3840), null, 7, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3ba5f78f-524e-4bb3-b4bc-d717add2027c"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3230), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3bbe56d0-766d-4e6d-9c24-1643e9f29cf5"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1610), null, 5, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3d1c513e-c63c-46a2-870e-a3830aa4cdf6"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2910), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3d5cd700-40b6-4738-adb9-98b8062373f3"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6100), null, 5, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3db20416-abae-406f-b6fc-146008f0c023"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(840), null, 8, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3f57cbb0-9f0a-48a3-812b-f1385d1a9a03"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5160), null, 6, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3f83e974-8d2d-4f59-852c-534e1eaec627"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2720), null, 7, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("40f8fa4b-155d-4056-9751-948228d242ac"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3920), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("412536c8-8bd0-4be9-aa3d-1bad9cad5f0e"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2660), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("41f03981-3d4f-4c3e-8467-f367a97b0466"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5850), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("41f044de-980b-4c2e-84b0-8e2d9d2a81cc"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1170), null, 4, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("420e0f0b-9e4c-47df-bd4b-845b6c201765"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4330), null, 7, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("423f8d7d-efef-4828-85bf-0969d18bb624"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1020), null, 5, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("42b26c1e-e7b3-47a9-b0dd-863d779187a6"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1790), null, 6, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("431046db-7d21-47a8-a0d6-c15ffd515af2"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1010), null, 6, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4326a789-7972-40a2-947d-a65c1b4406c5"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6500), null, 6, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("434df2e4-4d1d-49ce-97f0-b82600e801bf"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2730), null, 6, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4350aa3d-e69f-436d-b54f-61ad3a235ff9"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6360), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("436f165f-7c20-442b-9b5e-2cda5ee93099"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1770), null, 8, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("43ea2589-97fb-44c1-a224-698f5f316e1d"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4650), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4420182f-9556-44d2-939d-45df1f228e70"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1720), null, 5, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("44e2a69b-d91d-4481-8f94-1fcebfe31d71"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1290), null, 8, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("44f4118c-2a9f-43b3-bcda-dee3af8cc0e0"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6680), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("46bda821-a710-4b78-ad2a-285ed7e42b2d"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3560), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("478378fd-cbe7-4b04-847a-b38337dfbdf5"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1200), null, 5, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("481491ea-a3ce-4d0c-9765-79add579a116"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(860), null, 6, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("48b4c1c9-cb39-4a1e-a289-22222b3b3590"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6060), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4a327b26-a3c5-457c-9930-49de7e211895"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(850), null, 7, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4bb65fd1-822d-4d7a-bd21-1fb15b1c722a"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6660), null, 5, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4bf9bf39-9ea5-4596-a9bd-38b81065504b"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6520), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4c1a5c3d-ac61-4bdc-8455-6a76d5e2a662"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5860), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4c3048fa-08a8-4917-9db1-475d6b3de8ee"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4000), null, 7, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4c69edc7-8027-4d4b-b94e-f6e90c017057"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2740), null, 5, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4c98f55f-d563-452b-a222-a6b3bb6d5617"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3410), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4cbd4671-2bb9-4d9d-9d9c-c5374c4ce36d"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(940), null, 5, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4cf11eb9-2d57-4bb3-ac40-7af2b493ad1c"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4550), null, 5, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4d080d14-b77d-4c4b-9f85-39b9882a3fab"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3930), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4d32ce39-03c2-420e-af66-d461aebbd525"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4350), null, 5, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4d5eafda-af55-48bc-95dd-6413620f415e"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1390), null, 5, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4dafa36b-1ca4-4dc0-ba15-af6bae2d136d"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2420), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4f6e10be-3510-445e-9b0c-023a1f15cf83"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5280), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("509414c2-9801-45e0-961b-cc728b41f382"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4410), null, 5, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("50e9cf0d-de33-467b-9e11-9505e760aa2c"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2210), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("516fcfa3-3376-4191-8e85-5c753fb9a234"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(870), null, 5, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("518f94b9-9d8d-4197-9292-4ea45c24c501"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2100), null, 6, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("522a9308-15d6-462e-8c4c-f7ec2b2ac14d"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6160), null, 6, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5253d26f-69b9-4964-87a3-79b5c17be503"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5170), null, 5, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("527fe1d0-840b-46a5-9a70-fcadefc260d7"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5980), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("52d40f90-0b4d-40e1-8ef6-617e1eb0f91b"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2470), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5304601b-202a-415f-bea1-6d2b083ed37f"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4840), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("532be85e-7014-4e54-87d8-584a7a976647"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2400), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("53bec92f-bbed-42b5-91ef-94de01597c81"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1060), null, 5, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("54863956-3948-4812-9d8d-f6440551f6b0"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3430), null, 6, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("54cdf491-107d-488e-9619-63735b81592b"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2240), null, 7, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("54d1f0f3-75cc-47e5-b039-1c4cb86874b2"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4910), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("551f7f0f-a98b-49b1-aa2f-38516c498511"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6200), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("554f9134-6d16-4626-9484-4eb73e7f8146"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2770), null, 7, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("556aeb57-db2a-454c-b23d-921a2b924611"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6300), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5595c5e2-56bd-4eba-b32f-6f5828884644"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5630), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("563f841e-fa33-4a1d-8836-ba60dcd1e418"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1030), null, 8, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("56bed103-6895-45ad-84e7-bc58f6d327a0"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6440), null, 6, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("56f22db2-6bc3-4edd-8a65-a7a76f062fa6"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3820), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5701e0e8-34fc-478b-9cff-795eda3f6ad3"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6310), null, 7, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("57155963-95b5-4562-ac3e-1df09cbfbe40"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2090), null, 7, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("572be812-f4d9-47bc-9bab-253c981840c2"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3750), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5758a6dd-9db1-4d45-98e8-0fff0baa88a7"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1840), null, 5, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("579ea2d8-b451-4fb5-8546-f4441538b56e"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4580), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("57dbba16-665d-41ff-be10-6d646f1691a4"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6090), null, 6, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5811e8f1-55d0-40b5-9058-6ae4df62d504"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2040), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("585008ce-035d-4fc5-911b-e6561c15f433"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6250), null, 5, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5881b617-41a4-4fe6-a2ea-2467840000d3"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3140), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("59429e94-e00a-4f62-bb3b-57520dfc536f"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3600), null, 6, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("59de2caa-3704-4ae2-a70a-da98eefc88e2"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4520), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("59e9a391-322d-419d-819e-00ca832b68d2"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1600), null, 4, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("59f2a8c1-a95d-401f-bb5c-120e89188c8e"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3070), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5a75d6b5-945a-4239-96e9-7f4f9014664e"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2690), null, 5, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5b0f95c5-40cc-4094-a6ee-50d2a3f3dde5"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3520), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5b8caf6c-abdd-41cc-bd86-6af2086e4516"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2540), null, 7, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5c7922fb-49f0-4821-8cda-a29187647475"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3780), null, 6, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5ca7423c-618a-4f85-9652-fe888a93988d"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6280), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5cf34acb-120f-4905-94c9-6991793f5120"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6540), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5d01e23c-ecdd-4e30-be1e-d3b6e96e2f42"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4710), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5d3a92a0-58ae-4e30-aa6c-b9068276b7af"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4030), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5d731933-e382-4554-a85f-a69b34936e62"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2990), null, 6, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5dbca194-eacb-4299-9082-e6f539f7834d"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1060), null, 4, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5e2f6aec-5350-46aa-8107-7be6bc215f53"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5800), null, 7, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5e40216f-b5e2-4808-be4c-f733215d03ba"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3730), null, 5, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5e5b7188-ca1d-47d4-bf6a-56e7eb800376"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2770), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5ee3b71f-a15e-4b4a-a2b0-0aea082acca0"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1360), null, 4, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5f1ed1ba-f05b-4aa1-a52e-1592cdf5b47e"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(990), null, 4, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("607ae88b-a336-4279-9891-478fe576a129"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1120), null, 5, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60c6177b-018a-429e-86c7-6119bdde1d74"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4020), null, 5, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("62c8d867-bd45-43d4-bec9-10d33471a51a"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5340), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("62db2753-a452-4ce9-be99-8ed80a14bbb4"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2100), null, 5, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6439a46d-84b1-4d4a-ab21-6b4d6b7460e7"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6220), null, 7, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("644370d7-5bf8-40f4-954f-e8c29e72940c"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6140), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("646c5e0a-bca5-4152-97d0-ac720ec5acf4"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5760), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6522168d-da32-4079-9b28-152dcd694706"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5560), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("65dcaf56-6074-40b3-bf30-4ea4e80b3b92"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2350), null, 5, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6692bc4a-be54-432f-b142-c4683eda711f"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3640), null, 7, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("67422082-e4c2-451f-bf75-7320a7c6faa0"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4400), null, 6, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("681186c4-f65f-4b62-8b0f-b6bd1530fce7"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1630), null, 8, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6813814b-9790-4c7b-a6e3-ba422a1e64e1"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5910), null, 6, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("69775228-f33c-49ac-a596-84812636e4dd"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1950), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6aed0183-8658-4426-8e91-826329772355"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1450), null, 8, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6b1bf4ac-d28c-44d7-851a-6e3f3666d8c7"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3070), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6bb50cca-ec07-4f57-b677-f0d6b88327f8"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1270), null, 6, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6bba8adf-11bc-4188-b551-8e3a352ce2cc"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1940), null, 6, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6c1ac363-eb7c-42a0-8802-e678601dfdc5"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3710), null, 7, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6c7c2b82-0248-40bb-9cc9-7aea74af8d12"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3770), null, 7, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6c8ad81b-4f81-4fa5-8af7-738d603f6400"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1160), null, 5, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6d14a77a-6b29-444d-8e2c-1a893f769e3c"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6560), null, 7, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6d357eb7-aa39-45a3-bf84-d8571bb4414f"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1280), null, 4, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6db7c552-fc81-4145-87ac-7ead97f35453"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2800), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6eb8da07-2fbd-4118-bae7-85ca95f8e8f9"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6190), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6f082f56-b78c-44e6-834d-f94d645febe2"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2020), null, 5, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6f71efae-e4f2-416c-a557-1aa485c06596"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2700), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6f81c565-4cd3-46fa-b202-a6c366aa7da8"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5480), null, 5, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6ff98663-6f73-4984-b814-aa629f364324"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4250), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("705c3ac7-f33f-4dd5-958d-051b7681763c"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3390), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("70ff0812-6e42-4ed9-983c-1c07ed8d99d0"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3260), null, 7, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("712d315b-9b4e-4a56-be2a-6daadebba145"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2530), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7163ce01-da88-4662-892c-92b2178806d0"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5580), null, 7, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("72634de7-2ae0-42f6-af23-17e11615d6a8"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2680), null, 6, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("72de80bc-3b53-4da6-9db6-b5a62dd66178"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5920), null, 5, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("73752f5f-4732-437f-9d67-1b721610c27c"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5880), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("73f25fc4-9396-4036-a074-30cdef96ef4a"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1150), null, 6, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("74302f05-9690-4b7a-80e1-5ffb33a673de"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1130), null, 4, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("74f73492-0086-4f48-9bfd-813c3e39b981"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2190), null, 7, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("75e83785-f6fa-4883-8ca0-194d3e90a9fb"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2450), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7612997d-14cf-4bc5-a640-132d4a55c43c"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1420), null, 7, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("78efab52-8d0b-44e8-a000-8f178c245e53"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4210), null, 7, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("78f7c8a1-a9c5-4723-a1a4-f18cb2304245"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5060), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("79531392-dcdb-4835-bf34-9c2d064d1bc2"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2930), null, 7, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("795e1969-be8a-4a48-ac5a-254f9167ae80"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2430), null, 6, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("79de223a-c24a-4f06-a1df-075c876b23ae"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4290), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7a16146a-f1f0-4cc9-b81a-160507412eee"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2630), null, 7, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7affa17a-d955-41ce-bc73-b510b2aa9f9c"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3700), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7b8d0e5e-0ec5-4903-bdeb-cc3274bfb1b9"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1670), null, 8, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7c7dc4be-9f17-4593-b1ef-59d1ffce1ed3"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1000), null, 8, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7c8a1f88-885c-4efb-8ef9-f798a2734de6"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4800), null, 6, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7ca42f7a-c396-4d63-a821-55920e49ab43"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1300), null, 7, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7cc5de97-8bbe-44e9-8bb6-a9890758357f"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2230), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7cfee0fb-751e-4ffd-ae31-736ed6970582"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2310), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7db9dfee-4d4c-465f-ac9a-27d16acc78be"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4310), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7dc8ef8d-fe55-4ea8-a793-a0652d7d3f58"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1050), null, 6, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7df2b048-666a-4c05-a817-32346885521b"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2070), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7e7aecd8-9230-4328-b552-72b7e03890fa"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4600), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7f5a04de-6ab6-4257-bda3-447acb879363"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6490), null, 7, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7f5d2afc-f6e8-4e3c-b923-578e64ff0f99"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4360), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7f843c63-800e-4971-b4c6-b5d73dc63a39"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3170), null, 6, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7fcaf297-fb8b-46b2-8021-80c838ab9868"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4420), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("802d0352-ab17-496f-bce4-294c28ae5b9d"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2000), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("804cc9b7-7587-4fa6-8ece-443e806f816a"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1640), null, 6, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8051f7f6-ffd0-4967-aa9a-85f0b096eed3"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2360), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("80c0e612-a0c5-4093-bea7-c05ffeadedd7"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4180), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("81af392c-25d5-43e8-8131-36029ca79382"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2120), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("81bbdb22-d666-42f3-b2d4-01eb337993f0"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2570), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("82112567-0f79-45d4-a7ef-56145451d595"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(930), null, 7, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("822c6878-a3fc-495e-b328-ca256ff9fe71"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3220), null, 5, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8284ebf0-f45a-429f-b9e1-90bd936fa1e0"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1190), null, 6, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("82921ead-8563-44eb-9f2a-48419c8cf522"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2340), null, 6, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8342d150-29a2-48c0-a9b6-658d1dcc3f0f"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2590), null, 5, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("835b3b01-73da-45f6-ba8e-49c8cfd46943"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4790), null, 7, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("846ba78a-f026-42e6-8c4e-a172f0ac2006"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6170), null, 5, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("85943014-5547-4bc7-9767-ad81ca4a3f08"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4480), null, 5, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("85cb2a37-21b8-4281-ad18-449bc195ff95"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1680), null, 6, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("862bc3f9-8eb2-44e3-a3e1-7b397f173698"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5600), null, 6, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("86326138-8528-4a3f-9859-7b419aac16a1"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6130), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8651bfb0-4e58-447b-8505-2e57c18f4224"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1040), null, 7, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("869dae2e-15df-4deb-83dc-54c913687314"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4450), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("88b7010b-119c-4595-91d6-2d050387b1aa"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3320), null, 5, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("892f1f83-25dc-4ecb-90b1-4ec1b8f269af"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3870), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("89476e59-2922-4a9b-ab94-b3579cad20cc"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1860), null, 5, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8a7f2390-1109-4bb6-8632-6275003248da"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5830), null, 5, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8b7e399f-9050-437c-82da-79752dee17d1"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3130), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8bf128b5-ad2a-4b69-aca6-a30bb0622c91"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1540), null, 7, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8c0de0e8-2bba-48af-951f-c8ff123cab41"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3670), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8cf05c84-3256-449f-9918-24b610127775"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2820), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8d70b22b-ab3a-499a-866d-d0617b08bddd"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3200), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8db60837-2e29-4309-b8bb-93dba477b6e2"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3550), null, 5, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8dd2aae1-2bfa-4a01-9429-23a48848585e"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6620), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8de85ead-4b7f-45d7-b520-7ae7ad1303be"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1180), null, 8, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8e1c2ca3-3f7e-4ef5-a24f-41463e38b5aa"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2490), null, 5, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8e58af4e-0306-42f6-b5a2-b66e7c276494"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1960), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8e80fbb6-9558-4e06-9467-34e3657e5f5c"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3800), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8fa64db0-32eb-415e-b9bb-9961f0398a60"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4370), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("91ed4323-83e4-40a0-8808-f8d1cc49b259"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3860), null, 5, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("926323dc-61fa-4239-8e5c-d4bb8ceb119d"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1990), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("927e9904-a5c9-4edf-b8d8-81a383fd5e84"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2370), null, 7, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("927fed27-5719-44ad-ac74-1c1ffa8af5a2"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4130), null, 7, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("93e87a7c-aad8-4c3e-916e-ff0179d10a02"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3660), null, 5, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("940935c3-8628-49a4-a686-19e1af3395ee"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2580), null, 7, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("94570f4a-90df-4e5b-9b84-18ca9a357f8d"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4640), null, 5, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9505154f-ec8e-42e0-b299-0272398c7624"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1320), null, 5, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("95404e45-656e-42d0-80c4-932e7e56906d"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2940), null, 6, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("95623ba3-1e1f-4050-8d41-a2efc143a8b9"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(950), null, 4, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("95b44741-5bf3-4f21-a845-59df350ac12c"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5470), null, 6, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("95bdce55-9204-4d47-9c5f-780df92009ed"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3100), null, 7, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("96204f5f-8e24-4ee5-9135-bf5915aa6dd8"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6030), null, 6, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("970c4d75-dac4-4114-a93d-46989099c3c9"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6010), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("97882b89-9a3a-440d-8f20-fcc64c06f24c"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3100), null, 6, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("97a69135-a8b3-417c-bfce-4427c5f9fe96"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(910), null, 4, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("983eb61c-6a98-42fb-9e78-9fc0e3e25a71"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5370), null, 7, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("98c9c095-b034-443c-a4a5-50f6f72d8da3"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3580), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("98ee877c-fab9-4288-ae7c-bbb02c8a71b3"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5100), null, 5, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9943340c-453d-42c2-ad58-b0ec22e47234"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3570), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("994d88e8-b102-481a-b6a2-a39eeb8adc65"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1670), null, 7, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("998129c7-8713-4264-a870-f25282214e6e"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5700), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9a7d7429-a4f3-4141-b944-6594498df69e"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1810), null, 4, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9a8544f5-0bb6-4392-a440-dada539ef3b3"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4270), null, 7, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9aa6a310-7d4a-4ac4-b18c-8db2217f8d68"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4720), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9bca52c4-e1c7-419b-b350-83c1cfbb63d7"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4620), null, 6, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9bfc062d-1283-4a1c-941f-ff40fcfaec3d"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6230), null, 6, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9c1312a9-8a76-495e-9351-78fc1391d0da"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6480), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9c8d9fa1-c581-4f73-94b4-85473ab28607"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2300), null, 5, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9d189afe-27dd-4fa3-9e39-ef65455a2d5b"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2240), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9d520261-4dd5-4c66-addc-5d0c724f3d62"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2760), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9dc23c49-f50f-4dea-845c-1b4f42c58fd2"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2050), null, 7, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9dc7c695-be27-4b10-a8cd-71d3b50d7f15"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2320), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9e196ba9-2db0-4d88-8905-9480689ab90e"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2390), null, 5, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9e9e8443-a9d9-4e1d-9025-3a67f7a4d656"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1250), null, 4, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9ecfaa45-a4bd-49fa-8e8d-4db07215a365"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1730), null, 4, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9ef2353c-38a5-4d22-b3ca-5757fea3f522"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4460), null, 7, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9f2d2883-b27d-4a71-af96-fd6c2ce3bb30"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2420), null, 7, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9f4344e0-1115-4a93-9594-a6773dde79b3"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1410), null, 8, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9f4b6e53-cb85-4a3c-89d6-23e8ae53d903"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1310), null, 6, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9f9991ca-f995-4409-ae2a-927749d2bf7c"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3280), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a023558e-ff69-4c55-9415-376ff567f361"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2060), null, 5, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a0a23f8f-6375-4f06-9ae5-6fbbea2d083e"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1550), null, 6, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a1053ef4-2687-4076-aae5-188f2225f3f5"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2880), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a121dea8-85e2-4bbf-b4db-e65ffa5fcfc3"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4940), null, 7, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a214285e-67e0-4c63-ab1b-cd2f53eb625e"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3060), null, 5, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a26542c2-26c1-45c8-bdf4-e151cc37c37c"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3810), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a2a1d11a-3681-4d62-9c6e-38acff12e0a7"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1900), null, 5, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a2b9a0a8-fb27-4ebf-ae31-a9d4afafb057"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6270), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a2e1d0c5-6d72-4bce-a88c-9ac0e9715bc6"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2560), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a3b5b7d5-354d-4281-a515-997e03629b39"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2290), null, 7, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a413a016-62c8-4150-bc0a-48f5ee3e085f"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(960), null, 8, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a4460cb7-ecfd-4060-9c75-fa93656df16a"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2600), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a4964f0d-0149-4493-9c32-91217209155c"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2330), null, 7, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a4c7d022-8a1b-4c29-aae6-ae9b7fe7067a"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1260), null, 7, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a557e554-ff3b-417d-be0c-7b92c8efeac0"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2380), null, 6, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a5c5ba7c-4b55-4ad2-afc5-23fb47ecf8c3"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4280), null, 5, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a5f40fe5-27cd-4e6e-8efa-1c8ecb9dbe6d"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5290), null, 7, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a68e5d6c-0890-433b-8caf-c78dbdda65fc"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6040), null, 5, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a764770d-0c60-4775-a614-80c3202fd3cc"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6330), null, 5, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a77a7b10-9456-410a-aaff-6eb023d75b39"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5240), null, 5, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a78206f8-15ee-4fa8-bf07-5fa7c593eba9"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1390), null, 6, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a78e05a6-0bb4-497e-ac9d-34f71912f76d"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4090), null, 5, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a7c7b2f1-94f1-459b-87ad-80ba588f5420"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5110), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a7e65990-7b8d-461d-ac13-949548e76342"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1980), null, 5, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a826f2d3-785d-4efc-a42d-c25648e8f023"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4850), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a8798812-d377-467b-a766-a6b36e8654b9"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1740), null, 8, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a9420d07-b584-43b3-b1c0-e6da57e6d7fb"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3850), null, 6, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("aa7b88ec-77da-419d-a129-69558828ce71"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3120), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("aac8d14b-a564-41fb-8312-eb86140156ce"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2860), null, 5, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ab40504d-6ba3-436f-85ed-8790036a44d3"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1700), null, 7, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ab67b6a5-4ff5-444a-a919-b7575b63b718"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2410), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ac406017-17eb-44e3-a110-1ed1f7f844cc"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6340), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ac5a1a16-0fe0-4b3c-a855-85f7018173c5"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6460), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("acf2dec8-6753-4504-877a-85d4c1db5cad"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5300), null, 6, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ae393ce7-6293-44e0-9b69-0528cbf31a4a"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2970), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ae7e5120-f36d-4e7f-8596-8fb8f9f3fb33"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3590), null, 7, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("aea826cf-d7bf-4284-b960-cc4f3e629be6"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3650), null, 6, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("af48149e-96e6-4fd5-8017-8a1502448360"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2840), null, 7, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("af6cae1a-ac0f-45a7-aa6a-0897a758cc07"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(940), null, 6, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("af7a45fd-0a0c-4c2c-96b4-5b228c26c88d"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2200), null, 5, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("afc8a6d1-e482-4a84-9b7c-85d3a802cb5a"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5530), null, 5, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("aff8b19f-87ca-47c4-8998-ceecae1cb494"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6080), null, 7, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b11cdc27-ec18-45f8-8b04-826b7fcb8a25"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1070), null, 8, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b2211f65-6149-4648-a00f-277884b6d4ce"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1180), null, 7, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b24989b7-8af4-4021-9b46-277eb3d4ea45"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5440), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b27ac28c-aca8-4e8c-b1de-aacb9fad34c7"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1090), null, 5, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b29ffb91-85df-4227-bf91-e0c7a62d4b12"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1530), null, 8, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b2cffbe4-abd1-4985-b1dc-dea3e7d06fa4"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3350), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b4dc4ed4-106c-400e-b2c1-4a7c64c15eb8"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1770), null, 4, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b4e5a6fe-1560-4d33-88df-e1e90836bc3d"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4740), null, 6, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b52801ce-e7b4-49ab-8ed2-1a27ef84199b"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2950), null, 5, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b5aaa57e-754f-4a7e-97bf-a7765bf2f86e"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5350), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b6028529-d482-4732-bdbc-ff6796cee6e2"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1330), null, 8, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b6e23428-91c7-4608-9441-2ab75611c23b"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1400), null, 4, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b6e8dd9a-e2b3-4e6d-a3a4-046cc6f0bf00"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3110), null, 5, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b71407c1-d132-4fcb-a1c9-828fe2ec7078"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2550), null, 6, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b72d22e0-0786-4a6f-8b74-2efa958dd02d"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(900), null, 6, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b73c35b2-cfae-427d-9fcb-b7a25eae65d9"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3460), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b75cae63-d778-435d-98d3-4ee53271cc8d"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4960), null, 5, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b7892341-2027-4f38-a332-b8418bd57fa3"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2820), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b8158000-7926-42af-b646-b0277d3b76ac"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2780), null, 6, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b86589fa-785b-471e-a04b-844473180100"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2920), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b86a0b15-17fd-434e-8d52-87d39c62058a"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5190), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b88ef8f9-9bb6-4d6d-b47d-ff7e8a36ceb2"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1970), null, 7, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b8fc0ac5-02fb-4985-b73a-066aeae2a996"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3790), null, 5, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b91007f4-438e-4ae0-82f8-1336c5d7b504"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2130), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b947b0eb-1ae1-44af-9412-df2f47097432"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1520), null, 4, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b9a52dfd-b2d9-4d84-be7b-f15d19ed621d"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1820), null, 7, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("babacc6b-9c1e-43ba-a90d-a68262ceeb91"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3720), null, 6, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("baf25fc7-131a-4df0-97da-f457fec850a4"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4990), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bb58d530-a6f1-4928-84b0-e6fd84f1c243"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4880), null, 6, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bb6e9898-7057-4d38-bfb0-5d8ab1739915"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1740), null, 7, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bba9e39b-e03b-4686-ad78-6215657acf46"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1550), null, 5, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bbd201a2-49cb-4492-9f9a-fce22bd34f4f"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5990), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bc1d40ba-8875-4636-931b-193b60e31358"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2060), null, 6, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bd251264-60aa-499c-b93c-4a1c4b546d91"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4300), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bd6498a2-02a2-43bf-b90d-f7e30006fc22"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4680), null, 5, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("be842eb8-d28b-44de-89fa-358d1354a28c"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3270), null, 6, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bea85b0b-f249-4c37-a7b4-5e20b75e122d"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4950), null, 6, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bf71045d-0ffa-4016-81c3-fbf407b0f986"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2850), null, 6, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c00a39e0-20f6-4d6e-b497-ba0aa4d39f96"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4010), null, 6, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c0c67716-52c7-49a6-a216-47b703dd5e16"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4530), null, 7, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c18cccd8-d747-4d50-8a9e-a189b96b94b2"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1760), null, 5, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c1b1f702-2685-461b-a794-de38327824d9"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4780), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c1de8435-7296-4f3a-a277-712ba4529ee1"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3290), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c27c7777-a550-4958-9d58-0b9aad1b7c88"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2460), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c2c41d2d-7fc8-4dea-8af6-1918ee9422e1"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2900), null, 5, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c2e71c6a-d500-4a02-8fdd-570c29fe85c1"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5390), null, 5, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c324cc3d-1499-4366-9bd6-46447bd57380"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1480), null, 5, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c3d18b72-a9c9-4fc1-844f-6929c7d838e1"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3510), null, 5, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c40aca90-ee97-4726-8234-738a24265744"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3030), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c40f9479-ada9-4d59-8d76-571974d9b827"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6370), null, 7, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c47149a4-7934-4019-b86f-3e70c53d09ec"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(970), null, 7, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c4e4d8cb-70fd-4dd3-bc7b-12a479132df0"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1090), null, 6, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c5299c00-23bb-4d97-b41b-55eda7a0e8b1"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4120), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c56b426c-4661-4f32-bfab-a98b50bdcf37"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1440), null, 4, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c6679299-6b99-427d-8e64-ec11c5d5baa8"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1810), null, 8, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c7ab8e1b-cda4-4791-81cd-bf0b28f6ce74"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5940), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c7c3ac26-bcc2-4af1-9dac-92f1bc998b6f"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1350), null, 6, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c7e650f0-9abb-4b71-8de3-e29b5705e50e"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2480), null, 7, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c8a10d8c-82fa-4a36-a825-5bc178101d94"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2030), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c9c78072-38b6-4352-a97e-80c73880fcf8"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2080), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ca9db0d6-aff2-4531-bca0-6581510af5e9"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3630), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cae9f198-d6f4-4b19-82ab-4534a226afb5"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2160), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cb89dc9c-6f4c-466a-8c4b-cbcff8a9b971"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2010), null, 7, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ccb7ba93-d058-41a0-aada-7469ce062b2f"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2700), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ccd4ba69-103b-4ef2-be5c-c672a8d30f5f"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4040), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ce4ee702-8c0c-42c9-a327-baeb554ad0a8"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3480), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ceccb26f-9b6e-49df-9c3e-2b2334f37323"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3620), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cef3d24c-74d5-4931-b7a1-57587e911278"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1220), null, 7, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d0901586-b120-4163-802e-d31e07cb5520"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3010), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d152610b-db14-439b-9385-97baf3062229"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1880), null, 8, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d154dd82-b5ef-44e4-a1c9-7befccaa7343"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4540), null, 6, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d167ce0d-198f-42e6-8235-f07230245fe3"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5930), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d17a4b62-780d-46f2-8c2a-41770769de6f"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5420), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d19cd437-8d0d-4060-a89a-80fad17704d6"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5460), null, 7, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d2869c55-a394-4c51-baf7-1c861ce48dce"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4110), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d2fb5c6c-0891-46b2-9d01-ba4501946eb0"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4470), null, 6, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d32a68d1-f44a-4870-a1c5-5b986c82cf7c"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5660), null, 6, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d32df224-26b1-46f8-8ea6-a51505a4c6c5"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4610), null, 7, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d3a37e3e-4cfd-4da6-8dee-f2bb2fe16a46"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2750), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d45dfd83-265a-4eb5-ae80-64cf76e67820"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1780), null, 7, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d585d145-14dc-4c6c-bbcd-c4a72778c62f"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4170), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d5a7f999-6d9c-43c8-a31c-a38698553744"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6590), null, 5, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d73f3539-aacd-49bc-bd65-593b0078a17a"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5610), null, 5, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d748c7ce-be1b-4310-89c4-382741a487b7"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4660), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d7c6e27d-afaa-4d39-8445-4737910d364e"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6430), null, 7, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d7ece77c-a2f2-4455-94fe-260a0c52e502"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(880), null, 8, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d85a33b9-8b5a-4c82-ad17-43e2d052987b"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1030), null, 4, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d8df1037-160a-4e99-a9be-c2de53cfcaec"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3740), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d8f6367d-20ec-418b-bc03-840c315171a5"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3180), null, 5, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d9110b5c-ef19-48da-a74f-9f76c334e4c7"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2710), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d9269703-7b70-4924-b971-ce43d39e452c"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3900), null, 7, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d995e62b-1eee-418a-a2b3-e929158a2be7"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5150), null, 7, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d9b87041-6a66-498e-a688-a3a6ac05e186"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1860), null, 8, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("da2c632a-646c-4ab5-9037-45aaffc74d24"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6020), null, 7, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("da9702bc-2bf7-438c-b547-d03b3afe5176"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3280), null, 5, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("dafd30be-acae-4b1c-a8fc-98fc5f0ef26b"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6320), null, 6, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("db09953d-a00f-4ec1-a424-d75fcb63e4be"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3450), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("db5c6923-867d-4ffc-b884-cebce6b3dc45"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3950), null, 7, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("dcc5ef5b-0c26-4f4f-8015-63e717946eb0"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2520), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("dd526e75-800a-4b59-8e05-1550829ae071"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3890), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("deb26d7a-eb48-4946-9e05-e2b9c684a968"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4080), null, 6, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("df083746-598d-47c7-921f-f44ad91bdd5f"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(880), null, 4, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("df868a6f-f159-470c-ab8c-857fdfb470ca"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1580), null, 7, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("dfa76954-31ae-4af9-aede-6be2a45287a1"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4860), null, 7, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("dfc3e56c-288b-436f-8354-bcafd246bcac"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2110), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("dfca5228-cf3f-4473-882a-e33535b23cd1"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1520), null, 5, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e04daa4f-90b8-4140-a5f0-cdd7f99b2717"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4760), null, 5, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e0c8efeb-2bae-4181-b66b-f4f96ecae59c"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3490), null, 7, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e0d9b763-f9ca-454f-adcb-9d11ef6defe2"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1440), null, 5, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e14404a5-56f5-4f79-9326-35b145eca9dd"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3160), null, 7, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e1db45b9-5bbc-42b2-8230-7b83c1a05fd2"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5070), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e1f6fc52-0b67-48de-94eb-a1c913a6b963"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2790), null, 5, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e2123bb1-d907-42b0-985c-24d16ae52e6c"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3380), null, 5, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e287bf97-1a6d-410d-8fff-00af23b43d2b"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3330), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e2f9a594-5b51-485e-8f8c-09fa136f947c"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5900), null, 7, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e308981c-925a-48c1-9c48-73a8f2aa07cf"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3250), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e3329152-b6fe-4db3-aa26-4190d792bf51"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(980), null, 5, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e3a6ef9a-ee20-4ac7-9102-effd7d7e3d79"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1910), null, 4, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e48e37f5-9f99-4c3f-949e-25df5b13f57c"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5740), null, 6, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e4f8063c-019f-45a1-b7aa-a18feb72f101"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1100), null, 8, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e5949a5d-21fd-4b9f-86cb-1e6e7af22f20"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5780), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e5f22d0d-0cf7-4bbf-bd22-51bae968685e"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1430), null, 6, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e6aef077-6d1d-48ef-aa8b-d552eb374a57"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6670), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e6bb87e8-d1e8-4a1e-8480-78ef2ca4955a"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5870), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e75c5e58-ee5b-4a99-b2eb-42ed2e19735e"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4770), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e76b5954-79ec-4f71-915b-d21628c4ae02"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3310), null, 6, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e7926216-1c63-4434-bfe8-d297db911984"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6150), null, 7, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e79299f0-7b4d-4176-aa49-17c8174f87b5"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5970), null, 5, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e7d6d54e-0089-46c2-a58e-3d13191d432b"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3400), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e805aad1-a6b9-4b2d-83bd-f50d79fca711"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1940), null, 5, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e836d241-e28f-457e-8bcd-27ba01fb502f"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1980), null, 6, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e84c6961-85a4-4a85-bbb4-c89429390813"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3830), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e851ede0-1763-44a5-9861-153ae53a5b9e"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5140), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e86ad2e3-23e1-4d9f-9a0d-bcc1360f8c26"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6510), null, 5, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e88874e6-c6e0-4b9f-b243-1f7dbcddb0fd"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5260), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ea0f139d-bf4f-4163-a103-6a78e3a9c688"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2650), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ea9b2246-7e73-4e7d-832a-78f78de45f76"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2260), null, 5, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("eac31542-15bb-45ad-99c6-b5a5ba75e188"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2150), null, 5, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("eadef418-59c3-4d6e-bf3c-b2c22b56d5a0"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6390), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("eb703812-31ae-417a-ba0a-64d4dcb1e364"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1460), null, 7, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ebfd3e10-a527-43fd-82be-60e65746108f"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6650), null, 6, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ecd6fffb-e179-4a0a-95f4-5585b7048612"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3970), null, 5, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ed249a36-68c1-4da5-8e83-9f7ac0e29bde"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5790), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ee9edf07-7d97-4b70-9491-41239349136e"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3020), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("eee48cad-539f-4b37-b72b-7ab461c5b5bc"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5020), null, 7, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ef22eaf9-069d-4d83-bc3c-6c47d078057d"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1710), null, 6, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ef3f8f70-64c9-4509-8bc1-ee7f887f89a4"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5690), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("eff13d5e-1fb2-42e2-84bd-a215876f3237"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4820), null, 5, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f0686e56-dba8-4488-be1c-3dd757f52c8f"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4430), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f0fad18e-722f-43de-abc2-cb4a1f218549"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6420), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f1dd2ce3-d06a-44c5-8b27-b316ea961d15"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4590), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f20bbcc6-dec3-4ee2-9f97-a73fbc12eb30"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2960), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f4c34b6a-f986-46a5-b607-f65b102191d7"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4260), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f5fa06f3-45d2-4e7f-a218-5a86ec55ee3a"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5960), null, 7, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f63c1816-a317-43d7-96fe-9af3f255a0c4"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5430), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f6b523bc-18f1-4f5c-8475-5013778286de"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5030), null, 6, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f6d75106-0ca4-4fbb-aa3d-701637559a2d"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1320), null, 4, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f7ae2060-08d8-4f95-824f-6ab0e0f36edb"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3080), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f7bff944-9116-4b3f-a280-17493b9993c8"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3150), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f83f7261-2950-4f40-a483-1515175eccde"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3440), null, 5, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f8a4a7e0-4e47-4901-9429-4e173c0a1584"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1230), null, 6, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f8f26a33-631e-488d-9cb9-1b7a06710e1b"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5380), null, 6, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f99d5cb5-380c-4cb5-84c3-28fedb829403"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5750), null, 5, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f9a93ee2-6d72-4ece-be47-a1cbce31b6bb"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5120), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fadb689a-8fb8-4ee5-a7f0-0ee5f061d6db"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4730), null, 7, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("faf936cc-2f9c-471d-b2e6-369ee50141c2"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2180), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fb97e00c-7e41-4235-922e-1a5bda900d77"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2220), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fb9edd64-7b9c-41aa-8ed2-5799da8c1bb7"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4890), null, 5, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fba7b4d5-6cc3-42c3-b05f-780a23bca690"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2440), null, 5, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fbadc1c4-86aa-4717-8706-bb3b4a09e5c7"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(970), null, 6, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fbb1e4f9-5595-4c84-993d-c40305c9ce7f"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5330), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fc2408a8-9053-4080-8c2c-6c3d5194ad30"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(6450), null, 5, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fc717232-4b3a-4670-a6ec-6b6de86a7961"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2890), null, 7, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fc7671fd-85ea-43cb-8e27-06daba326af0"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1590), null, 5, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fc9270c0-76e8-4c79-8dfa-3b994f1d41e5"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1120), null, 6, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fca66928-b199-4733-b4f0-2a4fb69edced"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2670), null, 7, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fd054685-88c4-49b9-8de4-8b56da1513a1"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1920), null, 8, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fde25064-9e4f-4df6-86ed-345a4d067c3e"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3360), null, 7, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fe2ee7d0-57f6-4268-b313-55c922bae089"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2280), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fe477228-9fa6-4f08-9833-08d0431802f1"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(1560), null, 4, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fe802f22-95e4-4501-ac81-ec5f65f68294"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(2490), null, 6, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fe88dfc1-9f34-4909-bcd8-3f20c96ee545"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5200), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("febd7177-e1f1-4e18-b028-09b910fc1f39"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3540), null, 7, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ff1fcb34-9154-4c50-a4f4-6be90612b0f0"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(5570), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ffb8b3d4-b03d-4fcb-b519-6a1e80686b64"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(4060), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ffc3a289-6c98-47eb-9e29-3d32f2530971"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 25, 11, 5, 18, 159, DateTimeKind.Utc).AddTicks(3530), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advisors_DepartmentId",
                table: "Advisors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ceremonies_StudentAffairId",
                table: "Ceremonies",
                column: "StudentAffairId");

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyUser_UserId",
                table: "CeremonyUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FacultyId",
                table: "Courses",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyId",
                table: "Departments",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAuthenticators_UserId",
                table: "EmailAuthenticators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyDeansOffices_StudentAffairId",
                table: "FacultyDeansOffices",
                column: "StudentAffairId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAttachments_TranscriptId",
                table: "FileAttachments",
                column: "TranscriptId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GraduationLists_AdvisorId",
                table: "GraduationLists",
                column: "AdvisorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GraduationProcesses_GraduationListId",
                table: "GraduationProcesses",
                column: "GraduationListId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduationProcesses_StudentId",
                table: "GraduationProcesses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AdvisorId",
                table: "Messages",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_OtpAuthenticators_UserId",
                table: "OtpAuthenticators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rectorates_StudentAffairId",
                table: "Rectorates",
                column: "StudentAffairId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RequiredCourseListCourses_CourseId",
                table: "RequiredCourseListCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_RequiredCourseListCourses_RequiredCourseListId",
                table: "RequiredCourseListCourses",
                column: "RequiredCourseListId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DepartmentId",
                table: "Staffs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AssignedAdvisorId",
                table: "Students",
                column: "AssignedAdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RequiredCourseListId",
                table: "Students",
                column: "RequiredCourseListId");

            migrationBuilder.CreateIndex(
                name: "IX_TakenCourses_CourseId",
                table: "TakenCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TakenCourses_StudentId",
                table: "TakenCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TopStudentLists_RectorateStaffId",
                table: "TopStudentLists",
                column: "RectorateStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_TopStudentLists_StudentAffairsStaffId",
                table: "TopStudentLists",
                column: "StudentAffairsStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_TopStudentListStudents_TopStudentListId",
                table: "TopStudentListStudents",
                column: "TopStudentListId");

            migrationBuilder.CreateIndex(
                name: "IX_Transcripts_StudentId",
                table: "Transcripts",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AdvisorProfileId",
                table: "Users",
                column: "AdvisorProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advisors_Users_Id",
                table: "Advisors",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advisors_Departments_DepartmentId",
                table: "Advisors");

            migrationBuilder.DropForeignKey(
                name: "FK_Advisors_Users_Id",
                table: "Advisors");

            migrationBuilder.DropTable(
                name: "CeremonyUser");

            migrationBuilder.DropTable(
                name: "EmailAuthenticators");

            migrationBuilder.DropTable(
                name: "FileAttachments");

            migrationBuilder.DropTable(
                name: "GraduationProcesses");

            migrationBuilder.DropTable(
                name: "MailLogs");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "OtpAuthenticators");

            migrationBuilder.DropTable(
                name: "Rectorates");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "RequiredCourseListCourses");

            migrationBuilder.DropTable(
                name: "TakenCourses");

            migrationBuilder.DropTable(
                name: "TopStudentListStudents");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Ceremonies");

            migrationBuilder.DropTable(
                name: "Transcripts");

            migrationBuilder.DropTable(
                name: "GraduationLists");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "TopStudentLists");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "RequiredCourseLists");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "FacultyDeansOffices");

            migrationBuilder.DropTable(
                name: "StudentAffairs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Advisors");
        }
    }
}
