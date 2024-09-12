using API.Infrastructure;
using Application.Features.RoomCategory.Command.CreateRoomCategory;
using Application.Features.RoomCategory.Command.DeleteRoomCategory;
using Application.Features.RoomCategory.Command.UpdateRoomCategory;
using Application.Features.RoomCategory.Queries.GetAllRoomCategories;
using MediatR;

namespace API.Endpoints;

public class RoomCategory : EndpointGroupBase
{
  public override void Map(WebApplication app)
  {
    app.MapGroup(this)
        //.RequireAuthorization()
        .MapGet(GetAllRoomCategory)
        .MapPost(CreateRoomCategory)
        .MapGet(GetRoomCategory, "{id}")
        .MapPut(UpdateRoomCategoryDetail, "{id}")
        .MapDelete(DeleteRoomCategory, "{id}");
  }

  public async Task<IResult> GetAllRoomCategory(ISender sender, [AsParameters] GetAllRoomCategoryQuery query)
  {
    var getAllResponse = await sender.Send(query);
    return Results.Ok(getAllResponse) ?? Results.NotFound();
  }

  public async Task<IResult> CreateRoomCategory(ISender sender, CreateRoomCategoryCommand command)
  {
    var createResponse = await sender.Send(command);
    return Results.Ok(createResponse) ?? Results.NotFound();
  }

  public async Task<IResult> GetRoomCategory(ISender sender, int id)
  {
    var query = new GetRoomCategoryQuery { Id = id };
    var getResponse = await sender.Send(query);

    return Results.Ok(getResponse) ?? Results.NotFound();
  }

  public async Task<IResult> UpdateRoomCategoryDetail(ISender sender, int id, UpdateRoomCategoryCommand command)
  {
    command.Id = id;
    var updateResponse = await sender.Send(command);
    return Results.Ok(updateResponse) ?? Results.NotFound();
  }

  public async Task<IResult> DeleteRoomCategory(ISender sender, int id)
  {
    var query = new DeleteRoomCategoryCommand { Id = id };
    var deleteResponse = await sender.Send(query);
    return Results.Ok(deleteResponse) ?? Results.NotFound();
  }
}
