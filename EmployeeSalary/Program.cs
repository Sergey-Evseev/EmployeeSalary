//Lesson 5. Задание 1. Ранее в одном из практических заданий вы создавали класс «Сотрудник». Добавьте к уже созданному классу
//информацию о заработной плате сотрудника. Выполните перегрузку + (для увеличения зарплаты на указанную величину), 
//– (для уменьшения зарплаты на указанную величину), == (проверка на равенство зарплат сотрудников), < и > (проверка на меньше или больше 
//зарплат сотрудников), != и Equals. Используйте механизм свойств для полей класса.


using System;
using static System.Console;
namespace SimpleProject
{
    public class Human
    {
        string _firstName;
        string _lastName;
        DateTime _birthDate;
        public Human(string fName, string lName)
        {
            _firstName = fName;
            _lastName = lName;
        }
       
        public Human(string fName, string lName, DateTime date)
        {
            _firstName = fName;
            _lastName = lName;
            _birthDate = date;
        }


        public void Show()
        {
            WriteLine($"\nФамилия: {_lastName}\nИмя: { _firstName}\nДата рождения: {_birthDate.ToShortDateString()}");
        }
                
    }
    public class Employee : Human
    {
        double salary;
        public Employee(string fName, string lName) : base(fName, lName){ }
       
        public Employee(string fName, string lName, double salary) : base(fName, lName)
        {
            this.salary = salary;
        }
        
        public Employee(string fName, string lName, DateTime date, double salary)
        : base(fName, lName, date)
        {
            this.salary = salary;
        }
        public void Print() //вывод данных о сотруднике
        {
            Show();
            WriteLine($"Заработная плата: {salary} $");
        }
        
        //перегрузка оператора плюс
        public static Employee operator + (Employee e, double amount)
        {
            e.salary = e.salary + amount;           
            return e;
        }
        //перегрузка метода Equals
        public override bool Equals(object obj) {
            return this.salary == ((Employee)obj).salary; //cast принимаемого объекта к типу класса
        }
        //перегрузка оператора больше
        public static bool operator > (Employee e1, Employee e2)
        {
            return (e1.salary > e2.salary);
        }
        //перегрузка оператора меньше
        public static bool operator < (Employee e1, Employee e2)
        {
            return (e1.salary < e2.salary);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee("Jim", "Beam", 2440.55);
            employee1.Print();
            Employee employee2 = new Employee("Jack", "Smith", DateTime.Now, 3587.43);
            employee2.Print();

            Console.WriteLine("\nРавенство по Equals: " + employee1.Equals(employee2));    
            Console.WriteLine("\nЗарплаты сотрудников равны: " + (employee1 == employee2));
            Console.WriteLine("\nЗарплата сотрудника 1 больше сотрудника 2: " + (employee1 > employee2));
            Console.WriteLine("\nЗарплата сотрудника 1 меньше сотрудника 2: " + (employee1 < employee2));
            

        }
    }
}
