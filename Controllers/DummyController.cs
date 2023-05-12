using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Infrastructure;

[Route("api/[controller]")]
public class DummyController : Controller
{

    private ILogger<DummyController> _logger;

    private IMediator _mediator;

    public DummyController(ILogger<DummyController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [NonAction]
    protected ObjectResult DummyResult([ActionResultObjectValue] object value)
                => new(value) { StatusCode = StatusCodes.Status200OK };

    [HttpGet("load-sync")]
    public IActionResult LoadSync()
    {
        string message = "loading sync...";

        _logger.LogInformation("1 - Received request - tid: " + Thread.CurrentThread.ManagedThreadId);
        _mediator.Send(new DummyCommand("I'm a dummy!")).GetAwaiter().GetResult();        
        _logger.LogInformation("6 - Completed request - tid: " + Thread.CurrentThread.ManagedThreadId);
        message = "done loading sync! - tid: " + Thread.CurrentThread.ManagedThreadId;

        return DummyResult(message);
    }

    [HttpGet("load-async")]
    public async Task<IActionResult> LoadAsync()
    {
        string message = "loading async... - tid: " + Thread.CurrentThread.ManagedThreadId;

        _logger.LogInformation("1 - Received request - tid: " + Thread.CurrentThread.ManagedThreadId);
        await _mediator.Send(new DummyCommand("I'm a dummy!"));
        _logger.LogInformation("6 - Completed request - tid: " + Thread.CurrentThread.ManagedThreadId);
        message = "done loading async! - tid: " + Thread.CurrentThread.ManagedThreadId;

        return DummyResult(message);
    }
}
