namespace Task4
{
    public interface IAccountUtil
    {
        static abstract void Deposit(List<Account> accounts, double amount);
        static abstract void DepositChecking(List<CheckingAccount> accounts, double amount);
        static abstract void DepositSavings(List<SavingsAccount> accounts, double amount);
        static abstract void DepositTrust(List<TrustAccount> accounts, double amount);
        static abstract void Withdraw(List<Account> accounts, double amount);
        static abstract void WithdrawChecking(List<CheckingAccount> accounts, double amount);
        static abstract void WithdrawSavings(List<SavingsAccount> accounts, double amount);
        static abstract void WithdrawTrust(List<TrustAccount> accounts, double amount);
    }
}