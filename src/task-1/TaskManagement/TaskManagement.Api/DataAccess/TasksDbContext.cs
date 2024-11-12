using Microsoft.EntityFrameworkCore;
using TaskManagement.Api.DataAccess.Models;

namespace TaskManagement.Api.DataAccess;

public class TasksDbContext : DbContext
{
    public DbSet<TaskModel> Tasks { get; set; }

    public TasksDbContext(DbContextOptions<TasksDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var taskModelEntity = modelBuilder
            .Entity<TaskModel>()
            .ToTable("Tasks");

        taskModelEntity
            .HasKey(t => t.Id);

        taskModelEntity
            .Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();

        taskModelEntity
            .Property(e => e.Description)
            .HasMaxLength(500);

        taskModelEntity
            .HasData(GenerateTestData());
    }

    private TaskModel[] GenerateTestData()
    {
        var tasks = new[]
        {
            new TaskModel { Id = Guid.Parse("52FEDBFA-B0E2-4FF8-985C-92099E04CAC0"), Name = "Task 1", Description = "Description of Task 1", Status = TaskModelStatus.New, CreatedAt = DateTime.UtcNow },
            new TaskModel { Id = Guid.Parse("BE98E1D3-1759-4DAD-BFA7-C66D0725959F"), Name = "Task 2", Description = "Description of Task 2", Status = TaskModelStatus.InProgress, CreatedAt = DateTime.UtcNow.AddMilliseconds(1) },
            new TaskModel { Id = Guid.Parse("81CDDDB5-1880-4F84-8E55-DA4EF0A3BC5B"), Name = "Task 3", Description = "Description of Task 3", Status = TaskModelStatus.Completed, CreatedAt = DateTime.UtcNow.AddMilliseconds(2) },
            new TaskModel { Id = Guid.Parse("680604D3-2D72-4664-96DF-883E9EAE4585"), Name = "Task 4", Description = "Description of Task 4", Status = TaskModelStatus.New, CreatedAt = DateTime.UtcNow.AddMilliseconds(3) },
            new TaskModel { Id = Guid.Parse("10F85DDE-111F-4247-B1AC-929F4AB48A8C"), Name = "Task 5", Description = "Description of Task 5", Status = TaskModelStatus.InProgress, CreatedAt = DateTime.UtcNow.AddMilliseconds(4) },
            new TaskModel { Id = Guid.Parse("FFF94F9D-1BE6-402C-80D4-EBC76957DEC5"), Name = "Task 6", Description = "Description of Task 6", Status = TaskModelStatus.Completed, CreatedAt = DateTime.UtcNow.AddMilliseconds(5) },
            new TaskModel { Id = Guid.Parse("2D70788B-3E88-47CA-A86F-A0EC9F24CF4E"), Name = "Task 7", Description = "Description of Task 7", Status = TaskModelStatus.New, CreatedAt = DateTime.UtcNow.AddMilliseconds(6) },
            new TaskModel { Id = Guid.Parse("6AA5250A-B64E-4467-864F-0F80B46B7844"), Name = "Task 8", Description = "Description of Task 8", Status = TaskModelStatus.InProgress, CreatedAt = DateTime.UtcNow.AddMilliseconds(7) },
            new TaskModel { Id = Guid.Parse("AAA0613E-EB6A-43AA-AB41-93B892AC1F3A"), Name = "Task 9", Description = "Description of Task 9", Status = TaskModelStatus.Completed, CreatedAt = DateTime.UtcNow.AddMilliseconds(8) },
            new TaskModel { Id = Guid.Parse("03A28CBE-966A-4209-A7CB-FD5269BF2820"), Name = "Task 10", Description = "Description of Task 10", Status = TaskModelStatus.New, CreatedAt = DateTime.UtcNow.AddMilliseconds(9) },
            new TaskModel { Id = Guid.Parse("93AC9645-2566-42B0-AB6C-788509C81CBE"), Name = "Task 11", Description = "Description of Task 11", Status = TaskModelStatus.InProgress, CreatedAt = DateTime.UtcNow.AddMilliseconds(10) },
            new TaskModel { Id = Guid.Parse("BA66531F-ECA3-436F-94B9-8416FABADD58"), Name = "Task 12", Description = "Description of Task 12", Status = TaskModelStatus.Completed, CreatedAt = DateTime.UtcNow.AddMilliseconds(11) },
            new TaskModel { Id = Guid.Parse("6C1CBFE3-5ACD-40AD-96E6-ACF27FCA8C24"), Name = "Task 13", Description = "Description of Task 13", Status = TaskModelStatus.New, CreatedAt = DateTime.UtcNow.AddMilliseconds(12) },
            new TaskModel { Id = Guid.Parse("B9333151-42D3-4F3F-8B0B-CABE6AE1D37F"), Name = "Task 14", Description = "Description of Task 14", Status = TaskModelStatus.InProgress, CreatedAt = DateTime.UtcNow.AddMilliseconds(13) },
            new TaskModel { Id = Guid.Parse("E35016E7-670A-4CF5-831A-38D37ACEB65A"), Name = "Task 15", Description = "Description of Task 15", Status = TaskModelStatus.Completed, CreatedAt = DateTime.UtcNow.AddMilliseconds(14) },
            new TaskModel { Id = Guid.Parse("5372AF38-357A-4407-A148-313AA7109A4D"), Name = "Task 16", Description = "Description of Task 16", Status = TaskModelStatus.New, CreatedAt = DateTime.UtcNow.AddMilliseconds(15) },
            new TaskModel { Id = Guid.Parse("C8AA03FC-FD7B-4665-9AAB-68672D63A528"), Name = "Task 17", Description = "Description of Task 17", Status = TaskModelStatus.InProgress, CreatedAt = DateTime.UtcNow.AddMilliseconds(16) },
            new TaskModel { Id = Guid.Parse("2CEE431A-3491-4125-B0A5-EF01F1D98E9C"), Name = "Task 18", Description = "Description of Task 18", Status = TaskModelStatus.Completed, CreatedAt = DateTime.UtcNow.AddMilliseconds(17) },
            new TaskModel { Id = Guid.Parse("3E897919-05EE-4885-A1E0-2C8CFA489C2D"), Name = "Task 19", Description = "Description of Task 19", Status = TaskModelStatus.New, CreatedAt = DateTime.UtcNow.AddMilliseconds(18) },
            new TaskModel { Id = Guid.Parse("AC767DC0-0C32-4B65-A2DE-A5FD1AC77262"), Name = "Task 20", Description = "Description of Task 20", Status = TaskModelStatus.InProgress, CreatedAt = DateTime.UtcNow.AddMilliseconds(19) },
            new TaskModel { Id = Guid.Parse("F36D6407-9940-4AB2-B7CF-17CE52CC73D6"), Name = "Task 21", Description = "Description of Task 21", Status = TaskModelStatus.Completed, CreatedAt = DateTime.UtcNow.AddMilliseconds(20) },
            new TaskModel { Id = Guid.Parse("E44DF732-B8BD-4150-A3A0-6A6D8F958C03"), Name = "Task 22", Description = "Description of Task 22", Status = TaskModelStatus.New, CreatedAt = DateTime.UtcNow.AddMilliseconds(21) },
            new TaskModel { Id = Guid.Parse("3BFBB605-435C-44B1-BA2E-469911F93A62"), Name = "Task 23", Description = "Description of Task 23", Status = TaskModelStatus.InProgress, CreatedAt = DateTime.UtcNow.AddMilliseconds(22) },
            new TaskModel { Id = Guid.Parse("8C739263-6E73-4846-A22A-3BA74EEA28F2"), Name = "Task 24", Description = "Description of Task 24", Status = TaskModelStatus.Completed, CreatedAt = DateTime.UtcNow.AddMilliseconds(23) },
            new TaskModel { Id = Guid.Parse("C8F8BBA7-B018-46DF-8EA9-C72733C7C401"), Name = "Task 25", Description = "Description of Task 25", Status = TaskModelStatus.New, CreatedAt = DateTime.UtcNow.AddMilliseconds(24) }
        };

        return tasks;
    }
}
