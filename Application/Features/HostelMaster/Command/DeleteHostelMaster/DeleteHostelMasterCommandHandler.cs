using Application.Contracts.Logging;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using DomainHostelMaster = Domain.HostelMaster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;

namespace Application.Features.HostelMaster.Command.DeleteHostelMaster;


public class DeleteHostelMasterCommandHandler : IRequestHandler<DeleteHostelMasterCommand, ApiResponse>
{
  private IMapper _mapper;
  private IHostelMasterRepository _hostelMasterRepository;
  private IAppLogger<DeleteHostelMasterCommandHandler> _logger;
  private readonly APIResponseService _responseService;

  public DeleteHostelMasterCommandHandler(IMapper mapper, IHostelMasterRepository hostelMasterRepository
    , IAppLogger<DeleteHostelMasterCommandHandler> logger, APIResponseService responseService)
  {
    this._mapper = mapper;
    this._hostelMasterRepository = hostelMasterRepository;
    this._logger = logger;
    this._responseService = responseService;
  }

  public async Task<ApiResponse> Handle(DeleteHostelMasterCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var DeleteData = await _hostelMasterRepository.GetByIdAsync(request.Id);

      if (DeleteData == null)
      {
        return await _responseService.ApiFailResponse($"Room category with ID {request.Id} not found.");
      }

      await _hostelMasterRepository.DeleteASync(DeleteData);

      return await _responseService.ApiSuccessResponse(null);
    }
    catch (Exception ex)
    {
      _logger.LogWarning($"Error saving HostelMaster: {ex.Message}", ex);
      if (ex.InnerException != null)
      {
        _logger.LogWarning($"Inner Exception: {ex.InnerException.Message}");
      }
      throw new BadRequestException($"Error at HostelMaster: {ex.Message}");
    }
  }

}