using Project_7.Employee;
using Project_7.Задачи;
using System;

namespace MyApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var timur = new Employee("Тимур");                 // Генеральный директор
            var rashid = new Employee("Рашид", timur);          // Финансовый директор
            var oIlham = new Employee("О Ильхам", timur);       // Директор по автоматизации
            var lukas = new Employee("Лукас", rashid);          // Глава бухгалтерии
            var orkadiy = new Employee("Оркадий", oIlham);      // Начальник информационной службы
            var volodya = new Employee("Володя", orkadiy);      // Зам. начальника информационной службы
            var sergey = new Employee("Сергей", volodya);       // Руководитель разработчиков
            var laysan = new Employee("Ляйсан", sergey);        // Зам. руководителя разработчиков
            var marat = new Employee("Марат", laysan);          // Разработчик
            var dina = new Employee("Дина", laysan);            // Разработчик
            var ildar = new Employee("Ильдар", laysan);         // Разработчик
            var anton = new Employee("Антон", laysan);          // Разработчик
            var ilishat = new Employee("Ильшат", volodya);      // Руководитель системщиков
            var ivanych = new Employee("Иваныч", ilishat);      // Зам. руководителя системщиков
            var ilya = new Employee("Илья", ivanych);           // Сотрудник системщиков
            var vitya = new Employee("Витя", ivanych);          // Сотрудник системщиков
            var genya = new Employee("Женя", ivanych);          // Сотрудник системщиков

            //Подчиненные
            rashid.AddSubordinate(lukas);
            oIlham.AddSubordinate(orkadiy);
            orkadiy.AddSubordinate(volodya);
            volodya.AddSubordinate(sergey);
            volodya.AddSubordinate(ilishat);
            sergey.AddSubordinate(laysan);
            laysan.AddSubordinate(marat);
            laysan.AddSubordinate(dina);
            laysan.AddSubordinate(ildar);
            laysan.AddSubordinate(anton);
            ilishat.AddSubordinate(ivanych);
            ivanych.AddSubordinate(ilya);
            ivanych.AddSubordinate(vitya);
            ivanych.AddSubordinate(genya);

            var tasks = new List<TasksFromBoss>()
            {
                new TasksFromBoss("<<Учёт о зарплате>>"),
                new TasksFromBoss("<<Разработка сети>>"),
                new TasksFromBoss("<<Разработка нового интерфейса>>"),
            };

            foreach (var task in tasks)
            {
                switch (task.Title)
                {
                    case "<<Учёт о зарплате>>":
                        marat.AssignTask(task, sergey);
                        break;
                    case "<<Разработка сети>>":
                        vitya.AssignTask(task, ivanych);
                        break;
                    case "<<Разработка нового интерфейса>>":
                        dina.AssignTask(task, timur);
                        break;
                }
            }
        }
    }
}