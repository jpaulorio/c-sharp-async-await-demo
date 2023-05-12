using MediatR;

public class DummyCommandHandler : IRequestHandler<DummyCommand>
{
    private ILogger<DummyProcess> _logger;

    public DummyCommandHandler(ILogger<DummyProcess> logger) {
        _logger = logger;
    }

    public async Task<Unit> Handle(DummyCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("2 - Received command: " + request.CommandString +  " - tid: " + Thread.CurrentThread.ManagedThreadId);
        await new DummyProcess(_logger).doProcess();
        _logger.LogInformation("5 - Completed command: " + request.CommandString +  " - tid: " + Thread.CurrentThread.ManagedThreadId);

        return Unit.Value;
    }
} 