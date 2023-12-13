using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.Json;

public class Menu
{
    static public List<Content> contentPlans = new List<Content>
    {
        new VideoContent("Some Video", "A description", ePlatforms.YouTube, "1/2/24"),
    };
    static public List<Person> people = new List<Person>{
        // new Person("Jek", "itmejek@email.com")
    };

    static public void Start()
    {
        while (true)
        {
                
            Console.Clear();
            Console.WriteLine("~~ Welcome to the Content Creator Planner ~~\n");
            Console.WriteLine("Please select an option to get started:\n");
            Console.WriteLine("1. Create Content Plan");
            Console.WriteLine("2. Edit Content Plan");
            Console.WriteLine("3. View Current Content Plans");
            Console.WriteLine("4. View People");
            Console.WriteLine("5. Add Person");
            Console.WriteLine("6. Exit");

            Console.Write("\n> ");

            int response = GetResponse();

            switch (response)
            {
                case 1:
                    CreateContentPlan();
                    break;
                case 2:
                    SelectContent();
                    break;
                case 3:
                    Console.Clear();
                    for(int i = 0; i < contentPlans.Count; i++)
                    {
                        var content = contentPlans[i];
                        Console.WriteLine($"{i + 1}. {content.GetDetailsString()}");
                        content.ShowTasks().ForEach(task => Console.WriteLine($"   {(char)(i + 97)}. {task}"));
                    }
                    
                    Console.Write("\nPress enter to continue... ");
                    GetResponse();
                    break;
                case 4:
                    Console.Clear();
                    ViewPeople();
                    Console.Write("\nPress enter to continue... ");
                    GetResponse();
                    break;
                case 5:
                    AddPerson();
                    break;
                default:
                    Console.WriteLine("Exiting Program...");
                    return;
            }
        }
    }

    static public void SelectContent(bool OnlySelecting = false)
    {
        int index = 1;
        Console.Clear();
        Console.WriteLine("~~ Select Content ~~\n");
        foreach (Content content in contentPlans)
        {
            Console.WriteLine($"{index++}. {content.GetDetailsString()}");
        }
        if(!OnlySelecting) {
            Console.WriteLine($"{index++}. Create New Content");
        }
        Console.WriteLine($"{index}. Exit (Return to Main Menu)\n");
        Console.Write("> ");

        int response = GetResponse();
        
        if (response <= contentPlans.Count && response > 0){
            EditContent(contentPlans[response - 1]);
        } else if(response == contentPlans.Count + 1 && !OnlySelecting) {
            CreateContentPlan();
        } else {
            return;
        }

    }

    static public void CreateContentPlan()
    {
        string title, date;
        ePlatforms platform;

        Console.Clear();
        Console.WriteLine("~~ Select Content Type ~~");
        Console.WriteLine("1. Video");
        Console.WriteLine("2. Stream");
        Console.WriteLine("3. Social");
        Console.WriteLine("4. Exit");
        Console.Write("\n> ");

        int response = GetResponse();


        Console.Clear();
        Console.WriteLine("~~ Creating Content Plan ~~\n");
        switch (response)
        {
            case 1:
                Console.Write("What is the title? > ");
                title = Console.ReadLine();
                Console.Write("What is the video about? > ");
                string description = Console.ReadLine();
                Console.Write("When should it release (month/day/year)? > ");
                date = Console.ReadLine();
                bool shortVid = IsShort();
                platform = SelectPlatform();
                VideoContent video = new VideoContent(title, description, platform, date, shortVid);
                contentPlans.Add(video);
                break;
            case 2:
                Console.Write("What is the title? > ");
                title = Console.ReadLine();
                Console.Write("What Game are you playing? > ");
                string game = Console.ReadLine();
                Console.Write("When is the stream (month/day/year)? > ");
                date = Console.ReadLine();
                Console.Write("How long will you stream (eg. 2.5 [hours])? > ");
                double duration = double.Parse(Console.ReadLine());
                platform = SelectPlatform();
                StreamContent streamContent = new StreamContent(title, platform, date, duration, game);
                contentPlans.Add(streamContent);
                break;
            case 3:
                Console.Write("What is the title? > ");
                title = Console.ReadLine();
                Console.Write("What should the post say? > ");
                string postText = Console.ReadLine();
                Console.Write("When should it release (month/day/year)? > ");
                date = Console.ReadLine();
                platform = SelectPlatform();
                SocialContent socialContent = new SocialContent(title, platform, date, postText);
                contentPlans.Add(socialContent);
                break;
            default:
                return;
        }

        Console.WriteLine("\nNew plan created! Returning to main menu");
        Animation.LoadingDots(5);
    }

