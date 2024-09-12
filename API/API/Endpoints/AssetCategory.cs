using API.Infrastructure;
using Application.Features.AssetCategory.Command.CreateAssetCategory;
using Application.Features.AssetCategory.Command.DeleteAssetCategory;
using Application.Features.AssetCategory.Command.UpdateAssetCategory;
using Application.Features.AssetCategory.Queries.GetAllAssetCategories;
using MediatR;

namespace API.Endpoints;

public class AssetCategory : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetAllAssetCategory)
            .MapPost(CreateAssetCategory)
            .MapGet(GetAssetCategory, "{id}")
            .MapPut(UpdateAssetCategoryDetail, "{id}")
            .MapDelete(DeleteAssetCategory, "{id}");
    }

    public async Task<IResult> GetAllAssetCategory(ISender sender, [AsParameters] GetAllAssetCategoryQuery query)
    {
        var getAllResponse = await sender.Send(query);
        return Results.Ok(getAllResponse) ?? Results.NotFound();
    }

    public async Task<IResult> CreateAssetCategory(ISender sender, CreateAssetCategoryCommand command)
    {
        var createResponse = await sender.Send(command);
        return Results.Ok(createResponse) ?? Results.NotFound();
    }

    public async Task<IResult> GetAssetCategory(ISender sender, int id)
    {
        var query = new GetAssetCategoryQuery { Id = id };
        var getResponse = await sender.Send(query);

        return Results.Ok(getResponse) ?? Results.NotFound();
    }

    public async Task<IResult> UpdateAssetCategoryDetail(ISender sender, int id, UpdateAssetCategoryCommand command)
    {
        command.Id = id;
        var updateResponse = await sender.Send(command);
        return Results.Ok(updateResponse) ?? Results.NotFound();
    }

    public async Task<IResult> DeleteAssetCategory(ISender sender, int id)
    {
        var query = new DeleteAssetCategoryCommand { Id = id };
        var deleteResponse = await sender.Send(query);
        return Results.Ok(deleteResponse) ?? Results.NotFound();
    }
}
