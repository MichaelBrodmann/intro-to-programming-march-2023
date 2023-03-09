

using Banking.Domain;
using Banking.UnitTests.TestDoubles;

namespace Banking.UnitTests
{
    public class MakingWithdraws
    {
        [Theory]
        [InlineData(1)]
        [InlineData(1020.22)]
        [InlineData(5000)]
        public void MakingAWithdrawlDecreasesBalance(decimal amountToWithdraw)
        {
            var account = new BankAccount(new DummyBonusCalculator());
            var openingBalance = account.GetBalance();

            account.Withdraw(amountToWithdraw); // Command (Action)         // then
            Assert.Equal(openingBalance - amountToWithdraw,
                account.GetBalance());
        }
    }
}
