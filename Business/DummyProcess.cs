public class DummyProcess {

    private ILogger<DummyProcess> _logger;

    public DummyProcess(ILogger<DummyProcess> logger) {
        _logger = logger;
    }
    public async Task doProcess() {
        var firstThing = Task.Run(() => {
            _logger.LogInformation("3 - Started doing some stuff... - tid: " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(10000);
            _logger.LogInformation("4 - Finished doing some stuff... - tid: " + Thread.CurrentThread.ManagedThreadId);
        });
        var secondThing = Task.Run(() => {
            _logger.LogInformation("3 - Started doing another stuff... - tid: " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(10000);
            _logger.LogInformation("4 - Finished doing another stuff... - tid: " + Thread.CurrentThread.ManagedThreadId);
        });

        await Task.WhenAll(firstThing, secondThing);
        return;
    }
}