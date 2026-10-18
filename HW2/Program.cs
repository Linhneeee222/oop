using System;

class Program
{
    static Person InputPersonInfo(string name, string address, string sSalary)
    {
        if (sSalary == null || sSalary.Trim() == "")
        {
            throw new Exception("You must input Salary.");
        }

        double salary;
        if (!double.TryParse(sSalary, out salary))
        {
            throw new Exception("You must input digit.");
        }

        if (salary <= 0)
        {
            throw new Exception("Salary is greater than zero");
        }

        return new Person(name, address, salary);
    }

    static void DisplayPersonInfo(Person person)
    {
        Console.WriteLine("Information of Person you have entered:");
        Console.WriteLine("Name:" + person.GetName());
        Console.WriteLine("Address:" + person.GetAddress());
        Console.WriteLine("Salary:" + person.GetSalary());
        Console.WriteLine();
    }

    static Person[] SortBySalary(Person[] person)
    {
        if (person == null)
        {
            throw new Exception("Can't Sort Person");
        }

        for (int i = 0; i < person.Length - 1; i++)
        {
            for (int j = 0; j < person.Length - 1 - i; j++)
            {
                if (person[j].GetSalary() > person[j + 1].GetSalary())
                {
                    Person temp = person[j];
                    person[j] = person[j + 1];
                    person[j + 1] = temp;
                }
            }
        }

        return person;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("=====Management Person programer=====");

        Person[] persons = new Person[3];

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Input Information of Person");

            Console.Write("Please input name:");
            string name = Console.ReadLine();

            Console.Write("Please input address:");
            string address = Console.ReadLine();

            while (true)
            {
                Console.Write("Please input salary:");
                string sSalary = Console.ReadLine();

                try
                {
                    persons[i] = InputPersonInfo(name, address, sSalary);
                    break; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        try
        {
            persons = SortBySalary(persons);

            for (int i = 0; i < persons.Length; i++)
            {
                DisplayPersonInfo(persons[i]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}