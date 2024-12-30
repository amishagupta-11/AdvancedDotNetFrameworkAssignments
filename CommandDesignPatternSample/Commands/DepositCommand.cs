using CommandDesignPatternSample.Receiver;

namespace CommandDesignPatternSample.Commands
{
    /// <summary>
    /// Command to perform a deposit operation on a specific account.
    /// Implements the ICommand interface to execute and undo the deposit action.
    /// </summary>
    public class DepositCommand : ICommand
    {
        // The account to which the deposit will be made.
        private readonly Account Account;
        // The amount to be deposited.
        private readonly decimal Amount;   

        /// <summary>
        /// Initializes a new instance of the DepositCommand class.
        /// </summary>
        /// <param name="account">The account to deposit funds into.</param>
        /// <param name="amount">The amount to deposit.</param>
        public DepositCommand(Account account, decimal amount)
        {
            Account = account;
            Amount = amount;
        }

        /// <summary>
        /// Executes the deposit operation on the specified account.
        /// This method adds the amount to the account balance.
        /// </summary>
        public void Execute()
        {
            Account.Deposit(Amount);
        }

        /// <summary>
        /// Undoes the deposit operation by performing a withdrawal.
        /// This method subtracts the amount from the account balance.
        /// </summary>
        public void Undo()
        {
            Account.Withdraw(Amount);
        }
    }
}
