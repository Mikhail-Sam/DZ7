namespace Tumakov.упр_8._1
{
    public class BankAccount
    {
        private static long nextAccountNumber = 100000000;
        private string accountNumber;
        private decimal balance;
        private string ownerName;

        public string AccountNumber => accountNumber;
        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public string OwnerName
        {
            get { return ownerName; }
            set { ownerName = value; }
        }

        public BankAccount(decimal initialBalance, string ownerName)
        {
            accountNumber = GenerateAccountNumber(); // Уникальный номер генерируется автоматически
            Balance = initialBalance;
            OwnerName = ownerName;
        }

        private string GenerateAccountNumber()
        {
            return nextAccountNumber++.ToString();
        }

        //Метод для вывода информации о счёте
        public void ShowAccountDetails()
        {
            Console.WriteLine($"Номер счёта: {accountNumber}");
            Console.WriteLine($"Имя владельца: {ownerName}");
            Console.WriteLine($"Текущий баланс: {balance}");
        }

        //Метод для пополнения счёта
        public void Deposit(decimal amount)
        {
            balance += amount;
            Console.WriteLine($"{amount} зачислено на счёт");
        }

        //Метод для снятия средств со счёта
        public bool Withdraw(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"{amount} снято со счёта");
                return true;
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счёте");
                return false;
            }
        }
        //Метод для перевода денег с одного счёта на другой
        public bool Transfer(BankAccount bankAccount2, decimal summ)
        {
            if (balance >= summ && summ > 0)
            {
                balance -= summ;
                bankAccount2.balance += summ;
                Console.WriteLine($"На другой банковский счёт переведено {summ} руб ");
                return true;
            }
            else
            {
                Console.WriteLine("Недостаточно средств для переводы или перевод составляет 0 рублей");
                return false;
            }

        }
    }
}
