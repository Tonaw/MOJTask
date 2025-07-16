using System.ComponentModel.DataAnnotations;
using MOJTask.Models;
using Xunit;

namespace MOJTask.Tests;

public class MOJTaskTests
{
    [Fact]
    public void Task_WithValidData_IsValid()
    {
        var task = new CaseWorkerTask
        {
            Title = "Test Task",
            Status = "Pending",
            DueDate = DateTime.Now.AddDays(1)
        };

        var context = new ValidationContext(task);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(task, context, results, true);

        Assert.True(isValid);
    }
}
