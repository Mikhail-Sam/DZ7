using Tumakov.дз_8._2;
using Tumakov.упр_8._1;


namespace MyApp
{
    public class Program
    {
        //упр8.3
        public static string ReverseString(string str) // упр8.3
        {
            char[] chars = str.ToCharArray(); // для преобразования строки в массив символов
            Array.Reverse(chars); // переворачиваем символы
            return new string(chars); //преобразуем массив обратно в строку 

        }
        //упр 8.4
        public static bool IsIFormattable(object obj) // is
        {
            return obj is IFormattable; // is возвращает true, если объект поддерживает указанный интерфейс (IFormattable)
        }

        public static bool AsIFormattable(object obj) //as
        { //as пытается привести объект к типу интерфейса IFormattable. Если приводится успешно, возвращается ссылка на объект указанного типаБ иначе null
            var formattableObj = obj as IFormattable;
            return formattableObj != null;
        }

        //дз 8.1
        public static void SearchMail(ref string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                int indexx = s.IndexOf('#'); // ищем символ #, если находим, то indexx равен индексу символа

                if (indexx < s.Length - 1)
                {
                    s = s.Substring(indexx + 1).Trim(); //строка обрезается с начала до символа # включительно с помощью Substring
                    //Trim, чтобы удалить возможные пробелы слева и справа от почтового адреса
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 8.1");
            var myAccount = new BankAccount(1000m, "Иван Петров");
            var friendAccount = new BankAccount(500m, "Анна Иванова");
            myAccount.Transfer(friendAccount, 200m);
            myAccount.ShowAccountDetails();
            
            Console.WriteLine(string.Empty);
            Console.WriteLine("Упражнение 8.2");
            Console.Write("Введите строку для переворота: ");
            string userStr = Console.ReadLine();
            string reverse = ReverseString(userStr);
            Console.WriteLine($"Перевёрнутая строка: {reverse}");
            
            Console.WriteLine(string.Empty);
            Console.WriteLine("Упражнение 8.3");
            Console.WriteLine("Введите имя файла для поиска:");
            string fileName = Console.ReadLine();
            try
            {
                var texst = File.ReadAllText("../../../Files" + fileName); //операторов перехода вверх ../
                File.WriteAllText("../../../Files", texst.ToUpper());

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка {ex.Message}");
            }

            Console.WriteLine(string.Empty);
            Console.WriteLine("Упражнение 8.4");
            int number = 42;
            string text = "Hello";

            Console.WriteLine($"is: {IsIFormattable(number)}");
            Console.WriteLine($"as: {AsIFormattable(text)}");

            Console.WriteLine(string.Empty);
            Console.WriteLine("Домашнее задание 8.1");
            try
            {
                var file = File.ReadAllLines("../../../Files/дз 8.1");
                using StreamWriter writer = new StreamWriter("../../../Files/дз 8.1(2)");
                //StreamWriter позволяет удобно писать текстовую информацию в файлы
                for (int i = 0; i < file.Length; i++)
                {
                    SearchMail(ref file[i]);// Выделяем email из строки
                    writer.WriteLine(file[i]);// Записываем email в файл
                }

                Console.WriteLine("Операция выполнена успешно.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine(string.Empty);
            Console.WriteLine("Домашнее задание 8.2");
            Song song1 = new Song();
            song1.SetName("Летний дождь");
            song1.SetAuthor("Иван Иванов");

            Song song2 = new Song();
            song2.SetName("Зимняя ночь");
            song2.SetAuthor("Анна Петрова");

            Song song3 = new Song();
            song3.SetName("Весёлый ветер");
            song3.SetAuthor("Сергей Сергеев");

            Song song4 = new Song();
            song4.SetName("Осень в городе");
            song4.SetAuthor("Елена Смирнова");

            song2.SetPrev(song1); // связь песен
            song3.SetPrev(song2);
            song4.SetPrev(song3);

            Song[] songs = { song1, song2, song3, song4 };
            foreach (var song in songs) // вывод инфы о песнях
            {
                Console.WriteLine(song.Title());
            }
            bool eequal = song1.Equals(song2); // сравнение песен 1 и 2
            Console.WriteLine($"Первая и вторая песни одинаковы: {eequal}");
        }
    }
}