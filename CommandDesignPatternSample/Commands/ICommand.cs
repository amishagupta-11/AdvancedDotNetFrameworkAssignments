namespace CommandDesignPatternSample.Commands
{
    /// <summary>
    /// Represents a command that can be executed and undone.
    /// This interface defines the methods that all concrete command classes must implement.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the command.
        /// Each command will define its own behavior for the execution.
        /// </summary>
        void Execute();

        /// <summary>
        /// Undoes the command.
        /// Each command will define how to undo the operation it performed.
        /// </summary>
        void Undo();
    }
}
