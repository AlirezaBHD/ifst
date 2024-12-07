using Microsoft.AspNetCore.JsonPatch;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IPatchService<T, TDto>
    where T : class
    where TDto : class
{
    Task PatchAsync(int id, JsonPatchDocument<TDto> patchDoc);
}