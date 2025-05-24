namespace Application.Features.Users.Constants;

public static class UsersMessages
{
    public const string SectionName = "Users";

    // Genel mesajlar
    public const string UserDontExists = "UserDontExists";
    public const string PasswordDontMatch = "PasswordDontMatch";
    public const string UserMailAlreadyExists = "UserMailAlreadyExists";
    public const string InvalidUserType = "InvalidUserType";
    public const string UserIsNotActive = "UserIsNotActive";

    // Student mesajları
    public const string StudentNotFound = "StudentNotFound";
    public const string StudentNumberAlreadyExists = "StudentNumberAlreadyExists";
    public const string InvalidStudentNumber = "InvalidStudentNumber";

    // Staff mesajları
    public const string StaffNotFound = "StaffNotFound";
    public const string InvalidStaffType = "InvalidStaffType";
    public const string StaffAlreadyAssigned = "StaffAlreadyAssigned";

    // Advisor mesajları
    public const string AdvisorNotFound = "AdvisorNotFound";
    public const string AdvisorAlreadyAssigned = "AdvisorAlreadyAssigned";
    public const string MaxStudentLimitReached = "MaxStudentLimitReached";

    // Department Secretary mesajları
    public const string DepartmentSecretaryNotFound = "DepartmentSecretaryNotFound";
    public const string DepartmentNotFound = "DepartmentNotFound";

    // Deans Office mesajları
    public const string DeansOfficeStaffNotFound = "DeansOfficeStaffNotFound";
    public const string FacultyNotFound = "FacultyNotFound";
}
