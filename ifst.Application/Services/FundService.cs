using AutoMapper;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;

namespace ifst.API.ifst.Application.Services;

public class FundService : IFundService
{
    private readonly IFundRepository _fundRepository;
    private readonly IMapper _mapper;
    private readonly IGeneralServices<Fund> _generalServices;
    private readonly FileService _fileService;

    public FundService(IGeneralServices<Fund> generalServices,
        FileService fileService, IMapper mapper, IFundRepository fundRepository)
    {
        _generalServices = generalServices;
        _fileService = fileService;
        _mapper = mapper;
        _fundRepository = fundRepository;
    }
}