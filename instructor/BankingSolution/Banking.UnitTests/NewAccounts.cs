
using Banking.Domain;
using Banking.UnitTests.TestDoubles;

namespace Banking.UnitTests;

public class NewAccounts
{
    [Fact]
    public void NewAccountHasCorrectOpeningBalance()
    {
        // "Write the Code You Wish You Had" (WTCYWYH)
        // Given
        // Type identifier = initializer;
        var account = new BankAccount(new DummyBonusCalculator());
        // When
        decimal balance = account.GetBalance();
        // Then
        Assert.Equal(5000, balance);

        

    }
}
