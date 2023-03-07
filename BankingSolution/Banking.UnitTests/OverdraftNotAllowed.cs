
using Banking.Domain;

namespace Banking.UnitTests;

public class OverdraftNotAllowed
{
    

    [Fact]
    public void OverdraftDoesNotDecreaseBalance()
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();

        try
        {
            account.Withdraw(account.GetBalance() + 0.1M);
        }
        catch (OverdraftException)
        {
        //ignore
        }

        Assert.Equal(openingBalance, account.GetBalance());
    }
}
