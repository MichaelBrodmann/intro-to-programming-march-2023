
using Banking.Domain;
using Banking.UnitTests.TestDoubles;

namespace Banking.UnitTests;

public class OverdraftNotAllowed
{


    [Fact]
    public void OverdraftDoesNotDecreaseBalance()
    {
        // Given
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();

        try
        {
            account.Withdraw(account.GetBalance() + .01M);
        }
        catch (OverdraftException)
        {

            // Ignore this..
        }

        Assert.Equal(openingBalance, account.GetBalance());
    }

    [Fact]
    public void OverdraftThrowsException()
    {
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();

        Assert.Throws<OverdraftException>(() =>
        {
            account.Withdraw(account.GetBalance() + .01M);

        });


        //var rightExceptionThrow = ExceptionHelpers.Throws<OverdraftException>(() =>
        //{
        //    account.Withdraw(account.GetBalance() + .01M);
        //});

        //Assert.True(rightExceptionThrow);
    }

    
}

public class ExceptionHelpers
{
    public static bool Throws<TException>(Action suspectCode)
        where TException : Exception
    {
        var rightExceptionThrown = false;
        try
        {
            suspectCode();
        }
        catch (TException)
        {
            rightExceptionThrown = true;
        }
        return rightExceptionThrown; 
    }
}