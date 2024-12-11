using System;
using System.Collections.Generic;
using System.IO;

namespace Tumakov_Labs
{
    enum Bank_schet
    {
        Current,
        Saving
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Task8_1();
            Task8_2();
            Task8_3();
            Task8_4();
            DZ8_1();
            DZ8_2();
            Console.ReadKey();
        }
        /*Упражнение 8.1 В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить
метод, который переводит деньги с одного счета на другой.У метода два параметра: ссылка
на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.*/
        static void Task8_1()
        {
            Console.WriteLine(" ");
            BankAccount myAccount = new BankAccount(100000.00m, Bank_schet.Saving);
            Console.WriteLine("Первый счет: ");
            myAccount.PrintAccountInfo();
            myAccount.AccountReplenishment(5000.00m);
            myAccount.AccountWithdrawal(2000.00m);
            Console.WriteLine("\nВторой счет: ");
            BankAccount anotherAccount = new BankAccount(500.00m, Bank_schet.Current);
            anotherAccount.PrintAccountInfo();
            myAccount.Trasfer(anotherAccount, 1000.00m);
            Console.WriteLine("\nПосле изменения:");
            Console.WriteLine("Первый счет: ");
            myAccount.PrintAccountInfo();
            Console.WriteLine("\nВторой счет: ");
            anotherAccount.PrintAccountInfo();
        }
        static string ReverseOrder(string str)
        {
            char[] symb = str.ToCharArray();
            Array.Reverse(symb);
            return new string(symb);
        }
        /*Упражнение 8.2 Реализовать метод, который в качестве входного параметра принимает
строку string, возвращает строку типа string, буквы в которой идут в обратном порядке.
Протестировать метод.*/
        static void Task8_2()
        {
            Console.WriteLine("Введите строку: ");
            string str = Console.ReadLine();
            string reversedStr = ReverseOrder(str);
            Console.WriteLine(reversedStr);
        }
        /*Упражнение 8.3 Написать программу, которая спрашивает у пользователя имя файла. Если
такого файла не существует, то программа выдает пользователю сообщение и заканчивает
работу, иначе в выходной файл записывается содержимое исходного файла, но заглавными
буквами.*/
        static void Task8_3()
        {
            Console.WriteLine("Введите полный путь к файлу: ");
            string inputFile = Console.ReadLine();
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Нет такого файла.");
                return;
            }
            string outputFile = "..\\..\\toUpper.txt";
            try
            {
                string content = File.ReadAllText(inputFile).ToUpper();
                File.WriteAllText(outputFile, content);
                Console.WriteLine($"Содержимое файла '{inputFile}' записано в '{outputFile}' в верхнем регистре");
                Console.WriteLine("\nСодержимое выходного файла: ");
                Console.WriteLine(File.ReadAllText(outputFile));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
        static void CheckIFormattable(object obj)
        {
            if (obj is IFormattable)
            {
                Console.WriteLine($"{obj.GetType()} ({obj}) реализует интерфейс IFormattable.");
            }
            else
            {
                Console.WriteLine($"{obj.GetType()} ({obj}) не реализует интерфейс IFormattable.");
            }
            IFormattable formattable = obj as IFormattable;
            if (formattable != null)
            {
                string formatted = formattable.ToString("G", null);
                Console.WriteLine($"Форматированное значение: {formatted}");
            }
        }
        /*Упражнение 8.4 Реализовать метод, который проверяет реализует ли входной параметр
метода интерфейс System.IFormattable.Использовать оператор is и as. (Интерфейс
IFormattable обеспечивает функциональные возможности форматирования значения объекта
в строковое представление.)*/
        static void Task8_4()
        {
            int number = 11;
            string text = "Anna";
            CheckIFormattable(number);
            CheckIFormattable(text);
        }
        /*Домашнее задание 8.1 Работа со строками. Дан текстовый файл, содержащий ФИО и e-mail
адрес. Разделителем между ФИО и адресом электронной почты является символ #:
Иванов Иван Иванович # iviviv@mail.ru
Петров Петр Петрович # petr@mail.ru
Сформировать новый файл, содержащий список адресов электронной почты.
Предусмотреть метод, выделяющий из строки адрес почты. Методу в
качестве параметра передается символьная строка s, e-mail возвращается в той же строке s:
public void SearchMail (ref string s).*/
        static void DZ8_1()
        {
            string inputFilePath = "..\\..\\input.txt";
            string outputFilePath = "..\\..\\emails.txt";
            try
            {
                using (StreamReader reader = new StreamReader(inputFilePath))
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        SearchMail(ref line);
                        if (!string.IsNullOrEmpty(line))
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
                Console.WriteLine("Адреса электронной почты успешно записаны в файл " + outputFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
        public static void SearchMail(ref string s)
        {
            string[] parts = s.Split('#');
            if (parts.Length > 1)
            {
                s = parts[1].Trim();
            }
            else
            {
                s = string.Empty;
            }
        }
        /*Домашнее задание 8.2 Список песен. В методе Main создать список из четырех песен. В
цикле вывести информацию о каждой песне. Сравнить между собой первую и вторую
песню в списке. Песня представляет собой класс с методами для заполнения каждого из
полей, методом вывода данных о песне на печать, методом, который сравнивает между
собой два объекта:
class Song{
string name; //название песни
string author; //автор песни
Song prev; //связь с предыдущей песней в списке
//метод для заполнения поля name

//метод для заполнения поля author
//метод для заполнения поля prev
//метод для печати названия песни и ее исполнителя
public string Title(){... возвращ название+исполнитель...}
    //метод, который сравнивает между собой два объекта-песни:
    public bool override Equals(object d) { ...}}*/
        public static void DZ8_2()
        {
            List<Song> songs = new List<Song>();

            Song song1 = new Song { Name = "Antonio Vivaldi", Author = "Spring" };
            songs.Add(song1);

            Song song2 = new Song { Name = "Antonio Vivaldi", Author = "Spring", Prev = song1 };
            songs.Add(song2);

            Song song3 = new Song { Name = "Antonio Vivaldi", Author = "Summer", Prev = song2 };
            songs.Add(song3);

            Song song4 = new Song { Name = "Ludwig van Beethoven", Author = "Sonata for piano N14", Prev = song3 };
            songs.Add(song4);

            foreach (Song song in songs)
            {
                song.PrintInfo();
            }

            if (songs[0].Equals(songs[1]))
            {
                Console.WriteLine($"\nПервая и вторая песни одинаковы: {songs[0].Title()}");
            }
            else
            {
                Console.WriteLine($"\nПервая и вторая песни разные: {songs[0].Title()} и {songs[1].Title()}");
            }
        }
    }
}