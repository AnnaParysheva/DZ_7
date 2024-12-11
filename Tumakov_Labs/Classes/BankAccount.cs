using System;

namespace Tumakov_Labs
{
    //Создаем класс счет в банке
    class BankAccount
    {
        /// <summary>
        /// Статическая переменная для хранения последнего сгенерированного номера счета
        /// </summary>
        private static ulong lastAccountNumber = 1234567890;
        /// <summary>
        /// Номер счета
        /// </summary>
        private readonly Guid accountNumber;
        /// <summary>
        /// Баланс
        /// </summary>
        private decimal balance;
        /// <summary>
        /// Тип банковского счета
        /// </summary>
        private Bank_schet typeBankAccount;
        public BankAccount(decimal balance, Bank_schet typeBankAccount)
        {
            this.accountNumber = GenerateUniqueAccountNumber();
            this.balance = balance;
            this.typeBankAccount = typeBankAccount;
        }
        // Метод для генерации уникального номера счета
        private Guid GenerateUniqueAccountNumber()
        {
            lastAccountNumber++;
            return Guid.NewGuid();
        }
        public Guid GetAccountNumber()
        { return accountNumber; }
        // Метод, возвращающий баланс
        public decimal GetBalance()
        {
            return balance;
        }
        // Метод,возвращающий тип банковского счета
        public Bank_schet GetTypeBankAccount()
        {
            return typeBankAccount;
        }
        //Метод для изменения типа банковского счета
        public void ChangeTypeBankAccount(Bank_schet type)
        {
            typeBankAccount = type;
        }
        //Метод для пополнения счета
        public void AccountReplenishment(decimal sum)
        {
            if (sum < 0)
            {
                Console.WriteLine("Сумма пополнения должна быть больше 0");
            }
            else
            {
                balance += sum;
            }
        }
        //Метод для снятия со счета
        public void AccountWithdrawal(decimal sum)
        {
            if (balance - sum < 0)
            {
                Console.WriteLine("Невозможно снять такую сумму!");
            }
            else
            {
                balance -= sum;
            }
        }
        // Метод для вывода информации о счете
        public void PrintAccountInfo()
        {
            Console.WriteLine($"Номер счета: {accountNumber}");
            Console.WriteLine($"Баланс: {balance}");
            Console.WriteLine($"Тип счета: {typeBankAccount}");
        }
        // Метод для перевода денег с одного счета на другой
        public void Trasfer(BankAccount anotherAccount, decimal sum)
        {
            if (sum <= 0)
            {
                Console.WriteLine("Сумма перевода должна быть больше 0");
                return;
            }
            if (sum > balance)
            {
                Console.WriteLine("Невозможно перевести такую сумму!");
                return;
            }
            else
            {
                AccountWithdrawal(sum);
                anotherAccount.AccountReplenishment(sum);
                Console.WriteLine($"Переведено {sum} со счета {accountNumber} на счет {anotherAccount.GetAccountNumber()}");
            }
        }
    }
}
