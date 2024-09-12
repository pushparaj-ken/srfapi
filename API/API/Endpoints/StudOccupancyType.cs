using API.Infrastructure;
using Application.Features.StudOccupancyType.Command.CreateStudOccupancyType;
using Application.Features.StudOccupancyType.Command.DeleteStudOccupancyType;
using Application.Features.StudOccupancyType.Command.UpdateStudOccupancyType;
using Application.Features.StudOccupancyType.Queries.GetAllStudOccupancyType;
using MediatR;

namespace API.Endpoints;

public class StudOccupancyType : EndpointGroupBase
{
  public override void Map(WebApplication app)
  {
    app.MapGroup(this)
        //.RequireAuthorization()
        .MapGet(GetAllStudOccupancyType)
        .MapPost(CreateStudOccupancyType)
        .MapGet(GetStudOccupancyType, "{id}")
        .MapPut(UpdateStudOccupancyTypeDetail, "{id}")
        .MapDelete(DeleteStudOccupancyType, "{id}");
  }

  public async Task<IResult> GetAllStudOccupancyType(ISender sender, [AsParameters] GetAllStudOccupancyTypeQuery query)
  {
    var getAllResponse = await sender.Send(query);
    return Results.Ok(getAllResponse) ?? Results.NotFound();
  }

  public async Task<IResult> CreateStudOccupancyType(ISender sender, CreateStudOccupancyTypeCommand command)
  {
    var createResponse = await sender.Send(command);
    return Results.Ok(createResponse) ?? Results.NotFound();
  }

  public async Task<IResult> GetStudOccupancyType(ISender sender, int id)
  {
    var query = new GetStudOccupancyTypeQuery { Id = id };
    var getResponse = await sender.Send(query);

    return Results.Ok(getResponse) ?? Results.NotFound();
  }

  public async Task<IResult> UpdateStudOccupancyTypeDetail(ISender sender, int id, UpdateStudOccupancyTypeCommand command)
  {
    command.Id = id;
    var updateResponse = await sender.Send(command);
    return Results.Ok(updateResponse) ?? Results.NotFound();
  }

  public async Task<IResult> DeleteStudOccupancyType(ISender sender, int id)
  {
    var query = new DeleteStudOccupancyTypeCommand { Id = id };
    var deleteResponse = await sender.Send(query);
    return Results.Ok(deleteResponse) ?? Results.NotFound();
  }
}
