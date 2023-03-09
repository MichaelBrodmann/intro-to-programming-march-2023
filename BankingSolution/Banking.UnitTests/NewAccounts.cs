

using Banking.Domain;
using Banking.UnitTests.TestDoubles;
using Moq;

namespace Banking.UnitTests
{
    public class NewAccounts
    {
        [Fact]
        public void NewAccountHasCorrectOpeningBalance()
        {
            var account = new BankAccount(new Mock<ICalculateBonuses>().Object);
            decimal balance = account.GetBalance();
            Assert.Equal(5000, balance);
        }
    }
}
