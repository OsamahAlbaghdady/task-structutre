using AutoMapper;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Utils.Enums;
using Hangfire;

namespace BackEndStructuer.Helpers.HangFire;

public class StorageHangFire
{
    private static IRepositoryWrapper _repositoryWrapper;
    private static IMapper _mapper;

    public StorageHangFire(IRepositoryWrapper repositoryWrapper , IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public static void ExpireScheduling(ReservedStorage reservedStorage  , DateTime expiredDate)
    {
        var delay = expiredDate - DateTime.UtcNow;
        string jobId = BackgroundJob.Schedule(() => ExpireMethod(reservedStorage), delay);
        BackgroundJob.ContinueJobWith(jobId,() =>  BackgroundJob.Delete(jobId));
    }
    
    public async static Task<bool> ExpireMethod(ReservedStorage reservedStorage)
    {   
        reservedStorage.State = ReserveState.Completed;
        await _repositoryWrapper.ReservedStorage.Update(reservedStorage);
        return true;
    }
    
    
}