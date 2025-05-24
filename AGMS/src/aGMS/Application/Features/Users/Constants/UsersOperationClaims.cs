namespace Application.Features.Users.Constants;

public static class UsersOperationClaims
{
    private const string _section = "Users";

    // Admin yetkileri
    public const string Admin = $"{_section}.Admin";
    public const string SystemAdmin = $"{_section}.SystemAdmin";

    // Student yetkileri
    public const string Student = $"{_section}.Student";
    public const string StudentRead = $"{_section}.Student.Read";
    public const string StudentWrite = $"{_section}.Student.Write";

    // Staff yetkileri
    public const string Staff = $"{_section}.Staff";
    public const string StudentAffairsStaff = $"{_section}.StudentAffairsStaff";
    public const string Advisor = $"{_section}.Advisor";
    public const string DepartmentSecretary = $"{_section}.DepartmentSecretary";
    public const string DeansOfficeStaff = $"{_section}.DeansOfficeStaff";

    // Genel yetkiler
    public const string Read = $"{_section}.Read";
    public const string Write = $"{_section}.Write";
    public const string Create = $"{_section}.Create";
    public const string Update = $"{_section}.Update";
    public const string Delete = $"{_section}.Delete";
}
