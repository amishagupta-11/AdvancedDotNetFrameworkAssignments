using CommandDesignPatternSample.Commands;
using CommandDesignPatternSample.Invoker;
using CommandDesignPatternSample.Receiver;


namespace CommandDesignPatternSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Receiver
            var account = new Account("Amisha Gupta", 1000);

            // Invoker
            var transactionManager = new TransactionManager();

            // Commands
            var deposit100 = new DepositCommand(account, 100);
            var withdraw50 = new WithdrawCommand(account, 50);

            // Execute commands
            transactionManager.ExecuteCommand(deposit100);
            transactionManager.ExecuteCommand(withdraw50); 

            // Undo last command
            transactionManager.UndoLastCommand(); 

            // Undo another command
            transactionManager.UndoLastCommand(); 
        }
    }
}
