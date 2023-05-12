using MediatR;

public class DummyCommand : IRequest<Unit> {
    public string CommandString { get; }

    public DummyCommand(string commandString) {
        CommandString = commandString;
    }
}