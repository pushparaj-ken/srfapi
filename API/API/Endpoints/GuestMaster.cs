using API.Infrastructure;
using Application.Features.GuestMaster.Command.CreateGuestMaster;
using Application.Features.GuestMaster.Command.DeleteGuestMaster;
using Application.Features.GuestMaster.Command.UpdateGuestMaster;
using Application.Features.GuestMaster.Queries.GetAllGuestMaster;
using MediatR;

namespace API.Endpoints;

public class GuestMaster : EndpointGroupBase
{
  public override void Map(WebApplication app)
  {
    app.MapGroup(this)
        //.RequireAuthorization()
        .MapGet(GetAllGuestMaster)
        .MapPost(CreateGuestMaster)
        .MapGet(GetGuestMaster, "{id}")
        .MapPut(UpdateGuestMasterDetail, "{id}")
        .MapDelete(DeleteGuestMaster, "{id}");
  }

  public async Task<IResult> GetAllGuestMaster(ISender sender, [AsParameters] GetAllGuestMasterQuery query)
  {
    var getAllResponse = await sender.Send(query);
    return Results.Ok(getAllResponse) ?? Results.NotFound();
  }

  public async Task<IResult> CreateGuestMaster(ISender sender, CreateGuestMasterCommand command)
  {
    var createResponse = await sender.Send(command);
    return Results.Ok(createResponse) ?? Results.NotFound();
  }

  public async Task<IResult> GetGuestMaster(ISender sender, int id)
  {
    var query = new GetGuestMasterQuery { Id = id };
    var getResponse = await sender.Send(query);

    return Results.Ok(getResponse) ?? Results.NotFound();
  }

  public async Task<IResult> UpdateGuestMasterDetail(ISender sender, int id, UpdateGuestMasterCommand command)
  {
    command.Id = id;
    var updateResponse = await sender.Send(command);
    return Results.Ok(updateResponse) ?? Results.NotFound();
  }

  public async Task<IResult> DeleteGuestMaster(ISender sender, int id)
  {
    var query = new DeleteGuestMasterCommand { Id = id };
    var deleteResponse = await sender.Send(query);
    return Results.Ok(deleteResponse) ?? Results.NotFound();
  }
}
