using API.Infrastructure;
using Application.Features.StaffOccupancyType.Command.CreateStaffOccupancyType;
using Application.Features.StaffOccupancyType.Command.DeleteStaffOccupancyType;
using Application.Features.StaffOccupancyType.Command.UpdateStaffOccupancyType;
using Application.Features.StaffOccupancyType.Queries.GetAllStaffOccupancyType;
using MediatR;

namespace API.Endpoints;

public class StaffOccupancyType : EndpointGroupBase
{
  public override void Map(WebApplication app)
  {
    app.MapGroup(this)
        //.RequireAuthorization()
        .MapGet(GetAllStaffOccupancyType)
        .MapPost(CreateStaffOccupancyType)
        .MapGet(GetStaffOccupancyType, "{id}")
        .MapPut(UpdateStaffOccupancyTypeDetail, "{id}")
        .MapDelete(DeleteStaffOccupancyType, "{id}");
  }

  public async Task<IResult> GetAllStaffOccupancyType(ISender sender, [AsParameters] GetAllStaffOccupancyTypeQuery query)
  {
    var getAllResponse = await sender.Send(query);
    return Results.Ok(getAllResponse) ?? Results.NotFound();
  }

  public async Task<IResult> CreateStaffOccupancyType(ISender sender, CreateStaffOccupancyTypeCommand command)
  {
    var createResponse = await sender.Send(command);
    return Results.Ok(createResponse) ?? Results.NotFound();
  }

  public async Task<IResult> GetStaffOccupancyType(ISender sender, int id)
  {
    var query = new GetStaffOccupancyTypeQuery { Id = id };
    var getResponse = await sender.Send(query);

    return Results.Ok(getResponse) ?? Results.NotFound();
  }

  public async Task<IResult> UpdateStaffOccupancyTypeDetail(ISender sender, int id, UpdateStaffOccupancyTypeCommand command)
  {
    command.Id = id;
    var updateResponse = await sender.Send(command);
    return Results.Ok(updateResponse) ?? Results.NotFound();
  }

  public async Task<IResult> DeleteStaffOccupancyType(ISender sender, int id)
  {
    var query = new DeleteStaffOccupancyTypeCommand { Id = id };
    var deleteResponse = await sender.Send(query);
    return Results.Ok(deleteResponse) ?? Results.NotFound();
  }
}
