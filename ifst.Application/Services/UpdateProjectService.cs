using AutoMapper;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;

namespace ifst.API.ifst.Application.Services;


public class UpdateProjectService : IUpdateProjectService
{
    private readonly IUpdateProjectRepository _updateProjectRepository;
    private readonly IMapper _mapper;
    private readonly IGeneralServices<UpdateProject> _generalServices;
    private readonly FileService _fileService;

    public UpdateProjectService(IUpdateProjectRepository updateProjectRepository, IGeneralServices<UpdateProject> generalServices,
        FileService fileService, IMapper mapper)
    {
        _updateProjectRepository = updateProjectRepository;
        _generalServices = generalServices;
        _fileService = fileService;
        _mapper = mapper;
    }
}