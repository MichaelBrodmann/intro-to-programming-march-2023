

using Banking.Domain;

namespace Banking.UnitTests
{
    public class NewAccounts
    {
        [Fact]
        public void NewAccountHasCorrectOpeningBalance()
        {
            BankAccount account = new BankAccount();
            decimal balance = account.GetBalance();
            Assert.Equal(5000, balance);
        }
    }
}
