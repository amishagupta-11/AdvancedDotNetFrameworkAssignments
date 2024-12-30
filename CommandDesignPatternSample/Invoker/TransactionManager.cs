using CommandDesignPatternSample.Commands;

namespace CommandDesignPatternSample.Invoker
{
    /// <summary>
    /// Manages the execution and undoing of commands.
    /// This class maintains a stack of executed commands and allows for undoing the most recent command.
    /// </summary>
    public class TransactionManager
    {
        // Stack to store executed commands for undo functionality.
        private readonly Stack<ICommand> Commands = new();  

        /// <summary>
        /// Executes a given command and adds it to the stack for potential undo.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        public void ExecuteCommand(ICommand command)
        {
            command.Execute(); 
            Commands.Push(command);  
        }

        /// <summary>
        /// Undoes the most recent command that was executed.
        /// If no command is available to undo, a message is displayed.
        /// </summary>
        public void UndoLastCommand()
        {
            // Checks if there are any commands in the stack.
            if (Commands.Count > 0)  
            {
                var command = Commands.Pop();  
                command.Undo();  
            }
            else
            {
                Console.WriteLine("No commands to undo.");  
            }
        }
    }
}
