using Mapster;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Api.DataAccess;
using TaskManagement.Api.EndpointMethods.GetTasks.Models;

namespace TaskManagement.Api.Endpoint.GetTasks;

public static class GetTasksEndpoint
{
    public static void MapGetTasks(this WebApplication app)
    {
        app.MapGet("/tasks", async (TasksDbContext dbContext, [AsParameters] GetTasksRequest request) =>
        {
            var tasksQuery = dbContext.Tasks
                .AsNoTracking();
            var totalCount = await tasksQuery.LongCountAsync();
            var tasks = await tasksQuery
                .OrderBy(t => t.CreatedAt)
                .Skip(request.Page * request.PageSize)
                .Take(request.PageSize)
                .ToArrayAsync();

            var tasksViewModel = tasks.Adapt<TaskViewModel[]>();
            var response = new GetTasksResponse(request.Page, request.PageSize, totalCount, tasksViewModel);

            return Results.Ok(response);
        })
            .WithName("EditUsers")
            .WithSummary("EditUsers")
            .WithDescription("Edit users")
            .Produces<GetTasksResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
