// See https://aka.ms/new-console-template for more information
// Build data file with initial system tickets and data in a CSV
// Write Console application to process and add records to the CSV file
// Tickets.csv

// TicketID, Summary, Status, Priority, Submitter, Assigned, Watching

// 1,This is a bug ticket,Open,High,Drew Kjell,Jane Doe,Drew Kjell|John Smith|Bill Jones
string choice;
string file = "Tickets.csv";
List<string> lines = new List<string>();

do
{
    Console.WriteLine("1) Read data from file.");
    Console.WriteLine("2) Create file from data.");
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
                lines.Add(line);
            }
            sr.Close();

            foreach (string line in lines)
            {
                string[] arr = line.Split(',');
                // TODO: Display ticket info
                Console.WriteLine("Id: {0}, Summary: {1}, Status: {2}, Priority: {3}, User: {4}, Programmer: {5}, Supervisor: {6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
            }
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }
    else if (choice == "2")
    {
        Console.WriteLine("Enter a new ticket (Y/N)?");
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

            string addTicket = $"Id: {id}, Summary: {summary}, Status: {status}, Priority: {priority}, User: {user}, Programmer: {programmer}, Supervisor: {supervisor}";

            Console.WriteLine("Enter a new ticket (Y/N)?");
            resp = Console.ReadLine().ToUpper();
        }
        StreamWriter sw = new StreamWriter(file, append: true);
        foreach (string line in lines)
        {
            sw.WriteLine(line);
        }
        sw.Close();
    }
} while (choice == "1" || choice == "2");

    