using Banking.Domain;
using Moq;

namespace Banking.UnitTests.TestDoubles;

internal class BankAccountUsesBonusCalculator
{

    public void IntegratesWithBonusCalculator()
    {
        var bankAccount = new BankAccount(new StubbedBonusCalculator());

        bankAccount.Deposit(212.83M);

        Assert.Equal(5000M + 212.83M + 12M, bankAccount.GetBalance());
    }
    public void IntegratesWithBonusCalculatorWithStubbedObject()
    {
        var stubbedBonusCalculator = new Mock<ICalculateBonuses>();
        var bankAccount = new BankAccount(stubbedBonusCalculator.Object);
        var openingBalance = bankAccount.GetBalance();
        var amountOfDeposit = 212.83M;
        stubbedBonusCalculator.Setup(dil => dil.CalculateBankAccountDepositBonusFor(openingBalance, amountOfDeposit)).Returns(12M);

        bankAccount.Deposit(212.83M);

        Assert.Equal(5000M + 212.83M +12M, bankAccount.GetBalance());
    }
}
  
