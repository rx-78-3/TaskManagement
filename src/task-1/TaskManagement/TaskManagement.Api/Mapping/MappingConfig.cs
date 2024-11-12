using Mapster;
using TaskManagement.Api.DataAccess.Models;
using TaskManagement.Api.EndpointMethods.GetTasks.Models;

namespace TaskManagement.Api.Mapping;

public static class MappingConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<TaskModel, TaskViewModel>
            .NewConfig()
            .Map(dest => dest.Status, src => src.Status.ToString());
    }
}
