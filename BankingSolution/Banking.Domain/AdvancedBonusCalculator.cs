using System.ComponentModel;

namespace Banking.Domain;

public class AdvancedBonusCalculator : ICalculateBonuses
{
    public decimal CalculateBankAccountDepositBonusFor(decimal accountCurrentBalance, decimal amountOfDeposit)
    {
        return -42;
    }
}