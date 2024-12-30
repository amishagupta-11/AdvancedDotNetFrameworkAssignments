namespace CommandDesignPatternSample.Receiver
{
    /// <summary>
    /// Represents a bank account that allows deposits and withdrawals.
    /// It tracks the account holder and the balance, and provides methods for modifying the balance.
    /// </summary>
    public class Account
    {
        public string AccountHolder { get; }  
        public decimal Balance { get; private set; } 

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="accountHolder">The name of the account holder.</param>
        /// <param name="initialBalance">The initial balance of the account.</param>
        public Account(string accountHolder, decimal initialBalance)
        {
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        /// <summary>
        /// Deposits a specified amount into the account and updates the balance.
        /// </summary>
        /// <param name="amount">The amount to deposit into the account.</param>
        public void Deposit(decimal amount)
        {
            Balance += amount; 
            Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");  
        }

        /// <summary>
        /// Withdraws a specified amount from the account if sufficient funds are available.
        /// </summary>
        /// <param name="amount">The amount to withdraw from the account.</param>
        public void Withdraw(decimal amount)
        {
            // Checks if there are enough funds for the withdrawal.
            if (amount <= Balance)  
            {
                Balance -= amount;  
                Console.WriteLine($"Withdrew {amount:C}. New balance: {Balance:C}");  
            }
            else
            {
                Console.WriteLine($"Insufficient funds to withdraw {amount:C}. Current balance: {Balance:C}");  
            }
        }
    }
}
