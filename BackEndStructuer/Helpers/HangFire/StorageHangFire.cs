using AutoMapper;
using BackEndStructuer.Repository;
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

    public async static void ExpireScheduling(int id , DateTime expiredDate)
    {
        DateTime specificDate = expiredDate; 
        TimeZoneInfo timeZone = TimeZoneInfo.Utc; 
        DateTime utcSpecificDate = TimeZoneInfo.ConvertTimeToUtc(specificDate, timeZone);
        TimeSpan delay = utcSpecificDate - DateTime.UtcNow;
        string jobId = BackgroundJob.Schedule(() => ExpireMethod(id), delay);
        BackgroundJob.ContinueJobWith(jobId,() =>  BackgroundJob.Delete(jobId));
    }
    
    private async static void ExpireMethod(int id)
    {
     
    }
    
    
}