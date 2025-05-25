using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Hashing;
using Domain.Enums;

namespace Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType").IsRequired();
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(u => u.Name).HasColumnName("Name").IsRequired();
        builder.Property(u => u.Surname).HasColumnName("Surname").IsRequired();
        builder.Property(u => u.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(u => u.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(u => u.UserType).HasColumnName("UserType").IsRequired();

        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

        builder.HasMany(u => u.UserOperationClaims)
            .WithOne(uoc => uoc.User)
            .HasForeignKey(uoc => uoc.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.RefreshTokens)
            .WithOne(rt => rt.User)
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.EmailAuthenticators)
            .WithOne(ea => ea.User)
            .HasForeignKey(ea => ea.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.OtpAuthenticators)
            .WithOne(oa => oa.User)
            .HasForeignKey(oa => oa.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(GetSeeds());
    }

    public static Guid SystemAdminUserId { get; } = new Guid("11111111-1111-1111-1111-11111111111A");
    public static Guid StudentUserId { get; } = new Guid("22222222-2222-2222-2222-22222222222A");
    public static Guid StudentUserId2 { get; } = new Guid("3d537f74-b4bf-4d2f-9eeb-20a8bbb97f45");
    public static Guid StudentUserId3 { get; } = new Guid("b915a233-f885-4d89-9c21-bb42d11bb307");
    public static Guid StudentUserId4 { get; } = new Guid("cbcbda81-0c34-4807-a919-451a39ab82a4");
    public static Guid StudentUserId5 { get; } = new Guid("b0ae4eef-b3b4-43d9-991a-2d1f0430ff24");
    public static Guid StudentUserId6 { get; } = new Guid("9000296e-dd35-476c-8702-cb20fd49c946");
    public static Guid StudentUserId7 { get; } = new Guid("9cc804b6-cad5-484f-8806-4cb8d28d05df");
    public static Guid StudentUserId8 { get; } = new Guid("c4e05469-860b-4655-b844-f682a21fca23");
    public static Guid StudentUserId9 { get; } = new Guid("e9da95f6-f8fc-4fa9-b9e0-ee7b3a98d7e8");
    public static Guid StudentUserId10 { get; } = new Guid("7a1208e1-ed95-4eff-b46c-921b19cf6257");
    public static Guid StudentUserId11 { get; } = new Guid("b8ae502b-1c7f-4095-be4f-ff56b44f050b");
    public static Guid StudentUserId12 { get; } = new Guid("2c693ad3-3aba-4464-853a-90b37a1056f6");
    public static Guid StudentUserId13 { get; } = new Guid("655cc5b8-b540-4d45-b716-bf095f0e7ba4");
    public static Guid StudentUserId14 { get; } = new Guid("79cace77-5720-434d-97b6-0d47a61468a3");
    public static Guid StudentUserId15 { get; } = new Guid("69ac774a-242f-4774-889e-d3a3549c40c8");
    public static Guid StudentUserId16 { get; } = new Guid("0bf6c440-0020-4eb8-9f0c-551778411d4d");
    public static Guid StudentUserId17 { get; } = new Guid("a60ca811-a3c7-4eb1-887e-22b40c4046f5");
    public static Guid StudentUserId18 { get; } = new Guid("e8a7af40-b216-430e-967a-e590bab72810");
    public static Guid StudentUserId19 { get; } = new Guid("e8a7af40-b215-430e-967a-e590bab72810");
    public static Guid StudentUserId20 { get; } = new Guid("e8a7af40-b214-430e-967a-e590bab72810");
    public static Guid StudentUserId21 { get; } = new Guid("e8a7af40-b213-430e-967a-e590bab72810");
    public static Guid StudentUserId22 { get; } = new Guid("e8a7af40-b212-430e-967a-e590bab72810");
    public static Guid StudentUserId23 { get; } = new Guid("e8a7af40-b211-430e-967a-e590bab72810");
    public static Guid StudentUserId24 { get; } = new Guid("e8a7af40-b210-430e-967a-e590bab72810");
    public static Guid StudentUserId25 { get; } = new Guid("e8a7af40-b209-430e-967a-e590bab72810");
    public static Guid StudentUserId26 { get; } = new Guid("e8a7af40-b208-430e-967a-e590bab72810");
    public static Guid StudentAffairsStaffUserId { get; } = new Guid("33333333-3333-3333-3333-33333333333a");
    public static Guid ComputerEngineeringAdvisorUserId1 { get; } = AdvisorConfiguration.ComputerEngineeringAdvisorId1;

    public static Guid ElectricalEngineeringAdvisorUserId1 { get; } = AdvisorConfiguration.ElectricalEngineeringAdvisorId1;

    public static Guid PhysicsAdvisorUserId1 { get; } = AdvisorConfiguration.PhysicsAdvisorId1;

    public static Guid ChemistryAdvisorUserId1 { get; } = AdvisorConfiguration.ChemistryAdvisorId1;

    public static Guid MathematicsAdvisorUserId1 { get; } = AdvisorConfiguration.MathematicsAdvisorId1;

    public static Guid MechanicalEngineeringAdvisorUserId1 { get; } = AdvisorConfiguration.MechanicalEngineeringAdvisorId1;


    // Staff için User ID'leri
    public static Guid DepartmentSecretaryUserId { get; } = new Guid("55555555-5555-5555-5555-55555555555a");
    public static Guid ElectricalEngineeringDepartmentSecretaryUserId { get; } = new Guid("e32d7b07-a92e-4dda-83e0-c90ee8cad8e5");
    public static Guid PhysicsDepartmentSecretaryUserId { get; } = new Guid("89e73bfc-718e-49d4-92af-1c576d281cf4");
    public static Guid DeansOfficeStaffUserId { get; } = new Guid("66666666-6666-6666-6666-66666666666a");
    public static Guid ScienceFacultyDeansOfficeStaffUserId { get; } = new Guid("77777777-7777-7777-7777-77777777777a");
    public static Guid RectorateStaffUserId { get; } = new Guid("88888888-8888-8888-8888-88888888888a");

    private IEnumerable<User> GetSeeds()
    {
        // 1) System Admin
        HashingHelper.CreatePasswordHash("AdminPass123!", out byte[] adminHash, out byte[] adminSalt);
        yield return new User
        {
            Id = SystemAdminUserId,
            Name = "System",
            Surname = "Admin",
            Email = "admin@iyte.edu.tr",
            PasswordHash = adminHash,
            PasswordSalt = adminSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Admin,
            IsActive = true,
            PhoneNumber = "1234567890"
        };

        // 2) Student User 1
        HashingHelper.CreatePasswordHash("StudentPass123!", out byte[] studentHash, out byte[] studentSalt);
        yield return new User
        {
            Id = StudentUserId,
            Name = "Ali",
            Surname = "Veli",
            Email = "20220001@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "2345678901"
        };

        // 3) Student User 2
        yield return new User
        {
            Id = StudentUserId2,
            Name = "Ayşe",
            Surname = "Yılmaz",
            Email = "20220002@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "3456789012"
        };

        // 4) Student User 3
        yield return new User
        {
            Id = StudentUserId3,
            Name = "Mehmet",
            Surname = "Öz",
            Email = "20210003@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "4567890123"
        };

        // 5) Student User 4
        yield return new User
        {
            Id = StudentUserId4,
            Name = "Fatma",
            Surname = "Kaya",
            Email = "20190004@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "5678901234"
        };

        // 6-18) Additional Student Users (shortened for brevity)
        yield return new User
        {
            Id = StudentUserId5,
            Name = "Emre",
            Surname = "Demir",
            Email = "20220005@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "6789012345"
        };

        yield return new User
        {
            Id = StudentUserId6,
            Name = "Zeynep",
            Surname = "Aydın",
            Email = "20220006@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "7890123456"
        };

        yield return new User
        {
            Id = StudentUserId7,
            Name = "Burak",
            Surname = "Çelik",
            Email = "20210007@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "8901234567"
        };

        yield return new User
        {
            Id = StudentUserId8,
            Name = "Selin",
            Surname = "Yıldız",
            Email = "20220008@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "9012345678"
        };

        yield return new User
        {
            Id = StudentUserId9,
            Name = "Can",
            Surname = "Arslan",
            Email = "20200009@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "0123456789"
        };

        yield return new User
        {
            Id = StudentUserId10,
            Name = "Deniz",
            Surname = "Şahin",
            Email = "20220010@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "1122334455"
        };

        yield return new User
        {
            Id = StudentUserId11,
            Name = "Ece",
            Surname = "Güneş",
            Email = "20210011@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "2233445566"
        };

        yield return new User
        {
            Id = StudentUserId12,
            Name = "Mert",
            Surname = "Doğan",
            Email = "20220012@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "3344556677"
        };

        yield return new User
        {
            Id = StudentUserId13,
            Name = "İrem",
            Surname = "Kılıç",
            Email = "20200013@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "4455667788"
        };

        yield return new User
        {
            Id = StudentUserId14,
            Name = "Onur",
            Surname = "Özkan",
            Email = "20210014@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "5566778899"
        };

        yield return new User
        {
            Id = StudentUserId15,
            Name = "Pınar",
            Surname = "Altın",
            Email = "20220015@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "6677889900"
        };

        yield return new User
        {
            Id = StudentUserId16,
            Name = "Serkan",
            Surname = "Bozkurt",
            Email = "20200016@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "7788990011"
        };

        yield return new User
        {
            Id = StudentUserId17,
            Name = "Tuba",
            Surname = "Karaman",
            Email = "20210017@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "8899001122"
        };

        yield return new User
        {
            Id = StudentUserId18,
            Name = "Yasin",
            Surname = "Erdoğan",
            Email = "20220018@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "9900112233"
        };

        yield return new User
        {
            Id = StudentUserId19,
            Name = "Yusuf",
            Surname = "Yılmaz",
            Email = "20220019@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "1121334455"
        };

        yield return new User
        {   
            Id = StudentUserId20,
            Name = "Kasım",
            Surname = "Yılmaz",
            Email = "20220020@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt, 
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "1122339455"
        };          

        yield return new User
        {
            Id = StudentUserId21,
            Name = "Mehmet",
            Surname = "Yılmaz",
            Email = "20220021@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "1722334455"
        };

        yield return new User
        {
            Id = StudentUserId22,
            Name = "Aişe",
            Surname = "Yılgın",
            Email = "20220022@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "1122634455"
        };

        yield return new User
        {
            Id = StudentUserId23,
            Name = "Ayşe",  
            Surname = "Yılmaz",
            Email = "20220023@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "1122334454"
        };

        yield return new User
        {
            Id = StudentUserId24,
            Name = "Ayşecik",
            Surname = "Yıldır",
            Email = "20220024@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "1123445555"
        };

        yield return new User
        {
            Id = StudentUserId25,
            Name = "Memo",
            Surname = "Yilik",
            Email = "20220025@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "1123445556"
        };

        yield return new User
        {
            Id = StudentUserId26,   
            Name = "Aşkın",
            Surname = "Durmaz",
            Email = "20220026@std.iyte.edu.tr",
            PasswordHash = studentHash,
            PasswordSalt = studentSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Student,
            IsActive = true,
            PhoneNumber = "1123445557"
        };

        // 3) Student Affairs Staff
        HashingHelper.CreatePasswordHash("StaffPass123!", out byte[] staffHash, out byte[] staffSalt);
        yield return new User
        {
            Id = StudentAffairsStaffUserId,
            Name = "Hafize",
            Surname = "Kaya",
            Email = "studentaffairs@iyte.edu.tr",
            PasswordHash = staffHash,
            PasswordSalt = staffSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Staff,
            IsActive = true,
            PhoneNumber = "3334445566"
        };

        // 4-8) Advisor Users
        HashingHelper.CreatePasswordHash("AdvisorPass123!", out byte[] advisorHash, out byte[] advisorSalt);
        yield return new User
        {
            Id = ComputerEngineeringAdvisorUserId1,
            Name = "Ozan Raşit",
            Surname = "Yürüm",
            Email = "advisor1@iyte.edu.tr",
            PasswordHash = advisorHash,
            PasswordSalt = advisorSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Advisor,
            IsActive = true,
            PhoneNumber = "4445556677"
        };

        yield return new User
        {
            Id = ElectricalEngineeringAdvisorUserId1,
            Name = "Dr. Ayşe",
            Surname = "Demir",
            Email = "advisor2@iyte.edu.tr",
            PasswordHash = advisorHash,
            PasswordSalt = advisorSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Advisor,
            IsActive = true,
            PhoneNumber = "5556667788"
        };

        yield return new User
        {
            Id = PhysicsAdvisorUserId1,
            Name = "Dr. Hasan",
            Surname = "Özkan",
            Email = "advisor3@iyte.edu.tr",
            PasswordHash = advisorHash,
            PasswordSalt = advisorSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Advisor,
            IsActive = true,
            PhoneNumber = "6667778899"
        };

        yield return new User
        {
            Id = ChemistryAdvisorUserId1,
            Name = "Dr. Fatma",
            Surname = "Şen",
            Email = "advisor4@iyte.edu.tr",
            PasswordHash = advisorHash,
            PasswordSalt = advisorSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Advisor,
            IsActive = true,
            PhoneNumber = "7778889900"
        };

        yield return new User
        {
            Id = MathematicsAdvisorUserId1,
            Name = "Dr. Ali",
            Surname = "Güneş",
            Email = "advisor5@iyte.edu.tr",
            PasswordHash = advisorHash,
            PasswordSalt = advisorSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Advisor,
            IsActive = true,
            PhoneNumber = "8889990011"
        };

        yield return new User
        {
            Id = MechanicalEngineeringAdvisorUserId1,
            Name = "Dr. Zeynep",
            Surname = "Acar",
            Email = "advisor6@iyte.edu.tr",
            PasswordHash = advisorHash,
            PasswordSalt = advisorSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Advisor,
            IsActive = true,
            PhoneNumber = "9990001122"
        };

        // 9) Department Secretary
        HashingHelper.CreatePasswordHash("DeptSecretaryPass123!", out byte[] deptSecretaryHash, out byte[] deptSecretarySalt);
        yield return new User
        {
            Id = DepartmentSecretaryUserId,
            Name = "Emine",
            Surname = "Arslan",
            Email = "comp.deptsecretary@iyte.edu.tr",
            PasswordHash = deptSecretaryHash,
            PasswordSalt = deptSecretarySalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Staff,
            IsActive = true,
            PhoneNumber = "1111223344"
        };

        // 10) Electrical Engineering Department Secretary
        yield return new User
        {
            Id = ElectricalEngineeringDepartmentSecretaryUserId,
            Name = "Melek",
            Surname = "Çakır",
            Email = "elec.deptsecretary@iyte.edu.tr",
            PasswordHash = deptSecretaryHash,
            PasswordSalt = deptSecretarySalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Staff,
            IsActive = true,
            PhoneNumber = "2223334455"
        };

        // 11) Physics Department Secretary
        yield return new User
        {
            Id = PhysicsDepartmentSecretaryUserId,
            Name = "Ayşe",
            Surname = "Demir",
            Email = "physics.deptsecretary@iyte.edu.tr",
            PasswordHash = deptSecretaryHash,
            PasswordSalt = deptSecretarySalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Staff,
            IsActive = true,
            PhoneNumber = "5556667790"
        };

        // 12) Dekanlık Personeli
        HashingHelper.CreatePasswordHash("DeansOfficePass123!", out byte[] deansOfficeHash, out byte[] deansOfficeSalt);
        yield return new User
        {
            Id = DeansOfficeStaffUserId,
            Name = "Murat",
            Surname = "Kurt",
            Email = "deansoffice@iyte.edu.tr",
            PasswordHash = deansOfficeHash,
            PasswordSalt = deansOfficeSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Staff,
            IsActive = true,
            PhoneNumber = "6667778899"
        };

        // 13) Fen Fakültesi Dekanlık Personeli
        yield return new User
        {
            Id = ScienceFacultyDeansOfficeStaffUserId,
            Name = "Ayşe",
            Surname = "Yılmaz",
            Email = "science.deansoffice@iyte.edu.tr",
            PasswordHash = deansOfficeHash,
            PasswordSalt = deansOfficeSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Staff,
            IsActive = true,
            PhoneNumber = "7778889900"
        };

        // 14) Rektörlük Personeli
        HashingHelper.CreatePasswordHash("RectoratePass123!", out byte[] rectorateHash, out byte[] rectorateSalt);
        yield return new User
        {
            Id = RectorateStaffUserId,
            Name = "Yusuf",
            Surname = "Baran",
            Email = "rectorate@iyte.edu.tr",
            PasswordHash = rectorateHash,
            PasswordSalt = rectorateSalt,
            AuthenticatorType = 0,
            CreatedDate = DateTime.UtcNow,
            UserType = UserType.Staff,
            IsActive = true,
            PhoneNumber = "8889990011"
        };
    }
}
