public class DummyProcess {

    private ILogger<DummyProcess> _logger;

    public DummyProcess(ILogger<DummyProcess> logger) {
        _logger = logger;
    }
    public async Task doProcess() {
        var firstThing = Task.Run(() => {
            _logger.LogInformation("3.1 - Started doing some stuff... - tid: " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            _logger.LogInformation("4.1 - Finished doing some stuff... - tid: " + Thread.CurrentThread.ManagedThreadId);
        });
        var secondThing = Task.Run(() => {
            _logger.LogInformation("3.2 - Started doing another stuff... - tid: " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            _logger.LogInformation("4.2 - Finished doing another stuff... - tid: " + Thread.CurrentThread.ManagedThreadId);
        });

        await Task.WhenAll(firstThing, secondThing);
        return;
    }
}