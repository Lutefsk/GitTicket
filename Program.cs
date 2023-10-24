// Build data file with initial system tickets and data in a CSV
// Write Console application to process and add records to the CSV file
// Tickets.csv

// TicketID, Summary, Status, Priority, Submitter, Assigned, Watching

// 1,This is a bug ticket,Open,High,Drew Kjell,Jane Doe,Drew Kjell|John Smith|Bill Jones
using System.Data.Common;
using NLog;
using NLog.Config;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

string choice;
string file = "Tickets.csv";
string taskfile = "Tasks.csv";
string enhancefile = "Enhancements.csv";
List<Ticket> tickets = new List<Ticket>();
List<Enhancement> enhancements = new List<Enhancement>();
List<Task> tasks = new List<Task>();

do
{
    Console.WriteLine("1) Read data from bug ticket file.");
    Console.WriteLine("2) Create a bug ticket");
    Console.WriteLine("3) Read data from enhancement file.");
    Console.WriteLine("4) Request a system enhacnement");
    Console.WriteLine("5) Read data from task file.");
    Console.WriteLine("6) Create a new task");
    Console.WriteLine("Enter any other key to exit.");

    choice = Console.ReadLine();
    if (choice == "1")
    {
        if (File.Exists(file))
        {
            StreamReader sr = new StreamReader(file);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] arr = line.Split(',');
                tickets.Add(new Ticket
                {
                    Id = arr[0],
                    Summary = arr [1],
                    Status = arr [2],
                    Priority = arr [3],
                    User = arr [4],
                    Programmer = arr [5],
                    Supervisor = arr [6],
                    Severity = arr [7],

                });
            }
            sr.Close();

            foreach (Ticket Ticket in tickets)
            {
                Console.WriteLine(Ticket);
            }
                
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }
    else if (choice == "2")
    {
        Console.WriteLine("Enter a new bug ticket (Y/N)?");
        string resp = Console.ReadLine().ToUpper();
        while (resp == "Y")
        {
            Console.WriteLine("What is the TicketID?");
            string id = Console.ReadLine();

            Console.WriteLine("Ticket Summary:");
            string summary = Console.ReadLine();

            Console.WriteLine("Ticket Status:");
            string status = Console.ReadLine();

            Console.WriteLine("Ticket Priority:");
            string priority = Console.ReadLine();

            Console.WriteLine("Ticket Submitter:");
            string user = Console.ReadLine();

            Console.WriteLine("Ticket Assigned to:");
            string programmer = Console.ReadLine();

            Console.WriteLine("Programmer Supervisor:");
            string supervisor = Console.ReadLine();

            Console.WriteLine("Ticket Severity:");
            string severity = Console.ReadLine();

            Ticket addTicket = new Ticket
        {
            Id = id,
            Summary = summary,
            Status = status,
            Priority = priority,
            User = user,
            Programmer = programmer,
            Supervisor = supervisor,
            Severity = severity
        };

        tickets.Add(addTicket);
    }
    StreamWriter sw = new StreamWriter(file, append: true);
    foreach (Ticket ticket in tickets)
    {
        sw.WriteLine(tickets);
    }
    sw.Close();
    }

    else if (choice == "3")
    {
    if (File.Exists(enhancefile))
        {
            StreamReader sr = new StreamReader(enhancefile);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] arr = line.Split(',');
                enhancements.Add(new Enhancement
                {
                    Id = arr[0],
                    Summary = arr [1],
                    Status = arr [2],
                    Priority = arr [3],
                    User = arr [4],
                    Programmer = arr [5],
                    Supervisor = arr [6],
                    Software = arr [7],
                    Cost = arr [8],
                    Reason = arr [9],
                    Estimate = arr[10]

                });
            }
            sr.Close();

            foreach (Enhancement Enhancement in enhancements)
            {
                Console.WriteLine(Enhancement);
            }
                
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }

    else if (choice == "4")
    {
        Console.WriteLine("Enter a new enhancement request (Y/N)?");
        string resp = Console.ReadLine().ToUpper();
        while (resp == "Y")
        {
            Console.WriteLine("What is the EnhancementID?");
            string id = Console.ReadLine();

            Console.WriteLine("Enhancement Request Summary:");
            string summary = Console.ReadLine();

            Console.WriteLine("Status of Enhancement Request:");
            string status = Console.ReadLine();

            Console.WriteLine("Enhancement Priority:");
            string priority = Console.ReadLine();

            Console.WriteLine("Enhancement Submitter:");
            string user = Console.ReadLine();

            Console.WriteLine("Enhancement Request Assigned to:");
            string programmer = Console.ReadLine();

            Console.WriteLine("IT Deparment Supervisor:");
            string supervisor = Console.ReadLine();

            Console.WriteLine("Enhancement Software Name:");
            string software = Console.ReadLine();

            Console.WriteLine("Enhancement Cost in Dollars:");
            string cost = Console.ReadLine();

            Console.WriteLine("Enhancement Reason:");
            string reason = Console.ReadLine();

            Console.WriteLine("Enhancement Timeline in weeks:");
            string estimate = Console.ReadLine();

            Enhancement addEnhancement = new Enhancement
        {
            Id = id,
            Summary = summary,
            Status = status,
            Priority = priority,
            User = user,
            Programmer = programmer,
            Supervisor = supervisor,
            Software = software,
            Cost = cost,
            Reason = reason,
            Estimate = estimate
        };

        enhancements.Add(addEnhancement);
    }
    StreamWriter sw = new StreamWriter(enhancefile, append: true);
    foreach (Enhancement enhancement in enhancements)
    {
        sw.WriteLine(enhancements);
    }
    sw.Close();
    }
    else if (choice == "5")
    { 
        if (File.Exists(taskfile))
        {
            StreamReader sr = new StreamReader(taskfile);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] arr = line.Split(',');
                tasks.Add(new Task
                {
                    Id = arr[0],
                    Summary = arr [1],
                    Status = arr [2],
                    Priority = arr [3],
                    User = arr [4],
                    Programmer = arr [5],
                    Supervisor = arr [6],
                    Project = arr [7],
                    DueDate = arr [8],

                });
            }
            sr.Close();

            foreach (Task Task in tasks)
            {
                Console.WriteLine(Task);
            }
                
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }
    else if (choice == "6")
    {
      Console.WriteLine("Enter a new Task (Y/N)?");
        string resp = Console.ReadLine().ToUpper();
        while (resp == "Y")
        {
            Console.WriteLine("What is the Task ID?");
            string id = Console.ReadLine();

            Console.WriteLine("Task Summary:");
            string summary = Console.ReadLine();

            Console.WriteLine("Status of Task:");
            string status = Console.ReadLine();

            Console.WriteLine("Task Priority:");
            string priority = Console.ReadLine();

            Console.WriteLine("Task Submitter:");
            string user = Console.ReadLine();

            Console.WriteLine("Task Assigned to:");
            string programmer = Console.ReadLine();

            Console.WriteLine("Assignee Supervisor:");
            string supervisor = Console.ReadLine();

            Console.WriteLine("Task Project Name:");
            string project = Console.ReadLine();

            Console.WriteLine("Task Due Date:");
            string dueDate = Console.ReadLine();  

            Task addTask = new Task
        {
            Id = id,
            Summary = summary,
            Status = status,
            Priority = priority,
            User = user,
            Programmer = programmer,
            Supervisor = supervisor,
            Project = project,
            DueDate = dueDate,
        };

        tasks.Add(addTask);
    }
    StreamWriter sw = new StreamWriter(taskfile, append: true);
    foreach (Task task in tasks)
    {
        sw.WriteLine(tasks);
    }
    sw.Close();
    }

else 
{
    // log error
    logger.Error("You must enter a valid number");
}
} while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6");
    