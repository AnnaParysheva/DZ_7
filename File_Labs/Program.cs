using System;

namespace File_Labs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Console.ReadKey();
        }
        /*Написать программу, содержащую решение следующих задач:
На совещании у начальства раздавали задачи. Сотрудники фирмы так задолбались, что
решили, что будут получать задачи только в том случае, если это их прямое руководство.
Все возмущение началось из‐за того, что бухгалтерия решила автоматизировать себе работу,
они хотят приходить на работу, нажимать на кнопочку и чтобы все само делалось, а отдел
информационных технологий должен сделать эту задачу им. При назначении задач, задача должна иметь признак кому ее дают: системщикам или
разработчикам или начальству(начальник и зам.начальник отдела), а потом распределить задачи по сотрудникам. На экране будет следующее: от человека А
даётся задача «название задачи» человек Б. И надо вывести берет человек задачу или
нет.*/
        static void Task1()
        {
            var timur = new Employee("Тимур", "Генеральный директор");
            // Финансовый директор и его подчиненные
            var rashid = new Employee("Рашид", "Финансовый директор", timur);
            var lucas = new Employee("Лукас", "Главный бухгалтер", rashid);
            // Директор по автоматизации и его подчиненные
            var ilham = new Employee("О Ильхам", "Директор по автоматизации", timur);
            // Отдел информационных технологий
            var orkady = new Employee("Оркадий", "Начальник инф систем", ilham);
            var volodya = new Employee("Володя", "Зам.начальника", orkady);
            // Сектор системщиков
            var ilshat = new Employee("Ильшат", "Главный системщик", volodya);
            var ivanich = new Employee("Иваныч", "Зам системщика", ilshat);
            var ilya = new Employee("Илья", "Сотрудник", ivanich);
            var vitya = new Employee("Витя", "Сотрудник", ivanich);
            var zhenya = new Employee("Женя", "Сотрудник", ivanich);
            // Сектор разработчиков
            var sergey = new Employee("Сергей", "Главный разработчик", volodya);
            var lyasan = new Employee("Ляйсан", "Зам разработчика", sergey);
            var marat = new Employee("Марат", "Сотрудник", lyasan);
            var dina = new Employee("Дина", "Сотрудник", lyasan);
            var ildar = new Employee("Ильдар", "Сотрудник", lyasan);
            var anton = new Employee("Антон", "Сотрудник", lyasan);
            // Примеры задач
            timur.AssignTask("Улучшить финансовый отчет", rashid);
            rashid.AssignTask("Подготовить отчет", lucas);
            ilham.AssignTask("Автоматизировать процессы", orkady);
            orkady.AssignTask("Настроить сеть", ilshat);
            volodya.AssignTask("Разработать новую систему", sergey);
            sergey.AssignTask("Написать код", lyasan);
            lyasan.AssignTask("Тестировать приложение", dina);
            ilshat.AssignTask("Установить сервер", ivanich);
            ivanich.AssignTask("Настроить маршрутизатор", ilya);
            // Пример задачи, которую не возьмут
            timur.AssignTask("Написать код", dina);
        }
    }
}