

using Banking.Domain;

namespace Banking.UnitTests
{
    public class MakingDeposits
    {
        [Fact]
        public void DepositsIncreasesThebalance()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100M;

            account.Deposit(amountToDeposit);

            Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
        }
    }
}
