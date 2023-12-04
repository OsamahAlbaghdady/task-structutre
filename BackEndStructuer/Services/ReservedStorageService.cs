using AutoMapper;
using BackEndStructuer.DATA.DTOs.ReservedStorage;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using Microsoft.EntityFrameworkCore;

namespace BackEndStructuer.Services;

public interface IReservedStorageService
{
    Task<(ReservedStorageDto? reserved, string? error)> add(Guid Id, int storageId,
        ReservedStorageForm reservedStorageForm);

    Task<(List<ReservedStorageDto> reservedStorages, int? totalCount, string? error)> GetAll(Guid Id,
        ReservedStorageFilter filter);

    Task<(ReservedStorageDto? reservedStorage, string?error)> update(ReservedStorageUpdate reservedStorage, Guid id);
}

public class ReservedStorageService : IReservedStorageService
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ReservedStorageService(
        IMapper mapper,
        IRepositoryWrapper repositoryWrapper
    )
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }


    public async Task<(ReservedStorageDto? reserved, string? error)> add(Guid Id, int storageId,
        ReservedStorageForm reservedStorageForm)
    {
        var storage = await _repositoryWrapper.Storage.GetById(storageId);
        if (storage == null) return (null, "Storage not found");

        if (
            reservedStorageForm.StartDate < DateTime.Now ||
            reservedStorageForm.EndDate < DateTime.Now ||
            reservedStorageForm.EndDate < reservedStorageForm.StartDate
        ) return (null, "Sent date incorrect");

        var reservedStorage = await _repositoryWrapper.ReservedStorage.Get(x => x.StorageId == storageId &&
            ((reservedStorageForm.StartDate >= x.StartDate && reservedStorageForm.StartDate < x.EndDate) ||
             (reservedStorageForm.EndDate > x.StartDate && reservedStorageForm.EndDate <= x.EndDate) ||
             (reservedStorageForm.StartDate <= x.StartDate && reservedStorageForm.EndDate >= x.EndDate))
        );
        if (reservedStorage != null) return (null, "Storage already reserved");

        var newReserved = new ReservedStorage()
        {
            StorageId = storageId,
            UserId = Id,
            Destination = reservedStorageForm.Destination,
            Type = reservedStorageForm.Type,
            Count = reservedStorageForm.Count,
            StartDate = reservedStorageForm.StartDate,
            EndDate = reservedStorageForm.EndDate
        };

        var response = await _repositoryWrapper.ReservedStorage.Add(newReserved);
        var map = _mapper.Map<ReservedStorageDto>(response);
        return response == null ? (null, "Reserved storage couldn't complete") : (map, null);
    }

    public async Task<(List<ReservedStorageDto> reservedStorages, int? totalCount, string? error)> GetAll(Guid Id,
        ReservedStorageFilter filter)
    {
        var reserveds = await _repositoryWrapper.ReservedStorage.GetAll(x => 
                (x.UserId == Id) && 
                (filter.Destination == null || x.Destination.Contains(filter.Destination))&&
                (filter.Type == null || x.Type.Contains(filter.Type))
            ,
            r => 
                r.Include(u => u.User).
                    Include(s => s.Storage) ,
                filter.PageNumber
            );
        var map = _mapper.Map<List<ReservedStorageDto>>(reserveds.data);
        return (map, reserveds.totalCount, null);
    }

    public async Task<(ReservedStorageDto? reservedStorage, string? error)> update(
        ReservedStorageUpdate reservedStorage, Guid id)
    {
        var reserve = await _repositoryWrapper.ReservedStorage.GetById(id);
        if (reserve == null) return (null, "Reserved doesn't exists");
        reserve = _mapper.Map(reservedStorage , reserve);
        var response = await _repositoryWrapper.ReservedStorage.Update(reserve);
        var map = _mapper.Map<ReservedStorageDto>(reserve);
        return response == null ? (null, "Couldn't update reserve") : (map, null);
    }

}