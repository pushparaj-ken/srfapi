using API.Infrastructure;
using Application.Features.HostelMaster.Command.CreateHostelMaster;
using Application.Features.HostelMaster.Command.DeleteHostelMaster;
using Application.Features.HostelMaster.Command.UpdateHostelMaster;
using Application.Features.HostelMaster.Queries.GetAllHostelMaster;
using MediatR;

namespace API.Endpoints;

public class HostelMaster : EndpointGroupBase
{
  public override void Map(WebApplication app)
  {
    app.MapGroup(this)
        //.RequireAuthorization()
        .MapGet(GetAllHostelMaster)
        .MapPost(CreateHostelMaster)
        .MapGet(GetHostelMaster, "{id}")
        .MapPut(UpdateHostelMasterDetail, "{id}")
        .MapDelete(DeleteHostelMaster, "{id}");
  }

  public async Task<IResult> GetAllHostelMaster(ISender sender, [AsParameters] GetAllHostelMasterQuery query)
  {
    var getAllResponse = await sender.Send(query);
    return Results.Ok(getAllResponse) ?? Results.NotFound();
  }

  public async Task<IResult> CreateHostelMaster(ISender sender, CreateHostelMasterCommand command)
  {
    var createResponse = await sender.Send(command);
    return Results.Ok(createResponse) ?? Results.NotFound();
  }

  public async Task<IResult> GetHostelMaster(ISender sender, int id)
  {
    var query = new GetHostelMasterQuery { Id = id };
    var getResponse = await sender.Send(query);

    return Results.Ok(getResponse) ?? Results.NotFound();
  }

  public async Task<IResult> UpdateHostelMasterDetail(ISender sender, int id, UpdateHostelMasterCommand command)
  {
    command.Id = id;
    var updateResponse = await sender.Send(command);
    return Results.Ok(updateResponse) ?? Results.NotFound();
  }

  public async Task<IResult> DeleteHostelMaster(ISender sender, int id)
  {
    var query = new DeleteHostelMasterCommand { Id = id };
    var deleteResponse = await sender.Send(query);
    return Results.Ok(deleteResponse) ?? Results.NotFound();
  }
}
