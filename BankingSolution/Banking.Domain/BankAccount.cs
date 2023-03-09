﻿namespace Banking.Domain;

public class BankAccount
{
    private decimal _balance = 5000;
    public void Deposit(decimal amountToDeposit)
    {
        var bonusCalculator = new StandardBonusCalculator();
        var bonus = bonusCalculator.CalculateBankAccountDepositFor(_balance, amountToDeposit);
        _balance += amountToDeposit;
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if (amountToWithdraw > _balance)
        {
            throw new OverdraftException();
        }
        else
        {
            _balance -= amountToWithdraw;
        }
    }
}