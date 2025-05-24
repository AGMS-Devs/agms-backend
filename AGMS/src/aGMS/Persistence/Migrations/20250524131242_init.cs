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
                        onDelete: ReferentialAction.Cascade);
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
                    CeremonyId = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Users_Ceremonies_CeremonyId",
                        column: x => x.CeremonyId,
                        principalTable: "Ceremonies",
                        principalColumn: "Id");
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
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(5140), null, "Elektrik-Elektronik Mühendisliği bölümü öğrencileri için gerekli zorunlu dersler", "Elektrik-Elektronik Mühendisliği Zorunlu Dersler", null },
                    { new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(5150), null, "Makine Mühendisliği bölümü öğrencileri için gerekli zorunlu dersler", "Makine Mühendisliği Zorunlu Dersler", null },
                    { new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(5150), null, "Kimya bölümü öğrencileri için gerekli zorunlu dersler", "Kimya Bölümü Zorunlu Dersler", null },
                    { new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(5140), null, "Bilgisayar Mühendisliği bölümü öğrencileri için gerekli zorunlu dersler", "Bilgisayar Mühendisliği Zorunlu Dersler", null },
                    { new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(5150), null, "Matematik bölümü öğrencileri için gerekli zorunlu dersler", "Matematik Bölümü Zorunlu Dersler", null },
                    { new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(5150), null, "Fizik bölümü öğrencileri için gerekli zorunlu dersler", "Fizik Bölümü Zorunlu Dersler", null }
                });

            migrationBuilder.InsertData(
                table: "StudentAffairs",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OfficeName", "UpdatedDate" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(5210), null, "İYTE Öğrenci İşleri Daire Başkanlığı", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AdvisorProfileId", "AuthenticatorType", "CeremonyId", "CreatedDate", "DeletedDate", "Email", "IsActive", "Name", "PasswordHash", "PasswordSalt", "PhoneNumber", "Surname", "UpdatedDate", "UserType" },
                values: new object[,]
                {
                    { new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5080), null, "20200016@std.iyte.edu.tr", true, "Serkan", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "7788990011", "Bozkurt", null, 0 },
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5150), null, "advisor1@iyte.edu.tr", true, "Dr. Mehmet", new byte[] { 50, 81, 106, 127, 255, 235, 91, 143, 208, 178, 177, 222, 242, 33, 101, 99, 143, 6, 183, 211, 122, 191, 190, 53, 255, 158, 138, 158, 186, 5, 187, 222, 201, 252, 11, 152, 92, 81, 142, 36, 4, 33, 50, 72, 243, 234, 20, 179, 32, 202, 98, 182, 122, 165, 165, 202, 251, 128, 237, 164, 239, 191, 39, 38 }, new byte[] { 1, 6, 33, 58, 124, 109, 147, 33, 172, 75, 251, 67, 195, 193, 154, 43, 70, 66, 230, 152, 4, 51, 171, 15, 242, 97, 85, 38, 106, 31, 234, 192, 159, 43, 75, 42, 166, 255, 202, 26, 230, 70, 208, 16, 193, 88, 245, 118, 17, 84, 201, 72, 18, 36, 102, 225, 77, 200, 65, 80, 197, 237, 12, 174, 86, 155, 113, 241, 123, 76, 193, 232, 6, 232, 82, 42, 193, 124, 70, 218, 239, 209, 159, 148, 83, 87, 6, 208, 232, 149, 160, 227, 19, 197, 126, 5, 155, 173, 201, 182, 112, 107, 24, 99, 72, 34, 175, 104, 58, 153, 114, 237, 138, 117, 63, 110, 212, 86, 83, 234, 153, 140, 154, 239, 254, 250, 152, 103 }, "4445556677", "Yılmaz", null, 2 },
                    { new Guid("11111111-1111-1111-1111-11111111111a"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(4990), null, "admin@iyte.edu.tr", true, "System", new byte[] { 217, 180, 137, 85, 164, 103, 223, 228, 113, 204, 128, 127, 119, 7, 45, 61, 1, 78, 37, 3, 230, 101, 30, 194, 136, 140, 100, 87, 131, 148, 106, 94, 94, 2, 246, 254, 113, 108, 246, 183, 78, 108, 97, 38, 177, 158, 50, 133, 77, 100, 63, 141, 87, 153, 205, 144, 74, 137, 50, 68, 187, 162, 242, 197 }, new byte[] { 82, 206, 115, 114, 16, 192, 146, 252, 32, 177, 176, 211, 53, 214, 214, 172, 173, 123, 31, 119, 61, 145, 50, 184, 75, 89, 80, 50, 208, 160, 234, 100, 88, 202, 131, 203, 206, 18, 213, 50, 253, 187, 0, 55, 180, 42, 163, 190, 149, 159, 200, 46, 47, 199, 74, 129, 156, 58, 227, 68, 140, 42, 107, 33, 76, 152, 11, 54, 84, 212, 227, 203, 226, 149, 148, 126, 19, 217, 38, 231, 106, 179, 215, 65, 127, 26, 248, 185, 151, 54, 119, 202, 173, 25, 34, 165, 167, 217, 150, 109, 113, 89, 61, 208, 155, 161, 240, 17, 249, 113, 40, 249, 169, 131, 136, 160, 251, 103, 132, 89, 7, 207, 84, 219, 199, 175, 108, 143 }, "1234567890", "Admin", null, 3 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5150), null, "advisor2@iyte.edu.tr", true, "Dr. Ayşe", new byte[] { 50, 81, 106, 127, 255, 235, 91, 143, 208, 178, 177, 222, 242, 33, 101, 99, 143, 6, 183, 211, 122, 191, 190, 53, 255, 158, 138, 158, 186, 5, 187, 222, 201, 252, 11, 152, 92, 81, 142, 36, 4, 33, 50, 72, 243, 234, 20, 179, 32, 202, 98, 182, 122, 165, 165, 202, 251, 128, 237, 164, 239, 191, 39, 38 }, new byte[] { 1, 6, 33, 58, 124, 109, 147, 33, 172, 75, 251, 67, 195, 193, 154, 43, 70, 66, 230, 152, 4, 51, 171, 15, 242, 97, 85, 38, 106, 31, 234, 192, 159, 43, 75, 42, 166, 255, 202, 26, 230, 70, 208, 16, 193, 88, 245, 118, 17, 84, 201, 72, 18, 36, 102, 225, 77, 200, 65, 80, 197, 237, 12, 174, 86, 155, 113, 241, 123, 76, 193, 232, 6, 232, 82, 42, 193, 124, 70, 218, 239, 209, 159, 148, 83, 87, 6, 208, 232, 149, 160, 227, 19, 197, 126, 5, 155, 173, 201, 182, 112, 107, 24, 99, 72, 34, 175, 104, 58, 153, 114, 237, 138, 117, 63, 110, 212, 86, 83, 234, 153, 140, 154, 239, 254, 250, 152, 103 }, "5556667788", "Demir", null, 2 },
                    { new Guid("22222222-2222-2222-2222-22222222222a"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5030), null, "20220001@std.iyte.edu.tr", true, "Ali", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "2345678901", "Veli", null, 0 },
                    { new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5070), null, "20220012@std.iyte.edu.tr", true, "Mert", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "3344556677", "Doğan", null, 0 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5160), null, "advisor3@iyte.edu.tr", true, "Dr. Hasan", new byte[] { 50, 81, 106, 127, 255, 235, 91, 143, 208, 178, 177, 222, 242, 33, 101, 99, 143, 6, 183, 211, 122, 191, 190, 53, 255, 158, 138, 158, 186, 5, 187, 222, 201, 252, 11, 152, 92, 81, 142, 36, 4, 33, 50, 72, 243, 234, 20, 179, 32, 202, 98, 182, 122, 165, 165, 202, 251, 128, 237, 164, 239, 191, 39, 38 }, new byte[] { 1, 6, 33, 58, 124, 109, 147, 33, 172, 75, 251, 67, 195, 193, 154, 43, 70, 66, 230, 152, 4, 51, 171, 15, 242, 97, 85, 38, 106, 31, 234, 192, 159, 43, 75, 42, 166, 255, 202, 26, 230, 70, 208, 16, 193, 88, 245, 118, 17, 84, 201, 72, 18, 36, 102, 225, 77, 200, 65, 80, 197, 237, 12, 174, 86, 155, 113, 241, 123, 76, 193, 232, 6, 232, 82, 42, 193, 124, 70, 218, 239, 209, 159, 148, 83, 87, 6, 208, 232, 149, 160, 227, 19, 197, 126, 5, 155, 173, 201, 182, 112, 107, 24, 99, 72, 34, 175, 104, 58, 153, 114, 237, 138, 117, 63, 110, 212, 86, 83, 234, 153, 140, 154, 239, 254, 250, 152, 103 }, "6667778899", "Özkan", null, 2 },
                    { new Guid("33333333-3333-3333-3333-33333333333a"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5130), null, "studentaffairs@iyte.edu.tr", true, "Hafize", new byte[] { 194, 27, 176, 82, 134, 219, 40, 12, 14, 236, 34, 117, 188, 87, 145, 114, 180, 77, 46, 27, 99, 129, 247, 125, 54, 255, 111, 21, 6, 169, 148, 97, 213, 230, 227, 76, 34, 7, 101, 229, 46, 129, 71, 246, 220, 161, 161, 89, 126, 55, 8, 93, 84, 77, 164, 37, 114, 99, 176, 76, 122, 76, 88, 181 }, new byte[] { 23, 43, 163, 16, 215, 183, 200, 234, 177, 75, 235, 113, 40, 195, 184, 139, 50, 87, 221, 245, 248, 221, 199, 147, 55, 71, 154, 205, 234, 196, 47, 147, 56, 132, 105, 180, 141, 91, 229, 129, 197, 227, 222, 54, 166, 59, 167, 107, 87, 218, 168, 156, 116, 0, 220, 154, 70, 112, 97, 195, 107, 14, 148, 32, 212, 200, 180, 112, 58, 174, 74, 1, 139, 185, 4, 65, 122, 83, 155, 166, 45, 214, 234, 128, 189, 121, 130, 122, 126, 140, 69, 122, 178, 184, 43, 121, 9, 104, 118, 224, 37, 159, 226, 228, 31, 23, 145, 42, 0, 146, 239, 88, 167, 226, 245, 216, 255, 131, 52, 51, 161, 78, 34, 76, 13, 113, 23, 101 }, "3334445566", "Kaya", null, 1 },
                    { new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5030), null, "20220002@std.iyte.edu.tr", true, "Ayşe", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "3456789012", "Yılmaz", null, 0 },
                    { new Guid("44444444-4444-4444-4444-444444444444"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5160), null, "advisor4@iyte.edu.tr", true, "Dr. Fatma", new byte[] { 50, 81, 106, 127, 255, 235, 91, 143, 208, 178, 177, 222, 242, 33, 101, 99, 143, 6, 183, 211, 122, 191, 190, 53, 255, 158, 138, 158, 186, 5, 187, 222, 201, 252, 11, 152, 92, 81, 142, 36, 4, 33, 50, 72, 243, 234, 20, 179, 32, 202, 98, 182, 122, 165, 165, 202, 251, 128, 237, 164, 239, 191, 39, 38 }, new byte[] { 1, 6, 33, 58, 124, 109, 147, 33, 172, 75, 251, 67, 195, 193, 154, 43, 70, 66, 230, 152, 4, 51, 171, 15, 242, 97, 85, 38, 106, 31, 234, 192, 159, 43, 75, 42, 166, 255, 202, 26, 230, 70, 208, 16, 193, 88, 245, 118, 17, 84, 201, 72, 18, 36, 102, 225, 77, 200, 65, 80, 197, 237, 12, 174, 86, 155, 113, 241, 123, 76, 193, 232, 6, 232, 82, 42, 193, 124, 70, 218, 239, 209, 159, 148, 83, 87, 6, 208, 232, 149, 160, 227, 19, 197, 126, 5, 155, 173, 201, 182, 112, 107, 24, 99, 72, 34, 175, 104, 58, 153, 114, 237, 138, 117, 63, 110, 212, 86, 83, 234, 153, 140, 154, 239, 254, 250, 152, 103 }, "7778889900", "Şen", null, 2 },
                    { new Guid("55555555-5555-5555-5555-555555555555"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5160), null, "advisor5@iyte.edu.tr", true, "Dr. Ali", new byte[] { 50, 81, 106, 127, 255, 235, 91, 143, 208, 178, 177, 222, 242, 33, 101, 99, 143, 6, 183, 211, 122, 191, 190, 53, 255, 158, 138, 158, 186, 5, 187, 222, 201, 252, 11, 152, 92, 81, 142, 36, 4, 33, 50, 72, 243, 234, 20, 179, 32, 202, 98, 182, 122, 165, 165, 202, 251, 128, 237, 164, 239, 191, 39, 38 }, new byte[] { 1, 6, 33, 58, 124, 109, 147, 33, 172, 75, 251, 67, 195, 193, 154, 43, 70, 66, 230, 152, 4, 51, 171, 15, 242, 97, 85, 38, 106, 31, 234, 192, 159, 43, 75, 42, 166, 255, 202, 26, 230, 70, 208, 16, 193, 88, 245, 118, 17, 84, 201, 72, 18, 36, 102, 225, 77, 200, 65, 80, 197, 237, 12, 174, 86, 155, 113, 241, 123, 76, 193, 232, 6, 232, 82, 42, 193, 124, 70, 218, 239, 209, 159, 148, 83, 87, 6, 208, 232, 149, 160, 227, 19, 197, 126, 5, 155, 173, 201, 182, 112, 107, 24, 99, 72, 34, 175, 104, 58, 153, 114, 237, 138, 117, 63, 110, 212, 86, 83, 234, 153, 140, 154, 239, 254, 250, 152, 103 }, "8889990011", "Güneş", null, 2 },
                    { new Guid("55555555-5555-5555-5555-55555555555a"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5190), null, "comp.deptsecretary@iyte.edu.tr", true, "Emine", new byte[] { 116, 41, 30, 60, 5, 110, 254, 2, 129, 33, 53, 241, 13, 149, 42, 204, 53, 142, 50, 186, 159, 107, 24, 86, 118, 74, 218, 36, 132, 184, 141, 123, 5, 40, 22, 195, 209, 228, 229, 86, 173, 247, 146, 157, 152, 63, 115, 107, 190, 67, 101, 32, 114, 155, 67, 10, 145, 184, 88, 213, 21, 99, 235, 196 }, new byte[] { 170, 88, 167, 56, 165, 135, 212, 131, 226, 35, 251, 25, 101, 148, 19, 114, 171, 8, 46, 183, 151, 141, 114, 54, 179, 253, 167, 210, 227, 83, 125, 80, 175, 198, 173, 216, 197, 142, 51, 231, 145, 41, 8, 204, 14, 112, 251, 153, 157, 133, 168, 5, 175, 171, 24, 207, 83, 129, 145, 0, 47, 155, 109, 114, 63, 36, 172, 90, 169, 1, 151, 77, 232, 70, 226, 145, 151, 188, 136, 156, 183, 89, 63, 125, 171, 19, 177, 106, 157, 186, 88, 199, 59, 191, 237, 157, 81, 103, 40, 62, 26, 111, 60, 182, 34, 0, 88, 145, 165, 72, 103, 69, 203, 134, 56, 100, 169, 60, 26, 216, 104, 190, 47, 118, 124, 70, 82, 222 }, "1111223344", "Arslan", null, 1 },
                    { new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5070), null, "20200013@std.iyte.edu.tr", true, "İrem", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "4455667788", "Kılıç", null, 0 },
                    { new Guid("66666666-6666-6666-6666-666666666666"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5170), null, "advisor6@iyte.edu.tr", true, "Dr. Zeynep", new byte[] { 50, 81, 106, 127, 255, 235, 91, 143, 208, 178, 177, 222, 242, 33, 101, 99, 143, 6, 183, 211, 122, 191, 190, 53, 255, 158, 138, 158, 186, 5, 187, 222, 201, 252, 11, 152, 92, 81, 142, 36, 4, 33, 50, 72, 243, 234, 20, 179, 32, 202, 98, 182, 122, 165, 165, 202, 251, 128, 237, 164, 239, 191, 39, 38 }, new byte[] { 1, 6, 33, 58, 124, 109, 147, 33, 172, 75, 251, 67, 195, 193, 154, 43, 70, 66, 230, 152, 4, 51, 171, 15, 242, 97, 85, 38, 106, 31, 234, 192, 159, 43, 75, 42, 166, 255, 202, 26, 230, 70, 208, 16, 193, 88, 245, 118, 17, 84, 201, 72, 18, 36, 102, 225, 77, 200, 65, 80, 197, 237, 12, 174, 86, 155, 113, 241, 123, 76, 193, 232, 6, 232, 82, 42, 193, 124, 70, 218, 239, 209, 159, 148, 83, 87, 6, 208, 232, 149, 160, 227, 19, 197, 126, 5, 155, 173, 201, 182, 112, 107, 24, 99, 72, 34, 175, 104, 58, 153, 114, 237, 138, 117, 63, 110, 212, 86, 83, 234, 153, 140, 154, 239, 254, 250, 152, 103 }, "9990001122", "Acar", null, 2 },
                    { new Guid("66666666-6666-6666-6666-66666666666a"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5210), null, "deansoffice@iyte.edu.tr", true, "Murat", new byte[] { 110, 97, 153, 87, 144, 52, 143, 228, 50, 51, 242, 209, 2, 48, 237, 248, 125, 71, 72, 92, 43, 38, 140, 46, 6, 134, 72, 173, 48, 209, 186, 69, 202, 76, 185, 141, 103, 6, 153, 146, 232, 135, 83, 110, 213, 235, 111, 156, 91, 19, 52, 214, 173, 99, 60, 128, 162, 2, 179, 5, 88, 43, 165, 199 }, new byte[] { 30, 252, 23, 80, 25, 58, 177, 158, 38, 186, 89, 31, 99, 119, 173, 95, 73, 109, 25, 143, 168, 118, 130, 38, 121, 65, 30, 41, 122, 72, 58, 220, 144, 98, 222, 39, 118, 100, 239, 185, 187, 215, 176, 95, 165, 148, 152, 202, 195, 243, 252, 31, 187, 16, 170, 173, 113, 120, 22, 228, 82, 252, 182, 10, 71, 43, 23, 94, 3, 72, 52, 146, 174, 136, 204, 3, 144, 44, 50, 219, 241, 96, 239, 66, 118, 28, 152, 22, 254, 3, 41, 116, 12, 87, 233, 131, 251, 0, 50, 231, 216, 105, 121, 85, 128, 182, 215, 133, 47, 78, 236, 18, 183, 43, 237, 108, 101, 144, 52, 200, 216, 210, 228, 156, 48, 43, 209, 140 }, "6667778899", "Kurt", null, 1 },
                    { new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5080), null, "20220015@std.iyte.edu.tr", true, "Pınar", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "6677889900", "Altın", null, 0 },
                    { new Guid("77777777-7777-7777-7777-77777777777a"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5220), null, "science.deansoffice@iyte.edu.tr", true, "Ayşe", new byte[] { 110, 97, 153, 87, 144, 52, 143, 228, 50, 51, 242, 209, 2, 48, 237, 248, 125, 71, 72, 92, 43, 38, 140, 46, 6, 134, 72, 173, 48, 209, 186, 69, 202, 76, 185, 141, 103, 6, 153, 146, 232, 135, 83, 110, 213, 235, 111, 156, 91, 19, 52, 214, 173, 99, 60, 128, 162, 2, 179, 5, 88, 43, 165, 199 }, new byte[] { 30, 252, 23, 80, 25, 58, 177, 158, 38, 186, 89, 31, 99, 119, 173, 95, 73, 109, 25, 143, 168, 118, 130, 38, 121, 65, 30, 41, 122, 72, 58, 220, 144, 98, 222, 39, 118, 100, 239, 185, 187, 215, 176, 95, 165, 148, 152, 202, 195, 243, 252, 31, 187, 16, 170, 173, 113, 120, 22, 228, 82, 252, 182, 10, 71, 43, 23, 94, 3, 72, 52, 146, 174, 136, 204, 3, 144, 44, 50, 219, 241, 96, 239, 66, 118, 28, 152, 22, 254, 3, 41, 116, 12, 87, 233, 131, 251, 0, 50, 231, 216, 105, 121, 85, 128, 182, 215, 133, 47, 78, 236, 18, 183, 43, 237, 108, 101, 144, 52, 200, 216, 210, 228, 156, 48, 43, 209, 140 }, "7778889900", "Yılmaz", null, 1 },
                    { new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5070), null, "20210014@std.iyte.edu.tr", true, "Onur", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "5566778899", "Özkan", null, 0 },
                    { new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5060), null, "20220010@std.iyte.edu.tr", true, "Deniz", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "1122334455", "Şahin", null, 0 },
                    { new Guid("88888888-8888-8888-8888-88888888888a"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5240), null, "rectorate@iyte.edu.tr", true, "Mahmut", new byte[] { 94, 160, 12, 52, 231, 83, 60, 200, 22, 92, 182, 10, 223, 142, 222, 61, 156, 188, 99, 107, 169, 217, 41, 175, 167, 71, 248, 164, 21, 110, 65, 234, 228, 148, 146, 239, 100, 19, 194, 138, 79, 13, 8, 115, 247, 228, 118, 11, 49, 1, 156, 247, 174, 196, 201, 31, 36, 55, 218, 57, 123, 9, 8, 194 }, new byte[] { 143, 1, 38, 240, 37, 139, 89, 22, 187, 151, 54, 53, 68, 53, 198, 153, 96, 70, 152, 158, 129, 107, 74, 128, 2, 172, 141, 189, 214, 49, 128, 143, 15, 65, 186, 55, 249, 10, 206, 195, 214, 77, 230, 133, 230, 154, 20, 22, 246, 216, 208, 43, 99, 129, 53, 111, 3, 112, 177, 196, 151, 210, 199, 29, 244, 234, 109, 22, 90, 86, 31, 236, 185, 50, 227, 221, 204, 94, 19, 109, 34, 38, 132, 134, 225, 243, 137, 210, 30, 172, 223, 110, 29, 106, 171, 141, 103, 159, 1, 241, 158, 0, 86, 44, 212, 176, 165, 41, 116, 207, 210, 17, 82, 162, 20, 22, 21, 79, 131, 148, 45, 187, 33, 182, 227, 10, 27, 165 }, "8889990011", "Özdemir", null, 1 },
                    { new Guid("89e73bfc-718e-49d4-92af-1c576d281cf4"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5190), null, "physics.deptsecretary@iyte.edu.tr", true, "Ayşe", new byte[] { 116, 41, 30, 60, 5, 110, 254, 2, 129, 33, 53, 241, 13, 149, 42, 204, 53, 142, 50, 186, 159, 107, 24, 86, 118, 74, 218, 36, 132, 184, 141, 123, 5, 40, 22, 195, 209, 228, 229, 86, 173, 247, 146, 157, 152, 63, 115, 107, 190, 67, 101, 32, 114, 155, 67, 10, 145, 184, 88, 213, 21, 99, 235, 196 }, new byte[] { 170, 88, 167, 56, 165, 135, 212, 131, 226, 35, 251, 25, 101, 148, 19, 114, 171, 8, 46, 183, 151, 141, 114, 54, 179, 253, 167, 210, 227, 83, 125, 80, 175, 198, 173, 216, 197, 142, 51, 231, 145, 41, 8, 204, 14, 112, 251, 153, 157, 133, 168, 5, 175, 171, 24, 207, 83, 129, 145, 0, 47, 155, 109, 114, 63, 36, 172, 90, 169, 1, 151, 77, 232, 70, 226, 145, 151, 188, 136, 156, 183, 89, 63, 125, 171, 19, 177, 106, 157, 186, 88, 199, 59, 191, 237, 157, 81, 103, 40, 62, 26, 111, 60, 182, 34, 0, 88, 145, 165, 72, 103, 69, 203, 134, 56, 100, 169, 60, 26, 216, 104, 190, 47, 118, 124, 70, 82, 222 }, "5556667790", "Demir", null, 1 },
                    { new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5050), null, "20220006@std.iyte.edu.tr", true, "Zeynep", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "7890123456", "Aydın", null, 0 },
                    { new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5050), null, "20210007@std.iyte.edu.tr", true, "Burak", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "8901234567", "Çelik", null, 0 },
                    { new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5080), null, "20210017@std.iyte.edu.tr", true, "Tuba", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "8899001122", "Karaman", null, 0 },
                    { new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5040), null, "20220005@std.iyte.edu.tr", true, "Emre", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "6789012345", "Demir", null, 0 },
                    { new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5060), null, "20210011@std.iyte.edu.tr", true, "Ece", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "2233445566", "Güneş", null, 0 },
                    { new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5030), null, "20210003@std.iyte.edu.tr", true, "Mehmet", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "4567890123", "Öz", null, 0 },
                    { new Guid("c4e05469-860b-4655-b844-f682a21fca23"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5050), null, "20220008@std.iyte.edu.tr", true, "Selin", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "9012345678", "Yıldız", null, 0 },
                    { new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5030), null, "20190004@std.iyte.edu.tr", true, "Fatma", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "5678901234", "Kaya", null, 0 },
                    { new Guid("e32d7b07-a92e-4dda-83e0-c90ee8cad8e5"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5190), null, "elec.deptsecretary@iyte.edu.tr", true, "Melek", new byte[] { 116, 41, 30, 60, 5, 110, 254, 2, 129, 33, 53, 241, 13, 149, 42, 204, 53, 142, 50, 186, 159, 107, 24, 86, 118, 74, 218, 36, 132, 184, 141, 123, 5, 40, 22, 195, 209, 228, 229, 86, 173, 247, 146, 157, 152, 63, 115, 107, 190, 67, 101, 32, 114, 155, 67, 10, 145, 184, 88, 213, 21, 99, 235, 196 }, new byte[] { 170, 88, 167, 56, 165, 135, 212, 131, 226, 35, 251, 25, 101, 148, 19, 114, 171, 8, 46, 183, 151, 141, 114, 54, 179, 253, 167, 210, 227, 83, 125, 80, 175, 198, 173, 216, 197, 142, 51, 231, 145, 41, 8, 204, 14, 112, 251, 153, 157, 133, 168, 5, 175, 171, 24, 207, 83, 129, 145, 0, 47, 155, 109, 114, 63, 36, 172, 90, 169, 1, 151, 77, 232, 70, 226, 145, 151, 188, 136, 156, 183, 89, 63, 125, 171, 19, 177, 106, 157, 186, 88, 199, 59, 191, 237, 157, 81, 103, 40, 62, 26, 111, 60, 182, 34, 0, 88, 145, 165, 72, 103, 69, 203, 134, 56, 100, 169, 60, 26, 216, 104, 190, 47, 118, 124, 70, 82, 222 }, "2223334455", "Çakır", null, 1 },
                    { new Guid("e8a7af40-b208-430e-967a-e590bab72810"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5110), null, "20220026@std.iyte.edu.tr", true, "Aşkın", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "1123445557", "Durmaz", null, 0 },
                    { new Guid("e8a7af40-b209-430e-967a-e590bab72810"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5100), null, "20220025@std.iyte.edu.tr", true, "Memo", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "1123445556", "Yilik", null, 0 },
                    { new Guid("e8a7af40-b210-430e-967a-e590bab72810"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5100), null, "20220024@std.iyte.edu.tr", true, "Ayşecik", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "1123445555", "Yıldır", null, 0 },
                    { new Guid("e8a7af40-b211-430e-967a-e590bab72810"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5100), null, "20220023@std.iyte.edu.tr", true, "Ayşe", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "1122334454", "Yılmaz", null, 0 },
                    { new Guid("e8a7af40-b212-430e-967a-e590bab72810"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5090), null, "20220022@std.iyte.edu.tr", true, "Aişe", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "1122634455", "Yılgın", null, 0 },
                    { new Guid("e8a7af40-b213-430e-967a-e590bab72810"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5090), null, "20220021@std.iyte.edu.tr", true, "Mehmet", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "1722334455", "Yılmaz", null, 0 },
                    { new Guid("e8a7af40-b214-430e-967a-e590bab72810"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5090), null, "20220020@std.iyte.edu.tr", true, "Kasım", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "1122339455", "Yılmaz", null, 0 },
                    { new Guid("e8a7af40-b215-430e-967a-e590bab72810"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5090), null, "20220019@std.iyte.edu.tr", true, "Yusuf", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "1121334455", "Yılmaz", null, 0 },
                    { new Guid("e8a7af40-b216-430e-967a-e590bab72810"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5080), null, "20220018@std.iyte.edu.tr", true, "Yasin", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "9900112233", "Erdoğan", null, 0 },
                    { new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), null, 0, null, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(5060), null, "20200009@std.iyte.edu.tr", true, "Can", new byte[] { 201, 112, 101, 72, 250, 68, 58, 6, 80, 68, 23, 8, 170, 118, 36, 77, 139, 174, 12, 147, 252, 187, 103, 110, 174, 93, 88, 113, 96, 205, 214, 148, 215, 135, 15, 63, 153, 218, 175, 74, 208, 18, 97, 65, 175, 155, 103, 3, 183, 124, 29, 139, 73, 94, 243, 90, 74, 42, 129, 29, 16, 114, 106, 17 }, new byte[] { 121, 42, 15, 186, 165, 190, 154, 174, 20, 232, 200, 9, 79, 69, 139, 11, 104, 251, 232, 127, 58, 29, 129, 139, 82, 33, 37, 188, 37, 153, 152, 72, 39, 135, 47, 194, 114, 68, 195, 120, 205, 252, 180, 247, 76, 171, 127, 31, 110, 219, 209, 10, 57, 51, 187, 235, 51, 231, 190, 178, 89, 93, 0, 237, 190, 86, 18, 219, 168, 237, 207, 90, 78, 100, 248, 102, 70, 131, 163, 50, 154, 0, 165, 16, 159, 217, 246, 138, 206, 118, 12, 154, 102, 161, 69, 101, 107, 213, 30, 105, 29, 124, 188, 106, 224, 59, 109, 230, 218, 14, 226, 94, 168, 16, 131, 110, 226, 138, 1, 83, 162, 214, 126, 192, 152, 105, 168, 6 }, "0123456789", "Arslan", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "FacultyDeansOffices",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "FacultyName", "StudentAffairId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(30), null, "Fen Fakültesi", new Guid("11111111-1111-1111-1111-111111111111"), null },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(30), null, "Mühendislik Fakültesi", new Guid("11111111-1111-1111-1111-111111111111"), null }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DepartmentId", "FacultyId", "StaffPhone", "StaffRole", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-33333333333a"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(4730), null, null, null, "232-750-5001", 1, null },
                    { new Guid("66666666-6666-6666-6666-66666666666a"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(4740), null, null, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "232-750-5002", 2, null },
                    { new Guid("77777777-7777-7777-7777-77777777777a"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(4740), null, null, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "232-750-6002", 2, null },
                    { new Guid("88888888-8888-8888-8888-88888888888a"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(4740), null, null, null, "232-750-1001", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Transcripts",
                columns: new[] { "Id", "CompletedCourseCount", "CompletedCredit", "CreatedDate", "DeletedDate", "DepartmentGraduationRank", "FacultyGraduationRank", "GraduationYear", "RemainingCredit", "RequiredCourseCount", "StudentId", "StudentIdentityNumber", "TotalRequiredCredit", "TotalTakenCredit", "TranscriptDate", "TranscriptDescription", "TranscriptFileName", "TranscriptGpa", "UniversityGraduationRank", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("03c1f239-82e5-41ef-9769-bca0cacbd03e"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2760), null, "2", "8", "2024", 0, 24, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), "12345678910", 240, 240, new DateTime(2025, 5, 8, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2760), "Mezuniyet transkripti", "transcript_2023010.pdf", 3.72m, "14", null },
                    { new Guid("059c885b-d8e1-41e4-b59e-693251b28fd6"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2810), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), "12345678919", 240, 240, new DateTime(2025, 5, 16, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2810), "Mezuniyet transkripti", "transcript_2023019.pdf", 2.34m, "40", null },
                    { new Guid("098b2bcc-a139-479a-8d39-087cf3e2f472"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2780), null, "1", "6", "2024", 0, 24, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), "12345678913", 240, 240, new DateTime(2025, 4, 28, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2780), "Mezuniyet transkripti", "transcript_2023013.pdf", 3.82m, "8", null },
                    { new Guid("103edad6-6646-4d71-be49-6ab4b98542db"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2810), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), "12345678918", 240, 240, new DateTime(2025, 5, 16, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2800), "Mezuniyet transkripti", "transcript_2023018.pdf", 3.45m, "40", null },
                    { new Guid("19d82342-de68-4299-8351-d2308aedec99"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2800), null, "1", "4", "2024", 0, 24, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), "12345678917", 240, 240, new DateTime(2025, 5, 5, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2800), "Mezuniyet transkripti", "transcript_2023017.pdf", 3.77m, "11", null },
                    { new Guid("1cd88678-dbc6-4e26-be92-a3909d8c6f76"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2830), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), "12345678922", 240, 240, new DateTime(2025, 5, 16, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2820), "Mezuniyet transkripti", "transcript_2023022.pdf", 2.53m, "40", null },
                    { new Guid("353b6223-6ce0-4b2f-ad24-e08a88cc0512"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2840), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), "12345678924", 240, 240, new DateTime(2025, 5, 16, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2840), "Mezuniyet transkripti", "transcript_2023024.pdf", 2.73m, "40", null },
                    { new Guid("35850ebc-9d85-4de3-a01c-690a69d16172"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2780), null, "2", "11", "2024", 0, 24, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), "12345678914", 240, 240, new DateTime(2025, 5, 11, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2780), "Mezuniyet transkripti", "transcript_2023014.pdf", 3.58m, "23", null },
                    { new Guid("364dda92-7b9a-46be-8d86-779110a348f4"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2730), null, "3", "6", "2024", 0, 24, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), "12345678903", 240, 240, new DateTime(2025, 5, 4, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2720), "Mezuniyet transkripti", "transcript_2023003.pdf", 3.75m, "12", null },
                    { new Guid("425a8156-4585-4a9d-99cc-96d6139ef074"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2740), null, "2", "5", "2024", 0, 24, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), "12345678906", 240, 240, new DateTime(2025, 5, 6, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2740), "Mezuniyet transkripti", "transcript_2023006.pdf", 3.78m, "10", null },
                    { new Guid("4432234f-ed62-4ce4-94e7-1afa2c13771e"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2770), null, "4", "12", "2024", 0, 24, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), "12345678912", 240, 240, new DateTime(2025, 5, 15, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2770), "Mezuniyet transkripti", "transcript_2023012.pdf", 3.48m, "35", null },
                    { new Guid("4679af7f-e597-48fb-9080-11b2b34da26b"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2720), null, "2", "3", "2024", 0, 24, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), "12345678902", 240, 240, new DateTime(2025, 4, 29, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2720), "Mezuniyet transkripti", "transcript_2023002.pdf", 3.88m, "5", null },
                    { new Guid("6c529ec9-6185-433c-a982-dc600ae356a3"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2790), null, "1", "3", "2024", 0, 24, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), "12345678915", 240, 240, new DateTime(2025, 4, 30, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2790), "Mezuniyet transkripti", "transcript_2023015.pdf", 3.90m, "3", null },
                    { new Guid("741ec123-5a0e-4c7a-b815-28fb2e2b447e"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2710), null, "1", "1", "2024", 0, 24, new Guid("22222222-2222-2222-2222-22222222222a"), "12345678901", 240, 240, new DateTime(2025, 4, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2700), "Mezuniyet transkripti", "transcript_2023001.pdf", 3.95m, "1", null },
                    { new Guid("760e9042-f6cf-4e52-b7df-dc4e91e4ccf6"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2740), null, "1", "2", "2024", 0, 24, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), "12345678905", 240, 240, new DateTime(2025, 5, 2, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2740), "Mezuniyet transkripti", "transcript_2023005.pdf", 3.92m, "2", null },
                    { new Guid("77ecb265-84f3-4705-b042-74924a84b629"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2820), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), "12345678921", 240, 240, new DateTime(2025, 5, 16, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2820), "Mezuniyet transkripti", "transcript_2023021.pdf", 2.43m, "40", null },
                    { new Guid("816c1d27-27bf-4de7-b039-ee89cbd9519e"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2750), null, "4", "9", "2024", 0, 24, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), "12345678908", 240, 240, new DateTime(2025, 5, 12, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2750), "Mezuniyet transkripti", "transcript_2023008.pdf", 3.55m, "25", null },
                    { new Guid("9ac2dbd0-d71a-46fa-a02f-f21072f40fa4"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2850), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), "12345678926", 240, 240, new DateTime(2025, 5, 16, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2850), "Mezuniyet transkripti", "transcript_2023026.pdf", 2.93m, "40", null },
                    { new Guid("9c69b753-3d24-4745-a821-5d2f87be9c2f"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2790), null, "1", "1", "2024", 0, 24, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), "12345678916", 240, 240, new DateTime(2025, 4, 19, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2790), "Mezuniyet transkripti", "transcript_2023016.pdf", 3.98m, "1", null },
                    { new Guid("9dd92342-c26b-4e9f-b2e6-77982d99346b"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2730), null, "4", "8", "2024", 0, 24, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), "12345678904", 240, 240, new DateTime(2025, 5, 9, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2730), "Mezuniyet transkripti", "transcript_2023004.pdf", 3.65m, "18", null },
                    { new Guid("ada949cc-324f-49b4-a67b-c9241fe858be"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2750), null, "3", "7", "2024", 0, 24, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), "12345678907", 240, 240, new DateTime(2025, 5, 10, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2750), "Mezuniyet transkripti", "transcript_2023007.pdf", 3.68m, "15", null },
                    { new Guid("be760830-f76b-4273-90e4-0200c0fb0340"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2770), null, "3", "10", "2024", 0, 24, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), "12345678911", 240, 240, new DateTime(2025, 5, 13, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2770), "Mezuniyet transkripti", "transcript_2023011.pdf", 3.62m, "20", null },
                    { new Guid("c6f7baaf-9b86-4230-a5ec-aa26c2aa90a8"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2760), null, "1", "4", "2024", 0, 24, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), "12345678909", 240, 240, new DateTime(2025, 4, 26, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2760), "Mezuniyet transkripti", "transcript_2023009.pdf", 3.85m, "7", null },
                    { new Guid("cc5cb060-de1b-46b8-826d-45f246922063"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2840), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), "12345678925", 240, 240, new DateTime(2025, 5, 16, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2840), "Mezuniyet transkripti", "transcript_2023025.pdf", 2.83m, "40", null },
                    { new Guid("e41a83da-c6d6-42bd-b8b7-f6e17cf17928"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2830), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), "12345678923", 240, 240, new DateTime(2025, 5, 16, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2830), "Mezuniyet transkripti", "transcript_2023023.pdf", 2.63m, "40", null },
                    { new Guid("f54f0d31-df38-4b72-b6ee-27cc09cffa77"), 24, 240, new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2820), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), "12345678920", 240, 240, new DateTime(2025, 5, 16, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(2810), "Mezuniyet transkripti", "transcript_2023020.pdf", 2.23m, "40", null }
                });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("0141b3a9-d1fd-45d2-96c6-dff0a07ea0bb"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6240), null, new Guid("44444444-4444-4444-4444-444444444444"), null, new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("0f200f40-fa3a-40f8-94da-d72dfc61857e"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6250), null, new Guid("55555555-5555-5555-5555-555555555555"), null, new Guid("89e73bfc-718e-49d4-92af-1c576d281cf4") },
                    { new Guid("0ff9e17b-665b-4e3b-b70d-6a1e450cea10"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6210), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d") },
                    { new Guid("1a74b353-45cc-4fd2-afac-31dfa39c8f33"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6250), null, new Guid("55555555-5555-5555-5555-555555555555"), null, new Guid("e32d7b07-a92e-4dda-83e0-c90ee8cad8e5") },
                    { new Guid("21f4e6ab-fc45-4d28-9036-b33b018d826b"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6160), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45") },
                    { new Guid("229b5f1d-5df4-4bb8-8dfc-9ade9a69f289"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6250), null, new Guid("55555555-5555-5555-5555-555555555555"), null, new Guid("55555555-5555-5555-5555-55555555555a") },
                    { new Guid("31e624c7-4b43-44f1-b607-ebfeec00a8a4"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6220), null, new Guid("33333333-3333-3333-3333-333333333333"), null, new Guid("33333333-3333-3333-3333-33333333333a") },
                    { new Guid("40cd3ce3-6f8a-4eee-89d3-922cb988d12f"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6200), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("79cace77-5720-434d-97b6-0d47a61468a3") },
                    { new Guid("4a777d4e-0ff1-4c7a-a510-7842b5bb571e"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6160), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307") },
                    { new Guid("50fdd2df-c6d0-4972-94d0-025244b40915"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6210), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8") },
                    { new Guid("5bf354e5-9cb4-4f59-aae9-ea1895e42610"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6150), null, new Guid("11111111-1111-1111-1111-111111111111"), null, new Guid("11111111-1111-1111-1111-11111111111a") },
                    { new Guid("63a0510f-69af-469d-8548-2062c79efec0"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6170), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("9000296e-dd35-476c-8702-cb20fd49c946") },
                    { new Guid("8370e503-50a3-4d7d-a7fd-a892cdb661ed"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6220), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("e8a7af40-b216-430e-967a-e590bab72810") },
                    { new Guid("8ca59009-ad33-4bce-8ae2-45094dabf543"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6240), null, new Guid("44444444-4444-4444-4444-444444444444"), null, new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("90a01041-6bf8-4e37-8808-71a6867c8cf6"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6190), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257") },
                    { new Guid("99232f05-59cb-4594-8571-974b3b39fed4"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6230), null, new Guid("44444444-4444-4444-4444-444444444444"), null, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bc70eeaa-e7d5-4604-99fd-ffab0faa93d1"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6160), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("22222222-2222-2222-2222-22222222222a") },
                    { new Guid("c28ba7e9-07f1-4900-b369-4682f54003e4"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6180), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("c4e05469-860b-4655-b844-f682a21fca23") },
                    { new Guid("c58f7298-f767-48f0-818d-0a14d37df366"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6190), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8") },
                    { new Guid("c60a0e82-8d83-46e1-b056-2dc64d6314d7"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6260), null, new Guid("66666666-6666-6666-6666-666666666666"), null, new Guid("66666666-6666-6666-6666-66666666666a") },
                    { new Guid("d103e8fd-928b-4c3e-ba82-16035428a191"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6190), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b") },
                    { new Guid("d2213da2-6add-4c90-83df-84e32439ba48"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6200), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4") },
                    { new Guid("d2bb0540-138c-494d-8680-4df3f6bb0397"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6230), null, new Guid("44444444-4444-4444-4444-444444444444"), null, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("d8c47bca-55dd-43c5-a6a0-a8dcf5df9749"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6240), null, new Guid("44444444-4444-4444-4444-444444444444"), null, new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("dbe6ec0a-e906-49b9-9b13-3fada9e1f381"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6170), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24") },
                    { new Guid("dd959853-311c-49b0-b627-4647b0eead9e"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6260), null, new Guid("66666666-6666-6666-6666-666666666666"), null, new Guid("77777777-7777-7777-7777-77777777777a") },
                    { new Guid("e2f0ba07-26a9-4500-afda-66927bce7431"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6170), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4") },
                    { new Guid("e9d404ab-f2ec-4de1-a818-67adc2f2b588"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6200), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6") },
                    { new Guid("ed91d85e-8733-47d8-8647-2c9cae2f9230"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6230), null, new Guid("44444444-4444-4444-4444-444444444444"), null, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("f8036b61-f093-427a-a0bf-63d0d502891c"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6210), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5") },
                    { new Guid("f9a32412-b421-45fc-9674-02fddfcd063c"), new DateTime(2025, 5, 24, 13, 12, 42, 305, DateTimeKind.Utc).AddTicks(6180), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df") }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DepartmentName", "DepartmentPhone", "FacultyId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("11111111-2222-3333-4444-555555555555"), new DateTime(2025, 5, 24, 13, 12, 42, 299, DateTimeKind.Utc).AddTicks(9020), null, "Elektrik-Elektronik Mühendisliği", "232-750-7002", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), null },
                    { new Guid("22222222-3333-4444-5555-666666666666"), new DateTime(2025, 5, 24, 13, 12, 42, 299, DateTimeKind.Utc).AddTicks(9030), null, "Makine Mühendisliği", "232-750-7003", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), null },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2025, 5, 24, 13, 12, 42, 299, DateTimeKind.Utc).AddTicks(9000), null, "Fizik Bölümü", "232-750-6001", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), null },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2025, 5, 24, 13, 12, 42, 299, DateTimeKind.Utc).AddTicks(9010), null, "Kimya Bölümü", "232-750-6002", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), null },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2025, 5, 24, 13, 12, 42, 299, DateTimeKind.Utc).AddTicks(9010), null, "Matematik Bölümü", "232-750-6003", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), null },
                    { new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2025, 5, 24, 13, 12, 42, 299, DateTimeKind.Utc).AddTicks(9020), null, "Bilgisayar Mühendisliği", "232-750-7001", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), null }
                });

            migrationBuilder.InsertData(
                table: "Advisors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DepartmentId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(4170), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(4170), null, new Guid("11111111-2222-3333-4444-555555555555"), null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(4170), null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(4170), null, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(4170), null, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), null },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(4170), null, new Guid("22222222-3333-4444-5555-666666666666"), null }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCode", "CourseCredit", "CourseDescription", "CourseName", "CreatedDate", "DeletedDate", "DepartmentId", "ECTS", "FacultyId", "HalfYear", "PracticalHours", "TeoricHours", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), "PHYS121", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2490), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 6, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 4, null },
                    { new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), "PHYS122", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2500), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 6, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 4, null },
                    { new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), "CENG322", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2540), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 8, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 4, null },
                    { new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), "CENG213", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2510), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 6, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 3, null },
                    { new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), "CENG214", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2520), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 4, null },
                    { new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), "MATH144", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2500), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 5, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 3, null },
                    { new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), "MATH141", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2490), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 4, null },
                    { new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), "CENG218", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2530), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 6, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 3, null },
                    { new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), "CENG215", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2510), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 4, null },
                    { new Guid("4777afa3-a512-4353-8109-0674da099cf0"), "CENG424", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2560), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "fourth half year", 0, 3, null },
                    { new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), "CENG112", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2490), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 3, null },
                    { new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), "CENG216", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2520), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 5, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 3, null },
                    { new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), "CENG400", 0, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2540), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 4, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "fourth half year", 0, 0, null },
                    { new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), "CENG315", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2530), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 3, null },
                    { new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), "HIST202", 0, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2510), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 2, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 0, null },
                    { new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), "TURK201", 0, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2500), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 2, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 0, null },
                    { new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), "CENG222", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2530), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 5, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 3, null },
                    { new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), "CENG411", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2550), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 4, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "fourth half year", 0, 3, null },
                    { new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), "CENG323", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2530), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 8, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 3, null },
                    { new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), "MATH142", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2500), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 4, null },
                    { new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), "CENG418", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2550), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 6, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "fourth half year", 0, 3, null },
                    { new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), "MATH255", 3, "Discrete Mathematics course", "Discrete Mathematics", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2560), null, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), 6, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "second half year", 0, 3, null },
                    { new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), "CENG115", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2490), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 5, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 3, null },
                    { new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), "CENG312", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2540), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 3, null },
                    { new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), "CENG211", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2510), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 6, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 3, null },
                    { new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), "CENG212", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2520), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 5, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 3, null },
                    { new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), "CENG318", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2540), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 5, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 3, null },
                    { new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), "CENG311", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2530), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 8, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 4, null },
                    { new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), "CENG415", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2550), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 9, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "fourth half year", 0, 3, null },
                    { new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), "CENG111", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2470), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 4, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 3, null },
                    { new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), "TURK202", 0, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2510), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 2, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 0, null },
                    { new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), "CENG416", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2550), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 9, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "fourth half year", 0, 3, null },
                    { new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), "CENG316", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2540), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 8, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 3, null },
                    { new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), "CENG113", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2480), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 4, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 4, null },
                    { new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), "HIST201", 0, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(2500), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 2, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DepartmentId", "FacultyId", "StaffPhone", "StaffRole", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("55555555-5555-5555-5555-55555555555a"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(4730), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), null, "232-750-7004", 3, null },
                    { new Guid("89e73bfc-718e-49d4-92af-1c576d281cf4"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(4730), null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), null, "232-750-6004", 3, null },
                    { new Guid("e32d7b07-a92e-4dda-83e0-c90ee8cad8e5"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(4730), null, new Guid("11111111-2222-3333-4444-555555555555"), null, "232-750-7005", 3, null }
                });

            migrationBuilder.InsertData(
                table: "GraduationLists",
                columns: new[] { "Id", "AdvisorId", "CreatedDate", "DeletedDate", "GraduationListNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(7670), null, "ME-2024-001", null },
                    { new Guid("a44b3d2f-ab86-4f4e-92ef-fd61b2894bf1"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(7670), null, "PHYS-2024-001", null },
                    { new Guid("abfb59be-9c96-490f-9c4e-100c15c0c337"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(7670), null, "EE-2024-001", null },
                    { new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(7660), null, "CENG-2024-001", null },
                    { new Guid("c70e2d92-b390-4511-978b-e058c34c9099"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(7670), null, "MATH-2024-001", null },
                    { new Guid("d47dc5ec-0974-4ed7-a24d-99bfba1aac06"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(7670), null, "CHEM-2024-001", null }
                });

            migrationBuilder.InsertData(
                table: "RequiredCourseListCourses",
                columns: new[] { "Id", "CourseId", "CreatedDate", "DeletedDate", "RequiredCourseListId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("00f78633-5134-41ef-b7aa-20207390a0ee"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6970), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("01eab8b8-6baa-4a10-9f69-e139d9469c24"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7180), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("0366cc29-fdbb-4b63-bb50-521a1cb23ae2"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6550), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("0436a141-677c-4070-b791-4e93c88748e8"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6750), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("052a169e-55c9-45e5-b150-509f504f3981"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6860), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("06564c41-0ebd-43a4-af91-00aace746b94"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7040), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("07bdf602-93f7-409e-a3ce-96cbf1746c12"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6550), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("07c76270-0162-4c87-aa6a-978d5b5f3c7d"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7090), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("0e16f3a9-9817-4c79-87fd-86fc293b9bad"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7030), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("0e3bfefe-12df-4fcb-93fc-2d5f43d06921"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6670), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("0e73223d-49e7-4a15-b312-084ed09f5815"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6880), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("0fc7f327-2a18-4f6d-b720-5f51ead80aeb"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6530), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("117c0962-370d-4dc9-9069-93239816c505"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6920), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("11d5ee91-e98c-4f50-bdd1-4adab4872f50"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7060), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("11ebf7b7-9955-4e92-8c4e-ed26daa0bb5e"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7160), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("141246e4-cd00-4d23-967a-fe8b0fcfccfa"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7210), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("17283457-3c1c-410b-9d77-9f170b6f9623"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7050), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("175395c7-c13f-4125-946c-77dde8d40fee"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7240), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("1b5fd9a3-8ec2-4789-b016-37d3f937accc"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7200), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("1bc77392-346d-4097-8579-37fc337f044b"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6920), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("1e686a03-0eda-4478-b7b1-ca9fa1974ec4"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6400), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("1ed1b52e-8186-4000-b6f3-bb7cb2532f42"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6620), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("1f40caf3-574e-4bf8-9c51-81873b03a20e"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6410), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("1fbd030a-3d9b-4908-8282-927e7cd266b7"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6490), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("2129fa00-401e-4005-bc8b-82154fae9b73"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6990), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("22b2ef23-6461-4f62-907d-10ed1ae0ea0c"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6450), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("236d8bb9-7d24-4d98-abab-f48f1484f23e"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7140), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("23c5134d-ee15-4565-b9eb-a7d8c58068f9"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7220), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("2491cb97-160f-4511-b650-8529d2bb93d6"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6660), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("26e50482-e7ef-4e12-a144-72a0f50d630b"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6930), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("26ece956-c03f-4cbb-951d-9bcf32350a4c"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6490), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("279e05e6-6626-4dcc-a1d4-ed2a6f97af85"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6660), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("29a0370f-01f6-4b13-baab-f4873fb56342"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7240), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("2a4c6529-5072-4ce3-a84a-a22ad6bc539a"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6850), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("2ad90603-5a25-4a73-8df1-0022f480861f"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7090), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("2adf4acc-9f07-45fd-9acf-01dc1a49e88e"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6540), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("2cb1606c-7865-4f68-8af7-96a700e5673c"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7110), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("2d8499e5-89e0-41b0-9754-5f179cad28a4"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6480), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("2dcf50a3-7c05-497d-a162-77e38036033b"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6370), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("313aa762-189b-46b1-8259-70aad9e1baf3"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6540), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("3183b118-d985-4e9f-b8c4-c09129a8ffd0"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6360), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("359d96e6-6c1c-4d76-8cf0-41108792004d"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6680), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("3628aa05-1699-4a07-8a4e-2eeccef41d62"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7120), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("367be7de-ed84-49a9-9d53-f793c8f8dd6a"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6850), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("36d1ad2c-bad4-4ab2-8a8f-e3dcaec4e31e"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7100), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("375bc8c4-80a6-40ab-9cce-03ba6c75485e"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7170), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("37916fae-9d88-4e61-9a03-bbc7a5ff4392"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7130), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("37ba598d-9d94-4cf0-9571-c8aad6eab3f3"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6790), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("38cc5d10-3e64-468c-957b-8656c30f117e"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6760), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("39abab4e-dc5f-43ed-aabb-a75f4c1e862d"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7110), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("39cb3afc-6a12-4256-b232-2a8feed18d0f"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7010), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("3aaf953c-a737-4a03-bbae-e386957d69f8"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6810), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("3c6ab565-906f-44b4-a724-3cb75dc13c8d"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6960), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("3e3446e2-dc7e-432a-9f72-50931d2ee2d0"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6980), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("3f0ef5f4-1fce-4712-8552-6eb232ff76d7"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6400), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("40c4d4b2-2100-44b2-bd0a-1ea6a5044b44"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6990), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("42101274-7da7-419a-8ab3-da8e9eef09c5"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7100), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("42946d20-10ba-4d80-9c7d-6bb5392a631f"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6570), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("43236932-8e55-4879-9bec-8fca18e75ce3"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7180), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("449841f8-338d-4a76-8526-778b4dc3b27e"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6590), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("46d54578-eb3b-445a-980c-4c7839a9adfb"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6390), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("486172d0-65c7-4c57-b247-b40570e7922a"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7080), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("4a395e6e-0557-4bad-972c-2446aaf2c003"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7070), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("4b180097-6302-4de1-a3cb-2e60a417d9eb"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6580), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("4b4c57da-7f29-448b-a4e3-e0fdc6bb5899"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6800), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("4c17dfde-a2e3-4f75-8222-b0d988ddec2c"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6730), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("4c9dbc75-2baf-4978-89f8-bbe84d6bac68"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6370), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("4d37b8a7-7405-4fec-8ce1-f84c68d59be9"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6970), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("4fcfc550-883c-4d57-9612-a67224949865"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6510), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("500eff8a-fda1-4cc2-bb04-b349a339138b"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7000), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("510648d5-c855-4156-8c6f-c0eec2f12fa9"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6330), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("51552629-3825-4418-b96f-4ef2ae74bf88"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6800), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("5331885d-132d-452d-8e1f-979896af71be"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6320), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("53777e0b-6263-437c-9245-b86dd420e50a"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7040), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("55781913-ad0e-4032-bf72-e149af4694ca"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6360), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("5a5fc33b-1798-4bec-b03c-0a2ca5314fda"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6640), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("5d5f62d9-d8fb-4a68-89f7-38d261759810"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6340), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("5d8e6a1b-fc2c-47d7-b52a-18d5a086493c"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7200), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("5dc07da1-5ab2-4dbc-ba85-c36c372785e5"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6830), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("5ed8b309-3a67-406c-9de2-7daf7a1f39b7"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6770), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("60273f80-4ed2-44d1-aa3b-11dc754f33df"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6710), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("60baac74-3063-43e4-9bad-9a549d38cf8a"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7230), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("60e7760c-e03d-4f42-80b3-11b6c44c7e5f"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6760), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("6290d70e-8822-4e43-8c34-9664aac05f77"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6940), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("62c1458e-a95e-48f0-97e3-7922da63f461"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6940), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("635fb011-b944-44cd-84ab-51015bda4cbd"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6440), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("6367fe52-670f-4dae-bb67-f205ef21e406"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7150), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("63e410d9-fd23-4238-a282-874f49d497e2"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6930), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("645b84ec-2749-4433-804a-8b55a2e67c88"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7050), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("68c40f10-18d3-4eba-be2a-9959d56e8927"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6600), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("69386235-5086-4bf4-a504-b9ddcabede5a"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6950), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("69722b0d-3e6f-4ad4-a9c0-d474d134855a"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6430), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("69ebb2bd-44ae-432e-a919-7d661efd365e"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6810), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("6a0b20f0-2616-4580-9cae-14609f717d94"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6890), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("6a541a16-29f3-421c-92f1-0d5b22a3b21d"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7030), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("6ad1b755-3732-4898-aca1-d3fb9b852114"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6670), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("6b441b56-fae4-4539-b2b3-d3149312ea8d"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6690), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("6e9ab08e-4300-443b-9808-aeccf9a0413c"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6390), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("6f9c8d33-6d5c-4a7e-9108-c878ce006f5a"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6440), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("6fd3b2dc-97db-4263-a0ff-379d5282ea5b"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6820), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("7004913e-c1b6-4760-b1de-cad90b71c1ca"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6920), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("709c65ef-d1d8-4d06-b1dd-414cec2e15e4"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6680), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("7133df27-8174-4b5f-9587-3328e8a2af9f"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6570), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("720da0e0-4b30-40ca-9586-58a846d07824"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6840), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("72b89c43-0fd5-4ae0-82dc-34fc5080f904"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6830), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("72be0018-ceb3-42ac-b1d9-615aba8f4b26"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7000), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("7361495d-4eb3-4144-b3fa-67a7da3471c7"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6860), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("741d207d-52ce-46b8-a84b-3c641e8256dc"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7120), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("74e5a5f7-fb2e-4a95-9c72-79cf44160e0d"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6730), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("76478070-9df0-4e90-935a-8087c9d959ea"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6560), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("76abb9da-8ee4-4b8b-99db-9f8eb17f7b0a"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7240), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("76f7b7e6-fbac-4ac2-a467-1db9bcbd94e9"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6620), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("7ac6b01a-ed1f-4b5a-89d2-fb198f152497"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6630), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("7b17423b-bbb4-4fb9-bbac-ea45938ef9c8"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6900), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("7cda1461-d21e-4bfc-9426-0d30e3cf1f79"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6670), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("7de03976-9de9-43b2-841b-9788018df60c"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6900), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("7e898830-a65e-48d1-8cfd-90d178886b02"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6630), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("7efffdd0-9d07-4ac3-901f-60fcfbfdad75"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6790), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("7f376b22-3720-437f-9e71-e7560af5c973"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6990), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("7f65ba66-c97d-4f01-9004-0364296d03dc"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6740), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("81c9834e-ce44-49c5-b54d-2b6e0ff0d203"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7080), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("82439a4c-8fe8-4001-b31d-b6b99434f766"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6980), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("8260dbb3-1230-48e2-bb47-82158537a036"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6480), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("82bb8e5b-88df-4d80-b385-516f0ebeb860"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7120), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("8309e258-94dd-4338-96ee-dcef22f8df50"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6880), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("8452be0c-199d-404b-916b-b07d7c64b61e"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6420), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("8508ed00-edbd-48cd-998f-7ad1b7b14531"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6820), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("872cf0b7-7588-436d-bcee-264349378b47"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6330), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("873262fc-ca5e-499b-bef1-bb00bbdad6a5"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6900), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("8b7c85f8-a286-4502-a429-5f38b38d5b53"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7070), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("8ba13453-d6fc-49de-9cb0-d9febee55500"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7150), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("8d847bec-ca05-4ff4-8dd1-bd010d8a0c7c"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6870), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("8e9c63c6-6c68-410e-b8ca-546d11be0d28"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7190), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("8f59352f-9c08-4f29-8726-13b78cba0caf"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6650), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("91516391-e819-44da-8b12-307cd40024ba"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6530), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("933873f8-6c02-4755-888f-18f403a28810"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6960), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("942e448f-b13a-4a9a-b885-ad0ee751eb46"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7230), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("948fe2ec-a6a3-4d17-bbb7-87972d50cf94"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6510), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("95ab88f6-63fa-4189-b1f5-0d2ea833aea7"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6380), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("95d004d7-a2a6-4f0d-bab5-c6efd4745b1c"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6460), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("96a2b98e-d496-44ea-ae6d-6fb93dc51835"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7020), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("96b81b16-5866-4313-a6cc-f2d794bc676a"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6470), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("98ffb668-dd63-454d-a073-8e44892b761f"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6650), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("9926d8dc-4946-482a-98c8-b1182b9dbceb"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6350), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("99890e1d-47ec-4b4c-849e-9ddc694e7315"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7160), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("9a68826a-dab6-46ef-9315-5aedcbb09a9f"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6560), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("9e1a8a56-aac3-4cee-961d-1faa5f6d8646"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6610), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("9f04b1c0-e712-4d9a-ae40-a6c17966aec3"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7170), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("a1bc761e-dd16-4a43-93ac-61cb46e54d84"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6870), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("a2b0df2d-19ae-46fb-b5f3-d113f82d197b"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7200), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("a3af1145-a0e1-41e7-a2b7-71ef545af17a"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6970), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("a3e03cdc-4164-419d-ab6e-b7ee3561c9e0"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7070), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("a4a2e422-410d-41d9-b3ac-f86a3a548f56"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6910), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("aac0afd4-d733-40bd-9100-51dc3f504d20"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6380), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("ab2ea371-26f2-4589-bd7f-d79caca69440"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6350), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("abcfffd5-0b5b-4725-99e8-7c89fb24862f"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6840), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("ac9ba4bc-d80f-4980-99c5-113a87c2d077"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7090), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("afad75a4-1586-436f-b8fb-2f73fdcd7502"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6700), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("b01627f9-4608-4841-909a-c6f399f67bb1"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6460), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("b12f070f-ed87-4218-b57a-027981cf45f8"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6770), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("b13b983b-9fe8-49dd-9a5a-059ec6ab0e8c"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6340), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("b3113ed1-eac9-41b4-a6a0-83d56cae666f"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6640), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("b473e4c2-48db-4b9e-8a96-07b905dbb110"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6450), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("b77b738f-e2fb-449e-85c7-1b3dce0e8a67"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7060), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("b814ef2b-3f30-4339-b9c9-91c5ec77c66d"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6720), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("b85e379a-1daf-4172-8637-3eec3801b90d"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6500), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("b9c2332f-6f68-4722-b6e8-f4bd4374ca1a"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6590), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("b9e63966-9de6-4058-b147-efeba8d87041"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7220), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("bbbc4e77-2a78-44cf-b6b1-a65b88ef0151"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6630), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("bc2e92f3-d2ac-44ea-80aa-e29c34617d9d"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7050), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("bfc9eb4e-c4e2-41dd-9e42-9083b600bea0"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6430), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("c026eec4-b1f0-4898-a82e-d0251297a5a3"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6690), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("c13ea88a-95c1-4356-975c-2c7ac62d7341"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7130), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("c1773e8b-b40b-4c63-969e-e64ff4f3b7da"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6940), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("c2417325-0104-4905-bca0-dae2a70e35c2"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6720), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("c32c14ca-1a6a-4e1f-9250-89ee35bbf74d"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6790), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("c3ba01a1-d179-4bd3-960e-c5810cda1ad7"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6950), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("c483d827-a3af-491e-be9f-2465a8754173"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6580), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("c586407e-8814-4087-8399-ea26ca374d16"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6420), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("c74784be-0bf4-45dc-88c4-1238975e3d7f"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6780), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("cbe57153-eec1-4dd8-8e3e-bbdf8885a4cf"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6710), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("ceb927b9-06b0-45a5-994e-59f454260f51"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6520), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("d083a106-1912-48b5-929c-47b95025ed6d"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7210), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("d2773b1b-bf91-43b3-b2e5-13d6ad7fc607"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6500), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("d4eb8142-a606-4cd6-a25c-020088a98a5e"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6500), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("d51baaa7-dc41-4fc1-a33a-4c6ae5b419ad"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6750), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("d55c9432-c71d-461d-8a25-daef19cb6dfa"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7020), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("d5de0759-0439-4f05-8aa8-079b2987da6d"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6590), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("d6ca7d13-8b49-43d0-8532-d78e3c1cca78"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6390), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("d9777179-5748-4c23-8730-291ce7a33750"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7190), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("db5b7e3d-379c-4f73-b3fb-74e1cddfe6f8"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6780), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("de620139-5857-409f-bc4c-312e7dd959f3"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6710), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("de95ab1d-e1f5-4a77-b0c9-471868af561a"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6820), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("e621fe87-410c-42ef-9ce3-22eb116fb232"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6870), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("e6c0bd80-6166-4d80-9da4-603518c853e4"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6410), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("eb29f0df-5ed7-411b-8dac-1a245042cc31"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6470), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("efa11e5c-2365-4f39-8ff2-7f8dc2a0c93e"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6610), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("f1e0b667-7b94-49da-be68-12ea3f81dd2e"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7020), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("f1e1fcc7-8a12-49f6-9894-5256a7491be6"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6520), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("f2775f08-46d6-4316-b83d-54ececc85ca2"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6750), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("f34d35cc-ab79-44f1-bf68-afdc942720bc"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6700), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("f4fc9f71-154e-4c5a-b4de-d94a900e47d7"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6550), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("f524ecfd-d27c-46a3-94f9-dfc273bcb06c"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7140), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("f5f6e254-9fbc-4316-b9fb-f11b644c248d"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7150), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("f7794315-8af9-41d9-9af4-659af057c336"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6740), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("f9e21238-69bb-47e2-b8b8-781bcfc3d284"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7180), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("fbad6b27-b215-4ee9-9064-2d361a37e7e2"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(7010), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("fc82c135-dfef-4fb9-81d7-bcb39f878645"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6890), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("fd0eba04-3334-43d0-86a8-1ea04e3b3f7d"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6840), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("fe9a3b29-f5c6-46d8-907f-af8add4aedfa"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 300, DateTimeKind.Utc).AddTicks(6600), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssignedAdvisorId", "CreatedDate", "DeletedDate", "DepartmentId", "EnrollDate", "GraduationStatus", "RequiredCourseListId", "StudentNumber", "StudentStatus", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8880), null, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), "2023016", 0, null },
                    { new Guid("22222222-2222-2222-2222-22222222222a"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8830), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), "2023001", 0, null },
                    { new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8870), null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), "2023012", 0, null },
                    { new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8840), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), "2023002", 0, null },
                    { new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8880), null, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), "2023013", 0, null },
                    { new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8880), null, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), "2023015", 0, null },
                    { new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8880), null, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), "2023014", 0, null },
                    { new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8870), null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), "2023010", 0, null },
                    { new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8850), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), "2023006", 0, null },
                    { new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8850), null, new Guid("11111111-2222-3333-4444-555555555555"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), "2023007", 0, null },
                    { new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8890), null, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), "2023017", 0, null },
                    { new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8850), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), "2023005", 0, null },
                    { new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8870), null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), "2023011", 0, null },
                    { new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8840), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), "2023003", 0, null },
                    { new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8860), null, new Guid("11111111-2222-3333-4444-555555555555"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), "2023008", 0, null },
                    { new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8840), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), "2023004", 0, null },
                    { new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8900), null, new Guid("22222222-3333-4444-5555-666666666666"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), "2023026", 0, null },
                    { new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8900), null, new Guid("22222222-3333-4444-5555-666666666666"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), "2023025", 0, null },
                    { new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8900), null, new Guid("22222222-3333-4444-5555-666666666666"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), "2023024", 0, null },
                    { new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8900), null, new Guid("22222222-3333-4444-5555-666666666666"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), "2023023", 0, null },
                    { new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8890), null, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), "2023022", 0, null },
                    { new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8890), null, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), "2023021", 0, null },
                    { new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8860), null, new Guid("11111111-2222-3333-4444-555555555555"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), "20230081", 0, null },
                    { new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8860), null, new Guid("11111111-2222-3333-4444-555555555555"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), "20230071", 0, null },
                    { new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8890), null, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), "2023018", 0, null },
                    { new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 5, 24, 13, 12, 42, 302, DateTimeKind.Utc).AddTicks(8870), null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), "2023009", 0, null }
                });

            migrationBuilder.InsertData(
                table: "GraduationProcesses",
                columns: new[] { "Id", "AdvisorApproved", "AdvisorApprovedDate", "CreatedDate", "DeletedDate", "DepartmentSecretaryApproved", "DepartmentSecretaryApprovedDate", "FacultyDeansOfficeApproved", "FacultyDeansOfficeApprovedDate", "GraduationListId", "StudentAffairsApproved", "StudentAffairsApprovedDate", "StudentId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("119a66a3-479a-4b4d-8446-7f6b6edb08b1"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9790), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), null },
                    { new Guid("17b0ae03-34f9-40bc-a5b4-236565e1a603"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9780), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("c70e2d92-b390-4511-978b-e058c34c9099"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), null },
                    { new Guid("303bc86a-3786-4fc1-8012-1dcbe2231e8f"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9780), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("e8a7af40-b216-430e-967a-e590bab72810"), null },
                    { new Guid("3138c639-3579-45f0-afb6-1d0ef8912071"), true, new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9730), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9730), null, true, new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9730), true, new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9730), new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), true, new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9730), new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), null },
                    { new Guid("6bd40639-ff99-4bae-be93-70c24a4c7948"), true, new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9760), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9760), null, true, new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9760), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a44b3d2f-ab86-4f4e-92ef-fd61b2894bf1"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), null },
                    { new Guid("8a9fcb05-4f90-4a21-915d-191100143d72"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9750), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("abfb59be-9c96-490f-9c4e-100c15c0c337"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), null },
                    { new Guid("90e34bab-a757-4d9a-b9a7-ebe0cbd66160"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9770), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("d47dc5ec-0974-4ed7-a24d-99bfba1aac06"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), null },
                    { new Guid("9da45924-4f41-4c2f-9dc3-eeb6b6547a78"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9740), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), null },
                    { new Guid("9dcce897-5a07-42d1-b657-0adfc53e1b87"), true, new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9750), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9750), null, true, new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9750), true, new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9750), new Guid("abfb59be-9c96-490f-9c4e-100c15c0c337"), true, new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9750), new Guid("c4e05469-860b-4655-b844-f682a21fca23"), null },
                    { new Guid("b3526193-57d1-462f-9705-7b82ae8ff91c"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9760), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a44b3d2f-ab86-4f4e-92ef-fd61b2894bf1"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), null },
                    { new Guid("cd56132c-0fb9-43f0-a246-cf4f68ceb034"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9770), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("d47dc5ec-0974-4ed7-a24d-99bfba1aac06"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), null },
                    { new Guid("e675db6d-3906-4375-a8b1-fa35ce56c4c0"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 24, 13, 12, 42, 301, DateTimeKind.Utc).AddTicks(9770), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("c70e2d92-b390-4511-978b-e058c34c9099"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), null }
                });

            migrationBuilder.InsertData(
                table: "TakenCourses",
                columns: new[] { "Id", "CourseId", "CreatedDate", "DeletedDate", "Grade", "StudentId", "TakenDate", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("00602a82-8f1e-436f-8dae-07a6064b38cb"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3890), null, 7, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("00ae247e-d204-49ce-8ccb-3a9270004122"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4880), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("01163c24-4a1d-488a-880d-324183395c22"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(510), null, 8, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0117876b-f7d9-4ef9-83fd-54465d2fa3d1"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(390), null, 6, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("01948fee-d22b-40ab-815b-ed68b95a8c8f"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2450), null, 7, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("01df3994-114f-4754-ad75-f29dd8d0ce82"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2680), null, 5, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("02cd044d-061c-4cbe-ad00-7985dd1214a9"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4380), null, 5, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("02ea7beb-f7f9-4010-95b7-72637e2971c8"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3570), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("02f3f16b-ae10-4a4a-b4c6-8fa1e97177d4"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2550), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("03134d1c-ce2a-4cc5-8c83-d136ef058cd7"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(740), null, 7, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("03d5e753-6f9d-447a-94ce-39063d17e673"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2490), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("03f8121a-04c9-4d55-9e87-fff9bed02177"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2720), null, 6, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0400b025-db77-4289-8b3a-ad00497191f7"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4140), null, 6, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("041d511f-a4df-4eba-a8db-48d569296fb2"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(330), null, 5, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0467a717-ce36-47e3-a252-85dcf409f40a"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1240), null, 5, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("05354bd9-e552-41a3-be43-91edc578dc5a"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1640), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0593f1ae-56cc-429c-8a7a-efbcad688812"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(620), null, 8, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("062714d7-60bb-408d-9429-e5547dd47a16"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4610), null, 7, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0657be45-dba1-4a0a-b4b9-5dfc47ebad94"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3080), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("06a394cf-21ac-482c-bc1c-f9b97392d359"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1410), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0714c88e-7089-427d-9ade-70a563d67bc6"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3440), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("079b8060-7c12-446e-bee8-317b2f92d965"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5520), null, 6, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("08282403-7544-46f7-8471-8a88b8296888"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3300), null, 5, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("084caa61-0e02-4731-911d-8f1b7c9dc378"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4220), null, 5, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0854a533-aab4-4ed7-a81d-8c629866705b"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3120), null, 6, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("085c7833-f047-4c98-8eff-af9fffc40028"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(180), null, 6, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("08877b20-32ac-4c55-ad59-8a2b49ab4dd3"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1970), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("089c2f6b-8087-45e9-93ef-48a31d74c296"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2030), null, 7, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("08beef27-99f2-494b-a3f7-40ce9ba56cf8"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(880), null, 8, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("09f2161b-4503-439b-94c7-6a3b756b7c87"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3370), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0a649b13-e8a5-4c97-a135-9f611da510f4"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5430), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0a79a075-e0fc-4fe7-98ac-eb8eaeff84d4"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1910), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0ac7b8b9-11fa-42b5-8f0c-1508d87b2d30"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4130), null, 7, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0bb8e805-9bd8-4d8c-9556-5fb3e005991e"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1740), null, 7, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0bebc675-3161-44bb-a9e5-69fcf86ec481"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4200), null, 7, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0c16c55b-b14f-45f7-8e07-a87492b96dd9"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5370), null, 7, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0c2784aa-a5dd-4730-96ab-37320ad4485e"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3130), null, 5, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0c54b39c-ccff-4c9c-b01b-6d1b423fde3e"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1870), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0c7e34d4-7dd3-4ca9-8859-a3bfd0b9053f"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1890), null, 6, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0cdaafb2-f701-4050-bc79-69e69ee59698"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(330), null, 4, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0d298223-1546-4640-9b3a-f71224551736"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1490), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0d874e13-ef48-49f0-bf50-5fbb2de98d9d"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3460), null, 7, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0ddd5184-dfa0-4568-b6cf-e91bd42d48e5"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3470), null, 6, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0e04aa69-04c9-4b87-99a8-dc79e279c7d5"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3340), null, 7, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0e3455e1-da0f-4e73-8bad-a2e6381248f9"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1010), null, 5, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0e453155-a7ff-4ac5-8a1d-be5e5553d858"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(280), null, 8, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0e6cdb7e-732d-4652-b8fe-b9ac385770d0"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1000), null, 8, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0e88cc1a-b039-40c6-b88c-963f574adb39"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1990), null, 7, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0ebce08a-b18e-47a2-89b9-b0aee3fd0eec"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2130), null, 7, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0ece4e31-fd88-4775-9836-9c8094d35e25"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2570), null, 7, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("103f7176-e901-484f-969e-e2c6fa610efc"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1280), null, 7, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("10887cf8-2030-4f59-b576-d03dd89f337b"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1090), null, 5, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("10b1caed-71b1-474f-afc8-72b2dcb82670"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4370), null, 6, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("11d544f8-58af-4b1f-baaf-6ab6ae02e1f1"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(930), null, 7, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("11fd03b8-d5cb-4891-aad7-5abba0edb3fa"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4870), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1229042e-75b1-4de0-934e-b3dfa6cc4f1c"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1580), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1245aedf-e55f-4d87-8e87-10e6205f6c3b"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(570), null, 5, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1260306a-faa4-44c6-81b8-945d09792901"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1100), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("126867ee-a9dd-4753-9eef-9bccddea8630"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5160), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1270dcaa-3081-49e3-9545-90296e88e3a8"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4230), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("12c755df-4e01-4704-8df6-fcd79e2d484c"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3330), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("12f423f6-f023-496c-be0b-e81876abffd1"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4300), null, 5, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("130b5695-710e-4d2a-a1c4-58c01ea81e60"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4180), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("132373d3-937a-4dd3-9fcc-16fa8a37cba4"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(160), null, 5, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("135f4b14-97ab-4f83-89cd-f51b315532fb"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(310), null, 8, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("145f1ae6-cf15-4034-903f-f345a45e14ec"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(120), null, 5, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1489614d-5da0-4faa-b692-b46356598690"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2150), null, 5, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("15130179-c8fd-43ec-8f49-fcde83629e02"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2460), null, 5, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("155ee0e1-ea12-4d83-a74e-f61c99fe5110"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5350), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("157cb7c7-3208-418b-bc38-6344f03d8045"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1020), null, 8, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1640e6b0-415b-4e08-b0d5-28dc29e9549d"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(830), null, 6, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("16eca80f-23f1-427c-8a6b-5974d14328b7"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1790), null, 6, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("16ef7280-bd8b-4c4c-9c72-5321e8a56689"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1190), null, 7, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("179f655a-95d8-4251-91c0-cb6b7ffa2fb8"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3930), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("181cde1c-cdbd-4853-b3f9-f451c6448108"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1240), null, 6, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("183cf898-4087-4c4d-bd09-738513407436"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4470), null, 7, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1935247c-77f6-4feb-bf97-9f746f3d441d"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2000), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("19999659-2167-4c86-918e-5766ca64fb6b"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3390), null, 7, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("19edcbc9-0d10-4eb5-b64c-7aa04c9b9fda"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2100), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("19f0e0ae-3856-416f-9d5e-108cfe390bd2"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(720), null, 4, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1a75643c-0692-4639-b8cd-d3b7c11f9a52"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1730), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1ae3f5f4-f179-4a4a-b7a3-0ce08dbc5623"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(380), null, 7, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1af48ef2-249c-448f-8e8c-e69750c42d28"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2380), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1b596f4e-fcfa-4a27-b0d3-7b7a5d56153c"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(970), null, 6, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1bdb241d-7297-4281-95c2-d322ae9460dc"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3250), null, 6, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1d0456e0-eece-477b-8b80-e82e44b84579"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1530), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1d0ad360-af5f-4691-a8fd-3b3a829a3460"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1570), null, 5, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1d551090-ce71-4c1c-a183-d3a3acae53e2"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2240), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1d95560d-9a4b-448c-ad9f-80670f32b41c"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3240), null, 7, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1dd612d6-15fd-4243-bd32-b618cd9fbf2e"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4830), null, 7, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1ded89c4-e7ca-423b-a6be-0e0395fec2f7"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1050), null, 4, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1e28b190-7b72-4ddf-9070-b9ac1aca2ff0"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(420), null, 7, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1e31ecca-4ffc-4908-9439-839ebe925cf1"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(620), null, 4, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2053234f-b814-4144-b22f-825b258b9acf"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2300), null, 7, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("20a081dc-16a8-40c0-89b6-bd21126a326d"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2400), null, 6, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("215b7bfe-d99b-4dca-8da9-a0028eabd80c"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3860), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("218db2ff-be2f-420b-8b67-174ed04d39d4"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(410), null, 8, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("21a381ed-db10-4cd9-a0bc-c90d1322967d"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1690), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("21fbdbb7-77ce-4edd-88fc-500747197080"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2870), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("222c7981-fa16-421d-a0ab-35f980cbe784"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3100), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("235b44b9-6f2b-4153-bdf8-d0a30b34d4fa"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2250), null, 7, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("243a64d3-aa36-4670-ac33-47256025aa57"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2210), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2447ab18-11c1-4a71-a1b6-2c529f389de1"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1960), null, 5, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2453bb92-bf46-4933-b28c-7438abb92402"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1300), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2486fe0b-a1db-4087-b7a7-88b8c9c90d29"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(780), null, 8, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2511c32a-ead9-4c1f-ada6-8ff3f8818370"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(670), null, 7, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("25588b30-0841-4efe-aec7-350c9d4552fd"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2080), null, 6, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("258eb8ef-0743-4175-96ba-fd927a67aa13"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1950), null, 7, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("266aa9d2-10cc-4da4-9f35-e5d22c66d5f1"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1170), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("26cc60f5-ffc3-492b-b79b-dc7f1c936f09"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2710), null, 7, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("26d44eef-e811-4baa-899d-c6ffdfe52641"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4890), null, 7, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("26e10bd6-d91a-420a-8b44-e1b22b925aab"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3380), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("27149101-d33a-4603-b5e8-3c47f4fcb479"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3660), null, 5, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("28666cdf-440d-44db-b639-2341cd37a2e5"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(950), null, 4, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2875b0ad-66f2-46cd-83b3-47dc4238e837"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(920), null, 8, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("28d9d4e3-4d70-45fd-964d-74c75f303e32"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(990), null, 4, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("291793b4-4656-4064-8420-1ec7f07bb1a4"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2260), null, 6, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("29a4be1a-3561-4c74-be5a-437421dc8823"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1440), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2af3b15e-040d-49c0-aefc-0efefd481fa8"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1920), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2bcb1d1a-fe19-41ba-9fd0-e106c616c716"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(820), null, 8, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2c18cdee-39c9-4804-b6ac-a4d165d42fff"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3840), null, 5, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2c2cede9-6250-47b0-a2e1-24833ed5a86b"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(370), null, 8, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2d279ded-ae5b-4389-864d-d3f5aa778707"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1590), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2d39ac3c-be79-42a6-91c1-65277da0e515"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4640), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2d3af1b7-2176-4cad-80d8-896ca4eba2b9"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(430), null, 5, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2deecc0b-db0e-46ae-8805-9e74b1cb5220"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1220), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2e402c1f-f74f-40d1-956c-d137c331df46"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(840), null, 4, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2e64ed8c-f63e-45ed-814c-d7b123f57c1b"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(660), null, 8, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("306f8215-02f3-4670-809f-9ab3ec8f6988"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(450), null, 7, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("30ee0a0e-8293-4439-be34-3ba37d376e03"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3450), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3155f246-898a-4ffd-8d93-005301125628"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5270), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("32dcfb7d-db10-42a4-a2c4-a89e19d1a998"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1210), null, 5, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("32f15fab-d1d4-4954-8fb3-fb620303c3dd"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(100), null, 8, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("331cd6bc-d4de-4673-9178-5a2a59ab51c2"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2320), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("33a1bd3f-5cb7-45dc-87f5-00e06e2f3f1b"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5400), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("34bf3f41-bab2-41b5-b59c-a15e2323e14e"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2310), null, 5, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("34fbbad4-c049-4fd0-951a-d359ed13e2ad"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2620), null, 5, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("354eef64-875b-4922-9113-58c184a62f09"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1770), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("35ab620d-c798-4811-a455-c48b3b449506"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(960), null, 8, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("35bef29c-9afe-47f6-8871-5fe43679d060"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4330), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("362e2782-5ad8-45dd-b635-e9bfa6d24043"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2670), null, 6, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("362e86b0-d7f0-44e7-8312-ba87f2ca33be"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4660), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3733477f-04d4-4a0b-9c59-a7015c02c8a3"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1420), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("376b1deb-ecfa-4aca-8931-15f824a2e99e"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2290), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3981124f-b55a-4772-a62b-a10016e0ea6d"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3270), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("39b6f034-b9a7-4a3c-9727-ddc35f99e14f"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4260), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3ad9bce3-8c83-4e2d-b7b3-6f2dc4b39f63"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3520), null, 7, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3b382dde-b3e9-4783-a8eb-1545cc662b1a"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4420), null, 7, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3b63d7a4-cebc-4934-ae63-c378101f0494"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2500), null, 7, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3b981b10-54c6-4f34-a715-1b33fb29e2b0"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2600), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3c497e34-ce02-4ddf-8933-f1cfaafbe0c8"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(530), null, 6, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3d28d36b-e23f-4920-8b88-f1112bbf5dda"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4780), null, 6, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3e76cc38-023b-4ffa-8813-d615812f1118"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2890), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3f158a27-cc2a-4e80-8a32-03076ed57d8c"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(560), null, 7, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("40078c4e-6d95-44ea-9914-6fb05f8980f7"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1840), null, 6, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("40224c53-5a1b-4437-8c7a-13f18a762d92"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2820), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4078b070-5f17-4e36-a740-575d6c4303f7"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1500), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("40f6fea9-057d-467a-9b50-2faeb62ef45c"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2750), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4119c342-ae7b-4999-a8c0-c2fe6b06c548"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(580), null, 4, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("41a3c2ae-4345-4178-bc94-693c76ed4cd3"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(930), null, 6, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("41b786f1-f244-4dfd-982d-b45edcd1a2d0"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1290), null, 5, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4206fd76-f050-4a17-8d52-5d02d10134e6"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3640), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4237c376-2f38-41af-9f32-13391495708a"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2480), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4259d041-2cf3-4ba4-a8e7-59a6caf58cbd"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3200), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4287bfe6-4242-4bb4-a93d-c5ce059d0954"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2270), null, 5, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("42c5b589-e6b7-454f-9c5e-8f272a1a57f6"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2410), null, 5, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("43527a59-fc25-4f59-a4a5-4ab797070f5f"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2610), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("43558851-c754-4a40-8324-9a09f9c1bc1c"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1950), null, 6, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("43927d39-f332-42c3-9512-63717bf3d48e"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5530), null, 5, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("44337c80-c282-4826-8b66-f54d6dcb4798"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3910), null, 5, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("44b27bb9-4f29-4243-b245-d28714399e51"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2110), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("455f93fd-b285-48af-ab6c-8e31d864df88"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1080), null, 6, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("45cc7007-1e97-488b-b4bd-9667e27f38c5"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2540), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("45e5400a-3422-46d7-9f93-fa6b29fc5a05"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(600), null, 6, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("48c2135a-27e4-45e8-9d02-219048b8048c"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1140), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("49089133-d0ab-4778-b8ec-219f50d2bc49"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2910), null, 6, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("49376d77-d5c6-4d02-9e89-b0dfd03b948f"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2730), null, 5, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("498963e6-4f24-461b-94a0-1f32fac85514"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2010), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4a1ad856-6f68-4643-9ff2-c2e38a198045"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1520), null, 5, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4a797c27-f8da-4c2d-8b29-1d24851c2cb5"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4360), null, 7, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4ac611e3-ef4c-49d2-9560-f7c5634b4d4c"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4530), null, 7, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4af74848-1bd7-4488-81fa-77f37c31e043"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1380), null, 7, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4b681e8c-1c73-4f6f-ae8c-6bf6fbfc56c3"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2050), null, 5, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4b6f2e71-d587-45fd-abd4-5eca9e94e201"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5200), null, 6, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4b7be8d0-d2fa-4642-a738-2c1b5ddaf4c2"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3670), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4c30b415-b854-46b0-bd1a-4bea05420956"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1050), null, 5, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4c47fd05-7aa4-4906-8872-f95115893ccb"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(550), null, 8, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4c95c826-afcd-4636-b79f-149b906825f8"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3830), null, 6, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4cc39683-c319-48d7-b128-4335fb87845e"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2770), null, 7, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4cd94ace-991e-4543-802f-3dabb75bcfaf"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3020), null, 5, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4d38f5a3-3332-4f40-b10e-d22e2cc17eec"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(390), null, 5, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4d5b0c99-922b-40c1-8741-bfefbd4009cb"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(170), null, 8, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4d6a2ccd-08f0-4ce3-abe7-fe19531ff69a"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3600), null, 7, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4dc65e77-bcfd-480d-80d5-cab823143eef"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4620), null, 6, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4f694c32-18ea-4982-b099-10e243f25011"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3260), null, 5, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4fb90ba0-e229-43bb-805f-fa3ec3677676"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3580), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("508ebc29-a0d8-48aa-a978-7531b479a359"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4250), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("50d545f1-40a7-471a-98c3-e221a5fc3cc3"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3420), null, 5, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("50dd9b36-ee4d-4436-b129-5aea364abac3"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(60), null, 8, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("512e5fa9-e78d-45ae-b77c-f123c4cd935f"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(140), null, 7, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5130bc41-cf46-4cec-a57d-35fea0d15db1"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2330), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5227b47a-f413-4c51-a003-7d745bd861d8"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2590), null, 5, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("53aca0fd-5a98-4910-91e7-0da49f3af26e"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1780), null, 7, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("53f8d677-1ac3-4ee0-ba3c-881f0065c48b"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2320), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("54ac9c65-d9a8-40c2-8668-24e807a0730c"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(590), null, 8, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("559fa433-67a3-4255-bd7c-89b029b82ea7"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5330), null, 5, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("55edba4b-2666-4b3b-9f54-6fbfa681085c"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(90), null, 5, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5809df1c-d297-49c6-b20d-2384b5eeda08"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4980), null, 5, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("580e6711-8c50-4561-a751-edc9ee693fde"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(270), null, 4, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5840a4e3-f5e0-4f59-9684-2f2cd425598b"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2530), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5844faf7-dae0-4855-a7e8-c9594709528e"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4450), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("58d7c5a4-650b-4602-a651-fcab61eacd41"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5480), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("59840bba-f950-47c5-bd18-87afe11f8776"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(350), null, 7, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("59c75068-64ae-43f2-8758-3b7e6b972d8f"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(420), null, 6, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5a0f57d6-a3c0-4033-9144-de181c25d8c4"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2970), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5b148df4-90c4-476f-8d02-9961b2413d5b"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2120), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5bf1a6b8-a295-4455-9a1e-3f7870e3817b"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1010), null, 4, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5c1706e4-5308-4c28-8744-77e10e8e0249"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5450), null, 6, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5c4cae15-d123-4fc6-994b-212facb8bad5"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(650), null, 4, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5c9d1a6a-d76e-49ae-8c53-5c22b3594cc1"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1130), null, 5, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5ca4ca0d-2667-4ee1-92fa-9725121f23e9"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1550), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5cfdb0f5-d1f2-435c-a916-e16d084f2492"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5240), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5d21450f-330b-4e62-bbe0-da9cf59cd8f1"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1930), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5e1df4e0-d4dd-4b00-85fc-3b19d3bda391"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1350), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5e77a107-a227-4786-9ac2-3a0f2c9697a1"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2440), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5f64fc1e-7973-4597-8e06-344d0b8f7704"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(690), null, 8, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5fd5b07f-1748-4cdf-8efd-e7f2efb552ca"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(850), null, 7, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5fe30ec9-7f57-40a2-aa23-0e88bf8ac3e3"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4480), null, 6, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5ffe607b-9661-492e-a0b3-ff1a4a4094d4"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4510), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6037772a-cefd-4e44-ab52-7fee2dac4bac"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(790), null, 6, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("605256fb-e87c-4032-aee3-08408c2953ba"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3650), null, 7, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("607bded5-98c1-4b72-a36b-54bd5a64835a"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3620), null, 5, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60e12d29-d3fa-4c8d-9c75-722283e98461"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(350), null, 6, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60f70826-889f-447c-acde-2539f2a8a5ee"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3700), null, 7, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("61116212-7092-4fc6-98f6-5c61d1ac6bbf"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2990), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("61427f98-9612-4d19-a12d-11cf718244ac"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(850), null, 8, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("62252a02-a3bb-4d71-ac51-9568df322b16"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5460), null, 5, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("62c2cb95-dc7d-4e8e-8805-230e29143c04"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3630), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("62ffcf1d-eb4e-477c-ba3e-a46ac9d2a9ac"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2160), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6334f174-e6d0-4eb7-b19c-8ef667f641aa"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3750), null, 7, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6433bba8-1f7f-4a73-abca-18ff4113da5c"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1630), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("66190969-a8ab-4fc5-b8e0-f74c9983e605"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1140), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("66909dd2-3f06-4968-b9e2-9d94c474d06b"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4560), null, 5, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("66945bc2-193f-419d-9128-fa6674bca8c0"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3730), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("66db5415-1bda-49dc-aca0-ae7917235c8e"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(440), null, 4, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("67501664-80ac-48d8-a640-3d2ac55cb33c"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1370), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("67daa47a-806f-456d-a9ba-2f8f63f452b1"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3960), null, 7, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("68227254-2953-4d1b-a288-fc2729daad80"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2760), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("684614e7-33c5-4990-be1e-d5eed5517ef5"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3060), null, 6, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("69d08e9c-15e8-4c18-bdaf-9dd107f88490"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(480), null, 7, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6a695324-9715-4c9d-98ad-ff26bb93b15a"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3920), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6b0f1b41-f8e8-41b4-8230-f4db38f88609"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5500), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6b66dd24-9e1e-439c-9049-441f5fe7fd57"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5130), null, 5, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6b829f95-a1b5-4f97-9e69-3047b63aefda"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1820), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6bf82d02-8dfb-4a00-85fa-bc590406cd05"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(90), null, 4, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6d5c9427-b47c-4ca4-b14a-5a1cde5e475c"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4500), null, 5, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6db1c368-ebce-41aa-b2de-b2a001e4d0a1"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(130), null, 4, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6dec429f-94fc-4946-8eae-9062a699c44a"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4190), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6f005641-39a9-45c0-922d-17becbffc4a8"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4590), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6f116e2b-75ff-4764-9e6e-8908a33e16df"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2200), null, 6, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6fcaa99d-28a6-45d2-bd87-56d1c24a724a"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3170), null, 7, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6fd3bc6e-ba8b-4a22-9141-357eac0bc918"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(880), null, 4, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6fdaa5ff-31b4-4353-bef6-896e9668be81"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5220), null, 5, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("70181f9d-9d26-4865-b1e5-8e53a514bfe0"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3940), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("705acd05-999f-4f02-a25e-cf500714baed"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(760), null, 4, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("70753671-3fb3-4d4e-8f59-be8d0dae6853"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1730), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("71c80471-23e7-450c-b780-b4bfa2ab0fd0"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2640), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("71d4b82f-16a8-4c48-98a1-0f77241eff76"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2340), null, 7, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("72507f8c-adb5-4193-a8ff-15664ba2872a"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4900), null, 6, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("72b8fc59-efe2-4eb3-b560-dc5fae09e7ef"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2430), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7361b129-956c-4b94-bcc5-00d23c26232f"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(310), null, 7, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7388b962-1243-428c-b9f8-ae1bb75dcabe"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5080), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("739cc564-fd2e-4830-9257-009d59ee91ec"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1670), null, 6, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("73ed591b-1162-4935-a952-e3089e0ae553"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(530), null, 5, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("750b1dcb-06c2-49db-8c60-d49fa3b40b74"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3800), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7540d40d-4a8c-4f30-a9e1-d3faf63db702"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3490), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7674c9a6-19d0-4330-9491-7853bb99fb34"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(700), null, 7, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7687dc9c-dcf9-4240-865f-4f85d1600b80"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1820), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("777bbaa3-b5a6-48ea-ad93-e9efc3a15099"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(490), null, 6, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("779e611c-cd74-4513-8d8f-2827bd6fa5f8"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1620), null, 5, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7815d72d-ae8d-423a-856d-b6bcf09a1b85"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(220), null, 6, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("788ddf19-1cd4-43e2-b2c1-d0326978ad57"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2780), null, 6, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("78b56b7c-07d6-4df8-8879-f529231b02d6"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(290), null, 6, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("78fd8dda-b331-418c-a235-83603f70f4cd"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1880), null, 7, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("79690ca2-82d1-4a3d-a286-8ab47278e9ea"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4010), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("79af1c8a-2b9e-4843-8d3f-ef8a46fac9dc"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(680), null, 5, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7a0ba70d-88ca-4bc0-a474-7024eb20ef05"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3220), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7a49e0d9-9740-420a-8498-cfc9d9f9d9f1"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4650), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7ae7b7c1-9f37-41fc-b03c-df836ffb3811"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5030), null, 7, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7af3da03-c945-4037-b994-865779406e0f"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(770), null, 5, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7af40e2b-4d25-4e07-8518-f6f172d477cb"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3690), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7bb59299-0f48-4e99-85df-8c9a757a326a"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(230), null, 4, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7c435864-9aaa-4591-a0d5-eb0e402dd9e2"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1680), null, 5, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7c9eb0d2-a620-46c6-a4e1-a8fdc4d7ddd5"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1180), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7cfb483b-c72a-4282-a8f0-006060c43dea"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(110), null, 7, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7d309b53-ff81-41d7-b98d-5e3e25c59c9e"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3400), null, 6, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7d66dd51-62f0-40b1-822c-13c1b2e26972"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4840), null, 5, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7f73ab87-5ce9-43a7-9cce-b7e1a01145f3"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4020), null, 7, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7f9356b8-56d7-4e11-a6e7-b5ff50110d07"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3500), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7fcc51b7-1638-4f5b-aebd-230e3e970388"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(540), null, 4, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8022fb34-838a-4988-b780-289e75980a0e"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2920), null, 5, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("809e47dd-cdd8-454d-9285-27c9b119425d"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3000), null, 7, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("80da03ba-4a43-42ad-9f51-cfedf30205e9"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1510), null, 7, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8162404e-687b-450a-be26-ba1ca6e77a9a"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(940), null, 5, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("818e9421-8047-421a-93d7-531cf5a11d89"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1710), null, 5, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("81f666ee-c9dd-423d-8b59-6515502b23d0"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2180), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("829be7f1-70f3-4881-befb-a28224b93f59"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4740), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("82a7b35f-a041-454b-87a0-421dd308ca4f"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5000), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("83b9b880-97f1-4a03-a834-db2c2b40fca1"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5250), null, 7, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("83f7fe1a-5c02-4100-8b61-1e0dbe6df15d"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(890), null, 7, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("84376183-44d9-44dd-aacf-540a6dd2165a"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(900), null, 6, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("84a3d2f4-bcf3-4094-878a-339abfeaab63"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3480), null, 5, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("84dbc4b7-7d24-48b2-8d26-b5de592bb015"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1370), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("851c2cf7-1cf6-4809-9493-a2b02818c13a"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3360), null, 5, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("852e0918-5007-440e-9bec-f3dadd0c947b"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1290), null, 6, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("854c75fb-c177-4715-aebd-9c1c728c3ced"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1690), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("85a8510c-8d13-44eb-ad40-d67feb65c590"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4170), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("85df2953-a7fb-446a-9b98-61bdd27523cb"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1310), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("86174f56-7965-415e-a85f-f08bfca0bcf8"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(240), null, 8, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("862525f8-f057-4da7-bc9f-2b319141d0f7"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3540), null, 5, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("86ab4c08-eaf7-480d-ba8b-8e86b0466e83"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5050), null, 5, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("87213eb3-e3e3-4b15-902b-fa17bcdcf89f"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4340), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8755d38a-af0a-4be2-bd82-41b5a2101e0f"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(210), null, 7, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("877a70fc-2e8c-4631-a025-ad5400952db7"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(590), null, 7, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("879ae439-b9ac-48e7-ac54-fd1ab4002761"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3550), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("87b28f40-347f-4fa0-8757-731de77590d2"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3180), null, 6, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("87f49ca8-3e0f-464d-af89-79a985be631f"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5190), null, 7, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8803b85c-1ebc-4348-8e64-2ebf9d175618"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4730), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("88316d37-ea30-4743-bf92-5f4b0d43f11d"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2830), null, 7, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("884a3800-906b-426f-8b7e-79e2a05019e3"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4800), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("89165ee0-9e74-4d91-8ad3-fb3f03c96b8e"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3030), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("891799da-5b43-422e-89c7-901117674526"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4210), null, 6, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("89d7bb46-c8a2-4f24-b7bc-21d9e7b5e79d"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(370), null, 4, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("89f6401a-182e-4e74-9c1c-e28fd9199c95"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(460), null, 5, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8b259ad8-253a-49d3-a6a5-f6503584ed22"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1940), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8c4cc973-7f94-4f4b-b5fd-b6495241a50d"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1850), null, 5, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8c98cc7e-cb1b-4603-acaa-5658df6c4ce1"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3230), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8c9deb42-7049-4087-bfde-4d3dfbb361f4"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3090), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8ced5b1e-049e-4ebf-91e3-d98335eb46bf"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1420), null, 7, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8d06be20-38c1-4cf3-8957-9a217cf22cb1"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(810), null, 4, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8d6160bd-6f75-4bc9-b94c-6bb8874ef4fb"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5490), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8fa4182f-38d2-42ac-b20d-6fffe462fd01"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2700), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("909899fb-bc2b-45b2-a4fc-6651ee1a6fda"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4550), null, 6, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("90c5dd38-d827-425e-982c-43d23e3a91b6"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4570), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9126a192-0fe9-486d-9935-97b7ef2168f8"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1100), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("91448dcd-4f19-4c81-a95c-3d9865de7e15"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1650), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("91861280-5d74-43af-8fb2-7778813389f1"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4000), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("92324877-f13b-4f4c-b1f1-b54e9263e4f2"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2200), null, 5, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9299ce44-bd64-4f5d-8868-1fbb456cdfc3"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1980), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("92a94a7b-3671-4013-9169-1f91f9251c4c"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1550), null, 7, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("930a04d2-4ae4-44ef-9974-ac4d7e12466f"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3770), null, 6, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9524ad45-3d6c-42e6-8b77-30125033d6e2"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(910), null, 4, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("953f218c-b16e-4bbe-ae39-c69cb383f993"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(140), null, 8, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("96808eca-fe1c-4e2d-b700-855aa7efa473"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2860), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("96998122-d9f4-4977-84be-dbe7d1b9aed0"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2960), null, 5, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("974d32ec-ac3d-4029-94bb-74f3912c58fe"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5420), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("984615e9-2e13-4be0-aa26-c96b431c9f5c"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2280), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("998013a6-3bc1-41c6-95bd-ff68263fb7b9"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3190), null, 5, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9a1b440c-542c-43d7-acfa-410a0e8562e5"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2040), null, 6, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9a5fe97b-6c1a-445b-8c24-e34463df2911"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5560), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9aa135ca-46c2-4fa9-bfa3-68ab40cf63e2"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2980), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9aa6a78e-04e2-46f5-be9b-c2083e77ec15"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3790), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9ae59d6a-c246-4e98-8def-afa73e627a95"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2640), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9c726994-0428-4b7a-947e-3bdb97efe4df"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3780), null, 5, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9cf2c064-b60b-4f5b-bffc-548359abf07e"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(560), null, 6, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9d458603-81ab-4788-b711-46e1aa0db14c"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(480), null, 8, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9db7f689-ee3c-4b01-9ad1-9654dd764fd9"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5260), null, 5, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9e02f4ed-92d4-4ef3-881b-f39663468305"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1660), null, 7, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9e1088f1-df90-41c4-9fe4-21de7345b1d6"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4950), null, 7, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9ef2c66d-5ce5-4129-818d-31a77934ea4c"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5510), null, 7, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9f95daad-8897-4a18-8943-8f3fd6dbe2d8"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4400), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a00a317a-98e3-45f1-82b0-4c5f2279ea86"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2690), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a0e29ef6-522d-497b-bc54-475ef426da13"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(750), null, 5, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a0eb9f4a-5109-4c96-b898-361a67c9c756"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1800), null, 5, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a17fc095-c8fa-4545-b60d-db7e2731af56"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2940), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a198371a-834a-45f4-9541-0dcf3c8c50bd"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4440), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a204255c-843e-4f8f-8b4b-637a32b8314d"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4320), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a261171d-c4ab-4b0f-bd83-ac1e8e3319cc"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4810), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a31da766-7760-49f5-a3e5-5f611b25f11d"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4720), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a32485b9-c3fb-4675-bf42-a5783d0a571d"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3610), null, 6, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a34e46ed-40d2-4ba9-9a35-21fed078f32b"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(340), null, 8, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a35522ae-9911-47ad-a18b-bebb1680d8ba"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4030), null, 5, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a3a7ac9d-cdce-47eb-976f-b224f59f26a6"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3040), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a50fd362-0b09-4fd2-8ab6-c7accfb3fd90"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1830), null, 7, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a5264946-ce55-417e-8faf-4d29cf8a848a"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2180), null, 7, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a5f2f74a-847b-4549-9eea-e03097b8202c"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(190), null, 5, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a7121b73-3c0d-4863-a8ea-f3b81650eef5"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3290), null, 7, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a87c671b-e021-4918-bbc7-dbabbdb619a4"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(740), null, 6, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a9c1bcc7-2039-473b-9e20-f785e19a8f13"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1110), null, 7, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a9c2d1ba-8eee-4d2d-a8dc-03ccbe4550c7"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3990), null, 5, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a9d2e3b7-1d42-41fe-ba46-3d9e2195e1c9"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3900), null, 6, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("aa055622-3230-446a-a1c7-2109d92d720a"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1610), null, 6, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("aa1345b6-0652-4c45-afc1-89c403e1323d"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4580), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("aa30845c-8521-4664-a628-6e4c4736cc1a"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4070), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("aa87bc5c-1058-4190-afe9-c14617865b0f"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4090), null, 6, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("aadc8b21-ebda-4fcb-9d2d-b4ddedf9cd49"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(320), null, 6, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("aadcd2ab-d54e-4fb0-b848-59a35e763bef"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1470), null, 6, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ab470bc7-d35a-4a2f-9e2d-3ca743aa9108"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1330), null, 6, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ab7e2b9a-9a7e-4b69-a17b-3e51e9a77f72"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2460), null, 6, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("abffc373-2fef-4def-a725-aba074aeadf3"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(150), null, 6, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ac340b55-812c-4eee-a688-038011436d53"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4150), null, 5, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ac776381-397c-4906-925e-9fd3f436229a"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3740), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("acd351e7-1fcb-4442-86af-1706807254c3"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(200), null, 4, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ad1e23c6-61d5-4b69-ad3e-839927f8f398"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5310), null, 7, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("adc5fb98-a8fd-4684-a7c1-93a601d93a9f"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(500), null, 5, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("addcb64c-be14-401d-ab89-fa87aee5d78f"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5290), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("aff32ff8-0946-4ab9-8ae6-65dde982dbb1"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4430), null, 5, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b009c82d-a4ea-4e58-b181-db92607729ed"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(470), null, 4, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b19bb2f8-a3a7-4164-b928-4546c7c5ffac"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(250), null, 6, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b4271b7e-b6bc-4e44-967d-44bdb10e05ed"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5440), null, 7, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b4b3d8d4-3807-47ba-bb00-f852a5dba393"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2520), null, 5, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b4cfcaac-bca0-4260-81ee-e9198cc3715a"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4060), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b5408df2-0362-43c4-b61d-a76211515861"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1650), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b5efb8c7-28b6-42aa-9f4e-304e7e11ba8a"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5020), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b6f27edc-36d9-4a53-9506-b5a7d0335b91"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4100), null, 5, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b6f5d486-d4ab-4a21-b74a-05c17d8aff13"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3880), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b78164be-55c2-40be-a993-96f19a4f068f"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5060), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b8b2fa56-3602-44ac-8437-4f3712fb4c8a"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1150), null, 7, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ba056227-e7a6-4cf6-846d-ebe01570ac42"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(640), null, 6, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ba465df8-8e9b-4e11-a96c-b33c8cc6fcbe"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2020), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bac78066-11f4-4111-b1b0-019bc1adcacb"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3680), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bb275733-7688-411d-8df0-951c00b56656"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(180), null, 7, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bb67d571-54cc-4658-9ad7-08ac61b3e5b9"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2950), null, 7, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bbf53269-1e8c-4e39-93f3-0f48c34be0c0"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(730), null, 8, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bc060bb5-f20a-412f-95e9-eef36ebcb22b"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4110), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bcee3303-6ff2-4b95-8a22-3db6e846b6aa"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(80), null, 6, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("be062c48-c1af-4fde-bcd0-267457bfe488"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1330), null, 7, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("be13816a-4a43-4395-b76f-82e4f2bbc445"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1070), null, 7, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("be1b319f-c6e1-48da-959e-48dc21d16436"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4630), null, 5, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bea4331d-4a5c-4334-97d0-6cd3cd58fb6a"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(120), null, 6, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bed7fd1e-c071-4338-8f5c-89e9c4dbc9ba"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1780), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bf2a0b73-8180-4963-ac84-f624fc855c97"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4970), null, 6, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bfe51c1f-f32b-4fef-8afc-265211352eb2"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4790), null, 5, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bff7e240-f15c-4c8c-8329-66d4c8b6e95d"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1230), null, 7, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c06b03ee-f51a-42a7-9644-269eeffed6a0"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2510), null, 6, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c07effb8-925e-4a6b-ac9a-88b307f12980"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2580), null, 6, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c09a2c48-4aa2-4b4f-8a91-828fd0f5a727"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2350), null, 6, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c17fb8a7-45af-46a8-be96-0ad3f8e1d8df"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1760), null, 5, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c18f2c49-8464-47be-bdbb-7f1f7df2dd44"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1450), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c1e76229-5014-4e7f-aad5-b32bed929b96"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(690), null, 4, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c1f8748d-76ca-4943-a356-2b80d1fffb68"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5320), null, 6, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c274054d-b035-4b5e-afe4-16054a0653d6"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1030), null, 7, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c28f97c5-3de6-41a0-adcd-8f3d94ef686d"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3050), null, 7, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c2db467b-5d9c-46ba-951b-850da528ea81"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(980), null, 5, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c30fc731-c0b4-4fe2-8b4b-a2ba31a05b71"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1900), null, 5, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c373faa9-d620-4d7b-812d-31ba1d6d1469"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(250), null, 7, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c38572ac-4627-41e2-9b7e-a1c587dca4d5"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1210), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c3a76550-1400-423a-bf2a-e17bf068e5fb"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2370), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c47e079f-7d82-4255-ae33-9e3a82072cef"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4270), null, 7, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c49364c8-016a-4fa2-b14e-c8fbf48710cb"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4520), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c4b93022-4f67-4dde-81f4-a7fa76b6be36"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(400), null, 4, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c501897b-d82a-4298-911b-8bee43949c6d"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4040), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c523c669-e303-4f94-80ca-bde4afc893f8"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4850), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c52ddd3e-6e04-44fa-8249-ed9cb18c42fa"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4920), null, 5, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c577dd20-4674-4281-8258-b361d1011d58"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1750), null, 6, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c5898e03-ca72-45a8-83b7-b22babb666f5"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5140), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c5fa56f6-f0d2-4e04-ab0c-4198bd8475a0"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3720), null, 5, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c6fa27ab-5138-40d4-b7d6-0a2abf09f308"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2470), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c731ac92-7aaa-41ba-a770-b223f67ad6b9"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3150), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c784575e-dbf3-4734-9aed-33e9387a1957"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(500), null, 4, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c7891a00-4459-415d-83cc-69b1a8493f28"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1600), null, 7, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c85c6ad4-ccf6-40af-81ad-0af82bc6e41d"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1460), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c8f92383-8e5a-4fb1-8b16-71324e8b4548"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2850), null, 5, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c910fcb1-dc48-4313-b3bf-57b00511f230"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4940), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c934d181-b31c-4b39-a797-98e83ccd7140"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3980), null, 6, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c9694824-a14a-476d-90e0-bc925a5eecaf"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5100), null, 7, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c96eb617-fb5d-4220-a7e9-6ac028a08f48"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1170), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c96fc925-30a6-46d1-bd4c-ecd3b1b7a9cd"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2650), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ca3be252-8330-485e-82a6-9029af15286e"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(910), null, 5, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ca6f4323-ff72-463f-a65c-bc836900bd56"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2390), null, 7, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cbc58f44-eae6-43aa-9629-bc575a386963"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3850), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cc53a6ab-a734-49fd-8a2b-fe8bff8869ad"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1320), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ccd99142-80db-4ca1-9baa-ff54feeff760"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2790), null, 5, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cf1ab770-41f7-4bf7-8707-a5e46209b7c1"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1120), null, 6, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cfbf9588-32ab-4719-b47d-e32e659f343d"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(160), null, 4, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cfe4f1bc-11f9-402d-a4cf-c4790ab4589a"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(230), null, 5, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d0023316-4d4b-4200-9a59-a75ed97ba322"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4710), null, 5, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d079e3ec-1b72-4ee8-a95e-c099993c0fa3"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5300), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d26c863f-9702-40b0-a5ea-e06b1921e740"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(70), null, 7, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d295a29c-8dc5-4768-acd3-9a7dfcc990b6"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1510), null, 6, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d319fc2a-bd42-45b9-9048-fea1d8869cf1"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2560), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d39ca44b-9a0f-49cb-8af1-3d5492b4ecf6"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2140), null, 6, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d42a31d7-3cd2-478a-b7d8-484b044866d9"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1600), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d47d41f9-9d27-4dcf-ae02-52ba1a0bb30e"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2840), null, 6, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d4e4e473-a281-4504-805a-4d8dc06074f0"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1160), null, 5, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d54008eb-d74f-4024-a9cf-5284f6d71614"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(210), null, 8, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d5da4048-5224-46b5-9197-3ae36d9e4ed5"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1260), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d650fb56-2485-4921-ab24-ad3e7fc6937c"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4930), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d67a6ad6-ad63-4b6f-9ab7-30167b92d367"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(360), null, 5, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d75882ed-9635-44ae-9e2d-7ec180f44c6a"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(830), null, 7, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d7aaaa7e-3782-4127-b21e-8c5c078c3ba7"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3560), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d8313247-7117-409c-9520-7e3d9544617e"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2810), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d8499adb-1bea-481e-9e3b-eb6a68fafdf0"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2080), null, 7, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d8715807-5fc6-4ca1-a967-2542bec2e681"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(800), null, 5, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d8aceab0-11e8-4180-8148-f99048051b5c"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2360), null, 5, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d8afebce-25a4-4e20-b4e6-9d1ef119310e"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3110), null, 7, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d8dff6e4-dcda-411a-920b-2aa606281757"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(460), null, 6, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("dabdb25c-6635-4be4-8ab7-90577746815b"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2090), null, 5, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("db3eedef-9301-4258-b0f6-25eeb3faec1f"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(640), null, 5, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("db92047a-116a-4bf7-a2cd-2ec521296fe3"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4770), null, 7, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("dc4f8f6e-eaa5-4d50-bbb7-87e51217f04b"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3320), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("dc51f123-173f-4824-8ae8-2ba73c19f2a6"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1470), null, 7, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("dd49903f-b93c-443e-9924-f054019c109d"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2170), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("dda5c20e-6cec-4d8f-9689-81f7f32552f7"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4080), null, 7, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ddf6c57d-7f4f-423d-b27c-c0ba623502ea"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1430), null, 5, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ddfc6165-fe8a-47b0-92e9-5abb4471fabf"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5360), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("dea76501-07aa-474d-abc2-4799b0f29058"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5150), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("df5fc2d9-0e0a-40c7-81b9-29d74ec97b99"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5040), null, 6, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("dfb15cca-7caa-4a3b-8e7f-c52401e87649"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1200), null, 6, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e05974bc-c01b-4991-8828-db588293f678"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(610), null, 5, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e0766a8a-0aa2-4f5b-9ce6-0c03b9745e7c"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1810), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e2176070-f0df-4c93-838f-d86a72bede1a"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1270), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e271cb72-f8db-42ba-b711-d2078f187990"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4310), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e309b2e7-5a19-4ccc-840a-c9af3510385c"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5180), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e30f5b44-9faa-488d-81b4-bb8c674c3cbc"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(770), null, 4, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e397dfa1-79bb-40e0-99a0-94b1c7025bdc"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(440), null, 8, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e3a17fb8-47e7-4738-8a48-10bf9b38b9a3"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2420), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e3b3ee53-d4c3-4976-952e-64d74f30d8b0"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1720), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e3b4d04f-6e54-425d-b162-1f719d1efb66"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2930), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e3d2b399-7cd9-4a1c-af0d-2fd0d1b0cdf4"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4690), null, 6, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e3f95dd7-7195-46a1-9867-d518b89e76de"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3210), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e488cddc-2a52-4ad9-9852-20485c9ac58a"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1060), null, 8, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e4b77ec0-61b9-422f-9e5e-97eab86339df"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1880), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e5144f83-2961-4c3f-b5dc-2316a2b1fb2f"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2740), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e54962c5-9f77-43eb-a1dd-03292536ec7c"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1400), null, 5, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e6702635-3909-4d7e-880b-110f1f07a524"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(960), null, 7, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e698970f-2ace-4240-beec-f18ae9dafb4a"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2070), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e6c7074e-d71a-4822-837e-e266c76c17bf"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(260), null, 5, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e767db09-d9a5-4f39-af71-f6c2eac6e5c8"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3350), null, 6, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e8f33974-b1e9-4b10-bda9-a474dea74db8"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3140), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("eae27812-bf69-4b6a-903c-e944a114895f"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1340), null, 5, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("eb442dbe-6554-4458-b72f-b63a048f08e6"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3820), null, 7, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ec2ca2bb-d692-4f84-a63e-41b0da247d5d"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2000), null, 5, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ecf12451-077d-4198-9fcb-ebae9d3a0a19"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5090), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ecf87b44-babd-4078-abf2-ba9010099793"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(630), null, 7, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ee026ec0-be15-445c-86d4-b8e987dcd5aa"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(300), null, 5, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ee340a20-e4a8-4da0-9aea-2316e45962ad"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2880), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ee6044ff-2749-4611-b228-6f9381764134"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3710), null, 6, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("eeb820be-4dab-462b-9d59-863d1ca3580c"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(520), null, 7, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("eece9c50-3bfb-4604-889e-18ec01950add"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2220), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ef94f5d3-ec39-4c9d-9524-3d0996461e1a"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3810), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("efc35d41-b273-4574-b9fd-f00f2484e247"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(860), null, 6, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f0c7e6c4-dd5a-4985-8f07-14eab3f722db"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1860), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f10f8efb-d14c-4bcf-a263-a683553c5e89"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2660), null, 7, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f12f9e3b-ef7c-4441-94a0-0a9cbf7ccda3"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5230), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f151a82a-15b8-46d8-9623-61b52a571f4d"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(710), null, 6, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f17fd9da-53e5-4661-8a20-eac4d20d7193"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4760), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f1bb2cb6-ae5d-4353-b323-9c38eecdf2e5"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3510), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f1f83cc9-4d78-4731-b9d0-cd4ed88f3513"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3160), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f2770d20-b13b-4724-993a-c92770a8ecbf"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1360), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f2f69f4d-7a75-448c-8427-cc55e355f176"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3280), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f4b11d27-3da5-45bf-8eaf-1b25b36ffb4d"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(280), null, 7, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f5765434-0e20-4860-bfe3-32a6c3683f2e"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3430), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f5fc13a1-2bc8-4428-a1ec-eb18f65f9951"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1700), null, 7, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f620925d-01be-4cae-8f6c-9680ea1c2663"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3310), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f70fd0fb-dcca-4922-a04d-50ca0f1eb0c1"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(670), null, 6, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f736082b-f08d-486c-b26d-29efd361e2f5"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5550), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f74159f3-af27-411d-a0b4-dc0a2a05e5b8"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(720), null, 5, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f761e75e-c6e7-48fd-ae4b-1fefda9b04b7"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3010), null, 6, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f7c23e8e-8b3c-4da0-a497-194eb26b0413"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2900), null, 7, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f7d4fa1b-94c4-44a9-a933-88361e43fa59"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3950), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f822a955-625b-421c-a2cd-e316811f526b"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3530), null, 6, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f8b9c902-715f-46c3-83bc-77053be4ecc3"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4390), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f8cd6595-5bb5-42d8-a950-75bbf75884a2"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1390), null, 6, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f910e2b2-24cf-484c-b2b5-c91a607d9819"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2060), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f9461dc4-a192-43c9-8014-047d78a2d488"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5110), null, 6, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f94b1f3d-f158-4797-b38f-811aa3fa5f1b"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5390), null, 5, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f9660fbf-37ed-4161-90a2-bd5d2407bae9"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2800), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f97fcc04-7dc4-422c-ba96-d3c47d310d87"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1560), null, 6, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f99aa290-1663-40d9-8eb4-8f329c0ee6fb"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1540), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fa0ebc22-737c-4866-96a5-f467d0d11f6e"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4990), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fb41f43f-d49a-471c-99b0-5c5d4ed5684b"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2230), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fb4848e1-ae1c-4680-9536-96074f399c31"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1480), null, 5, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fbd515a5-9e72-4acf-99e6-8e29126f7cf8"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(870), null, 5, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fbf6dcbf-7af1-4e1e-96ee-a86d0781a5e0"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4120), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fc3c9f7e-9647-46ab-93aa-85f381984e1e"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4460), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fc3f27e4-6e61-4f59-bc44-1c08a3f90f1e"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1250), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fd19baf5-0b15-47a0-9000-5dd4d9fd75d4"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(5380), null, 6, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fd437054-44b4-42aa-ba0b-83ad8a156526"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(790), null, 7, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fe450168-14b5-4d1a-a537-7b7927fd66eb"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(3070), null, 5, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("feb9fa1e-bdc8-4876-b188-017644310299"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(1040), null, 6, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ff09476d-2ca0-4074-84d3-3b594aaeacae"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4290), null, 6, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ff7832c5-e8e2-40e2-9906-171d4cd07034"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(2620), null, 7, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ffe45c90-738e-460f-a0c2-c3f35f6634ce"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 13, 12, 42, 303, DateTimeKind.Utc).AddTicks(4680), null, 7, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null }
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
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_CeremonyId",
                table: "Users",
                column: "CeremonyId");

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
                name: "Users");

            migrationBuilder.DropTable(
                name: "Advisors");

            migrationBuilder.DropTable(
                name: "Ceremonies");

            migrationBuilder.DropTable(
                name: "StudentAffairs");
        }
    }
}
