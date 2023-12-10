using System;

class Program
{
    static void Main(string[] args)
    {
        Person myself = new Person("Jacob", "myEmail@email.com");
        Task task = new Task("Finish Project", "Finish Homework Assignment", myself, DateTime.Parse("10/12/23 2:00pm"));
        Task subTask1 = new Task("Create Class Diagrams", "create all the diagrams to represent what each class will need", myself, DateTime.Parse("12/9/23"));
        Task subTask2 = new Task("Create Class Diagrams", "create all the diagrams to represent what each class will need", myself, DateTime.Parse("12/9/23"));
        Task subTask3 = new Task("Create Class Diagrams", "create all the diagrams to represent what each class will need", myself, DateTime.Parse("12/9/23"));

        task.AddSubtask(subTask1);
        task.AddSubtask(subTask2);
        task.AddSubtask(subTask3);

        task.C

        Console.WriteLine(task.TaskToString());
        task.DisplaySubTasks();
        Console.Read();
    }
}