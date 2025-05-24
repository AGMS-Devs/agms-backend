using System;

namespace Application.Constants;

public class BaseOperationClaims
{

    public const string Admin = "Admin";
    public const string Student = "Student";
    public const string Advisor = "Advisor";
    public const string Staff = "Staff";
    public const string DepartmentSecretary = "Department Secretary";
    public const string FacultysDeansOffice = "Faculty's Deans Office";
    public const string StudentAffairs = "Student Affairs";
    public const string Rectorate = "Rectorate";
    
    public static string[] AllRoles => [Admin, Student, Advisor, Staff, DepartmentSecretary, FacultysDeansOffice, StudentAffairs, Rectorate];
     
    public static class Operations
    {
        public const string Read = "Read";
        public const string Write = "Write";
        public const string Create = "Create";
        public const string Update = "Update";
        public const string Delete = "Delete";
    }
    
    public static string[] GetOperationsForSection(string section)
    {
        return [
            $"{section}.{Operations.Read}",
            $"{section}.{Operations.Write}",
            $"{section}.{Operations.Create}",
            $"{section}.{Operations.Update}",
            $"{section}.{Operations.Delete}"
        ];
    }
}
