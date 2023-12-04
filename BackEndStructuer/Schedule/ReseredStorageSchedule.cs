using BackEndStructuer.Entities;
using BackEndStructuer.Helpers.OneSignal;
using BackEndStructuer.Repository;

namespace BackEndStructuer.Schedule;


public class NotifyEndReserved
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly PeriodicTimer _timer;
    private Task? _timerTask;
    private readonly CancellationTokenSource _cts = new();

    public NotifyEndReserved(
        TimeSpan interval ,
        IRepositoryWrapper repositoryWrapper
    )
    {
        _timer = new PeriodicTimer(interval);
        _repositoryWrapper = repositoryWrapper;
    }


    public void Start()
    {
        _timerTask = DoWorkAsync();
    }

    private async Task DoWorkAsync()
    {
        try
        {
            while (!_cts.Token.IsCancellationRequested)
            {
                Console.WriteLine("fffff");
                // var resrveds = await _repositoryWrapper.ReservedStorage.GetAll(
                //     x => (DateTime.Now.AddDays(1) == x.EndDate)
                //     );
                //
                // foreach (var resrved in resrveds.data)
                // {
                //     var notification = new Notifications();
                //     OneSignal.SendNoitications(notification, resrved.UserId.ToString());
                // }
                await Task.Delay(TimeSpan.FromSeconds(60 * 60 * 24)); // Example delay of 1 second
            }
        }
        catch (OperationCanceledException e)
        {
        
        }
    }

    public async Task StopAsync()
    {
        if (_timerTask == null)
        {
            return;
        }
        _cts.Cancel();
        await _timerTask;
        _cts.Dispose();
    }
}