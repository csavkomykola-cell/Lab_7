using System;
class BankTerminal
{
    public Action<int> OnMoneyWithdraw;
    public void Withdraw(int amount)
    {
        Console.WriteLine($"Зняття {amount} грн...");
        OnMoneyWithdraw?.Invoke(amount);
    }
}
class Program
{
    static void Main()
    {
        BankTerminal terminal = new BankTerminal();
        terminal.OnMoneyWithdraw += amount =>
        {
            Console.WriteLine($"Лог: знято {amount} грн");
        };
        terminal.Withdraw(100);
        terminal.OnMoneyWithdraw = null;
        terminal.Withdraw(200);
        terminal.OnMoneyWithdraw?.Invoke(1000000);
    }
}