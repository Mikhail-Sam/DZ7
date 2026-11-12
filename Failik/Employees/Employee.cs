using Project_7.Задачи;
using System;
using System.Threading.Tasks;

namespace Project_7.Employee
{
    public class Employee
    {
        public string Name { get; set; }
        public Employee Boss { get; set; }
        public List<Employee> Subordinates { get; set; }

        public Employee(string name, Employee boss = null) // null - для босса
        {
            Name = name;
            Boss = boss;
            Subordinates = new List<Employee>(); //Подчиненные
        }

        //Добавление подчиненного к своему боссу
        public void AddSubordinate(Employee employee)
        {
            Subordinates.Add(employee);
            employee.Boss = this;
        }

        //Прием задачи от указанного сотрудника
        public bool AcceptTaskFrom(Employee taskGiver)
        {

            if (taskGiver == null || taskGiver == Boss)
            {
                return true;
            }

            foreach (var subordinate in Subordinates)
            {
                if (subordinate.AcceptTaskFrom(taskGiver)) //  "запрос" подчиненному взять задачу от своего босса
                {
                    return true;
                }
            }

            return false;
        }

        //Назначение задачи сотруднику
        public void AssignTask(TasksFromBoss task, Employee giver)
        {
            Console.WriteLine($"{giver.Name} отправил запрос на задачу -> \n{task.Title} человеку по имени -> {Name}");
            if (AcceptTaskFrom(giver))
            {
                Console.WriteLine($"{Name} берёт задачу");
            }
            else
            {
                Console.WriteLine($"{Name} отказывается брать задачу");
            }
        }
    }
}