using CommandDesignPatternSample.Receiver;

namespace CommandDesignPatternSample.Commands
{
    /// <summary>
    /// Represents a command to withdraw a specific amount from an account.
    /// This class implements the ICommand interface to execute and undo the withdrawal operation.
    /// </summary>
    public class WithdrawCommand : ICommand
    {
        // The account to withdraw from.
        private readonly Account Account;
        // The amount to withdraw.
        private readonly decimal Amount;   

        /// <summary>
        /// Initializes a new instance of the <see cref="WithdrawCommand"/> class.
        /// </summary>
        /// <param name="account">The account from which to withdraw the amount.</param>
        /// <param name="amount">The amount to withdraw.</param>
        public WithdrawCommand(Account account, decimal amount)
        {
            Account = account;
            Amount = amount;
        }

        /// <summary>
        /// Executes the withdraw operation on the account.
        /// This method calls the <see cref="Account.Withdraw"/> method to deduct the specified amount from the account.
        /// </summary>
        public void Execute()
        {
            Account.Withdraw(Amount);
        }

        /// <summary>
        /// Undoes the withdraw operation by depositing the withdrawn amount back into the account.
        /// This method calls the <see cref="Account.Deposit"/> method to reverse the withdrawal.
        /// </summary>
        public void Undo()
        {
            Account.Deposit(Amount);
        }
    }
}
