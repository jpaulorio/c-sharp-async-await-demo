using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mediatr_test.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private IMediator _mediator;

    public string Message { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    // public async void OnGet()
    // {
    //     Message = "Loading async...";
    //     _logger.LogInformation("1 - Received request");
    //     var unitValue = await _mediator.Send(new DummyCommand("I'm a dummy!"));
    //     _logger.LogInformation("6 - Completed request" + unitValue.ToString());
    //     Message = "Done loading async!";
    // }

        public void OnGet()
    {
        Message = "Loading sync...";
        _logger.LogInformation("1 - Received request");
        _mediator.Send(new DummyCommand("I'm a dummy!")).GetAwaiter().GetResult();
        _logger.LogInformation("6 - Completed request");
        Message = "Done loading sync!";
    }
}