    static public void EditContent(Content content)
    {
        int offset = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("~~ Content Editor ~~");
            Console.WriteLine();
            Console.WriteLine($"Editing: {content.GetDetailsString()}");
            Console.WriteLine();
            Console.WriteLine("Please select an option to get started:");
            Console.WriteLine();
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Complete Task");
            Console.WriteLine("4. Change Selection");
            if(content.GetType() == typeof(StreamContent))
            {
                Console.WriteLine("5. Edit Collaborators");
                Console.WriteLine("6. Exit");
                offset = 10;
            } else {
                Console.WriteLine("5. Exit");
            }

            Console.Write("\n> ");

            string title, description, date;

            int response = GetResponse();
            switch (response + offset)
            {
                case 1:
                case 11:
                    Console.Write("What is this task?: ");
                    title = Console.ReadLine();
                    Console.Write("How should I complete this task?: ");
                    description = Console.ReadLine();
                    Console.Write("When should I complete this task?: ");
                    date = Console.ReadLine();
                    Person person = SelectPerson();
                    Task task = new Task(title, description, person, date);
                    content.AddTask(task);
                    break;
                case 3:
                case 13:
                    int i = 1;
                    System.Console.WriteLine("~~ Select a Task ~~\n");
                    var tasks = content.ShowTasks();
                    if(tasks.Count == 0) {
                        Console.Write("No Tasks to complete! Press enter to continue... ");
                        GetResponse();
                        return;
                    }

                    tasks.ForEach(task => System.Console.WriteLine($"{i++}. {task}"));

                    Console.Write("\n> ");

                    int taskToComplete = GetResponse();
                    if (taskToComplete < tasks.Count)
                    {
                        return;
                    }

                    content.CompleteTask(taskToComplete - 1);
                    break;
                case 2:
                case 12:
                    Console.Clear();
                    Console.WriteLine(content.GetDetailsString());
                    char index = 'a';
                    content.ShowTasks().ForEach(task => Console.WriteLine($"    {index++}. {task}"));
                    Console.Write("\nPress enter to continue... ");
                    GetResponse();
                    break;
                case 4:
                case 14:
                    SelectContent(true);
                    return;
                case 15:
                    StreamContent stream = (StreamContent)content;
                    stream.AddCollaborator(SelectPerson());
                    break;
                default:
                    return;
            }
        }
    }

    static private int GetResponse()
    {
        int response;
        try
        {
            response = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            return -1;
        }

        return response;
    }

    static private ePlatforms SelectPlatform()
    {
        int index = 1;
        Console.WriteLine("~~ Select a Platform ~~\n");
        foreach (var platform in Enum.GetValues(typeof(ePlatforms)))
        {
            Console.WriteLine($"{index++}. {platform}");
        }

        Console.Write("\n> ");

        int response = GetResponse();

        return (ePlatforms)(response-1);

    }

    static private bool IsShort()
    {
        Console.Write("Will this video be a short? (Y)es / (N)o ");

        string response = Console.ReadLine();

        switch (response.ToLower()) {
            case "y":
            case "yes":
                return true;
            default:
                return false;
        }
    }
    static private void ViewPeople()
    {
        if(people.Count < 1) {
            Console.WriteLine("There is nothing here yet. Try adding something first!");
        }

        int index = 1;
        foreach (var person in people)
        {
            System.Console.WriteLine($"{index++}. {person.GetName()}");
        }
    }
    static private Person SelectPerson()
    {
        System.Console.WriteLine("~~ Select Person ~~\n");
        ViewPeople();
        System.Console.WriteLine($"{people.Count + 1}. Add new person");

        Console.Write("\n> ");

        int response = GetResponse();

        if (response <= people.Count && response > 0) {
            return people[response - 1];
        } else {
            return AddPerson();
        }
    }
    static private Person AddPerson()
    {
        Console.Write("What is the person's prefered name? ");
        string name = Console.ReadLine();
        Console.Write("What email can they be contacted by? ");
        string email = Console.ReadLine();
        Person person = new Person(name, email);
        Console.Write($"Adding {name} to list");
        Animation.LoadingDots(3);
        people.Add(person);
        return person;
    }

    // private void DisplayList<T>(List<T> list, string listName)
    // {

    // }
}