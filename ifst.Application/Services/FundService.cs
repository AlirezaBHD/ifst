using AutoMapper;
using ifst.API.ifst.Application.DTOs.FundDto;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;

namespace ifst.API.ifst.Application.Services;

public class FundService : IFundService
{
    #region Injection

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

    #endregion

    #region Fund Detail By Id

    public async Task<FundDto> FundDetailById(int id)
    {
        var fundObj = await _fundRepository.GetByIdAsyncLimited<FundDto>(id, includes:f => f.Projects);
        return fundObj;
    }
    
    #endregion

    #region List of Funds

    public async Task<IEnumerable<ListFundDto>> ListFunds()
    {
        var funds = await _fundRepository.GetAllAsyncLimited<ListFundDto>();
        return funds;
    }
    
    #endregion

    #region Create Fund

    public async Task<FundDto> CreateFunds(CreateFundDto fundDto)
    {
        var fund = _mapper.Map<Fund>(fundDto);
        await _fundRepository.AddAsync(fund);
        await _fundRepository.SaveAsync();
        var returnDto = _mapper.Map<FundDto>(fund);
        return returnDto;
    }

    public async Task UpdateFund(int id, UpdateFundDto fundDto)
    {
        var addedAmount = fundDto.AddedAmount;
        var fund = await _fundRepository.GetByIdAsync(id);
        fund.GatheredAmount += addedAmount;
        _fundRepository.Update(fund);
        await _fundRepository.SaveAsync();
    }

    #endregion
    
    #region Delete Fund

    public async Task DeleteFund(int id)
    {
        var fund = await _fundRepository.GetByIdAsync(id);
        _fundRepository.Remove(fund);
        await _fundRepository.SaveAsync();
    }

    #endregion
}