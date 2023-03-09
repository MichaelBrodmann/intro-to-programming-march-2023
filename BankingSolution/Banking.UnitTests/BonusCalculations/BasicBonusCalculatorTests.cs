

using Banking.Domain;

namespace Banking.UnitTests.BonusCalculations;

public class BasicBonusCalculatorTests
{
    [Theory]
    [InlineData(5000, 100, 10)]
    [InlineData(5000, 200, 20)]
    [InlineData(4999, 100, 0)]
    public void DepositsGetBonusBasedOnBalance(decimal balance, decimal amount, decimal expectedBonus)
    {
        var bonusCalculator = new StandardBonusCalculator();

        decimal bonus = bonusCalculator.CalculateBankAccountDepositBonusFor(balance, amount);

        Assert.Equal(expectedBonus, bonus);
    }
}
