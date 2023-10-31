// Build data file with initial system tickets, enhancements and task in a CSV file
// Write Console application to process and add records to the CSV file
using System.Data.Common;
using NLog;
using NLog.Config;

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
    Console.WriteLine("3) Find a bug ticket via status."); 
    Console.WriteLine("4) Find a bug ticket via priority."); 
    Console.WriteLine("5) Find a bug ticket via submitter");
    Console.WriteLine("6) Read data from enhancement file.");
    Console.WriteLine("7) Request a system enhacnement");
    Console.WriteLine("8) Read data from task file.");
    Console.WriteLine("9) Create a new task");
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
        if (resp == "Y")
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
        sw.WriteLine($"{ticket.Id},{ticket.Summary},{ticket.Status},{ticket.Priority},{ticket.User},{ticket.Programmer},{ticket.Supervisor},{ticket.Severity}");
    }
    sw.Close();

    }
    else if (choice == "3")
    {
        Console.WriteLine("Enter the status to search for:");
        string findStatus = Console.ReadLine();
        {
                var foundTickets = tickets.FindAll(ticket => ticket.Status.Equals(findStatus));
                if (foundTickets.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Tickets with status " + findStatus + ":");
                foreach (var ticket in foundTickets)
                {
                    Console.WriteLine(ticket);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("No tickets found with the status: " + findStatus);
            }
        }
    }
    else if (choice == "4")
    {
        Console.WriteLine("Enter the priority to search for:");
        string findPriority = Console.ReadLine();
        {
                var foundTickets = tickets.FindAll(ticket => ticket.Priority.Equals(findPriority));
                if (foundTickets.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Tickets with priority " + findPriority + ":");
                foreach (var ticket in foundTickets)
                {
                    Console.WriteLine(ticket);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("No tickets found with the priority: " + findPriority);
            }
        }
    }
    else if (choice == "5")
    {
        Console.WriteLine("Enter the submitter to search for:");
        string findUser = Console.ReadLine();
        {
                var foundTickets = tickets.FindAll(ticket => ticket.Priority.Equals(findUser));
                if (foundTickets.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Tickets with priority " + findUser + ":");
                foreach (var ticket in foundTickets)
                {
                    Console.WriteLine(ticket);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("No tickets found with the priority: " + findUser);
            }
        }
    }
    else if (choice == "6")
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

    else if (choice == "7")
    {
        Console.WriteLine("Enter a new enhancement request (Y/N)?");
        string resp = Console.ReadLine().ToUpper();
        if (resp == "Y")
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
        sw.WriteLine($"{enhancement.Id},{enhancement.Summary},{enhancement.Status},{enhancement.Priority},{enhancement.User},{enhancement.Programmer},{enhancement.Supervisor},{enhancement.Software},{enhancement.Cost},{enhancement.Reason},{enhancement.Estimate}");
    }
    sw.Close();

    }
    else if (choice == "8")
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
    else if (choice == "9")
    {
      Console.WriteLine("Enter a new Task (Y/N)?");
        string resp = Console.ReadLine().ToUpper();
        if (resp == "Y")
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
       sw.WriteLine($"{task.Id},{task.Summary},{task.Status},{task.Priority},{task.User},{task.Programmer},{task.Supervisor},{task.Project},{task.DueDate}");
    }
    sw.Close();

    }
else 
{
    // log error
    logger.Error("You must enter a valid number");
}
} while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6" && choice != "7" && choice != "8" && choice != "9");
    