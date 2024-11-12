namespace TaskManagement.Api.EndpointMethods.GetTasks.Models;

public record GetTasksResponse(int Page, int PageSize, long TotalCount, IEnumerable<TaskViewModel> Data);
