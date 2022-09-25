namespace MarsService.Models
{
    public interface IRover
    {
        int Id { get; }
        Position GetPosition();
        bool ExecuteCommand(Command cmd);
    }
}