using System;
using System.Collections.Generic;

namespace File_Labs
{
    class Employee
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; }
        /// <summary>
        /// Начальник
        /// </summary>
        public Employee Boss { get; }
        public List<Employee> Subordinates { get; } = new List<Employee>();
        public Employee(string name, string position, Employee boss = null)
        {
            Name = name;
            Position = position;
            Boss = boss;
            if (boss != null)
            {
                boss.AddSubordinate(this);
            }
        }
        public void AddSubordinate(Employee employee)
        {
            Subordinates.Add(employee);
        }
        public void AssignTask(string task, Employee target)
        {
            if (target.Boss == this)
            {
                Console.WriteLine($"От {Name} даётся задача '{task}' {target.Name}. {target.Name} берёт задачу.");
            }
            else
            {
                Console.WriteLine($"От {Name} даётся задача '{task}' {target.Name}. {target.Name} не берёт задачу.");
            }
        }
    }
}

