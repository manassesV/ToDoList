using Moq;
using ToDoList.Application.Commands;
using ToDoList.Domain.AggregatesModel.TodoTaskAggregate;
using ToDoList.Domain.AggregatesModel.TaskAggregate;

[TestClass]
public class CreateTodoTaskCommandHandlerTests
{
    private Mock<ITodoTaskRepository> _mockRepo;
    private Mock<Microsoft.Extensions.Logging.ILogger<CreateTodoTaskCommandHandler>> _mockLogger;
    private CreateTodoTaskCommandHandler _handler;

    [TestInitialize]
    public void Setup()
    {
        _mockRepo = new Mock<ITodoTaskRepository>();
        _mockLogger = new Mock<Microsoft.Extensions.Logging.ILogger<CreateTodoTaskCommandHandler>>();
        _handler = new CreateTodoTaskCommandHandler(_mockRepo.Object, _mockLogger.Object);
    }

    [TestMethod]
    public async Task Handle_ValidRequest_ReturnsSuccess()
    {
        // Arrange
        var command = new CreateTodoTaskCommand
        (
          "Tarefa Teste",
          "Descrição",
           DateTime.UtcNow.AddDays(1),
          false
        );

        _mockRepo.Setup(r => r.UnitOfWork.SaveEntitiesAsync(It.IsAny<CancellationToken>()))
                 .ReturnsAsync(true);

        _mockRepo.Setup(r => r.Add(It.IsAny<TodoTask>())).Verifiable();

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsTrue(result.IsSuccess);
        _mockRepo.Verify(r => r.Add(It.IsAny<TodoTask>()), Times.Once);
        _mockRepo.Verify(r => r.UnitOfWork.SaveEntitiesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [TestMethod]
    public async Task Handle_InvalidTodoTask_ReturnsFailure()
    {
        // Arrange
        var command = new CreateTodoTaskCommand
        (
           "",  
          "Descrição",
           DateTime.UtcNow.AddDays(1),
           false
        );

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsFalse(result.IsSuccess);
    }
}
