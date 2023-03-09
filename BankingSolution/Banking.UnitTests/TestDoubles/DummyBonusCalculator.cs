
using Banking.Domain;

namespace Banking.UnitTests.TestDoubles
{
    public class DummyBonusCalculator : ICalculateBonuses
    {
        public decimal CalculateBankAccountDepositFor(decimal accountCurrentBalance, decimal amountOfDeposit)
        {
            return 0;
        }
    }
}
