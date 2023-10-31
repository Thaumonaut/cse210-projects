using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job {
            Company = "Microsoft",
            EndYear = 2024,
            StartYear = 2020,
            JobTitle = "UI Developer"
        };

        Job job2 = new Job {
            Company = "Amazon", 
            JobTitle = "Test Engineer", 
            StartYear = 2012, 
            EndYear = 2024
        };

        Resume resume = new Resume();
        resume.Name = "Jacob Perry";
        resume.Jobs.Add(job1);
        resume.Jobs.Add(job2);

        resume.Display();


    }
}