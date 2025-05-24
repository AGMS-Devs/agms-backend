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
                    { new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(7370), null, "Elektrik-Elektronik Mühendisliği bölümü öğrencileri için gerekli zorunlu dersler", "Elektrik-Elektronik Mühendisliği Zorunlu Dersler", null },
                    { new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(7380), null, "Makine Mühendisliği bölümü öğrencileri için gerekli zorunlu dersler", "Makine Mühendisliği Zorunlu Dersler", null },
                    { new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(7380), null, "Kimya bölümü öğrencileri için gerekli zorunlu dersler", "Kimya Bölümü Zorunlu Dersler", null },
                    { new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(7370), null, "Bilgisayar Mühendisliği bölümü öğrencileri için gerekli zorunlu dersler", "Bilgisayar Mühendisliği Zorunlu Dersler", null },
                    { new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(7380), null, "Matematik bölümü öğrencileri için gerekli zorunlu dersler", "Matematik Bölümü Zorunlu Dersler", null },
                    { new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(7380), null, "Fizik bölümü öğrencileri için gerekli zorunlu dersler", "Fizik Bölümü Zorunlu Dersler", null }
                });

            migrationBuilder.InsertData(
                table: "StudentAffairs",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OfficeName", "UpdatedDate" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(2600), null, "İYTE Öğrenci İşleri Daire Başkanlığı", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AdvisorProfileId", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "IsActive", "Name", "PasswordHash", "PasswordSalt", "PhoneNumber", "Surname", "UpdatedDate", "UserType" },
                values: new object[,]
                {
                    { new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6000), null, "20200016@std.iyte.edu.tr", true, "Serkan", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "7788990011", "Bozkurt", null, 0 },
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6090), null, "advisor1@iyte.edu.tr", true, "Dr. Mehmet", new byte[] { 56, 107, 69, 14, 212, 110, 240, 43, 74, 232, 99, 208, 187, 54, 25, 201, 116, 59, 53, 20, 163, 166, 202, 10, 126, 171, 84, 6, 47, 238, 236, 88, 128, 239, 53, 188, 78, 178, 22, 6, 70, 231, 85, 248, 157, 101, 240, 235, 57, 243, 69, 216, 210, 75, 33, 109, 82, 99, 79, 45, 11, 58, 254, 25 }, new byte[] { 187, 115, 152, 134, 191, 8, 164, 78, 169, 152, 9, 240, 226, 5, 148, 11, 170, 110, 36, 206, 60, 207, 171, 62, 214, 113, 50, 168, 241, 28, 5, 144, 4, 205, 176, 193, 72, 199, 222, 207, 144, 115, 232, 132, 128, 35, 189, 217, 175, 128, 250, 142, 181, 170, 33, 67, 29, 0, 54, 229, 19, 53, 242, 116, 160, 147, 192, 246, 122, 93, 211, 192, 39, 50, 188, 168, 62, 253, 236, 36, 201, 229, 78, 86, 95, 223, 163, 157, 75, 137, 100, 42, 70, 55, 123, 70, 142, 104, 56, 255, 195, 125, 82, 211, 235, 28, 50, 109, 140, 218, 29, 252, 49, 173, 30, 162, 246, 173, 212, 189, 76, 169, 99, 89, 18, 22, 198, 112 }, "4445556677", "Yılmaz", null, 2 },
                    { new Guid("11111111-1111-1111-1111-11111111111a"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(5910), null, "admin@iyte.edu.tr", true, "System", new byte[] { 240, 143, 74, 217, 10, 230, 230, 175, 80, 161, 164, 112, 115, 226, 25, 12, 149, 228, 193, 31, 134, 18, 151, 21, 65, 204, 65, 255, 39, 76, 31, 3, 59, 90, 122, 47, 197, 147, 192, 227, 252, 245, 33, 189, 74, 140, 59, 74, 214, 177, 104, 4, 25, 227, 142, 222, 39, 66, 210, 77, 111, 168, 18, 154 }, new byte[] { 166, 175, 218, 126, 200, 29, 33, 114, 208, 34, 184, 213, 115, 76, 166, 132, 73, 202, 101, 192, 12, 121, 60, 43, 108, 21, 111, 202, 110, 166, 103, 56, 35, 89, 37, 161, 94, 42, 241, 94, 90, 204, 219, 122, 46, 184, 100, 71, 18, 74, 10, 193, 111, 41, 32, 170, 234, 147, 61, 157, 128, 122, 130, 250, 11, 225, 40, 161, 67, 142, 68, 255, 207, 131, 64, 181, 27, 14, 20, 48, 53, 105, 11, 81, 34, 184, 80, 29, 180, 206, 249, 58, 232, 5, 20, 251, 40, 255, 149, 134, 154, 171, 239, 64, 182, 176, 207, 132, 107, 109, 19, 219, 122, 0, 159, 49, 88, 170, 163, 220, 38, 189, 25, 28, 7, 162, 89, 95 }, "1234567890", "Admin", null, 3 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6090), null, "advisor2@iyte.edu.tr", true, "Dr. Ayşe", new byte[] { 56, 107, 69, 14, 212, 110, 240, 43, 74, 232, 99, 208, 187, 54, 25, 201, 116, 59, 53, 20, 163, 166, 202, 10, 126, 171, 84, 6, 47, 238, 236, 88, 128, 239, 53, 188, 78, 178, 22, 6, 70, 231, 85, 248, 157, 101, 240, 235, 57, 243, 69, 216, 210, 75, 33, 109, 82, 99, 79, 45, 11, 58, 254, 25 }, new byte[] { 187, 115, 152, 134, 191, 8, 164, 78, 169, 152, 9, 240, 226, 5, 148, 11, 170, 110, 36, 206, 60, 207, 171, 62, 214, 113, 50, 168, 241, 28, 5, 144, 4, 205, 176, 193, 72, 199, 222, 207, 144, 115, 232, 132, 128, 35, 189, 217, 175, 128, 250, 142, 181, 170, 33, 67, 29, 0, 54, 229, 19, 53, 242, 116, 160, 147, 192, 246, 122, 93, 211, 192, 39, 50, 188, 168, 62, 253, 236, 36, 201, 229, 78, 86, 95, 223, 163, 157, 75, 137, 100, 42, 70, 55, 123, 70, 142, 104, 56, 255, 195, 125, 82, 211, 235, 28, 50, 109, 140, 218, 29, 252, 49, 173, 30, 162, 246, 173, 212, 189, 76, 169, 99, 89, 18, 22, 198, 112 }, "5556667788", "Demir", null, 2 },
                    { new Guid("22222222-2222-2222-2222-22222222222a"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(5940), null, "20220001@std.iyte.edu.tr", true, "Ali", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "2345678901", "Veli", null, 0 },
                    { new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(5990), null, "20220012@std.iyte.edu.tr", true, "Mert", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "3344556677", "Doğan", null, 0 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6100), null, "advisor3@iyte.edu.tr", true, "Dr. Hasan", new byte[] { 56, 107, 69, 14, 212, 110, 240, 43, 74, 232, 99, 208, 187, 54, 25, 201, 116, 59, 53, 20, 163, 166, 202, 10, 126, 171, 84, 6, 47, 238, 236, 88, 128, 239, 53, 188, 78, 178, 22, 6, 70, 231, 85, 248, 157, 101, 240, 235, 57, 243, 69, 216, 210, 75, 33, 109, 82, 99, 79, 45, 11, 58, 254, 25 }, new byte[] { 187, 115, 152, 134, 191, 8, 164, 78, 169, 152, 9, 240, 226, 5, 148, 11, 170, 110, 36, 206, 60, 207, 171, 62, 214, 113, 50, 168, 241, 28, 5, 144, 4, 205, 176, 193, 72, 199, 222, 207, 144, 115, 232, 132, 128, 35, 189, 217, 175, 128, 250, 142, 181, 170, 33, 67, 29, 0, 54, 229, 19, 53, 242, 116, 160, 147, 192, 246, 122, 93, 211, 192, 39, 50, 188, 168, 62, 253, 236, 36, 201, 229, 78, 86, 95, 223, 163, 157, 75, 137, 100, 42, 70, 55, 123, 70, 142, 104, 56, 255, 195, 125, 82, 211, 235, 28, 50, 109, 140, 218, 29, 252, 49, 173, 30, 162, 246, 173, 212, 189, 76, 169, 99, 89, 18, 22, 198, 112 }, "6667778899", "Özkan", null, 2 },
                    { new Guid("33333333-3333-3333-3333-33333333333a"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6050), null, "studentaffairs@iyte.edu.tr", true, "Hafize", new byte[] { 241, 134, 91, 25, 227, 188, 92, 216, 11, 150, 225, 252, 217, 121, 230, 90, 175, 181, 181, 39, 190, 99, 86, 189, 159, 78, 52, 111, 62, 3, 113, 39, 73, 67, 162, 44, 238, 244, 107, 148, 146, 150, 123, 213, 239, 249, 88, 78, 77, 206, 173, 81, 123, 237, 2, 35, 27, 89, 150, 106, 30, 97, 170, 129 }, new byte[] { 80, 0, 155, 97, 38, 207, 97, 116, 5, 26, 111, 60, 116, 206, 195, 103, 135, 195, 194, 213, 210, 170, 253, 181, 47, 219, 6, 202, 186, 227, 227, 242, 4, 31, 68, 52, 228, 132, 136, 62, 216, 25, 14, 152, 133, 139, 77, 66, 159, 16, 10, 196, 232, 166, 76, 92, 173, 77, 247, 16, 202, 40, 148, 77, 129, 28, 222, 235, 212, 65, 61, 246, 29, 102, 8, 174, 133, 167, 141, 197, 95, 163, 107, 76, 65, 136, 247, 84, 60, 63, 72, 236, 84, 42, 198, 223, 41, 225, 198, 13, 39, 220, 254, 90, 180, 11, 0, 237, 180, 46, 108, 84, 102, 88, 130, 193, 66, 205, 79, 233, 220, 34, 12, 32, 63, 214, 196, 38 }, "3334445566", "Kaya", null, 1 },
                    { new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(5950), null, "20220002@std.iyte.edu.tr", true, "Ayşe", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "3456789012", "Yılmaz", null, 0 },
                    { new Guid("44444444-4444-4444-4444-444444444444"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6100), null, "advisor4@iyte.edu.tr", true, "Dr. Fatma", new byte[] { 56, 107, 69, 14, 212, 110, 240, 43, 74, 232, 99, 208, 187, 54, 25, 201, 116, 59, 53, 20, 163, 166, 202, 10, 126, 171, 84, 6, 47, 238, 236, 88, 128, 239, 53, 188, 78, 178, 22, 6, 70, 231, 85, 248, 157, 101, 240, 235, 57, 243, 69, 216, 210, 75, 33, 109, 82, 99, 79, 45, 11, 58, 254, 25 }, new byte[] { 187, 115, 152, 134, 191, 8, 164, 78, 169, 152, 9, 240, 226, 5, 148, 11, 170, 110, 36, 206, 60, 207, 171, 62, 214, 113, 50, 168, 241, 28, 5, 144, 4, 205, 176, 193, 72, 199, 222, 207, 144, 115, 232, 132, 128, 35, 189, 217, 175, 128, 250, 142, 181, 170, 33, 67, 29, 0, 54, 229, 19, 53, 242, 116, 160, 147, 192, 246, 122, 93, 211, 192, 39, 50, 188, 168, 62, 253, 236, 36, 201, 229, 78, 86, 95, 223, 163, 157, 75, 137, 100, 42, 70, 55, 123, 70, 142, 104, 56, 255, 195, 125, 82, 211, 235, 28, 50, 109, 140, 218, 29, 252, 49, 173, 30, 162, 246, 173, 212, 189, 76, 169, 99, 89, 18, 22, 198, 112 }, "7778889900", "Şen", null, 2 },
                    { new Guid("55555555-5555-5555-5555-555555555555"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6100), null, "advisor5@iyte.edu.tr", true, "Dr. Ali", new byte[] { 56, 107, 69, 14, 212, 110, 240, 43, 74, 232, 99, 208, 187, 54, 25, 201, 116, 59, 53, 20, 163, 166, 202, 10, 126, 171, 84, 6, 47, 238, 236, 88, 128, 239, 53, 188, 78, 178, 22, 6, 70, 231, 85, 248, 157, 101, 240, 235, 57, 243, 69, 216, 210, 75, 33, 109, 82, 99, 79, 45, 11, 58, 254, 25 }, new byte[] { 187, 115, 152, 134, 191, 8, 164, 78, 169, 152, 9, 240, 226, 5, 148, 11, 170, 110, 36, 206, 60, 207, 171, 62, 214, 113, 50, 168, 241, 28, 5, 144, 4, 205, 176, 193, 72, 199, 222, 207, 144, 115, 232, 132, 128, 35, 189, 217, 175, 128, 250, 142, 181, 170, 33, 67, 29, 0, 54, 229, 19, 53, 242, 116, 160, 147, 192, 246, 122, 93, 211, 192, 39, 50, 188, 168, 62, 253, 236, 36, 201, 229, 78, 86, 95, 223, 163, 157, 75, 137, 100, 42, 70, 55, 123, 70, 142, 104, 56, 255, 195, 125, 82, 211, 235, 28, 50, 109, 140, 218, 29, 252, 49, 173, 30, 162, 246, 173, 212, 189, 76, 169, 99, 89, 18, 22, 198, 112 }, "8889990011", "Güneş", null, 2 },
                    { new Guid("55555555-5555-5555-5555-55555555555a"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6130), null, "comp.deptsecretary@iyte.edu.tr", true, "Emine", new byte[] { 86, 174, 30, 0, 158, 88, 17, 71, 172, 53, 16, 28, 54, 137, 44, 86, 229, 12, 83, 163, 182, 210, 161, 99, 214, 247, 181, 254, 4, 132, 1, 112, 190, 108, 155, 0, 38, 126, 172, 96, 152, 152, 13, 71, 88, 245, 20, 35, 82, 80, 164, 45, 25, 205, 129, 174, 114, 98, 183, 21, 41, 141, 21, 84 }, new byte[] { 65, 178, 183, 62, 99, 237, 213, 9, 226, 78, 114, 15, 137, 218, 0, 191, 6, 252, 171, 199, 184, 143, 11, 176, 223, 170, 181, 61, 42, 26, 99, 82, 122, 162, 196, 13, 206, 236, 58, 233, 200, 201, 247, 249, 153, 177, 61, 163, 186, 146, 15, 76, 234, 151, 3, 231, 6, 132, 76, 1, 85, 126, 157, 167, 26, 18, 234, 60, 105, 0, 189, 55, 253, 8, 190, 65, 212, 114, 70, 219, 40, 23, 64, 180, 242, 232, 28, 214, 60, 4, 0, 253, 177, 194, 67, 40, 189, 112, 43, 232, 206, 218, 2, 153, 194, 178, 56, 73, 167, 216, 169, 121, 123, 75, 207, 52, 68, 133, 199, 192, 117, 233, 3, 11, 115, 194, 107, 63 }, "1111223344", "Arslan", null, 1 },
                    { new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(5990), null, "20200013@std.iyte.edu.tr", true, "İrem", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "4455667788", "Kılıç", null, 0 },
                    { new Guid("66666666-6666-6666-6666-666666666666"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6110), null, "advisor6@iyte.edu.tr", true, "Dr. Zeynep", new byte[] { 56, 107, 69, 14, 212, 110, 240, 43, 74, 232, 99, 208, 187, 54, 25, 201, 116, 59, 53, 20, 163, 166, 202, 10, 126, 171, 84, 6, 47, 238, 236, 88, 128, 239, 53, 188, 78, 178, 22, 6, 70, 231, 85, 248, 157, 101, 240, 235, 57, 243, 69, 216, 210, 75, 33, 109, 82, 99, 79, 45, 11, 58, 254, 25 }, new byte[] { 187, 115, 152, 134, 191, 8, 164, 78, 169, 152, 9, 240, 226, 5, 148, 11, 170, 110, 36, 206, 60, 207, 171, 62, 214, 113, 50, 168, 241, 28, 5, 144, 4, 205, 176, 193, 72, 199, 222, 207, 144, 115, 232, 132, 128, 35, 189, 217, 175, 128, 250, 142, 181, 170, 33, 67, 29, 0, 54, 229, 19, 53, 242, 116, 160, 147, 192, 246, 122, 93, 211, 192, 39, 50, 188, 168, 62, 253, 236, 36, 201, 229, 78, 86, 95, 223, 163, 157, 75, 137, 100, 42, 70, 55, 123, 70, 142, 104, 56, 255, 195, 125, 82, 211, 235, 28, 50, 109, 140, 218, 29, 252, 49, 173, 30, 162, 246, 173, 212, 189, 76, 169, 99, 89, 18, 22, 198, 112 }, "9990001122", "Acar", null, 2 },
                    { new Guid("66666666-6666-6666-6666-66666666666a"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6150), null, "deansoffice@iyte.edu.tr", true, "Murat", new byte[] { 98, 73, 56, 115, 214, 42, 157, 128, 125, 206, 30, 170, 195, 235, 233, 75, 29, 51, 62, 14, 29, 95, 86, 121, 161, 187, 78, 68, 221, 209, 163, 173, 145, 29, 181, 83, 35, 176, 215, 21, 65, 55, 66, 79, 24, 68, 54, 75, 18, 159, 73, 142, 55, 39, 122, 61, 181, 22, 178, 4, 46, 154, 12, 63 }, new byte[] { 183, 71, 180, 113, 220, 148, 214, 133, 175, 218, 160, 204, 66, 212, 235, 68, 220, 140, 16, 178, 27, 127, 225, 79, 197, 58, 185, 20, 224, 144, 216, 5, 237, 90, 205, 192, 26, 254, 115, 129, 75, 140, 88, 141, 182, 148, 211, 206, 99, 99, 133, 147, 232, 223, 221, 148, 165, 9, 246, 202, 128, 251, 184, 41, 158, 147, 53, 45, 127, 166, 87, 46, 59, 77, 116, 96, 245, 77, 221, 54, 140, 7, 170, 9, 127, 32, 18, 125, 255, 137, 142, 235, 23, 64, 153, 123, 166, 197, 41, 31, 123, 130, 101, 56, 191, 231, 68, 226, 78, 110, 67, 239, 157, 106, 200, 161, 109, 63, 114, 97, 59, 126, 55, 148, 152, 148, 224, 243 }, "6667778899", "Kurt", null, 1 },
                    { new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6000), null, "20220015@std.iyte.edu.tr", true, "Pınar", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "6677889900", "Altın", null, 0 },
                    { new Guid("77777777-7777-7777-7777-77777777777a"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6160), null, "science.deansoffice@iyte.edu.tr", true, "Ayşe", new byte[] { 98, 73, 56, 115, 214, 42, 157, 128, 125, 206, 30, 170, 195, 235, 233, 75, 29, 51, 62, 14, 29, 95, 86, 121, 161, 187, 78, 68, 221, 209, 163, 173, 145, 29, 181, 83, 35, 176, 215, 21, 65, 55, 66, 79, 24, 68, 54, 75, 18, 159, 73, 142, 55, 39, 122, 61, 181, 22, 178, 4, 46, 154, 12, 63 }, new byte[] { 183, 71, 180, 113, 220, 148, 214, 133, 175, 218, 160, 204, 66, 212, 235, 68, 220, 140, 16, 178, 27, 127, 225, 79, 197, 58, 185, 20, 224, 144, 216, 5, 237, 90, 205, 192, 26, 254, 115, 129, 75, 140, 88, 141, 182, 148, 211, 206, 99, 99, 133, 147, 232, 223, 221, 148, 165, 9, 246, 202, 128, 251, 184, 41, 158, 147, 53, 45, 127, 166, 87, 46, 59, 77, 116, 96, 245, 77, 221, 54, 140, 7, 170, 9, 127, 32, 18, 125, 255, 137, 142, 235, 23, 64, 153, 123, 166, 197, 41, 31, 123, 130, 101, 56, 191, 231, 68, 226, 78, 110, 67, 239, 157, 106, 200, 161, 109, 63, 114, 97, 59, 126, 55, 148, 152, 148, 224, 243 }, "7778889900", "Yılmaz", null, 1 },
                    { new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(5990), null, "20210014@std.iyte.edu.tr", true, "Onur", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "5566778899", "Özkan", null, 0 },
                    { new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(5980), null, "20220010@std.iyte.edu.tr", true, "Deniz", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "1122334455", "Şahin", null, 0 },
                    { new Guid("88888888-8888-8888-8888-88888888888a"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6180), null, "rectorate@iyte.edu.tr", true, "Mahmut", new byte[] { 157, 171, 234, 43, 143, 117, 143, 127, 194, 2, 227, 175, 53, 162, 255, 245, 201, 194, 26, 110, 180, 135, 34, 171, 101, 146, 100, 138, 188, 94, 153, 123, 106, 165, 132, 141, 237, 18, 2, 255, 59, 191, 109, 105, 155, 0, 155, 204, 188, 197, 143, 59, 158, 239, 53, 150, 28, 237, 251, 232, 139, 117, 21, 249 }, new byte[] { 60, 7, 116, 77, 203, 14, 176, 130, 169, 206, 157, 17, 179, 190, 63, 116, 123, 14, 180, 55, 162, 84, 149, 154, 218, 41, 17, 86, 66, 78, 132, 21, 75, 222, 168, 94, 30, 73, 86, 144, 150, 85, 55, 147, 32, 24, 176, 162, 143, 37, 94, 33, 145, 163, 222, 246, 141, 5, 48, 170, 77, 191, 190, 188, 44, 99, 94, 242, 101, 193, 115, 203, 2, 171, 190, 16, 234, 167, 138, 99, 163, 195, 159, 213, 99, 152, 102, 156, 185, 168, 185, 31, 154, 39, 62, 19, 54, 102, 31, 245, 158, 240, 150, 81, 240, 114, 3, 199, 53, 253, 208, 99, 122, 128, 156, 229, 250, 6, 216, 79, 196, 53, 49, 106, 220, 229, 72, 15 }, "8889990011", "Özdemir", null, 1 },
                    { new Guid("89e73bfc-718e-49d4-92af-1c576d281cf4"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6130), null, "physics.deptsecretary@iyte.edu.tr", true, "Ayşe", new byte[] { 86, 174, 30, 0, 158, 88, 17, 71, 172, 53, 16, 28, 54, 137, 44, 86, 229, 12, 83, 163, 182, 210, 161, 99, 214, 247, 181, 254, 4, 132, 1, 112, 190, 108, 155, 0, 38, 126, 172, 96, 152, 152, 13, 71, 88, 245, 20, 35, 82, 80, 164, 45, 25, 205, 129, 174, 114, 98, 183, 21, 41, 141, 21, 84 }, new byte[] { 65, 178, 183, 62, 99, 237, 213, 9, 226, 78, 114, 15, 137, 218, 0, 191, 6, 252, 171, 199, 184, 143, 11, 176, 223, 170, 181, 61, 42, 26, 99, 82, 122, 162, 196, 13, 206, 236, 58, 233, 200, 201, 247, 249, 153, 177, 61, 163, 186, 146, 15, 76, 234, 151, 3, 231, 6, 132, 76, 1, 85, 126, 157, 167, 26, 18, 234, 60, 105, 0, 189, 55, 253, 8, 190, 65, 212, 114, 70, 219, 40, 23, 64, 180, 242, 232, 28, 214, 60, 4, 0, 253, 177, 194, 67, 40, 189, 112, 43, 232, 206, 218, 2, 153, 194, 178, 56, 73, 167, 216, 169, 121, 123, 75, 207, 52, 68, 133, 199, 192, 117, 233, 3, 11, 115, 194, 107, 63 }, "5556667790", "Demir", null, 1 },
                    { new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(5960), null, "20220006@std.iyte.edu.tr", true, "Zeynep", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "7890123456", "Aydın", null, 0 },
                    { new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(5960), null, "20210007@std.iyte.edu.tr", true, "Burak", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "8901234567", "Çelik", null, 0 },
                    { new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6000), null, "20210017@std.iyte.edu.tr", true, "Tuba", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "8899001122", "Karaman", null, 0 },
                    { new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(5960), null, "20220005@std.iyte.edu.tr", true, "Emre", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "6789012345", "Demir", null, 0 },
                    { new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(5980), null, "20210011@std.iyte.edu.tr", true, "Ece", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "2233445566", "Güneş", null, 0 },
                    { new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(5950), null, "20210003@std.iyte.edu.tr", true, "Mehmet", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "4567890123", "Öz", null, 0 },
                    { new Guid("c4e05469-860b-4655-b844-f682a21fca23"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(5970), null, "20220008@std.iyte.edu.tr", true, "Selin", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "9012345678", "Yıldız", null, 0 },
                    { new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(5950), null, "20190004@std.iyte.edu.tr", true, "Fatma", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "5678901234", "Kaya", null, 0 },
                    { new Guid("e32d7b07-a92e-4dda-83e0-c90ee8cad8e5"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6130), null, "elec.deptsecretary@iyte.edu.tr", true, "Melek", new byte[] { 86, 174, 30, 0, 158, 88, 17, 71, 172, 53, 16, 28, 54, 137, 44, 86, 229, 12, 83, 163, 182, 210, 161, 99, 214, 247, 181, 254, 4, 132, 1, 112, 190, 108, 155, 0, 38, 126, 172, 96, 152, 152, 13, 71, 88, 245, 20, 35, 82, 80, 164, 45, 25, 205, 129, 174, 114, 98, 183, 21, 41, 141, 21, 84 }, new byte[] { 65, 178, 183, 62, 99, 237, 213, 9, 226, 78, 114, 15, 137, 218, 0, 191, 6, 252, 171, 199, 184, 143, 11, 176, 223, 170, 181, 61, 42, 26, 99, 82, 122, 162, 196, 13, 206, 236, 58, 233, 200, 201, 247, 249, 153, 177, 61, 163, 186, 146, 15, 76, 234, 151, 3, 231, 6, 132, 76, 1, 85, 126, 157, 167, 26, 18, 234, 60, 105, 0, 189, 55, 253, 8, 190, 65, 212, 114, 70, 219, 40, 23, 64, 180, 242, 232, 28, 214, 60, 4, 0, 253, 177, 194, 67, 40, 189, 112, 43, 232, 206, 218, 2, 153, 194, 178, 56, 73, 167, 216, 169, 121, 123, 75, 207, 52, 68, 133, 199, 192, 117, 233, 3, 11, 115, 194, 107, 63 }, "2223334455", "Çakır", null, 1 },
                    { new Guid("e8a7af40-b208-430e-967a-e590bab72810"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6030), null, "20220026@std.iyte.edu.tr", true, "Aşkın", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "1123445557", "Durmaz", null, 0 },
                    { new Guid("e8a7af40-b209-430e-967a-e590bab72810"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6030), null, "20220025@std.iyte.edu.tr", true, "Memo", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "1123445556", "Yilik", null, 0 },
                    { new Guid("e8a7af40-b210-430e-967a-e590bab72810"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6020), null, "20220024@std.iyte.edu.tr", true, "Ayşecik", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "1123445555", "Yıldır", null, 0 },
                    { new Guid("e8a7af40-b211-430e-967a-e590bab72810"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6020), null, "20220023@std.iyte.edu.tr", true, "Ayşe", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "1122334454", "Yılmaz", null, 0 },
                    { new Guid("e8a7af40-b212-430e-967a-e590bab72810"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6020), null, "20220022@std.iyte.edu.tr", true, "Aişe", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "1122634455", "Yılgın", null, 0 },
                    { new Guid("e8a7af40-b213-430e-967a-e590bab72810"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6010), null, "20220021@std.iyte.edu.tr", true, "Mehmet", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "1722334455", "Yılmaz", null, 0 },
                    { new Guid("e8a7af40-b214-430e-967a-e590bab72810"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6010), null, "20220020@std.iyte.edu.tr", true, "Kasım", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "1122339455", "Yılmaz", null, 0 },
                    { new Guid("e8a7af40-b215-430e-967a-e590bab72810"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6010), null, "20220019@std.iyte.edu.tr", true, "Yusuf", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "1121334455", "Yılmaz", null, 0 },
                    { new Guid("e8a7af40-b216-430e-967a-e590bab72810"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(6000), null, "20220018@std.iyte.edu.tr", true, "Yasin", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "9900112233", "Erdoğan", null, 0 },
                    { new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), null, 0, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(5980), null, "20200009@std.iyte.edu.tr", true, "Can", new byte[] { 198, 236, 154, 216, 248, 159, 22, 137, 148, 132, 188, 201, 156, 139, 192, 53, 209, 99, 61, 133, 102, 92, 187, 99, 221, 203, 238, 134, 46, 204, 224, 6, 89, 220, 80, 184, 0, 45, 3, 217, 10, 121, 22, 80, 174, 39, 178, 245, 108, 17, 215, 227, 243, 157, 195, 4, 189, 245, 107, 241, 48, 190, 122, 157 }, new byte[] { 92, 173, 12, 170, 63, 18, 177, 116, 187, 254, 140, 177, 225, 158, 15, 214, 115, 153, 248, 47, 109, 145, 72, 150, 135, 103, 75, 12, 191, 71, 191, 115, 221, 39, 58, 86, 140, 215, 16, 13, 126, 248, 3, 205, 131, 87, 19, 196, 102, 56, 86, 241, 5, 201, 184, 73, 254, 26, 218, 99, 248, 77, 79, 145, 81, 247, 110, 27, 102, 221, 116, 144, 92, 242, 190, 198, 236, 45, 63, 187, 38, 244, 31, 0, 112, 15, 182, 111, 204, 34, 126, 124, 140, 133, 78, 244, 89, 192, 131, 83, 252, 34, 56, 35, 27, 39, 39, 112, 189, 2, 139, 125, 78, 234, 108, 210, 132, 144, 125, 104, 39, 97, 206, 65, 229, 31, 174, 57 }, "0123456789", "Arslan", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "FacultyDeansOffices",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "FacultyName", "StudentAffairId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(2030), null, "Fen Fakültesi", new Guid("11111111-1111-1111-1111-111111111111"), null },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(2040), null, "Mühendislik Fakültesi", new Guid("11111111-1111-1111-1111-111111111111"), null }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DepartmentId", "FacultyId", "StaffPhone", "StaffRole", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-33333333333a"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(2070), null, null, null, "232-750-5001", 1, null },
                    { new Guid("66666666-6666-6666-6666-66666666666a"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(2090), null, null, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "232-750-5002", 2, null },
                    { new Guid("77777777-7777-7777-7777-77777777777a"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(2090), null, null, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "232-750-6002", 2, null },
                    { new Guid("88888888-8888-8888-8888-88888888888a"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(2090), null, null, null, "232-750-1001", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Transcripts",
                columns: new[] { "Id", "CompletedCourseCount", "CompletedCredit", "CreatedDate", "DeletedDate", "DepartmentGraduationRank", "FacultyGraduationRank", "GraduationYear", "RemainingCredit", "RequiredCourseCount", "StudentId", "StudentIdentityNumber", "TotalRequiredCredit", "TotalTakenCredit", "TranscriptDate", "TranscriptDescription", "TranscriptFileName", "TranscriptGpa", "UniversityGraduationRank", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("05a850dd-895d-4e1c-b134-5ff1a19aa63e"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3310), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), "12345678918", 240, 240, new DateTime(2025, 5, 16, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3300), "Mezuniyet transkripti", "transcript_2023018.pdf", 3.45m, "40", null },
                    { new Guid("05def74a-b2c0-46e1-92fb-ba3d86ecc26e"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3350), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), "12345678926", 240, 240, new DateTime(2025, 5, 16, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3350), "Mezuniyet transkripti", "transcript_2023026.pdf", 2.93m, "40", null },
                    { new Guid("0747e806-cd6c-4675-8ac4-83550b8641db"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3200), null, "1", "1", "2024", 0, 24, new Guid("22222222-2222-2222-2222-22222222222a"), "12345678901", 240, 240, new DateTime(2025, 4, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3190), "Mezuniyet transkripti", "transcript_2023001.pdf", 3.95m, "1", null },
                    { new Guid("0f471f96-b7d5-4105-adf6-95122b3c408a"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3240), null, "3", "7", "2024", 0, 24, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), "12345678907", 240, 240, new DateTime(2025, 5, 10, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3240), "Mezuniyet transkripti", "transcript_2023007.pdf", 3.68m, "15", null },
                    { new Guid("0f6b552d-5894-43d5-bdd1-08ac50473a36"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3270), null, "3", "10", "2024", 0, 24, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), "12345678911", 240, 240, new DateTime(2025, 5, 13, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3260), "Mezuniyet transkripti", "transcript_2023011.pdf", 3.62m, "20", null },
                    { new Guid("13f3866a-e786-4c83-87c1-8279016fd736"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3280), null, "1", "6", "2024", 0, 24, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), "12345678913", 240, 240, new DateTime(2025, 4, 28, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3280), "Mezuniyet transkripti", "transcript_2023013.pdf", 3.82m, "8", null },
                    { new Guid("1d0980f9-0528-4ea3-8acc-b71c3a4317a7"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3250), null, "1", "4", "2024", 0, 24, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), "12345678909", 240, 240, new DateTime(2025, 4, 26, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3250), "Mezuniyet transkripti", "transcript_2023009.pdf", 3.85m, "7", null },
                    { new Guid("3b613e45-f921-4722-b6ef-46a83a671369"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3350), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), "12345678925", 240, 240, new DateTime(2025, 5, 16, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3340), "Mezuniyet transkripti", "transcript_2023025.pdf", 2.83m, "40", null },
                    { new Guid("47070f17-cc02-4ca9-8233-aa5e541a9d4a"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3320), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), "12345678920", 240, 240, new DateTime(2025, 5, 16, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3320), "Mezuniyet transkripti", "transcript_2023020.pdf", 2.23m, "40", null },
                    { new Guid("4cc4b4a0-c8c4-44a9-9710-1d9841dc38ad"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3320), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), "12345678921", 240, 240, new DateTime(2025, 5, 16, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3320), "Mezuniyet transkripti", "transcript_2023021.pdf", 2.43m, "40", null },
                    { new Guid("51230988-037b-4280-9afc-683716eee765"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3250), null, "4", "9", "2024", 0, 24, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), "12345678908", 240, 240, new DateTime(2025, 5, 12, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3250), "Mezuniyet transkripti", "transcript_2023008.pdf", 3.55m, "25", null },
                    { new Guid("6a40c746-e48c-401e-a340-464d5bc57e5b"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3300), null, "1", "4", "2024", 0, 24, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), "12345678917", 240, 240, new DateTime(2025, 5, 5, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3300), "Mezuniyet transkripti", "transcript_2023017.pdf", 3.77m, "11", null },
                    { new Guid("77003c4c-0e88-425a-8677-b47fddcf5400"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3280), null, "2", "11", "2024", 0, 24, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), "12345678914", 240, 240, new DateTime(2025, 5, 11, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3280), "Mezuniyet transkripti", "transcript_2023014.pdf", 3.58m, "23", null },
                    { new Guid("779c88be-06e4-42ca-87c3-1197fda9d844"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3270), null, "4", "12", "2024", 0, 24, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), "12345678912", 240, 240, new DateTime(2025, 5, 15, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3270), "Mezuniyet transkripti", "transcript_2023012.pdf", 3.48m, "35", null },
                    { new Guid("804f6369-85df-49bd-829c-8ee54b9cb18b"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3330), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), "12345678923", 240, 240, new DateTime(2025, 5, 16, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3330), "Mezuniyet transkripti", "transcript_2023023.pdf", 2.63m, "40", null },
                    { new Guid("807b4c5d-ad92-402f-84bc-fcfe8f9b8115"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3230), null, "1", "2", "2024", 0, 24, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), "12345678905", 240, 240, new DateTime(2025, 5, 2, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3230), "Mezuniyet transkripti", "transcript_2023005.pdf", 3.92m, "2", null },
                    { new Guid("83a84451-90c4-4d65-8e21-545b79b5d3c2"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3340), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), "12345678924", 240, 240, new DateTime(2025, 5, 16, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3340), "Mezuniyet transkripti", "transcript_2023024.pdf", 2.73m, "40", null },
                    { new Guid("8715ebd2-fe86-4924-9cf4-5a91d00a2eb0"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3260), null, "2", "8", "2024", 0, 24, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), "12345678910", 240, 240, new DateTime(2025, 5, 8, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3260), "Mezuniyet transkripti", "transcript_2023010.pdf", 3.72m, "14", null },
                    { new Guid("9d75dc1a-51db-46a3-9f2a-31edae2ffdfc"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3310), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), "12345678919", 240, 240, new DateTime(2025, 5, 16, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3310), "Mezuniyet transkripti", "transcript_2023019.pdf", 2.34m, "40", null },
                    { new Guid("a2bae3df-ef7a-47cc-815e-93e4ccc82339"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3290), null, "1", "1", "2024", 0, 24, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), "12345678916", 240, 240, new DateTime(2025, 4, 19, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3290), "Mezuniyet transkripti", "transcript_2023016.pdf", 3.98m, "1", null },
                    { new Guid("d26d8f28-0cf2-4a68-9bda-b40461a822e8"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3210), null, "2", "3", "2024", 0, 24, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), "12345678902", 240, 240, new DateTime(2025, 4, 29, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3210), "Mezuniyet transkripti", "transcript_2023002.pdf", 3.88m, "5", null },
                    { new Guid("dd57fa83-f2c1-4f3a-b614-5d4895bd7611"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3220), null, "4", "8", "2024", 0, 24, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), "12345678904", 240, 240, new DateTime(2025, 5, 9, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3220), "Mezuniyet transkripti", "transcript_2023004.pdf", 3.65m, "18", null },
                    { new Guid("eb989cad-32c0-4164-bffb-3ef82f6f0947"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3330), null, "2", "13", "2024", 0, 24, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), "12345678922", 240, 240, new DateTime(2025, 5, 16, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3330), "Mezuniyet transkripti", "transcript_2023022.pdf", 2.53m, "40", null },
                    { new Guid("ec63050b-9e6b-49bd-b82e-20502b6203a7"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3240), null, "2", "5", "2024", 0, 24, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), "12345678906", 240, 240, new DateTime(2025, 5, 6, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3230), "Mezuniyet transkripti", "transcript_2023006.pdf", 3.78m, "10", null },
                    { new Guid("f7537d25-bfc4-460c-a03f-59bab3b41bc1"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3220), null, "3", "6", "2024", 0, 24, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), "12345678903", 240, 240, new DateTime(2025, 5, 4, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3220), "Mezuniyet transkripti", "transcript_2023003.pdf", 3.75m, "12", null },
                    { new Guid("fd3dea4a-7d97-4fa5-903c-68bde8effbac"), 24, 240, new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3290), null, "1", "3", "2024", 0, 24, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), "12345678915", 240, 240, new DateTime(2025, 4, 30, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(3290), "Mezuniyet transkripti", "transcript_2023015.pdf", 3.90m, "3", null }
                });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("033e5052-e750-4db7-83f9-bab5819db6bf"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7240), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df") },
                    { new Guid("044218ba-9171-4e48-b05c-7c1d11d44bd8"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7330), null, new Guid("55555555-5555-5555-5555-555555555555"), null, new Guid("89e73bfc-718e-49d4-92af-1c576d281cf4") },
                    { new Guid("04af0764-8d79-4a83-a1aa-ec7e7ce1c151"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7210), null, new Guid("11111111-1111-1111-1111-111111111111"), null, new Guid("11111111-1111-1111-1111-11111111111a") },
                    { new Guid("0f5330a5-8493-40b2-b139-7253b7ca9a85"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7270), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8") },
                    { new Guid("17255d36-077b-4018-bbe2-73ec47fa2982"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7300), null, new Guid("44444444-4444-4444-4444-444444444444"), null, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("20d44367-ebfc-4011-9eb4-ac3ef8f46bcf"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7300), null, new Guid("44444444-4444-4444-4444-444444444444"), null, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("29cddfda-c81f-4e65-b9a9-59cee81164cf"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7280), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d") },
                    { new Guid("2a190515-a24b-45ad-9ae7-a0ed0b1330f2"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7320), null, new Guid("55555555-5555-5555-5555-555555555555"), null, new Guid("e32d7b07-a92e-4dda-83e0-c90ee8cad8e5") },
                    { new Guid("3ac6e044-e6ce-4e6e-a70d-d2133e1dfed8"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7310), null, new Guid("44444444-4444-4444-4444-444444444444"), null, new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("3e5ee6c0-95dd-40a9-bdb9-a1ebed23f3a5"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7330), null, new Guid("66666666-6666-6666-6666-666666666666"), null, new Guid("66666666-6666-6666-6666-66666666666a") },
                    { new Guid("450f2500-e6e7-4435-8a89-2b44d0db108b"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7250), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8") },
                    { new Guid("49a6fb25-6105-4bc0-a414-20684b5a2ee6"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7320), null, new Guid("55555555-5555-5555-5555-555555555555"), null, new Guid("55555555-5555-5555-5555-55555555555a") },
                    { new Guid("6605a6e2-38c1-4dc1-a982-e128c6f98c96"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7250), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257") },
                    { new Guid("6fbf22c8-51d3-43b3-b97a-c901e9faf601"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7230), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307") },
                    { new Guid("7132e999-2f40-4714-9e43-342023c671e2"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7290), null, new Guid("33333333-3333-3333-3333-333333333333"), null, new Guid("33333333-3333-3333-3333-33333333333a") },
                    { new Guid("745dc71f-c1e5-4037-9d7b-5a92d50fd7c7"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7310), null, new Guid("44444444-4444-4444-4444-444444444444"), null, new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("871fcec8-790a-4b39-ad5a-42665677ae4f"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7220), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45") },
                    { new Guid("96974baa-9424-4fde-b0fd-b1bcbba0b254"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7250), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("c4e05469-860b-4655-b844-f682a21fca23") },
                    { new Guid("9d604964-7612-4921-8f11-f65ee76eab36"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7300), null, new Guid("44444444-4444-4444-4444-444444444444"), null, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("a4a46d54-05c1-4b89-8c7b-524381094e48"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7310), null, new Guid("44444444-4444-4444-4444-444444444444"), null, new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("a9dd6518-6e7e-45f3-9d14-1eb29d7f8731"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7260), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6") },
                    { new Guid("b2642369-448b-4be3-87a8-0bb32c25f4d5"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7290), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("e8a7af40-b216-430e-967a-e590bab72810") },
                    { new Guid("bb392d70-cd43-40c1-b380-c142475940bc"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7330), null, new Guid("66666666-6666-6666-6666-666666666666"), null, new Guid("77777777-7777-7777-7777-77777777777a") },
                    { new Guid("c273c9f5-03e2-4f53-8a51-0bb5fb8b1fa8"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7230), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24") },
                    { new Guid("c4b80ddc-8024-471e-a44b-7625418654ce"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7260), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b") },
                    { new Guid("cbfd05aa-6935-4071-b519-f71fbf9b1d3a"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7230), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4") },
                    { new Guid("cfea60d6-1a86-4cdb-9eb1-a6d46fbd84f3"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7270), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("79cace77-5720-434d-97b6-0d47a61468a3") },
                    { new Guid("e84b7e00-5f8a-451a-8050-52f34ad722ea"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7240), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("9000296e-dd35-476c-8702-cb20fd49c946") },
                    { new Guid("e8dec398-9599-45d3-a36c-34fb6b8bb2fa"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7220), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("22222222-2222-2222-2222-22222222222a") },
                    { new Guid("f75c7dd2-17ea-47ed-bb1e-aaaf6570c214"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7270), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4") },
                    { new Guid("ff4d613e-d9a5-45b9-b62d-3af687c65ccb"), new DateTime(2025, 5, 24, 22, 57, 26, 841, DateTimeKind.Utc).AddTicks(7280), null, new Guid("22222222-2222-2222-2222-222222222222"), null, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5") }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DepartmentName", "DepartmentPhone", "FacultyId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("11111111-2222-3333-4444-555555555555"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(970), null, "Elektrik-Elektronik Mühendisliği", "232-750-7002", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), null },
                    { new Guid("22222222-3333-4444-5555-666666666666"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(980), null, "Makine Mühendisliği", "232-750-7003", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), null },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(950), null, "Fizik Bölümü", "232-750-6001", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), null },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(960), null, "Kimya Bölümü", "232-750-6002", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), null },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(960), null, "Matematik Bölümü", "232-750-6003", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), null },
                    { new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(970), null, "Bilgisayar Mühendisliği", "232-750-7001", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), null }
                });

            migrationBuilder.InsertData(
                table: "Advisors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DepartmentId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 24, 22, 57, 26, 835, DateTimeKind.Utc).AddTicks(7070), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 24, 22, 57, 26, 835, DateTimeKind.Utc).AddTicks(7070), null, new Guid("11111111-2222-3333-4444-555555555555"), null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 5, 24, 22, 57, 26, 835, DateTimeKind.Utc).AddTicks(7070), null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 5, 24, 22, 57, 26, 835, DateTimeKind.Utc).AddTicks(7070), null, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 24, 22, 57, 26, 835, DateTimeKind.Utc).AddTicks(7070), null, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), null },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 24, 22, 57, 26, 835, DateTimeKind.Utc).AddTicks(7070), null, new Guid("22222222-3333-4444-5555-666666666666"), null }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCode", "CourseCredit", "CourseDescription", "CourseName", "CreatedDate", "DeletedDate", "DepartmentId", "ECTS", "FacultyId", "HalfYear", "PracticalHours", "TeoricHours", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), "PHYS121", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4510), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 6, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 4, null },
                    { new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), "PHYS122", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4520), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 6, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 4, null },
                    { new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), "CENG322", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4560), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 8, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 4, null },
                    { new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), "CENG213", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4530), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 6, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 3, null },
                    { new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), "CENG214", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4540), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 4, null },
                    { new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), "MATH144", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4510), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 5, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 3, null },
                    { new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), "MATH141", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4500), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 4, null },
                    { new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), "CENG218", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4540), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 6, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 3, null },
                    { new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), "CENG215", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4530), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 4, null },
                    { new Guid("4777afa3-a512-4353-8109-0674da099cf0"), "CENG424", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4580), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "fourth half year", 0, 3, null },
                    { new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), "CENG112", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4510), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 3, null },
                    { new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), "CENG216", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4540), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 5, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 3, null },
                    { new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), "CENG400", 0, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4560), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 4, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "fourth half year", 0, 0, null },
                    { new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), "CENG315", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4550), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 3, null },
                    { new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), "HIST202", 0, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4530), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 2, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 0, null },
                    { new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), "TURK201", 0, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4520), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 2, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 0, null },
                    { new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), "CENG222", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4550), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 5, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 3, null },
                    { new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), "CENG411", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4570), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 4, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "fourth half year", 0, 3, null },
                    { new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), "CENG323", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4550), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 8, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 3, null },
                    { new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), "MATH142", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4510), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 4, null },
                    { new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), "CENG418", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4570), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 6, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "fourth half year", 0, 3, null },
                    { new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), "MATH255", 3, "Discrete Mathematics course", "Discrete Mathematics", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4580), null, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), 6, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "second half year", 0, 3, null },
                    { new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), "CENG115", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4500), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 5, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 3, null },
                    { new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), "CENG312", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4550), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 7, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 3, null },
                    { new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), "CENG211", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4530), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 6, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 3, null },
                    { new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), "CENG212", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4540), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 5, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 3, null },
                    { new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), "CENG318", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4560), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 5, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 3, null },
                    { new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), "CENG311", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4550), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 8, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 4, null },
                    { new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), "CENG415", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4570), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 9, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "fourth half year", 0, 3, null },
                    { new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), "CENG111", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4500), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 4, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 3, null },
                    { new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), "TURK202", 0, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4530), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 2, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 0, null },
                    { new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), "CENG416", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4570), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 9, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "fourth half year", 0, 3, null },
                    { new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), "CENG316", 3, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4560), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 8, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "third half year", 0, 3, null },
                    { new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), "CENG113", 4, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4500), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 4, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "first half year", 0, 4, null },
                    { new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), "HIST201", 0, "Course description to be added", "Course name to be added", new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(4520), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), 2, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "second half year", 0, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DepartmentId", "FacultyId", "StaffPhone", "StaffRole", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("55555555-5555-5555-5555-55555555555a"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(2080), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), null, "232-750-7004", 3, null },
                    { new Guid("89e73bfc-718e-49d4-92af-1c576d281cf4"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(2080), null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), null, "232-750-6004", 3, null },
                    { new Guid("e32d7b07-a92e-4dda-83e0-c90ee8cad8e5"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(2080), null, new Guid("11111111-2222-3333-4444-555555555555"), null, "232-750-7005", 3, null }
                });

            migrationBuilder.InsertData(
                table: "GraduationLists",
                columns: new[] { "Id", "AdvisorId", "CreatedDate", "DeletedDate", "GraduationListNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(4450), null, "ME-2024-001", null },
                    { new Guid("a44b3d2f-ab86-4f4e-92ef-fd61b2894bf1"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(4450), null, "PHYS-2024-001", null },
                    { new Guid("abfb59be-9c96-490f-9c4e-100c15c0c337"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(4450), null, "EE-2024-001", null },
                    { new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(4440), null, "CENG-2024-001", null },
                    { new Guid("c70e2d92-b390-4511-978b-e058c34c9099"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(4450), null, "MATH-2024-001", null },
                    { new Guid("d47dc5ec-0974-4ed7-a24d-99bfba1aac06"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(4450), null, "CHEM-2024-001", null }
                });

            migrationBuilder.InsertData(
                table: "RequiredCourseListCourses",
                columns: new[] { "Id", "CourseId", "CreatedDate", "DeletedDate", "RequiredCourseListId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("03a4cca8-13a7-4487-9509-fed597efd1a5"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8930), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("06155aeb-56dc-45e8-b33d-c1e05b50aa23"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8850), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("0615f948-2bf6-40f3-a501-a200db6e9cc1"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9550), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("06221105-44c4-4493-996c-4c1d962c56c8"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9360), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("07a07f3e-f2d4-4c38-9562-7cdbb7bd7a92"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9670), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("08b4fd4b-1737-4435-af52-1fb93dfd2acb"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9600), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("08d7b7d9-0592-45c6-8cad-41e8cc0f286e"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8980), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("097edb70-fcec-4552-b644-876ef2afbc3a"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9440), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("0aad7124-9a4e-418b-9b12-24deb1e5e3f0"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9380), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("0b43f18e-d6a8-4538-93f9-7509e2e2121c"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9050), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("0c4c4d4c-4a45-4c5b-931f-ed84d82d3aff"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9080), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("0d5ffe05-8702-45dc-9586-26d8fa8a1e98"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9310), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("0dc6cc46-4f21-4ee3-bacc-3c599edd1f3d"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8920), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("0e3848c9-cf32-4d13-851b-567a1686dadc"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8940), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("0e748f92-b2cd-4db9-90cb-f548f9c1f7a0"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8910), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("10310b18-43ae-49c2-ba62-53d0a5421316"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9520), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("118d5d02-0198-4d32-a413-69950d2d4daf"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8950), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("144c3da1-66e9-4e20-a91e-27b66d2b9438"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8930), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("176c4306-2e5c-4e51-8f63-0d871214015c"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8970), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("1a1fa4ba-d0c7-405e-93e9-784455a99554"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9600), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("1bd988fa-b227-4d6c-a9d6-ae76820a9625"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9040), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("1c4ca1d7-2b42-452d-9f79-ce8663f345fd"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9400), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("1da1421d-31d1-4907-88b0-ca01a3837e5d"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8700), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("1dba2880-edaa-4b21-a5ca-0a36c71a0a98"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9540), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("1e3facbe-1afd-4ba0-92ad-3e47ef65c3fc"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8720), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("1f585191-7c73-4086-9391-5dbbee7816b5"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9170), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("1f6fbdcb-7ef9-4e16-9fe7-19153d07b0e5"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9070), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("1fbfdd94-3c32-4cde-a065-bb244eb0bb1d"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9660), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("1fd0c201-ef78-40d3-bffb-c5c094f05e8b"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8830), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("229a203b-8d9a-4248-b4bf-6768f27f1aaa"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8790), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("22db053d-6379-4540-8ac5-3afbd207db14"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9520), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("2387cbf7-36d5-4119-b2b7-4c7b16afa550"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9490), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("2392f14d-9af4-4b14-b72c-4942b85eb4b2"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8850), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("2536d861-4251-46d2-b4fb-5ce6aae7ff15"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9590), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("256ee7df-bd93-4cc9-a1dc-73e6c5bbc6e7"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9260), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("263bbd95-304f-4838-a6b4-745865fcd5bc"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9160), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("27133545-163d-43ae-bcf8-8bcb1ec0059f"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8760), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("29190aab-665e-472e-bf8d-c314dec8f351"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8970), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("2a5ea9f8-f8bb-4b5a-ad00-c0208f127a58"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8870), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("2a948938-72ff-4d79-bf40-38a49dafd2a9"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9430), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("2d4f2729-b3ff-4b88-aa07-43c2a5557076"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9210), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("2e252414-bd29-4214-9e7a-8d9f6710c9ed"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9590), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("2e6b873a-82cf-4b04-b620-a07551e01bc9"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9640), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("2f0c8abc-d621-415a-b50f-94b4fca4479c"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9270), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("30217ff3-a54f-426f-ba2b-ad3bea6c325b"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9490), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("31f2dfa8-81fe-46a9-a514-4c957ee7348a"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8910), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("32540db7-d217-4a78-8fa2-9f352bcea16f"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8870), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("3286f3a7-3247-4000-8197-7f7a708468ab"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9500), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("34327729-fdb3-429a-91a4-1096785c4d53"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9390), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("353d78aa-2f97-4325-b2b5-31274aacbd25"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9050), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("368c0106-257f-4656-b7ee-8a87833e2c83"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9430), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("3717d0f4-738f-4a86-b823-a35732f52a3b"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8890), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("384e45ff-c59b-41a5-b3d1-cf84637bb2a9"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8760), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("387293b9-ee6c-4061-851e-af937c87353d"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9470), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("38744776-4f9c-446b-a265-1798f5dc9dcf"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9240), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("391afdcb-a13e-4f67-8244-ed8ecdfc58cf"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9500), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("3b56face-f3ac-43c7-8618-b982298b31ce"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9030), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("3c87a623-7311-4935-a57e-f1b6ac121dfa"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8750), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("3e052a1d-65f3-4f4e-aab2-0b25bc195232"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9060), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("3e2baedc-dac3-4498-b8f5-8a8b7c2a493d"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8850), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("3e57c9a8-34a3-4347-af71-b44b54f163b2"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9260), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("40803997-5e69-46da-931e-56c02b7e8a4a"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9470), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("409d6854-4e6f-4b69-8660-4ba4347bea28"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9170), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("4518a961-3434-4e4b-aaac-d7085e4d14e2"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8770), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("469dfe59-ef2e-4c9a-8abf-565ed28aeec1"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8840), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("47469c27-6084-48ff-989e-a71d64fdb8a1"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9570), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("4a89f78d-08cb-4e08-8d05-2d14bda93aa3"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8770), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("4bfc0d66-379e-4226-a21b-6f43d2dbf278"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9440), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("4c2ae9bd-8e40-496e-92d5-65ee6bfdc60b"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9110), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("4d1d13b9-0af5-4ffc-ae35-8ea380f9d170"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9580), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("4db76e05-9c33-4c74-b6a8-628a0c7b2200"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9200), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("4f6c4bbb-b861-4fe1-957d-5366edda104e"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9560), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("532ab2a7-712e-441b-af15-12c4f7219bf8"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9210), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("54cb18b4-d303-4803-97b9-2931086a8376"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9550), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("5538b7a7-d862-47f4-913a-3f877233a719"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9290), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("55f35b3f-f766-4699-96c0-3363cad09cb0"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9010), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("566a32ba-1f27-49c3-900b-126dc34f3915"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9310), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("57c443ac-4fce-4aa2-a71f-de24010106d8"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9190), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("5913f8f1-637f-40ab-86ee-174b56306ddb"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8830), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("5989a4e5-5a3e-4460-9ad5-9f3c09d11616"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8750), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("5a1f18da-110f-474d-8a51-ca11b64c1ac6"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9000), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("5b828891-170c-40f8-a703-17173c1b98d1"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9090), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("5c6b8b37-272a-454b-a4a3-5afa0ed60700"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8730), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("5c70ee46-f496-44e4-b412-51569a3753db"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9510), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("5e5e64a8-e7c7-4661-8a33-ed2003bd51c1"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9060), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("5e81eb0e-50f0-47cc-bec0-23c1687266c8"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9280), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("5f9c09e7-1990-4a86-a917-09a075450b8d"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9190), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("62499ace-0de0-43fe-84e9-88174fc527ba"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9340), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("634146b8-55ea-4962-92aa-4eb9eb2613cb"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9370), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("6341b4c2-4e1f-441c-ae10-ea00ce989a93"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9530), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("64c28d9e-52aa-462b-8a88-dfabc3efe920"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9280), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("667dc8d2-d568-4e38-8bbb-6ffa5a8ba222"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9630), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("67f6a810-9531-4ba3-b82c-12354c7cc0f9"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8840), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("67f8bb30-db1f-414f-9b76-b2ecc5a4bc67"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8740), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("69ed0ec0-58c3-4273-a6fc-122fbf44e8e6"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8960), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("6d16d9fb-7938-4a73-926b-fb350edaaceb"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9280), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("703c45e6-5245-4d76-830e-583a17287fbc"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9420), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("737d2372-4076-4edf-9fd8-3e582b2f5ba2"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9300), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("76253dbf-2a69-4ffa-b8f8-5daf5a689e0b"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9140), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("7940de3b-1e8f-497e-b986-90439cc9b001"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9030), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("7b0237b3-cbaa-4759-b44e-f8bdf65f0149"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8890), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("7b126682-2787-4c68-b6a5-91e447c405c0"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9460), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("7ceaec93-67d7-44c5-93d8-6d5979ddee22"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9410), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("7d31973b-814b-4056-8316-15d45a37ba41"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9670), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("7e1703f1-51fb-4819-a7bf-b0793089e725"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8980), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("82018e3b-e632-409e-8f77-561a0907625b"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9610), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("8415b963-eccc-4d52-b4e2-b70a816760fe"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9220), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("8422980a-e6fa-4527-a144-b350529f6704"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9100), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("873d1117-4688-4243-aa95-2bd38821a670"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9350), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("87d4acde-3164-4a12-be25-cb18897bb8ec"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9560), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("88764e47-9cde-4f12-bb63-33cdf319a7d5"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9650), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("887cbeab-3a8f-47f6-8bd2-0bc8efc6d4e3"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9450), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("89218187-416e-4ba7-b361-80db61d94795"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9390), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("8968e56f-ded9-4fca-af37-02b955afe257"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8800), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("89daaa6c-52fd-42ae-840d-64be4bf3ffbd"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9200), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("8a7165a7-e4d9-41b9-816b-3c7af2ac3040"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8950), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("8b4e08f2-63c1-4b4f-a0d1-46bfd08e3010"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9650), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("8be0f35d-aabf-4ca7-aa6d-cb4cc739dba9"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9640), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("8ced4afd-4ae4-48db-b7ec-52b4b1b26704"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9140), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("8f33f8ab-20b5-4421-aa96-587f37a83d4b"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8730), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("9354b7df-743d-4e2a-9f99-34c5922a38ab"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9250), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("94a8d7f7-999f-4e48-a23c-ce2ad5196f5e"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9320), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("9538e41d-e06e-422c-8a84-558bf7d054f3"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9240), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("956bb892-7a32-4b5b-8cae-aae2b9e3cd3f"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9520), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("95af0bae-c176-42e4-b0f4-ad7b0b04d17c"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9110), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("983d6e3c-6df4-4636-ad69-71bfd993cba0"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9020), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("99782e71-dd25-4433-917e-9fa39d3b19e1"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9450), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("9a410591-fa5f-44b9-bcf7-31e9f144ef63"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8810), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("9a60894b-d6e3-4ca9-a676-81d07a703610"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9180), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("9b4433f2-c2b9-4800-89df-e06ef551cd50"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9160), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("9c85fefe-54b9-4c84-b1a0-b3575d69ca43"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8880), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("9dabaa1b-8510-49f5-bbe1-afd91416387e"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9630), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("9e2cdc98-49fe-4bfa-8163-611a4ed7e4c7"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9410), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("9eff548e-c56d-4e11-97c0-b649791e1e11"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9220), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("9f3fddb7-03a7-4bc0-911b-5906f453f265"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9120), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("a1ba2967-137a-49df-a815-5414444290d3"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8890), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("a4cfca48-a852-419d-90d7-f9c271580fab"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9610), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("a7fa96bd-75f3-4eaa-a4a4-aa105b47a78a"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9340), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("a9c5d115-3738-4440-9f2d-e0da4b15494c"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9130), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("ad2b76dd-92ed-4266-933b-a89934a2287b"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8820), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("ad4b1cc1-7084-4648-934b-5f4964129ca6"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8870), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("ae35c0df-0d38-4012-b69e-17c99130ffd9"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9480), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("ae721d20-1aef-44f3-99bd-571bf3038507"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9080), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("b042061e-7c9f-45ce-bfcf-ce679065dbf8"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9150), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("b0f97294-2f9f-472e-9931-debe96079ce7"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9120), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("b1813069-159b-47b2-859b-06e2ffd720e4"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9580), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("b228c10c-2cec-4741-b873-65845905286d"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9530), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("b4e450e8-b173-4886-ab4f-34ff8ec758c4"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8800), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("b618effa-5740-4676-8758-d52b1073b692"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9140), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("b934acc3-088f-45c4-9e77-4216633b2bc8"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9310), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("b9f749ec-5cfa-4c7e-850a-e030b24530b4"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8810), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("bb3df27f-f022-4cac-bf22-4d877dd902b1"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8990), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("bc5017cb-e0b7-4cde-8022-3a26d702d991"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8940), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("be08655c-964e-4416-b065-944df973da01"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9480), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("bf0cc36f-0803-4554-9f52-e2a0177e4ff4"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9350), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("c0425c91-5436-4109-8913-a8539f5fe257"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9470), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("c1644136-d919-423c-9beb-bac7afbc9763"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9290), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("c3d075ba-3b65-4ecd-802f-7f6ab40a2337"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9340), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("c50d7e5c-5914-48af-ab8e-27b264b9ad25"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9250), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("c53686fc-ce29-4b93-94ed-cdf7b56a5989"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8740), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("c5944e85-4fac-4c92-9bff-a8979bbf1c75"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9560), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("c6464506-89b9-45eb-a642-be50562c5c93"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9360), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("c66efd1a-2c6a-44d8-9e00-c58f0fc23d6a"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9540), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("c78c716a-ebc8-41ff-bf62-524a9275e29b"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9230), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("c95e8725-e035-403f-af47-9fef19edb9cc"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9620), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("c9d6ddaa-8ebc-45e6-b13d-fefe26c89b77"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8820), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("cae26ede-e3dc-4a69-a726-33b52c65c052"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9330), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("cae8bf22-9df1-4b04-9156-217725ead1ec"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9620), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("cbbfa7ea-b628-44ff-b133-2718b95af428"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8900), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("cc187887-59d8-474e-a74a-bc2de060900b"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9460), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("ccfd4414-c2b8-45ea-8a36-72336edcdb03"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9570), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("cfecfb0f-c490-4cee-b642-c900842bee3d"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9110), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("d178f643-f075-428e-9e1c-bdedd6f0c48a"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9600), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("d2e57dc5-b01f-40b5-a0c6-4d5e7dd096a0"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8720), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("d32c7d85-4429-4ad3-a1c6-cc28f4c2e1e2"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9050), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("d3a3dfb3-ed98-4a4f-8035-bc5f1b022419"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9100), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("d508dd19-919c-447b-b32b-e10388454007"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9070), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("d6accb6a-d14c-4e22-bd7e-9f51228516a2"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8780), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("d991c65f-30a2-4047-af59-b70b1a5a7b29"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8710), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("da5ed21f-98c0-45c4-bb5d-f77bc290e233"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9400), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("da99d91d-341f-478d-8e13-e88771da69c1"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8920), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("dc08841c-bc20-4850-a3ea-62a743f47ba3"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9130), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("de7ab13b-03d2-4fe4-918d-fb588f128be2"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9380), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("df2fd3c2-e9b6-42cd-b130-0dd8765781e5"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9400), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("df89e930-9b9d-4567-aae7-8dac1b39d86e"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9660), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("e0d94929-8b26-4525-bcd2-2c6e1e9c7127"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9300), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("e1c70626-5f30-40d9-9a55-4fa76e667294"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9370), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("e2bb718c-6a74-4898-af1d-0dd65ae99563"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9330), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("e3d4de4f-f457-45df-8f70-3b67e4648ccd"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9430), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("e575aa87-d61c-45b0-96de-148dc5ad5fac"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9150), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("e6f94e98-0372-4fff-9eae-76181c27ffb1"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9230), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("e89ff147-fa11-4324-b75e-6a39bc6bfd9b"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8790), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("e8c40689-4004-4c89-bff0-0984cb0d5c56"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9640), null, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), null },
                    { new Guid("e98c0af9-d3bb-4f83-91d1-29e4f32b19d4"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9180), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("e9be4590-edc6-42ac-a4b4-a8fd87c43a7e"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9380), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("ea730379-9133-409e-a18e-aeb2f7c1d44e"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9180), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("ecbfd5fc-1e07-4f3e-b124-43cd0a2d96f8"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9260), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("ed22fe40-3130-4db9-9432-cd4f6c3019ab"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9210), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null },
                    { new Guid("ee73414d-bc6a-4c04-8085-bd6a13f4ecb5"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8910), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("ef3e465f-4de7-4b20-b67c-c906d668e431"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9010), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("ef466486-94e4-4e75-b10a-016cdcc785e5"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8720), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("f0b1a14b-be0a-463e-81ec-f536c3022129"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9040), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("f2ee15dc-de81-490e-8d3d-ed77d12bb0d6"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8860), null, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), null },
                    { new Guid("f38e91fa-a745-4f94-82d4-2f59bcb56fb5"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8960), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("f4070a51-a23b-4ae0-8aab-87ab8deddcc4"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(8990), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("f5fdeda4-6680-468f-bf2a-08c5154182c3"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9510), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("f95c8c6c-dcd0-4c90-b45d-a617b720745f"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9090), null, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), null },
                    { new Guid("fbe2112c-8f04-460a-8348-3f676986a70c"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9020), null, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), null },
                    { new Guid("fcba480c-0238-46e4-9a0a-9b2a868d6f30"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9420), null, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), null },
                    { new Guid("fd144f86-2f8f-4dbe-9269-b6388a626d47"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 834, DateTimeKind.Utc).AddTicks(9320), null, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), null }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssignedAdvisorId", "CreatedDate", "DeletedDate", "DepartmentId", "EnrollDate", "GraduationStatus", "RequiredCourseListId", "StudentNumber", "StudentStatus", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6480), null, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), "2023016", 0, null },
                    { new Guid("22222222-2222-2222-2222-22222222222a"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6420), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), "2023001", 0, null },
                    { new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6470), null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), "2023012", 0, null },
                    { new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6430), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), "2023002", 0, null },
                    { new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6470), null, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), "2023013", 0, null },
                    { new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6470), null, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), "2023015", 0, null },
                    { new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6470), null, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("7bbe170d-9ce7-4eb1-9bd4-5b47fc1edb10"), "2023014", 0, null },
                    { new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6460), null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), "2023010", 0, null },
                    { new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6440), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), "2023006", 0, null },
                    { new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6450), null, new Guid("11111111-2222-3333-4444-555555555555"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), "2023007", 0, null },
                    { new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6480), null, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), "2023017", 0, null },
                    { new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6440), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), "2023005", 0, null },
                    { new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6460), null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), "2023011", 0, null },
                    { new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6430), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), "2023003", 0, null },
                    { new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6450), null, new Guid("11111111-2222-3333-4444-555555555555"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), "2023008", 0, null },
                    { new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6440), null, new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("c66c4c18-7cff-4ca2-9b66-c6d2d883397e"), "2023004", 0, null },
                    { new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6500), null, new Guid("22222222-3333-4444-5555-666666666666"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), "2023026", 0, null },
                    { new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6490), null, new Guid("22222222-3333-4444-5555-666666666666"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), "2023025", 0, null },
                    { new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6490), null, new Guid("22222222-3333-4444-5555-666666666666"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), "2023024", 0, null },
                    { new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6490), null, new Guid("22222222-3333-4444-5555-666666666666"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("746570e3-58d1-477d-b49d-84b272af6b18"), "2023023", 0, null },
                    { new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6490), null, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), "2023022", 0, null },
                    { new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6480), null, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), "2023021", 0, null },
                    { new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6460), null, new Guid("11111111-2222-3333-4444-555555555555"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), "20230081", 0, null },
                    { new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6450), null, new Guid("11111111-2222-3333-4444-555555555555"), new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("0b8fcf71-6994-4a27-b309-5dcb10110c71"), "20230071", 0, null },
                    { new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6480), null, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("c9d0e1f2-a3b4-4c5d-6e7f-890123456abc"), "2023018", 0, null },
                    { new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(6460), null, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f89"), "2023009", 0, null }
                });

            migrationBuilder.InsertData(
                table: "GraduationProcesses",
                columns: new[] { "Id", "AdvisorApproved", "AdvisorApprovedDate", "CreatedDate", "DeletedDate", "DepartmentSecretaryApproved", "DepartmentSecretaryApprovedDate", "FacultyDeansOfficeApproved", "FacultyDeansOfficeApprovedDate", "GraduationListId", "StudentAffairsApproved", "StudentAffairsApprovedDate", "StudentId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0bdb19e9-5782-44f9-8ff2-cfeb673fb5cb"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6650), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6660), null, true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6660), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6660), new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6660), new Guid("22222222-2222-2222-2222-22222222222a"), null },
                    { new Guid("171a094c-c2f1-4972-afbc-b3ff246d3085"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6700), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("abfb59be-9c96-490f-9c4e-100c15c0c337"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), null },
                    { new Guid("18dda5d1-8843-48fa-a40b-b3cd0f6914a7"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6760), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6760), null, true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6760), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6760), new Guid("a44b3d2f-ab86-4f4e-92ef-fd61b2894bf1"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6760), new Guid("e8a7af40-b212-430e-967a-e590bab72810"), null },
                    { new Guid("31eee5e7-4b35-4823-994f-600d680e6a11"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6750), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6750), null, true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6750), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6750), new Guid("abfb59be-9c96-490f-9c4e-100c15c0c337"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6750), new Guid("e8a7af40-b214-430e-967a-e590bab72810"), null },
                    { new Guid("3916fdfa-1b00-4528-9094-a3e88889c955"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6740), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("e8a7af40-b216-430e-967a-e590bab72810"), null },
                    { new Guid("40fe0ae1-7706-4e37-981f-7889b12223aa"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6720), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("d47dc5ec-0974-4ed7-a24d-99bfba1aac06"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), null },
                    { new Guid("41e71689-1b66-4c16-a625-e28eca976544"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6730), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("c70e2d92-b390-4511-978b-e058c34c9099"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), null },
                    { new Guid("4d2e1287-b09e-4632-a8bb-9aa42446630f"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6750), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6750), null, true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6750), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6750), new Guid("a44b3d2f-ab86-4f4e-92ef-fd61b2894bf1"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("e8a7af40-b213-430e-967a-e590bab72810"), null },
                    { new Guid("506d0eab-f3ef-49bf-b38c-2463e1f26563"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6720), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("d47dc5ec-0974-4ed7-a24d-99bfba1aac06"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), null },
                    { new Guid("54377178-6542-4b5c-920e-895923737f00"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6660), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6660), null, true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6660), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6660), new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6660), new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), null },
                    { new Guid("5702b227-c4c9-475b-82e9-c87000f7a940"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6690), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6700), null, true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6690), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6690), new Guid("abfb59be-9c96-490f-9c4e-100c15c0c337"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6690), new Guid("c4e05469-860b-4655-b844-f682a21fca23"), null },
                    { new Guid("5d15b42d-58a2-4b59-b6f2-186f81d7e93c"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6740), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6740), null, true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6740), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6740), new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6740), new Guid("e8a7af40-b215-430e-967a-e590bab72810"), null },
                    { new Guid("6d0d681d-d434-461b-b927-8cfcbad3d346"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6680), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6690), null, true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6680), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6690), new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6690), new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), null },
                    { new Guid("744cf3e5-b87f-40e1-8d57-a0f6c9db1f1a"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6670), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6670), null, true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6670), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), null },
                    { new Guid("7d313308-1f4b-430f-8b94-a60d5e884b79"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6710), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a44b3d2f-ab86-4f4e-92ef-fd61b2894bf1"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), null },
                    { new Guid("7ed02ad1-8919-4748-9886-e63bb4edb0a7"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6730), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("c70e2d92-b390-4511-978b-e058c34c9099"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), null },
                    { new Guid("91a07c74-419f-4062-8a92-071c7ff23f0b"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6780), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6780), null, true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6780), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6780), new Guid("c70e2d92-b390-4511-978b-e058c34c9099"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6780), new Guid("e8a7af40-b208-430e-967a-e590bab72810"), null },
                    { new Guid("a087286b-4625-4ac8-a083-9444e384b6c6"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6770), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6770), null, true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6770), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6770), new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6770), new Guid("e8a7af40-b209-430e-967a-e590bab72810"), null },
                    { new Guid("afef7e40-7d43-4dfd-8117-d83d3dfb37d4"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6760), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6760), null, true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6760), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6760), new Guid("d47dc5ec-0974-4ed7-a24d-99bfba1aac06"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6760), new Guid("e8a7af40-b211-430e-967a-e590bab72810"), null },
                    { new Guid("b30f6dec-6e4b-448a-89a9-5d2d8c172052"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6700), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6700), null, true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6700), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6700), new Guid("abfb59be-9c96-490f-9c4e-100c15c0c337"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6700), new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), null },
                    { new Guid("b36e0d34-9377-4143-a4c9-0a3c024c618c"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6680), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), null },
                    { new Guid("bcf7a0aa-ef3e-41fd-b5f0-ce06150f4211"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6710), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6710), null, true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6710), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a44b3d2f-ab86-4f4e-92ef-fd61b2894bf1"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), null },
                    { new Guid("c6f6bee3-4605-45a4-903d-c30c3bcbe15d"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6730), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), null },
                    { new Guid("e4a091a8-be7f-4775-aa01-eddc946aa89b"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6670), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6680), null, true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6670), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6680), new Guid("b07416a8-3151-48bf-a2e1-e3c5863f2683"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6680), new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), null },
                    { new Guid("ef1d29ab-d06f-4faa-a11c-af5f92778be1"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6770), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6770), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("c70e2d92-b390-4511-978b-e058c34c9099"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("e8a7af40-b210-430e-967a-e590bab72810"), null },
                    { new Guid("fd556190-6ea8-4fb7-bae7-37e31485cb0d"), true, new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6690), new DateTime(2025, 5, 24, 22, 57, 26, 837, DateTimeKind.Utc).AddTicks(6690), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("abfb59be-9c96-490f-9c4e-100c15c0c337"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), null }
                });

            migrationBuilder.InsertData(
                table: "TakenCourses",
                columns: new[] { "Id", "CourseId", "CreatedDate", "DeletedDate", "Grade", "StudentId", "TakenDate", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0035106c-8de1-455f-9c16-0fb3861b7333"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3460), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("007edc82-a1a4-4711-9c39-019e919b87b4"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8710), null, 8, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("00e831c1-cd2a-453e-994c-3529bacd4bed"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2300), null, 7, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0162f162-53e6-4ab6-9077-d75c9844235e"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(780), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("01777e57-2e88-4ab4-8ab4-58d8753ec15d"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8290), null, 6, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("01d4b23d-4dc0-4fb5-8569-0916c12f8dbe"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9330), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("02600fc7-d975-4521-ae51-9a3766f254bf"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(40), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("02b706dc-f4e7-44a7-a4db-4de8d77cec6e"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7750), null, 4, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("03386a34-9fc0-4ac8-a3b6-0e530d6061b6"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9210), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("034034e9-aea7-41aa-83de-eea188c125c0"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1720), null, 5, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("03f5d9be-b445-440e-80c5-e527729bdbda"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8990), null, 6, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("040b06a1-5175-4b0d-a51e-12f27ae657b0"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(460), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("045795ac-8796-4c62-ad1f-659a265d75df"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9030), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("04b03574-9524-43b4-9616-3aaa051872b5"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3470), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("05794c7e-04a0-486b-a0ed-31229677b7bd"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8610), null, 7, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("05e4510d-b887-4604-9688-e13394349684"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3290), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("05e8aaf7-460e-46c9-b84d-dc14fcc17346"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1980), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("063b61de-3d5e-4ec3-a432-c0532b960f07"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3040), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("06861b27-a0e4-41c7-948e-faab64b86272"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3570), null, 5, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0697cc46-4d7c-4b56-8717-3a0a0ab870f8"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3020), null, 6, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("06a60081-ba04-4949-99e6-d89e144629f5"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1360), null, 5, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("07458c6e-0553-467f-82ec-bd88fb5f4e66"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(890), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("07465db6-37aa-42d5-92b5-eeeb8ad21ae8"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3620), null, 7, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("07551c1e-cd4a-4418-a18a-d0784de63c0a"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9970), null, 7, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("07cbf59d-678c-424f-94ff-d6a8a8050b29"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9060), null, 5, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0803b201-1ee4-4cd0-a0f2-d545b2c30625"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8740), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0883ff25-ce8e-458e-9a7b-2c5c4eb36e3b"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3240), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("08c0b0d8-e997-4ef0-bde2-3798cade7c76"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(440), null, 6, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("09614a5f-209b-4893-9714-a9fa37e42d71"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9820), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("09f50512-354b-4830-8f98-9ddd881902cf"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1230), null, 5, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0a2cc0e8-c826-46da-9bf8-eee8c60bc000"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8670), null, 8, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0aea6547-3bd1-4938-8361-e98e738336c2"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3090), null, 6, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0b490b9e-f0e5-49f0-b872-2c4a073047dc"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8170), null, 7, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0b56ab49-b5a6-4e2a-b88f-c1efa5bdd93a"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3350), null, 7, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0b5f8bde-05e0-4904-bbe8-5d534724af7c"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8570), null, 7, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0c50ebc2-c706-4c57-8447-af617ef6099d"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(760), null, 5, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0cc7a414-a915-48f1-93cd-1a22cc56f35f"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9960), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0d1e7507-c165-4922-a333-6d04deaaae68"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1100), null, 6, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0d958799-49e7-43d9-924f-9e03ab6a3f96"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1290), null, 5, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0dca123c-0f50-4a3a-a32f-d8f9ecdfd6ef"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2310), null, 6, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0de87b0e-8faf-4e40-99a5-41cccb5bcae7"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(470), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0e82c704-056c-4383-8b7f-7b8678323712"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8200), null, 8, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0f2cd96e-6f07-41a3-a329-1367c33b915e"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1200), null, 7, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0faeb423-fa3a-48dc-bbb0-49b595f24ac1"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9590), null, 6, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("0fda749e-346a-4e35-8fca-a2edb8ac7827"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1690), null, 7, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("10079a56-18d3-48d4-89b8-76b357e99e57"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8410), null, 8, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("105a44cc-7157-41bc-995f-746d025e7909"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(430), null, 7, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("10801e63-35aa-438c-a6b1-fd2100c02a34"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(490), null, 6, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("10c40925-75fe-4190-99c1-0085b076b11f"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1620), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("10e5cd26-892c-40c9-8f72-fcaf71ed8fe7"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9350), null, 6, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("11c33945-d7d5-4b1c-b4f8-977826e1a102"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(240), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("122399ec-2549-4c55-ba14-27e53744145f"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1900), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("12278576-c534-4cd5-8f2a-d855a9eab2e6"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1670), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("12b21b26-9f0e-41a0-b56e-fea1a3c4a57d"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8150), null, 5, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1323c6b5-9cc0-4c15-b4e9-d6bcc0e76e57"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8260), null, 5, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("13678128-0d8c-42ec-83ed-51c2fbc10e70"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3480), null, 7, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("144b7878-9ef4-4fe4-b53b-4456b95036c3"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8430), null, 6, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("14a4b08c-dda2-4d12-950e-2ec2c114a21a"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7820), null, 5, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("15eaec85-6fc0-4542-a2f2-3f61eafcbf4b"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9740), null, 6, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("16433a34-7503-4498-a87e-3ec8a578bdfb"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2770), null, 7, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("176b5b51-b1b3-4086-bac5-ae4121ee9b56"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8730), null, 5, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("178315b2-90a9-454c-ad7c-853de53e4650"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(290), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("18173bb8-8177-4185-ae47-f21e7a28891d"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3370), null, 6, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("18e049f9-3ebc-46b6-8ede-ad79f7169abf"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(700), null, 6, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1931dd32-c30e-4fa9-8c4d-1ec3142e3a5f"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9730), null, 7, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("19d341ef-2bf5-4ebe-be44-9e076fef5c73"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9100), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("19fa79b5-3131-4333-899c-281c9da3650c"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8210), null, 7, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1a26fdbe-c272-4d8c-ae1b-ca952362f13e"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8800), null, 7, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1ac1f248-1151-4350-bdce-4a9da8b12ea9"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(990), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1b230170-7a69-4213-a8c6-5de949f54017"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9260), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1b51a63a-ca13-48f9-a5cb-11e145d1bca6"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(690), null, 7, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1bbee433-949a-4724-bcbb-6905109d729c"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2080), null, 6, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1c84edd8-0aff-415f-b3df-0f63f44c60ad"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3150), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1cd0f3c9-202e-4450-9107-bb6a4ad56efa"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9540), null, 5, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1d974e9b-fe8e-4601-8461-112916547541"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(560), null, 6, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1dd7ac98-915b-416d-9483-21291730c185"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8830), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1e87dba8-0964-40ea-9050-71e4b88b3ccb"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2180), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1ea34a41-e56b-48c2-94cb-7810414ed02a"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1740), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1eabac1d-efeb-465d-bc30-d3b0dbd0129d"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3280), null, 5, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1ec318db-f1ed-41b4-822d-a9339bb99cd6"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9370), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1f2203ac-60ff-4fd4-97e6-25ef32937b85"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9440), null, 6, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1f29e967-bf03-4385-9149-cbaefeadfd85"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3380), null, 5, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1f6a4efe-0ad4-4f24-913a-03d493bd248f"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(950), null, 5, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1f8e9ac4-86f3-49e9-a897-49e97174991b"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8020), null, 7, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1fe0b4d3-d894-4019-88cf-e23ac32fbc96"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1850), null, 7, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("1fed85bf-46a7-4fb4-8b38-006a06308b49"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9520), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2011826f-7eae-47af-a21b-d469b8a906e4"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9150), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("211362e4-6fe2-4e72-8378-a553be1b755a"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1370), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("217aeaa5-ee8f-42e2-a430-4108b34c32c9"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3500), null, 6, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("217fbd31-92e8-43a1-ab39-7366c72294af"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1540), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("21bd02e7-6e6b-4790-8827-97af5957c569"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8640), null, 4, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("22012a6e-31cf-49c4-bb0d-0de82091e7f2"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(260), null, 6, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("226f6a50-54fd-4c68-b95f-9f2203e120db"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3700), null, 7, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2296e936-9de9-4e62-81ef-10e870e73f00"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2450), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("22b72a5a-a1b4-4208-a706-a1536f96c306"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8830), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("22ce293b-170f-4cab-b188-982f6a91cc0c"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(130), null, 6, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("22f861fc-9797-45a3-9dea-d516a24d96fc"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8280), null, 7, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2300ce48-e353-4f21-b499-bf331415b17a"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1170), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2335e1dc-6008-4c5c-af2c-6ddd86d158c2"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9770), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("233eeea7-4524-42e7-bc40-5200502ca3a0"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1530), null, 5, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("23a6b959-c64a-4673-aade-1cfeb55ac05c"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9840), null, 7, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("23f3e9d6-fdcb-42ca-b935-9c0262d995ad"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1730), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("24d4df4b-0024-4e98-b78c-c137ad0667ed"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(10), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("24f271bf-6694-47d7-9e40-f9c010a5ce17"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9560), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("25d60342-73fc-4224-8319-2a996b2d88f2"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8070), null, 5, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("268df898-5285-4d4e-bfd8-48e19815d067"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8470), null, 6, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("27287ecc-840c-4c22-8f65-2a59448c8f2e"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8810), null, 5, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("274bd811-62f8-4b32-8820-984dc5f2abdd"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(720), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2771d9f6-b696-48d6-b551-e26741c4f7b6"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7880), null, 6, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("28010b6c-5bd1-425b-aef0-a20fb0410504"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3110), null, 5, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("282d0146-384d-41e5-b13b-f90948f20138"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2800), null, 5, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("283ebd81-6890-4b4c-9d47-400338a1cd34"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1090), null, 7, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("298e0b3c-b8f4-4c42-94b3-7806e13872c6"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(340), null, 5, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2ad16ff4-0c9b-48a9-bcf1-a1ebbe673b2c"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2550), null, 6, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2b6de36e-4da1-4ae4-8448-3e7bcfa54872"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1420), null, 7, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2b7ef97a-19d8-4c05-8f49-2d82f410ca8f"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8680), null, 6, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2be55a19-987c-49ab-99e3-a01969edde2d"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1270), null, 6, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2c36e166-a7cf-4d58-a808-ac2633bf8758"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8040), null, 4, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2c560c07-1031-44ff-8ac5-9234af4d8741"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3670), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2da3ea83-f716-40e2-bd1f-40d687e2170f"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8250), null, 6, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2e6dc330-2431-49e4-bcf1-9a62089e974d"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7810), null, 6, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2ed39a60-ea03-4d32-88d9-4410bfb85245"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7970), null, 4, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("2efcc34b-de78-4387-9f84-f26f9159567f"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7770), null, 6, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("305a8898-213a-4789-8d79-d8c0cf2cf11b"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8090), null, 8, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("30928a6e-5df6-47f5-be57-3a37f54577fe"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9680), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("30afe264-2ef7-485c-82ef-e883d9ebdd4b"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8870), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("30cb04dc-efb2-4546-894e-77b0a2f9b4a1"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8510), null, 5, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3184383c-0720-4243-aadc-56989e0fc552"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(370), null, 7, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("31ae28fd-888c-4af6-bd77-6a6183122ddb"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9990), null, 5, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("324e26f9-0f17-44f3-ac32-1f4084331b1c"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3270), null, 6, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3252f600-296c-4ea8-9337-adfe3d93a10d"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8650), null, 5, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("32a0a8ee-946c-4cfd-b2b0-d2e8096ba705"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1460), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("32e63c4c-a61f-437c-a725-337df7e0c6e9"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3060), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("339c6a8e-d55a-45d0-a2b9-4774f193f9d1"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8850), null, 6, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("33bbc2c6-9e64-4d14-bf29-2094efdf4f5b"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8190), null, 5, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("34c6e07d-9597-49b7-8bc9-2323f9f8932e"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(870), null, 6, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("35329729-551c-4667-97b4-0f1688c707e3"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(650), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("36243ff7-9b26-4b1b-956f-5aae98376118"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(100), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3679ad2a-a429-4390-bd3b-d06d961ed90e"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3310), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("36ad4a15-acbd-475c-a3b1-a8bd42b66390"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8440), null, 4, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("36bc417e-f183-4181-a4d6-dbe94352dbad"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1500), null, 7, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("370e384c-a889-4191-828a-2632e271f46b"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8780), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("380edecd-aa02-4600-b632-340f6ec9089a"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7790), null, 4, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3810fb13-0990-4b74-9e56-b6926c4549a2"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1070), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("381af488-58a9-44df-981e-f8c9e046a80c"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3000), null, 7, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("38492bff-c52d-4996-b92b-1d2a7c70b637"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(190), null, 7, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("38672138-2e07-4b34-b1ca-cca13296d17b"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1000), null, 7, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3933a6c4-bd1a-4410-afeb-aeade00beb8b"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(90), null, 5, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("39a530e9-a0e9-480f-bf2d-ca91474110b8"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8880), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("39d5a13c-6010-421a-b146-bba3c35e27c9"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1970), null, 5, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3c03fe4c-a612-47a3-9b8f-7a94f577f0ff"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9600), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3c3ac8ff-87ab-4feb-82fa-af5bc2eb5513"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1040), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3c6b5306-b885-4c7c-be0a-e4b3cb4f2820"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(510), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3ca5998f-f9bf-4e0e-98df-363d72376f74"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2930), null, 7, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3cc988f8-f426-4984-9456-bdc01ecde6bc"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(400), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3d73654e-6e9e-4e37-a01c-948c472edf80"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1880), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3e60a027-7f89-4930-b788-bacf03e592b8"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(920), null, 7, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3ef96662-2f0b-42c1-8ead-20a2f69a0d33"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8380), null, 5, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3efcc6e7-f59b-4a18-a537-8eb3f9603e39"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2960), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3f317823-c0f7-4769-a59e-b12640a429c1"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9850), null, 6, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("3f705d69-6559-4540-8bee-c8b9a871735d"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3390), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("403228d2-1f77-4bc9-b4b0-8901ed70eb03"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3610), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4065ee4b-e86e-4973-8205-5663db8589d2"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2030), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("407b9221-acb0-4fe9-a0a2-d86504ca4497"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1130), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("40e099c1-7e50-40b2-a551-73d494b565ce"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8180), null, 6, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("40ec12af-3153-4196-aa22-88cc5eff4450"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(970), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("415cd55e-4939-4727-999a-f4fef0862ebf"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(940), null, 6, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("42869bf4-c542-44d3-9398-be8faafa1b54"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3070), null, 7, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("42cc41fb-798c-40c5-b8b5-c87b4103dbf5"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1060), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("42f52584-0f6a-49fb-a585-cc7b76db926b"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8130), null, 8, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("43fedf9b-8a91-467d-973e-2e9872086080"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(410), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("440668b9-2fe4-4a3f-8573-8476c21527f3"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9340), null, 7, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("44289642-81ad-4b67-9ac3-a147a00bc745"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7830), null, 8, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4472d7ff-4a48-462f-a4e7-7a8b6c6cadbf"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3740), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("45a63d08-8505-4d70-9fc0-194420fb6df0"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8310), null, 4, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("45bc599a-dc9f-409f-a006-d23825638358"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9130), null, 7, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("45bffef6-795a-4d4f-af66-f1f9d6f85c5a"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8700), null, 4, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("46662d38-49f4-4337-bcab-06689b0acc9c"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8790), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("46f9a7a6-792e-4be4-b946-061d5851ce3b"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8450), null, 8, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("49aa49e3-55e9-4990-aadb-544b0c6dca3c"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8500), null, 6, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4a085ee9-96c6-4f8d-a187-3de399ba9400"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2850), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4a6d29c5-4879-4b15-98c0-fba85f6547d8"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(360), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4acdd90e-6bc8-484f-bd2f-f934442d5bae"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1550), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4b144737-fc9b-4630-9c9e-d613d96995d9"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7720), null, 8, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4c0bc7cc-97c3-463e-9c5a-d00d8eeadea4"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2100), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4c222742-f2c9-4644-aa48-5f54f20f38c0"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2520), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4d8353d8-969a-4813-b66d-bec1e1d50fcc"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8340), null, 5, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4e7f6dee-b0c3-4490-b980-4b83714257e8"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8960), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4f073543-3b89-4bc5-bf43-aa40e1c19829"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9980), null, 6, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4f2f43de-0d37-48ed-9277-3166366ef05a"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8310), null, 8, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("4ffd565f-6c4a-4496-aee2-410b9b768005"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8060), null, 6, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("50167bda-4d9c-42af-87e1-66ce88927dfc"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7670), null, 4, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("50ab79fb-ad6c-4a46-a35a-223435f51269"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7780), null, 5, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("50ce327d-b37c-42c5-8976-54b0c296db10"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2620), null, 6, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("515ee587-be4a-4a25-a4b0-eb47458b61a3"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1490), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("51962f4c-8a9a-4e33-8960-236f0b6d80fc"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2440), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("51ef5c8a-641b-46ba-9f22-9b4727ebafdd"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9780), null, 7, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("52763ea8-3f09-44bb-88f4-b43da6d21a71"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2000), null, 7, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("52caa271-8bab-4de0-b125-3567faec49e1"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7650), null, 7, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("550ae35b-3baf-46d4-91b3-b95a39d2ccd3"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8980), null, 7, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5527fc39-2e32-4cea-89bc-ca8405ec9fca"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2400), null, 7, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("556f4a4a-0f04-48f3-8457-6c3d4a5632a5"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(660), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("55c1080b-36ac-4e8f-b639-9c8c4cba39be"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9140), null, 6, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("55f7e17e-5f0f-408e-b954-f9c2d76ef27c"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9690), null, 5, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("565c5971-68c4-4009-932e-baeb9715438d"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7740), null, 5, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("56fd057b-af6e-47eb-90ea-f13a55108007"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2730), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("586207eb-c3da-4989-bb1e-93dd50119a96"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9450), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("58e824a4-5ca7-4719-8a14-c5f969f0be21"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7990), null, 7, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("58ecd26e-953b-4b6a-b0c8-b7d4e5f26b24"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2670), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("59f5b46a-2b3c-4ed1-ad1c-fb3a8ef6acc5"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8770), null, 5, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5a4f8ae3-3456-4199-a808-e237e47d7623"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2340), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5a58c9d9-a15e-4654-8708-45f5a99dfbb9"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8970), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5a66e463-e441-49dc-96a4-58e8a9bef7f6"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9650), null, 6, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5ac1d616-7f64-42ea-a1dc-316f08327fd7"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(610), null, 7, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5ae3dd5a-2f48-4534-9946-b2cdd3071774"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8430), null, 5, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5bd704b6-ad2e-43ec-a9c6-9278f9d27385"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2650), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5c4b28e9-d9f7-4b47-a6d4-fb7eb7edf2c6"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1110), null, 5, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5ca76ada-9fd1-403d-8e25-9b98401a3250"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9670), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5e667b83-87f0-4115-b419-dcf62d4ffbe8"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(50), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5e737fa3-1da2-4e45-803b-4352490fc1b1"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9520), null, 7, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("5f2f4005-3aa4-4cff-ae08-049cb74b7e9c"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(210), null, 5, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("601c848d-4bb7-427c-b611-3efc093e885e"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8520), null, 8, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("605d3a98-7774-416e-916d-7c6d5e9a9138"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7980), null, 8, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("608c2ca4-0c1b-4a8c-b6ae-0d13bc64552c"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9170), null, 7, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("609a4d23-348c-4052-a6a8-06eecc7065d2"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(330), null, 6, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60a89690-bae0-4d7d-8e26-d0db925e5559"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7900), null, 8, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("60fc6244-3430-417b-b9a5-430d3cac75c3"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("614b0608-8831-44ea-bf21-aec1872c39b2"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7660), null, 6, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("61c20ab9-81a6-4fe1-a9e8-e48e98b13846"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3340), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("621e2bf6-8a99-42ae-864f-dc1351bacdb3"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(860), null, 7, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("62231095-05b7-4879-800e-155cc73a626b"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1190), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("62bbfc18-961f-471a-aa97-e37a6a120421"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9240), null, 5, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("632243ab-ca25-4b61-b28f-1aa9e31896d4"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9280), null, 7, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("63b8c461-83d0-4150-9acc-03ebeaad9ab7"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1400), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("63fed09b-a638-4421-939e-1365a16fcecc"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2360), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("64888c9f-0e5d-4ac1-aafd-417f7b7fe9d4"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8550), null, 4, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6506fa7a-087d-4534-949a-849b23715f03"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(850), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("65209aec-ab6f-421e-965a-0ff06d22e58b"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9250), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("655a621d-54bb-47fa-8c35-7a52cb0a655f"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9090), null, 7, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("662d7b03-e253-4612-a4c1-ead4e63c8ff5"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(160), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("67528d1c-9e3b-4692-bb0c-3f685bd0ac6b"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9120), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("69e55597-211a-4f29-bbee-4cd42f7deb4f"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9690), null, 7, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6a06b253-31d5-41bb-a083-462d73dfb05a"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7790), null, 8, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6a4d5287-706c-468f-951a-9209a07206bf"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2250), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6a4de77a-d8fe-4cd7-81c6-c0f3a49774c0"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2330), null, 5, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6a54da9a-0e1c-4823-81b6-64d07f06ca16"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1780), null, 6, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6abe6af5-5e98-44ef-bc29-7350c09fec34"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8090), null, 7, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6ae19aa7-2d69-4255-b0e3-364de39f4dea"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1680), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6b552b0b-ac29-4d23-bf43-c40238e68d34"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(60), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6c296177-3e81-4c3c-9243-81c0dddc26e0"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2700), null, 6, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6c5ca3c1-96eb-4522-a8af-a440e2761443"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2760), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6c93eb2d-8898-4b05-8d2a-69ad3674b942"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8160), null, 8, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6e867034-64d3-4469-b1c3-325fa4017eb8"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7820), null, 4, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("6f333fbc-1469-42a2-a68f-ffea4036221b"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2470), null, 7, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7002ecf7-cce1-482c-9663-fdd996368eb3"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8230), null, 4, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7176b991-7b29-4e63-99de-2e06d0dbd7c0"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9160), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("71c6c9bd-d46a-4ac2-bb49-fa0f8b1fc4c4"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9910), null, 6, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("71ec1c5e-c2e4-46b0-91eb-af5b65a25b83"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(710), null, 5, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("721ef3ec-5ea3-43ce-917a-82f8c28b2d1e"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2140), null, 6, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7276a6e8-f13c-405b-a925-626d1089ec2e"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9430), null, 7, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("729236c3-d61d-46d3-beac-8fbfe750a07f"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2240), null, 5, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("72aa4813-3e84-4fc2-a7c2-cd61a4fd08bf"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1450), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("73accd96-9868-4748-82b9-b96126c90c4c"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2370), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("73ed9833-17ef-4dc0-bfb3-4be5dc66db64"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8690), null, 5, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7407b61c-6c8f-4d68-bb30-828eaf02d1d6"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1510), null, 6, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("74a90d9b-6c96-4722-9756-ba9a9bd05445"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1120), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("755c7bd5-a2a5-486c-8710-bc1f82260cd3"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9940), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("76cd2d56-d01a-4f9e-99e1-3f25d6fc2a77"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3640), null, 6, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("76e886e6-983b-4bb6-b59e-0062f12c1151"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2210), null, 7, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("76f67203-a3b6-4c0f-b5a3-a009b0549be1"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2990), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("775f06e1-703b-454f-bf3c-ddfbf0e3a5dd"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2830), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("77d86c6e-fb4d-4e11-bcb5-e4c49010a94a"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1920), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("783673bb-f98b-424d-a145-2533ed3a92a3"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9870), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("79894ca2-452a-458e-a6d3-262f7f2291b3"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8220), null, 5, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("79a8ac64-f988-4f9b-a08b-fd9e5b1d7dff"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(110), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7a0c8db2-7c05-4233-89ee-947fd8c5f089"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3420), null, 7, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7c732d01-09c7-4ce2-87a9-36074cebdb69"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2870), null, 7, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7cd282fa-1509-4120-8e11-e1855243ce84"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(80), null, 6, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7d5ebaa6-1090-4b2f-9935-d06806dc943d"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8040), null, 5, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7e194f0d-baed-441a-b5d7-9264a974ebe4"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9620), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7e1afe17-ee5a-4997-a2a0-a463a4622401"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2840), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7e4c5e3f-ba45-4c9e-a7ec-a23622e488e1"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7930), null, 4, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7e83ebd9-4e4e-4176-b92c-ed5cb4b13e82"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8330), null, 6, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7ea308a4-646c-4bdf-9ddd-67d80a1095e3"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9790), null, 6, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7f967a7c-659f-4df5-9270-67906ff1b920"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3660), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("7fc59125-f7fc-4e72-bc51-d7a9489eb125"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7850), null, 6, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("80ac45fe-6fbd-4cf1-ac5f-093d35d56ee7"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(450), null, 5, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("80c6e8a4-c8e9-4206-9a09-a7719f1d4e44"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9720), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("810ce7bd-4363-44d5-ba46-6e6b2c8ff5d5"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1590), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("810d3a30-ccfc-429f-aac3-3447e6cd4a1a"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8350), null, 4, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("81802dad-4bb1-44bc-b1ab-3c3d79bee3bc"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8930), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("81e545cd-7b97-40ee-b7a4-6354a37a65f8"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1140), null, 7, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("81fd6f44-3f2d-4545-b720-fea4419fefaa"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2510), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("82978dfd-ce81-4613-8b6b-290c5fa37884"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8320), null, 7, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("82980460-9912-4394-b9fc-4f030fdc55cc"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(220), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("829a9317-e35f-447a-a313-93c666b63db7"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(740), null, 7, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8367295b-371e-4a77-9bda-bb902574899f"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(170), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8399503d-bb83-4027-9e05-6cff50d08a3c"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2970), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("83ebdb7b-ccb5-48f4-a7a5-e0ba679a89c3"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8470), null, 4, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8433857b-a32c-478f-b38a-4d0653bc04c3"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9510), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("84679643-907f-46ae-8784-e503a18f7ad4"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8900), null, 5, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8481a3e6-9935-4732-9ab2-c6e9bcf84996"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9090), null, 5, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("84db02cc-57c5-4553-baec-491e1602ba05"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8280), null, 8, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("85843443-1d19-41b2-b355-465f59e12f63"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1790), null, 5, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("85923c5c-a78b-4446-904c-289c9d284db2"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7950), null, 7, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("85b63d7b-cb80-4739-9561-333d8eb8529e"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9860), null, 5, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("86147c2f-3fac-4fcc-932e-1b8fe521c29f"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(960), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8621416e-9fbc-472a-8e3c-7a177cf4ac52"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7870), null, 7, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("868951de-9da6-4f8f-ae86-d52c65b38903"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7760), null, 8, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("878211c2-4b8d-425c-b436-810928fefd71"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8980), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("896fe548-dfe2-479f-9e1d-e160b5e44b58"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8750), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8b01c6a5-f314-49ad-8293-13f47e56d7b4"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(570), null, 5, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8b134ac6-75e4-4a58-9c62-6c20ee82ba8b"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3510), null, 5, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8c12d68f-f544-4453-a59f-1b265df50427"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1560), null, 7, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8cb2bebe-2c65-4b0c-882d-1c09cb8f34ed"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(310), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8cd8fa4a-c494-4c92-a69e-8f2af6dd2471"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(300), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8dae7aa6-3250-4d26-89f9-9d09c88306ea"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8880), null, 7, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8de26f2c-4ec3-4ba3-9696-e3274e0d5f88"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8540), null, 6, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8e71a03f-c9f2-44bd-8d28-ca1cf50719ba"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8920), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8f3f15c2-c6fe-4c51-b41c-6027eabefd54"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8930), null, 7, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8f9edd37-a6ec-48ec-b44d-96cd896587db"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1660), null, 5, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8fbeffd7-2c21-4cb6-ab69-e81340ab06a4"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(30), null, 5, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("8ffe0647-08f1-494b-a513-15886fcd5f6b"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(20), null, 7, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("901e6c13-7abe-4de2-95d0-87dbb62eab6c"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1340), null, 7, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("909a6dc9-f0f8-4add-939a-368460fced40"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9000), null, 5, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("90dd2146-1e64-4af2-813f-eaef2204092f"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2890), null, 5, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("924168bd-ad25-40eb-95ca-db1ca9ea3864"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1650), null, 6, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("92d037fc-7068-4fb7-b09a-4de86fa0213a"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8950), null, 5, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("931a1ae5-7c8b-480b-bdd2-7185f9ba638f"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3600), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("934896c6-4fc9-4b30-84b0-2f77cc88ce82"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2270), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("936bfb85-e1ad-45d4-a914-3623761058e4"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2040), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("93abc6bb-ff4f-4f9d-9c5f-18441d710625"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9140), null, 5, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("93cd522d-fc1c-4daa-82a3-d710d782aa2e"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2660), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("93e460e5-c5cd-4b4f-b333-774409f7ca0a"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7910), null, 6, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("948dee19-0a35-4873-96aa-1b019cfc4ae8"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1910), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("957f4ea4-cbda-4bed-a93a-452a24d92721"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2130), null, 7, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("96082a1c-6166-47d5-892c-fd589cd3b86b"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3210), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9617d54b-e6e4-4805-bade-09b0473859b3"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8250), null, 7, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("96612c87-c48b-465a-a045-bf871d705b8a"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8120), null, 4, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("967f5e2f-0e19-4ec9-843c-c10bbfdff368"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9950), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("96ea502e-dcff-4ade-96c9-e1a6d3da2123"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(680), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("98c2998e-4e4b-461f-9d80-6f76d781a819"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9420), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("98efb3bc-340e-472c-81be-4c9949340f48"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9270), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("996f0edf-363a-4856-885c-ebbb2e73f5c8"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(550), null, 7, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("99a860ed-981e-4f63-9d0b-b656b86066c7"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7700), null, 6, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9a277ef7-96ec-4cc0-a73c-b78a0ae811c5"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2640), null, 5, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9ab23d71-6cea-48e7-97a7-70cf21e6d1f9"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9070), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9aefa78d-1a94-4abe-9bed-c9efee7298df"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3320), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9b434bce-fcf9-4c4a-8194-85553e81f943"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9110), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9bcdcb50-3c39-4cda-bdc7-47fd87c741d9"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9220), null, 7, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9c02f76c-cdc4-4446-863d-2bad45e7fd0f"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2120), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9c0de30a-948b-4325-85b5-11b531a65fb2"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3410), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9c5755d6-8e52-495b-b5d0-3846cfb4689b"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8730), null, 6, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9c704034-4ea9-476f-94d2-4a7748a4df20"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7870), null, 8, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9cd287a9-b884-479f-9f1e-088087c9a1fb"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(280), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9d46bd55-1e80-4c57-92cc-d7b7099454fc"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9880), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9da6a039-dad8-4b2d-b47b-41cb1d8a56af"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8100), null, 6, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9e761cf6-f1eb-40e7-a25a-33195653f0f3"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8560), null, 8, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9ec84401-0248-44b4-80d1-bed913c7695f"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8030), null, 6, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9ed71e1a-b9e6-4e8e-9d6b-c512ba88e14a"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(540), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9ee2adb3-a2c0-4a06-ad29-f24f78c7af37"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9460), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9f38861e-94dd-4ccd-b772-8006e514bd9b"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7690), null, 7, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9f5bf291-92ad-48f0-a6cb-7f9eb74b6b20"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7890), null, 5, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9fb06273-e76f-4d86-b6de-cdd7f5072c8a"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1480), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9fb538e2-2796-4be2-9bb0-5b945abf1d09"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2570), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("9ff9c70c-f1dc-4595-a408-37ae2b5bca57"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1240), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a03577b3-7209-42bd-8a81-6613d400dfcf"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9080), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a1e20ae8-e12d-456f-9958-6bd19a1f6103"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3720), null, 5, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a2ada726-3202-4a43-8631-d7b67d16c202"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(120), null, 7, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a31781bc-f1c2-4cec-b841-104e8ec17b9b"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1950), null, 6, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a33a0865-bd72-4713-911f-bbafdce5539f"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9490), null, 5, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a501936b-59b5-4e4c-b2e9-54d67ac880f5"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1320), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a537ec5f-7597-4638-8d41-9edb0f61d3c8"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9630), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a558181c-ec46-461a-a4eb-b561df7175a2"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1860), null, 6, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a573f25c-4698-44ea-a824-124f7ba048db"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1210), null, 6, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a594ff85-dc64-4a9b-9edc-33b2cf91f6ee"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2200), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a65f8b9b-35f8-45f9-898c-71b39dbf3457"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1870), null, 5, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a66f0655-5656-4f1b-868d-d2c48853cb86"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8480), null, 8, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a6c03873-f328-4159-b708-143cf2dfa33c"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3030), null, 5, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a6dbd9c2-7fb2-4f01-8e98-4782005640c6"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8580), null, 6, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a6fafd24-f611-4b08-ba09-4f43e53de0ab"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7730), null, 7, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a7ce7b2f-f5b0-402c-aa40-828a9c85a012"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8420), null, 7, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a7f94014-3da0-4b8e-8c1a-65a689da9e40"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2220), null, 6, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a85fda32-7490-4163-a4ba-d31aec49952c"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1810), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a92d230b-afb5-4021-b190-04ce597cbad3"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9050), null, 6, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("a9e5205d-10db-4d7f-8ef5-b2b922522410"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8640), null, 8, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("aa37e51a-c894-4528-b9ef-354031a6ba8f"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2050), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("aa9927ec-208d-4c98-98d2-394264746de0"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8770), null, 6, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ab35b930-9e07-4770-ba20-8e359ca63b84"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(520), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ab3718c1-66e8-479e-8aae-13a0cc904eea"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(900), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("abdb692c-79ee-4e00-92ff-e020aa13ce61"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7760), null, 7, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ac769ba1-4fc9-44fa-8df4-bf14314f513b"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3250), null, 7, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("acaa99ec-0d5a-421b-b567-1666f0080c80"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3120), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ace4ed71-7ad4-4476-866d-102945db3790"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(250), null, 7, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ad0da4fb-4ec0-401e-8091-cbd25d5c1d5f"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8400), null, 5, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ad14403e-ed59-44d6-b83b-ea1119ad6b69"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(600), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ad7bdaa1-c970-418d-b6eb-dea0b4292237"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8400), null, 4, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ad94b9ea-78e5-4c05-97c1-369898581950"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1030), null, 5, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ad9c7362-3e99-4b13-a40f-e8bd6b0f0ef3"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(820), null, 5, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("add3ee26-4c7b-42bd-bbf2-e814eff3d199"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1390), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("af475bea-f487-4a41-bad5-da6bc882ad02"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3430), null, 5, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b0952961-3373-415d-ad05-a7f94ec79678"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9440), null, 5, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b1f44b43-0887-47cd-af77-890c32771183"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9200), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b21805be-322e-4d02-97c9-0439670276cf"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2810), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b44ebfce-1b87-485d-998f-0d4f48b40294"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1830), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b47f6c34-00e0-4f45-9ff3-ffb432a21d73"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7860), null, 4, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b5f86d49-fc3d-420b-89f6-f8301ffa2bd0"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8270), null, 4, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b66a5301-59ff-471a-8506-ba3c36c90713"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8060), null, 7, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b911004f-ad5e-4357-b24d-6e3362e9e846"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9320), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b9745163-e633-4318-9064-9afc95b0d77e"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1250), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b98abe3f-06af-4ac4-bf84-75cf668d4f48"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9020), null, 8, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b98d5991-9045-4577-be5b-7e81bccb89fe"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9500), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("baddef72-8043-4f80-b759-4fe61da2f2dc"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8550), null, 5, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bae12328-8da5-4a27-8665-0bb7e3c13b39"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1300), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bb42689a-6b48-430e-bad7-9cf79c8ae94d"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7920), null, 5, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bbed5484-c5fd-40b3-8c9f-840bfa7a7351"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(200), null, 6, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bbf5a4e9-3928-4d1c-9246-cac82d047ba0"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3170), null, 7, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bc77929d-1afe-468c-8acc-948cf33d40eb"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9800), null, 5, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bd17fcac-b778-4a6d-9c87-7fa640c1afc8"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8300), null, 5, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bd3edb1c-605d-4b12-a50c-170e5193ec46"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9930), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bd472e0c-ad30-41a2-83ac-723af9e537f3"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8590), null, 4, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bdd65745-5dc5-428d-b0d7-36a8f868f1c6"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1160), null, 5, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bdd80b92-c5f1-4ed4-8d69-e4a5d4ba752c"), new Guid("fcce7661-1144-40da-a60c-abee39a52e1d"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2380), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bdefa113-62d8-4ece-bf46-410cf64befaa"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2480), null, 5, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("beb49e8d-0f05-4f87-9431-5664ed7192a2"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7660), null, 5, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("befbaac1-471c-4501-bf49-b9d080905505"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(880), null, 5, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bf236762-8501-45af-95fc-e024dfba0557"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1440), null, 5, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bfacaaba-d39e-4930-8601-34492aa5ac83"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8000), null, 5, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bfb57751-c25f-4d82-b4bf-9a5526a36e95"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7850), null, 5, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("bfec427c-e714-449c-9880-ae57da6bb6fa"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7710), null, 4, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c03e4cc8-4d22-48a5-8b3e-c7bff1e7052f"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(70), null, 7, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c0534ed5-a17c-4ad8-9f0d-a1ff546bc1ce"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9890), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c06d7f29-938d-4735-adc0-2872d8bc2010"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(620), null, 6, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c0b9cc8a-e19f-4384-a790-27720627c40e"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1350), null, 6, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c1855662-9490-4932-9263-25a23ebcb5e0"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9010), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c1d1d5ac-1119-4148-a656-f43c32103a0b"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9700), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c2cd5ae7-1c4c-4e99-bd11-4cff524dde56"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9640), null, 7, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c40d8191-3451-44c8-8ac9-f066bdc8e07e"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(150), null, 5, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c432c29c-0c44-4208-bdfd-a7266802d201"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1820), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c4557ff9-d946-4276-8a5c-0b35592ed468"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9750), null, 5, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c48f3eed-ef6d-4fec-a04d-9d664fd11cea"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8010), null, 4, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c4c2b495-8dca-4302-b4a1-74b93512dca2"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8240), null, 8, new Guid("69ac774a-242f-4774-889e-d3a3549c40c8"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c53b8667-e812-488a-b533-e325d6c0c541"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2600), null, 7, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c598b0be-fbed-4821-bb9d-ee76d4918356"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3230), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c5a0d1fa-b538-48dd-9750-139e7819a7bb"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9190), null, 5, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c6054864-adcf-4b81-ad36-fa3e689f71b2"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(500), null, 5, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c65b4763-4edb-4d94-bff8-1fae7220e71c"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1710), null, 6, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c743bf49-2318-4a8f-a62c-b026d65aa821"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2530), null, 7, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c781dae1-f377-406b-8a92-681a7824581b"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2410), null, 6, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c8c953e5-cdde-47f4-b3d7-ac7ac5c5092a"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(640), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c9f51453-0e5b-4172-b0b3-e0ef79b17395"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7640), null, 8, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cb1ab071-5c6c-4b96-be93-67decd7af477"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9920), null, 5, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cc04be28-eb96-44b3-994a-104d7086065d"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8010), null, 8, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cc5dd2e6-e961-4e05-8621-060a9c58ba96"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2290), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cce5cf21-8a41-4692-ae29-2e9f847209eb"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8050), null, 8, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cd885513-f2c1-48dd-94fc-7ed112dcb334"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7940), null, 8, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cd8eb393-252c-4695-82bc-2fe5f3212ace"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8130), null, 7, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cd9a6a1f-f338-48d4-98ae-cf8a635e5bee"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(480), null, 7, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cdf6f434-4f9f-4979-b4ab-0d0c54b6a720"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(830), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ce825136-9631-4ed2-978c-f3a23036bbb4"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7730), null, 6, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ce90951e-9537-4de4-ace7-dde52f1be142"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8220), null, 6, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cfe03334-3e7d-4712-882b-633ffde70b82"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1180), null, 4, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("cff2ec67-3103-4d6c-a73c-2a91d42d58e5"), new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9380), null, 7, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d0a7ec02-4803-4b9a-82b5-c4c865404a7e"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3710), null, 6, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d0c9f5f3-c9db-4445-a053-5947938e2d1e"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8360), null, 8, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d139488d-1e2c-41a9-9c79-9048dae1c7f7"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(630), null, 5, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d1635b50-1074-4069-8ff2-cdea110aa19a"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8080), null, 4, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d1956101-83c2-4327-a40b-ba2faae3e1fb"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7960), null, 5, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d1c5e307-cbf0-4aaa-ae31-cedc6a32395a"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7950), null, 6, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d2209522-ba2e-4c85-98bf-ea51ce1cedbd"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(180), null, 8, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d26073bd-d945-437b-ab39-7bc67f13debc"), new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7680), null, 8, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d2663462-72d4-4b1e-bf3d-54c21ce1ac7e"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7900), null, 7, new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d2913c26-638f-4565-aede-ffac8fd57567"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3520), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d35208c2-8f97-4617-b777-ec787485cb5c"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8660), null, 4, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d3a4d22e-d2e8-4f93-b4e6-ddd24fa9b5f7"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(790), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d3de3af2-5a29-475a-adc6-1526bcf01842"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2490), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d4d33abb-7e65-46e8-a04c-ac1b962624a9"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(770), null, 4, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d571ce17-252e-46af-84f6-5015114cf914"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8680), null, 7, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d6898b71-8fb2-4d7e-8560-76c9b9754244"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3580), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d7ac2579-5b23-4afd-ae04-75b14c5d1e0b"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9530), null, 6, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d7ccb058-7c1a-4281-938a-d035cb5c4440"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9480), null, 6, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d7d3642f-0bf1-4682-9f01-be3dc6ccc5f6"), new Guid("a4b77974-698e-47a9-9818-a82e4b22191f"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2160), null, 5, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d83cd362-1ea5-4270-adb1-bcac06105275"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9660), null, 5, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d8b853f0-4de1-423d-b5e3-52df514c873e"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9370), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d8c4737c-40f7-431c-9ea3-9fdd03655e9a"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3440), null, 4, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d912fba6-ec50-41e3-b8c4-60157b4ba135"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8890), null, 6, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d93ff630-6350-4ee4-84be-6f79381e2786"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(800), null, 7, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d9a91f28-c812-41eb-b66e-6993aadecaa8"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3560), null, 6, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d9f16f1b-5743-4d0c-ba46-91da95796143"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9030), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("da9bfc78-3a79-407b-ad46-053a59fb8f58"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8390), null, 4, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("db7cb7a9-710b-4fb9-8df5-aebe7acbb7dd"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8140), null, 6, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("dd66ee51-c661-4202-bf46-197951afd25c"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2780), null, 6, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("de4a6f10-fff4-48ff-bcf4-ad4765f1a6a1"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1770), null, 7, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("de70072a-015c-4646-9ba1-92ed396c6f04"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8600), null, 8, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("df52f096-f5db-47c2-a187-797765bc603d"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9400), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("dfb39692-c86a-4b20-9fca-1f328f4f15c5"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9710), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("dfc392e4-274b-4dbf-b400-c61de9029717"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1260), null, 7, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e03e0283-6a31-4c0a-a16b-4adc6b057aea"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9410), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e09b026f-b674-4d34-8e1d-467cc46babf8"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8510), null, 4, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e105534e-e7f2-4585-a43e-e9008106070f"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8190), null, 4, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e1508e5e-a06f-42d7-ae7a-92145050860b"), new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3140), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e1955b42-77a4-48da-945d-bfa9a52034c9"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8820), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e1fd16b7-4119-4d13-8108-6eb09a20093f"), new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(420), null, 8, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e2df8f9d-6431-42d9-9449-ca88708f74b2"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1430), null, 6, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e35813eb-7d9c-49fd-b14d-b5084a78faee"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8760), null, 7, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e3674997-2d96-4b0e-bf8c-b50ef8697db5"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8940), null, 6, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e38f46ef-de23-4d67-8930-a812104e0ec6"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1940), null, 7, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e3dd4224-7379-4508-b58f-94a8bf1a6a58"), new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9760), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e42264aa-4f6c-4e9b-8338-14c195164fc3"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2560), null, 5, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e4287b0f-60b9-4b4c-9ea2-cfe2e52cdb50"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2690), null, 7, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e4b19824-cd7a-4894-9906-23f5b7850add"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1990), null, 8, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e5113ba8-7d7b-4a1a-a13b-fdb27f2469df"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1010), null, 6, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e5269a6b-59a4-4fb6-87ee-612a69c00917"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2720), null, 5, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e5566ca6-23e8-47d3-ac13-3f35d65a6000"), new Guid("60b000b9-7671-4e2e-9169-044f271cf78f"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8160), null, 4, new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e602b980-cae1-4ff8-86dc-5f6220ce46b6"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9220), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e6282405-a4b4-4c0f-929f-e1711c7824f4"), new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(810), null, 6, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e67c392c-fd8f-4126-8239-4efa33022173"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9290), null, 6, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e6de8806-3e4d-4cf8-b6b6-2426e5178c85"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9830), null, 8, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e7828002-20ca-4823-bdcd-3baedf14b476"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8460), null, 7, new Guid("e8a7af40-b216-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e7acde56-ad28-4194-9b11-ae1daeebd35d"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8590), null, 5, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e7d53704-d6a1-4223-b7c4-4dd5f67553dd"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2900), null, 4, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e855e312-1dd0-4ef4-9d4e-32830c1f1e8c"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2170), null, 4, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e8906873-86fa-477c-9927-3914395d1f17"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2740), null, 4, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e8e07716-104b-43ba-8316-1726abb2c0ce"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1580), null, 5, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e901d1c7-a278-4f52-8c9e-8c24b0d23d28"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8860), null, 5, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e92b2b52-b174-4ffa-bd5b-efb09c42d7d5"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(350), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e94b3187-91ab-4a2b-9a60-0c5c26ba2599"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9040), null, 7, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ea32e57f-5814-4b71-951d-57dfe38b5e7a"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9570), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ea8e695b-ffdd-4b7c-a225-d079d73080de"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(910), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("eb837cdf-fb0d-4cfd-a0cc-9f98433cc288"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9610), null, 8, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("edde62bf-0edc-4b4b-9364-0b7870e6633d"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8360), null, 7, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("eded2325-791c-461b-a727-8baae2956ce9"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7800), null, 7, new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ee53d28b-9352-4b1a-a319-076108c6b6d7"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1330), null, 8, new Guid("79cace77-5720-434d-97b6-0d47a61468a3"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ee8bd47e-e6d5-4115-b52f-888064df4aa8"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3200), null, 5, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ee9b8ddf-fe7d-4771-8139-a033fede7efb"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(230), null, 4, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("eee39d9f-23ea-4efa-b6f3-d429390ab6fb"), new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(320), null, 7, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ef1bbf9b-0c27-4322-b82e-17bafd56fda1"), new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8370), null, 6, new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ef517abf-6434-48c7-b2b9-464b0f6ec4f9"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9300), null, 4, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ef92b89c-2835-4066-a82b-f1366c10b73c"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9470), null, 7, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("efa3605b-d5fa-4bbe-854c-3f8ff22d1247"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(580), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("efbc8dc8-825b-48c8-8f8c-0923b07ec9e1"), new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2090), null, 5, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f033db9a-f9e5-40a9-b3ce-4a3978620e3e"), new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9550), null, 4, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f057ed00-80c2-4a3c-a036-868a52afcc29"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9180), null, 6, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f0635e6d-3ae4-4400-a5ce-502fb8feb208"), new Guid("4d61379e-f179-4f77-ba15-ac504acc3145"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2880), null, 6, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f0a5e354-7ff0-4740-b93e-f56078e6b4e4"), new Guid("185e5459-ee35-416c-821d-ec6c5c93e914"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8620), null, 6, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f12cf744-ab3d-4576-b40e-d76476bc1833"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9580), null, 7, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f1836567-0c0a-4343-a51c-d4dfe251b0f0"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9310), null, 8, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f19733b5-4328-4e12-a3a5-75b071b17cad"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3750), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f2094229-fe0b-4fbc-a3ec-5a9b5976fb6e"), new Guid("0d457f60-7e5f-4898-926a-da3a08a52086"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1050), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f220b389-811e-45c4-9ade-22f1cb17f05e"), new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9900), null, 7, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f28c5760-b6c7-4742-9d30-ac9652ef3a61"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9390), null, 5, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f2c1122b-293e-4b66-b152-3d531fa710a6"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(730), null, 8, new Guid("e8a7af40-b211-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f44a77c7-5d2d-42b1-9b94-542cbb01eb8d"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8630), null, 5, new Guid("e8a7af40-b212-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f468e6e5-3992-4038-aa2c-c1e3b91ede2d"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8720), null, 7, new Guid("e8a7af40-b209-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f4a77ccf-f1be-49b1-a263-e8a1a834f705"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9590), null, 5, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f5e02325-4a0f-47f6-95b7-fc8502731423"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7840), null, 7, new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f6601e4b-8bfc-48d5-bf8a-9867f4f1b4d6"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2070), null, 7, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f726a349-e96f-4828-88e4-bfcc9342fceb"), new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8110), null, 5, new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f7b27ac5-8ce4-4bf7-b208-78740cc68ca9"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8490), null, 7, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f7b62980-92e0-443d-8229-aab1845a140b"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2940), null, 5, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f8682b7a-0037-4986-9913-f8e1e9922a30"), new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3650), null, 5, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f892a860-e900-4139-920f-2cf3d71294c3"), new Guid("4352c9aa-850e-4810-ad3e-3d289b764461"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2920), null, 8, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fa2e36a3-6572-45a4-9fa6-cbbfc76659cb"), new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8530), null, 7, new Guid("e8a7af40-b213-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("faa6b819-57da-4a5e-be1a-0fb20471add0"), new Guid("4777afa3-a512-4353-8109-0674da099cf0"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3690), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fb725fa9-6213-484c-bf29-c4f4b04fc015"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(270), null, 5, new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fc02343f-be44-4f8a-a520-9ac22412fcbd"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2020), null, 5, new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fc20fffc-e3c2-4ca6-9842-65797f1a578b"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9230), null, 6, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fc38ba23-7bc0-42d8-adbf-9b91b9494f71"), new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(380), null, 5, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fc3bc31c-c54c-4599-b6da-b1f073dac049"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9360), null, 5, new Guid("9000296e-dd35-476c-8702-cb20fd49c946"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fc483cda-926c-4ee2-ac89-b8b294d1f7c3"), new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1610), null, 4, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fc75e299-afb8-4f15-a8c6-5abc0b832022"), new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2420), null, 5, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fd0754c8-8a1e-4474-ac19-dd5db88e6fab"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8910), null, 4, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fd7421ac-1a0d-4af3-a469-df12d77e07e6"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1630), null, 7, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fdc2921b-e150-4da4-8b34-8929be1fb0ff"), new Guid("8326f736-1827-4131-80e0-8ec78340ac0a"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7700), null, 5, new Guid("22222222-2222-2222-2222-22222222222a"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fdcd44fb-f915-4446-8869-16688acd6279"), new Guid("702736bc-c6e0-4417-abad-ab8561561e96"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3180), null, 6, new Guid("e8a7af40-b215-430e-967a-e590bab72810"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fe340e40-fc37-4bc4-9e37-4d99d1721e2f"), new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(8840), null, 7, new Guid("e8a7af40-b208-430e-967a-e590bab72810"), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fe72d29e-1ed7-4873-af3b-fc4aa1e3540d"), new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3550), null, 7, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fe917eab-adfa-40a0-a140-cc874073eed3"), new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(590), null, 4, new Guid("e8a7af40-b210-430e-967a-e590bab72810"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("feb93de3-f0aa-4871-a873-e8e274f4dff7"), new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(7990), null, 6, new Guid("c4e05469-860b-4655-b844-f682a21fca23"), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fee3e90c-a9c7-4b4a-89a1-e07a057bff7c"), new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9810), null, 4, new Guid("b915a233-f885-4d89-9c21-bb42d11bb307"), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ff077af2-d855-4803-bfe2-d74519e3af73"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(2590), null, 8, new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ff24d1a7-c7ad-4aa2-bbdc-7f4aa006e51c"), new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(3530), null, 8, new Guid("e8a7af40-b214-430e-967a-e590bab72810"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ff2705cf-453f-41a7-a1b5-204f64896497"), new Guid("177d582d-96ce-4bd8-9496-5e2167148c57"), new DateTime(2025, 5, 24, 22, 57, 26, 839, DateTimeKind.Utc).AddTicks(1760), null, 8, new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4"), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("fff3a3c6-bc40-4daf-96e6-6d1226b14a27"), new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d"), new DateTime(2025, 5, 24, 22, 57, 26, 838, DateTimeKind.Utc).AddTicks(9300), null, 5, new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null }
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
