using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    // Bilgisayar Mühendisliği Dersleri
    public static readonly Guid CENG111Id = new Guid("d659a77b-8797-43ee-a9ce-7a8e55342ffb");
    public static readonly Guid CENG113Id = new Guid("fcce7661-1144-40da-a60c-abee39a52e1d");
    public static readonly Guid CENG115Id = new Guid("a0e4e7bd-3c32-488d-8130-8a5c5c926ef5");
    public static readonly Guid CENG112Id = new Guid("4d61379e-f179-4f77-ba15-ac504acc3145");
    public static readonly Guid CENG211Id = new Guid("a6926dc0-6f52-4530-93b4-1e31fcaa2fbf");
    public static readonly Guid CENG213Id = new Guid("185e5459-ee35-416c-821d-ec6c5c93e914");
    public static readonly Guid CENG215Id = new Guid("4352c9aa-850e-4810-ad3e-3d289b764461");


    public static readonly Guid MATH144Id = new Guid("2b3be9bf-e9f7-4175-986b-7157111d58c4");
    public static readonly Guid HIST201Id = new Guid("fd25c679-de6e-442f-b220-ae1cd94178a8");
    public static readonly Guid TURK201Id = new Guid("6160e613-f5b1-4f6c-b801-7bdc98285d11");
    public static readonly Guid HIST202Id = new Guid("60b000b9-7671-4e2e-9169-044f271cf78f");
    public static readonly Guid TURK202Id = new Guid("dd901284-03df-435c-9d49-864bb7dc3cd6");
    public static readonly Guid CENG212Id = new Guid("a9271f43-0d23-4f1c-8c4c-6fea1a81df2b");
    public static readonly Guid CENG214Id = new Guid("25bea32d-14e6-4372-b86a-a8e2b5c59a55");
    public static readonly Guid CENG216Id = new Guid("509f72a4-7316-432f-b767-d9bfd5ef2dac");
    public static readonly Guid CENG218Id = new Guid("2f5adab5-a558-47f6-98e3-f629f78d53e1");
    public static readonly Guid CENG222Id = new Guid("68b661d5-0a91-4eb9-b9b0-41688997faae");
    public static readonly Guid CENG311Id = new Guid("b20986e4-bcaa-4943-9e8d-87e8eeb21fec");
    public static readonly Guid CENG315Id = new Guid("5b8f2e37-1505-4b17-aa2a-5c43d9d4a643");
    public static readonly Guid CENG323Id = new Guid("70df7418-f58b-465a-b37e-e27e6f7bbc29");
    public static readonly Guid CENG312Id = new Guid("a4b77974-698e-47a9-9818-a82e4b22191f");
    public static readonly Guid CENG316Id = new Guid("e14116ac-265c-46eb-9d28-ffbd0532e365");
    public static readonly Guid CENG318Id = new Guid("adcd61e5-ac31-4a67-b86e-742c4ad8f5c1");
    public static readonly Guid CENG322Id = new Guid("177d582d-96ce-4bd8-9496-5e2167148c57");
    public static readonly Guid CENG400Id = new Guid("52b3d1fb-7e74-463b-a595-a79f3dd94517");
    public static readonly Guid CENG411Id = new Guid("702736bc-c6e0-4417-abad-ab8561561e96");
    public static readonly Guid CENG415Id = new Guid("cca30d11-98e1-4dc0-b85b-00d81b6ed572");
    public static readonly Guid CENG416Id = new Guid("e00787a4-696d-4e24-b039-56e1accdf7fe");
    public static readonly Guid CENG418Id = new Guid("870e41ec-30f0-43a1-9d1b-877b31d4f3b9");
    public static readonly Guid CENG424Id = new Guid("4777afa3-a512-4353-8109-0674da099cf0");

    // Matematik Dersleri
    public static readonly Guid MATH141Id = new Guid("2cd45c09-641c-481e-b9ea-0f2a31489ade");
    public static readonly Guid MATH142Id = new Guid("8326f736-1827-4131-80e0-8ec78340ac0a");
    public static readonly Guid MATH255Id = new Guid("911583ec-668b-4d3a-9cf1-e3743c92af5d");

    // Fizik Dersleri
    public static readonly Guid PHYS121Id = new Guid("09cd6d07-87e2-4b72-8bfb-bd479ba5b1c8");
    public static readonly Guid PHYS122Id = new Guid("0d457f60-7e5f-4898-926a-da3a08a52086");





    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CourseName).HasColumnName("CourseName").IsRequired();
        builder.Property(c => c.CourseCode).HasColumnName("CourseCode").IsRequired();
        builder.Property(c => c.TeoricHours).HasColumnName("TeoricHours").IsRequired();
        builder.Property(c => c.PracticalHours).HasColumnName("PracticalHours").IsRequired();
        builder.Property(c => c.ECTS).HasColumnName("ECTS").IsRequired();
        builder.Property(c => c.HalfYear).HasColumnName("HalfYear").IsRequired();
        builder.Property(c => c.CourseDescription).HasColumnName("CourseDescription").IsRequired();
        builder.Property(c => c.CourseCredit).HasColumnName("CourseCredit").IsRequired();
        builder.Property(c => c.DepartmentId).HasColumnName("DepartmentId").IsRequired();
        builder.Property(c => c.FacultyId).HasColumnName("FacultyId").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasOne(c => c.Department)
               .WithMany()
               .HasForeignKey(c => c.DepartmentId);

        builder.HasOne(c => c.FacultyDeansOffice)
               .WithMany()
               .HasForeignKey(c => c.FacultyId);

        builder.HasData(GetSeeds());
    }

    private IEnumerable<Course> GetSeeds()
    {
        return new List<Course>
        {
            new Course
            {
                Id = CENG111Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG111",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 4,
                HalfYear = "first half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG113Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG113",
                CourseDescription = "Course description to be added",
                CourseCredit = 4,
                TeoricHours = 4,
                PracticalHours = 0,
                ECTS = 4,
                HalfYear = "first half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow

            },

            new Course
            {
                Id = CENG115Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG115",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 5,
                HalfYear = "first half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = MATH141Id,
                CourseName = "Course name to be added",
                CourseCode = "MATH141",
                CourseDescription = "Course description to be added",
                CourseCredit = 4,
                TeoricHours = 4,
                PracticalHours = 0,
                ECTS = 7,
                HalfYear = "first half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = PHYS121Id,
                CourseName = "Course name to be added",
                CourseCode = "PHYS121",
                CourseDescription = "Course description to be added",
                CourseCredit = 4,
                TeoricHours = 4,
                PracticalHours = 0,
                ECTS = 6,
                HalfYear = "first half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG112Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG112",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 7,
                HalfYear = "first half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = MATH142Id,
                CourseName = "Course name to be added",
                CourseCode = "MATH142",
                CourseDescription = "Course description to be added",
                CourseCredit = 4,
                TeoricHours = 4,
                PracticalHours = 0,
                ECTS = 7,
                HalfYear = "first half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = MATH144Id,
                CourseName = "Course name to be added",
                CourseCode = "MATH144",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 5,
                HalfYear = "first half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = PHYS122Id,
                CourseName = "Course name to be added",
                CourseCode = "PHYS122",
                CourseDescription = "Course description to be added",
                CourseCredit = 4,
                TeoricHours = 4,
                PracticalHours = 0,
                ECTS = 6,
                HalfYear = "first half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = HIST201Id,
                CourseName = "Course name to be added",
                CourseCode = "HIST201",
                CourseDescription = "Course description to be added",
                CourseCredit = 0,
                TeoricHours = 0,
                PracticalHours = 0,
                ECTS = 2,
                HalfYear = "second half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = TURK201Id,
                CourseName = "Course name to be added",
                CourseCode = "TURK201",
                CourseDescription = "Course description to be added",
                CourseCredit = 0,
                TeoricHours = 0,
                PracticalHours = 0,
                ECTS = 2,
                HalfYear = "second half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG211Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG211",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 6,
                HalfYear = "second half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG213Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG213",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 6,
                HalfYear = "second half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG215Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG215",
                CourseDescription = "Course description to be added",
                CourseCredit = 4,
                TeoricHours = 4,
                PracticalHours = 0,
                ECTS = 7,
                HalfYear = "second half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = HIST202Id,
                CourseName = "Course name to be added",
                CourseCode = "HIST202",
                CourseDescription = "Course description to be added",
                CourseCredit = 0,
                TeoricHours = 0,
                PracticalHours = 0,
                ECTS = 2,
                HalfYear = "second half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = TURK202Id,
                CourseName = "Course name to be added",
                CourseCode = "TURK202",
                CourseDescription = "Course description to be added",
                CourseCredit = 0,
                TeoricHours = 0,
                PracticalHours = 0,
                ECTS = 2,
                HalfYear = "second half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG212Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG212",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 5,
                HalfYear = "second half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG214Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG214",
                CourseDescription = "Course description to be added",
                CourseCredit = 4,
                TeoricHours = 4,
                PracticalHours = 0,
                ECTS = 7,
                HalfYear = "second half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG216Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG216",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 5,
                HalfYear = "second half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG218Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG218",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 6,
                HalfYear = "second half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG222Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG222",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 5,
                HalfYear = "second half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG311Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG311",
                CourseDescription = "Course description to be added",
                CourseCredit = 4,
                TeoricHours = 4,
                PracticalHours = 0,
                ECTS = 8,
                HalfYear = "third half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG315Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG315",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 7,
                HalfYear = "third half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG323Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG323",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 8,
                HalfYear = "third half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG312Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG312",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 7,
                HalfYear = "third half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG316Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG316",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 8,
                HalfYear = "third half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG318Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG318",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 5,
                HalfYear = "third half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG322Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG322",
                CourseDescription = "Course description to be added",
                CourseCredit = 4,
                TeoricHours = 4,
                PracticalHours = 0,
                ECTS = 8,
                HalfYear = "third half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG400Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG400",
                CourseDescription = "Course description to be added",
                CourseCredit = 0,
                TeoricHours = 0,
                PracticalHours = 0,
                ECTS = 4,
                HalfYear = "fourth half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG411Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG411",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 4,
                HalfYear = "fourth half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG415Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG415",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 9,
                HalfYear = "fourth half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG416Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG416",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 9,
                HalfYear = "fourth half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = CENG418Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG418",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 6,
                HalfYear = "fourth half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course            {
                Id = CENG424Id,
                CourseName = "Course name to be added",
                CourseCode = "CENG424",
                CourseDescription = "Course description to be added",
                CourseCredit = 3,
                TeoricHours = 3,
                PracticalHours = 0,
                ECTS = 7,
                HalfYear = "fourth half year",
                DepartmentId = DepartmentConfiguration.ComputerEngineeringDepartmentId,
                FacultyId = FacultyDeansOfficeConfiguration.EngineeringFacultyId,
                CreatedDate = DateTime.UtcNow
            },

            new Course
            {
                Id = MATH255Id,
                CourseName = "Discrete Mathematics",
                CourseCode = "MATH255",
                CourseDescription = "Discrete Mathematics course",                CourseCredit = 3,                TeoricHours = 3,                PracticalHours = 0,                ECTS = 6,                HalfYear = "second half year",                DepartmentId = DepartmentConfiguration.MathematicsDepartmentId,                FacultyId = FacultyDeansOfficeConfiguration.ScienceFacultyId,                CreatedDate = DateTime.UtcNow            },        };
    }
}
