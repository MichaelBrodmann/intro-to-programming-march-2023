namespace Banking.Domain
{
    public interface ICalculateBonuses
    {
        decimal CalculateBankAccountDepositFor(decimal accountCurrentBalance, decimal amountOfDeposit);
    }
}