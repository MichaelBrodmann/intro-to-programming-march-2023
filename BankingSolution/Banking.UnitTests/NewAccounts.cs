

using Banking.Domain;
using Banking.UnitTests.TestDoubles;

namespace Banking.UnitTests
{
    public class NewAccounts
    {
        [Fact]
        public void NewAccountHasCorrectOpeningBalance()
        {
            BankAccount account = new BankAccount(new DummyBonusCalculator());
            decimal balance = account.GetBalance();
            Assert.Equal(5000, balance);
        }
    }
}
